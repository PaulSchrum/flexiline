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
                Projection = Camera3D.ProjectionType.Orthogonal, Size = 10.0f,
                        Position = new Vector3(6.0f, 4.0f, 8.0f),
                Current = true
            };

            AddChild(camera);
            camera.LookAt(Vector3.Zero, Vector3.Up);
        }

        private void CreateTestGeometry()
        {
            var redSymb = new FLSymbology{ Color = Colors.Red };
            var grnSymb = new FLSymbology{ Color = Colors.Green };
            var bluSymb = new FLSymbology{ Color = Colors.Blue };

            var symbology = new FLSymbology();
            _renderer.Add(LineSegment.Create(
                    new Vector3(0.0f,0.0f,0.0f),
                    new Vector3(2.0f, 1.5f, 0.0f),
                    redSymb
                )
            );

            _renderer.Add(
                LineSegment.Create(
                    new Vector3(-1.0f, 0.0f, 0.0f),
                    new Vector3(3.0f, 1.5f, 0.0f),
                    grnSymb
                )
            );

            _renderer.Add(
                LineSegment.Create(
                    new Vector3(-2.0f, 1.0f, 0.0f),
                    new Vector3(3.0f, 1.5f, 0.0f ),
                    bluSymb
                )
            );
        }
    }
}