using Godot;
using Flexiline.Elements;
using Flexiline.Rendering;
using Flexiline.Symbology;

namespace Demo
{
    public partial class Main : Node3D
    {
        [Export]
        private bool shouldCreateTestGeometry = true;

        private FlexilineRenderer _renderer = null!;

        public override void _Ready()
        {
            _renderer = GetNode<FlexilineRenderer>("FlexilineRenderer");
            CreateCamera();

            if (shouldCreateTestGeometry)
            {
                CreateTestGeometry();
            }
        }

        private void CreateCamera()
        {
            var camera = new Camera3D
            {
                Projection = Camera3D.ProjectionType.Orthogonal, Size = 6.5f,
                        Position = new Vector3(6.0f, 4.0f, 8.0f),
                Current = true
            };

            AddChild(camera);
            camera.LookAt(Vector3.Zero, Vector3.Up);
        }

        private void CreateTestGeometry()
        {
            var redSymb = new FLSymbology{ Color = Colors.Red, Weight = 0 };
            var grnSymb = new FLSymbology{ Color = Colors.Green, Weight = 7 };
            var bluSymb = new FLSymbology{ Color = Colors.Blue, Weight = 15 };

            var symbology = new FLSymbology();
            _renderer.Add(LineSegment.Create(
                    new Vector3(0.0f,0.0f,0.0f),
                    new Vector3(2.0f, 1.5f, 0.0f),
                    redSymb));

            _renderer.Add(
                LineSegment.Create(
                    new Vector3(-1.0f, 0.0f, 0.0f),
                    new Vector3(4.0f, 2.5f, 0.0f),
                    grnSymb));

            _renderer.Add(
                LineSegment.Create(
                    new Vector3(-2.0f, 1.0f, 0.0f),
                    new Vector3(3.0f, 1.5f, 0.0f ),
                    bluSymb));

            _renderer.Add(
                LineSegment.Create(
                    new Vector3(-3.0f, 2.5f, 0.0f),
                    new Vector3(3.0f, 2.5f, 0.0f),
                    new FLSymbology{Color = Colors.White, Weight = 5}));

            _renderer.Add(
                LineSegment.Create(
                    new Vector3(-2.5f, -2.0f, 0.0f),
                    new Vector3(-2.5f, 2.0f, 0.0f),
                    new FLSymbology{Color = Colors.Yellow, Weight = 5}));

            _renderer.Add(
                LineSegment.Create(
                    new Vector3(1.5f, -2.0f, 0.0f),
                    new Vector3(1.8f, -1.8f, 0.0f),
                    new FLSymbology{Color = Colors.Cyan, Weight = 12}));

            _renderer.Add(
                LineSegment.Create(
                    new Vector3(0.0f, -2.2f, 0.0f),
                    new Vector3(0.0f, -2.2f, 0.0f),
                    new FLSymbology{Color = Colors.Magenta, Weight = 15}));
        }
    }
}