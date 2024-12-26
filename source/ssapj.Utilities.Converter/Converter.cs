using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
// ReSharper disable All

namespace ssapj.Utilities
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct RGB
    {
        public byte B;
        public byte G;
        public byte R;
    }

    public static class Converter
    {
        public static int GetIntFromRgb(byte r, byte g, byte b)
        {
            var rgb = new RGB { R = r, G = g, B = b };
            return Unsafe.As<RGB, int>(ref rgb);
        }

        public static (byte a, byte r, byte g, byte b) GetArgbByteValueTuple(uint value)
        {
            return ((byte)(value >> 24), (byte)(value >> 16), (byte)(value >> 8), (byte)(value));
        }

    }
}
