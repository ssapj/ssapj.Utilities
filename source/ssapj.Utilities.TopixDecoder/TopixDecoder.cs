using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ssapj.Utilities
{
    public class TopixDecoder
    {
        private readonly ushort _blockPerLine;
        private readonly byte[] _data;

        public TopixDecoder(ushort dotsPerLine, byte[] data)
        {
            this._blockPerLine = (ushort)(dotsPerLine / 8u + (dotsPerLine % 8u != 0u ? 1u : 0u));
            this._data = data;
        }

        public (List<byte[]>, ushort dotPerLine) Decode()
        {
            var lineNumber = 0;
            ushort offset = 0;
            var lines = new List<byte[]>();

            do
            {
                var (readBytes, bytes) = this.GetLine(offset, this._data);

                if (offset == 0)
                {
                    lines.Add(bytes);
                }
                else
                {
                    var l = lines[lineNumber - 1];
                    lines.Add(bytes.Select((x, index) => (byte)(l[index] ^ x)).ToArray());
                }

                lineNumber++;
                offset += readBytes;
            } while (offset < this._data.Length);

            //カットは受け取った方でやってくれ
            return (lines, (ushort)(this._blockPerLine * 8));
        }

        public (ushort readBytes, byte[] bytes) GetLine(ushort readOffset, ReadOnlySpan<byte> byteSpan)
        {
            var bytes = new byte[this._blockPerLine];
            ushort offsetCounter = 0;
            const ushort step = 512;
            var counter = 0;
            var offset = step * counter;

            do
            {
                var (readBytes, bytes1) = this.GetL1Value((ushort)(readOffset + offsetCounter), byteSpan, (ushort)Math.Min(this._blockPerLine - offset, step));
                Buffer.BlockCopy(bytes1, 0, bytes, offset, bytes1.Length);
                offsetCounter += readBytes;
                counter++;
                offset = step * counter;
            } while (offset < this._blockPerLine);

            return (offsetCounter, bytes);
        }

        public (ushort readBytes, byte[] bytes) GetL1Value(ushort readOffset, ReadOnlySpan<byte> byteSpan, ushort maxBlock = 512)
        {
            if (maxBlock < 1 || 512 < maxBlock)
            {
                throw new ArgumentException();
            }

            var bytes = new byte[Math.Min(maxBlock, (ushort)512)];
            ushort offsetCounter = 1;
            const byte step = 64;
            var bitArray = new BitArray(new byte[] { byteSpan[readOffset] });
            var offset = 0;
            var counter = 0;

            do
            {
                if (bitArray[7 - counter])
                {
                    var (readBytes, bytes1) = this.GetL2Value((ushort)(readOffset + offsetCounter), byteSpan, (byte)Math.Min((ushort)(maxBlock - offset), step));
                    Buffer.BlockCopy(bytes1, 0, bytes, offset, bytes1.Length);
                    offsetCounter += readBytes;
                }

                counter++;
                offset = step * counter;
            } while (offset < maxBlock);

            return (offsetCounter, bytes);
        }



        public (ushort readBytes, byte[] bytes) GetL2Value(ushort readOffset, ReadOnlySpan<byte> byteSpan, byte maxBlock = 64)
        {
            const byte step = 8;

            if (maxBlock < 1 || step * 8 < maxBlock)
            {
                throw new ArgumentException();
            }

            var bytes = new byte[Math.Min(maxBlock, 64u)];
            var flags = new BitArray(new byte[] { byteSpan[readOffset] });
            ushort additionalOffset = 1;
            byte counter = 0;
            byte byteOffset = 0;

            do
            {
                if (flags[7 - counter])
                {
                    var (readBytes, bytes1) = this.GetL3Value((ushort)(readOffset + additionalOffset), byteSpan, (byte)Math.Min(maxBlock - byteOffset, step));
                    Buffer.BlockCopy(bytes1, 0, bytes, byteOffset, bytes1.Length);
                    additionalOffset += readBytes;

                }

                counter++;
                byteOffset = (byte)(step * counter);
            } while (byteOffset < maxBlock);


            return (additionalOffset, bytes);
        }

        public (ushort readBytes, byte[] bytes) GetL3Value(ushort readOffset, ReadOnlySpan<byte> byteSpan, byte maxBlock = 8)
        {

            if (maxBlock < 1 || 8 < maxBlock)
            {
                throw new ArgumentException();
            }

            var bytes = new byte[Math.Min(maxBlock, 8u)];
            ushort offsetCounter = 1;
            var flags = new BitArray(new byte[] { byteSpan[readOffset] });
            byte counter = 0;

            do
            {
                if (flags[7 - counter])
                {
                    bytes[counter] = byteSpan[readOffset + offsetCounter];
                    offsetCounter++;
                }

                counter++;
            } while (counter < maxBlock);

            return (offsetCounter, bytes);
        }
    }

}

