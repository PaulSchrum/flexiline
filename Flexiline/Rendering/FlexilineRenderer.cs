using Godot;
using System;
using System.Collections.Generic;
using Flexiline.Elements;

namespace Flexiline.Rendering;

public partial class FlexilineRenderer : Node3D
{
    private static readonly Shader LinearElementShader = 
            GD.Load<Shader>(
                "res://Flexiline/Shaders/LinearElement.gdshader");

    private readonly Dictionary<
        LinearElementBase,
        MeshInstance3D
    > _renderObjects = new();

    public void Add(LinearElementBase element)
    {
        switch (element)
        {
            case LineSegment lineSegment:
                AddLineSegment(lineSegment);
                break;

            default:
                throw new NotSupportedException(
                    $"Unsupported Flexiline element type: " +
                    $"{element.GetType().Name}"
                );
        }
    }

    public void Update(LinearElementBase element)
    {
        switch (element)
        {
            case LineSegment lineSegment:
                UpdateLineSegment(lineSegment);
                break;

            default:
                throw new NotSupportedException(
                    $"Unsupported Flexiline element type: " +
                    $"{element.GetType().Name}"
                );
        }
    }

    public void Remove(LinearElementBase element)
    {
        if (!_renderObjects.Remove(
            element,
            out MeshInstance3D? renderObject))
        {
            return;
        }

        renderObject.QueueFree();
    }

    private void AddLineSegment(LineSegment lineSegment)
    {
        if (_renderObjects.ContainsKey(lineSegment))
        {
            throw new InvalidOperationException(
                "The element has already been added " +
                "to this renderer."
            );
        }

        var material = new ShaderMaterial
        {
            Shader = LinearElementShader
        };

        SetLineSegmentShaderParameters(
            material,
            lineSegment
        );

        var meshInstance = new MeshInstance3D
        {
            Mesh = new QuadMesh(),
            MaterialOverride = material
        };

        _renderObjects.Add(
            lineSegment,
            meshInstance
        );

        AddChild(meshInstance);
    }

    private void UpdateLineSegment(
        LineSegment lineSegment)
    {
        if (!_renderObjects.TryGetValue(
            lineSegment,
            out MeshInstance3D? meshInstance))
        {
            throw new InvalidOperationException(
                "The element has not been added " +
                "to this renderer."
            );
        }

        var material =
            (ShaderMaterial)meshInstance.MaterialOverride;

        SetLineSegmentShaderParameters(
            material,
            lineSegment
        );
    }

    private static void SetLineSegmentShaderParameters(
        ShaderMaterial material,
        LineSegment lineSegment)
    {
        material.SetShaderParameter("p1", lineSegment.StartPoint);
        material.SetShaderParameter("p2", lineSegment.EndPoint);

        material.SetShaderParameter("line_color", lineSegment.Symbology.Color);
    }
}
