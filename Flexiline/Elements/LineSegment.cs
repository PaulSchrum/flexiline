using Godot;
using Flexiline.Symbology;

namespace Flexiline.Elements;

public partial class LineSegment : LinearElementBase
{
    public Vector3 StartPoint { get; set; } = Vector3.Zero;

    public Vector3 EndPoint { get; set; } = Vector3.Zero;

    public FLSymbology Symbology { get; set; }
        = new FLSymbology();

    public static LineSegment Create(
        Vector3 startPoint,
        Vector3 endPoint,
        FLSymbology? symbology = null)
    {
        return new LineSegment
        {
            StartPoint = startPoint,
            EndPoint = endPoint,
            Symbology =
                symbology ?? new FLSymbology()
        };
    }
}
