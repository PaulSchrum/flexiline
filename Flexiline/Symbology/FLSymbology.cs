using Godot;
using System;

namespace Flexiline.Symbology
{
    public partial class FLSymbology : Resource
    {
        private byte weight;
        public byte Weight
        {
            get => weight;
            set => weight = Math.Min(value, (byte)31);
        }

        public Color Color { get; set; } = Colors.Red;
    }
}
