using Godot;
using System;

public partial class LineSegment : Resource
{
    public Symbology Symbology { get; set; } = new Symbology();
    public Vector3 StartPoint { get; set; } = Vector3.Zero;
    public Vector3 EndPoint { get; set; } = Vector3.Zero;

    public static LineSegment Create(
        Vector3 startPoint, Vector3 endPoint, Symbology symbology)
    {
        return new LineSegment
        {
            StartPoint = startPoint,
            EndPoint = endPoint,
            Symbology = symbology
        };
    }
}
