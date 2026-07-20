using Godot;

public partial class Main : Node3D
{
    public override void _Ready()
    {
        Camera3D camera = new Camera3D
        {
            Projection = Camera3D.ProjectionType.Orthogonal,
            Size = 10.0f,
            Position = new Vector3(6.0f, 4.0f, 8.0f),
            Current = true
        };

        AddChild(camera);

        camera.LookAt(Vector3.Zero, Vector3.Up);
    }
}
