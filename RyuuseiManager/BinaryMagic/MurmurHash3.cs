using System.Text;

namespace RyuuseiManager.BinaryMagic
{
    public static class MurmurHash3
    {
        public static uint Hash32(ReadOnlySpan<byte> data, uint seed = 0)
        {
            const uint c1 = 0xcc9e2d51;
            const uint c2 = 0x1b873593;

            uint h1 = seed;
            int length = data.Length;
            int roundedEnd = length & ~0x3;

            for (int i = 0; i < roundedEnd; i += 4)
            {
                uint k1 = BitConverter.ToUInt32(data.Slice(i, 4));

                k1 *= c1;
                k1 = (k1 << 15) | (k1 >> 17);
                k1 *= c2;

                h1 ^= k1;
                h1 = (h1 << 13) | (h1 >> 19);
                h1 = h1 * 5 + 0xe6546b64;
            }

            uint k2 = 0;
            switch (length & 3)
            {
                case 3: k2 ^= (uint)data[roundedEnd + 2] << 16; goto case 2;
                case 2: k2 ^= (uint)data[roundedEnd + 1] << 8; goto case 1;
                case 1:
                    k2 ^= data[roundedEnd];
                    k2 *= c1;
                    k2 = (k2 << 15) | (k2 >> 17);
                    k2 *= c2;
                    h1 ^= k2;
                    break;
            }

            h1 ^= (uint)length;
            h1 ^= h1 >> 16;
            h1 *= 0x85ebca6b;
            h1 ^= h1 >> 13;
            h1 *= 0xc2b2ae35;
            h1 ^= h1 >> 16;

            return h1;
        }

        public static byte[] Hash32LittleEndianBytes(string input, uint seed = 0)
        {
            var data = Encoding.UTF8.GetBytes(input);
            uint hash = Hash32(data, seed);
            byte[] bytes = BitConverter.GetBytes(hash);

            if (!BitConverter.IsLittleEndian)
                Array.Reverse(bytes);

            return bytes;
        }
    }

}
