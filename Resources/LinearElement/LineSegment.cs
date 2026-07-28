using Godot;
using System;

namespace LinearElement
{
    public partial class LineSegment : LinearElementBase
    {
        public Symbology Symbology { get; set; } = new Symbology();
        public Vector3 StartPoint { get; set; } = Vector3.Zero;
        public Vector3 EndPoint { get; set; } = Vector3.Zero;

        public static LineSegment Create(
            Vector3 startPoint, Vector3 endPoint, Symbology symbology)
        {
            LineSegment newLS =  new LineSegment
            {
                StartPoint = startPoint,
                EndPoint = endPoint,
                Symbology = symbology
            };

            var shaderMaterial = new ShaderMaterial
            {
                Shader = shader
            };

            shaderMaterial.SetShaderParameter(
                "p1",
                newLS.StartPoint
            );

            shaderMaterial.SetShaderParameter(
                "p2",
                newLS.EndPoint
            );

            var meshInstance = new MeshInstance3D
            {
                Mesh = new QuadMesh(),
                MaterialOverride = shaderMaterial
            };

            AddChild(meshInstance);
            return newLS;
        }
   
    }
}
