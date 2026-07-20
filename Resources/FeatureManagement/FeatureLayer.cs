using Godot;
using System.Collections.Generic;

public partial class FeatureLayer : Node3D
{
    private readonly List<LineSegment> _lineSegments = new()
    {
        LineSegment.Create(
            new Vector3(0.0f, 0.0f, 0.0f),
            new Vector3(2.0f, 1.5f, 0.0f),
            new Symbology()),

        LineSegment.Create(
            new Vector3(-1.0f, 0.0f, 0.0f),
            new Vector3(3.0f, 1.5f, 0.0f),
            new Symbology()),

        LineSegment.Create(
            new Vector3(-2.0f, 1.0f, 0.0f),
            new Vector3(3.0f, 1.5f, 0.0f),
            new Symbology()),
    };

    public override void _Ready()
    {
        Shader shader = GD.Load<Shader>(
            "res://Resources/Shaders/LinearElement.gdshader"
        );

        foreach (LineSegment line in _lineSegments)
        {
            var shaderMaterial = new ShaderMaterial
            {
                Shader = shader
            };

            shaderMaterial.SetShaderParameter(
                "p1",
                line.StartPoint
            );

            shaderMaterial.SetShaderParameter(
                "p2",
                line.EndPoint
            );

            var meshInstance = new MeshInstance3D
            {
                Mesh = new QuadMesh(),
                MaterialOverride = shaderMaterial
            };

            AddChild(meshInstance);
        }
    }

    public void Add(LineSegment lineSegment)
    {
        _lineSegments.Add(lineSegment);
    }
}