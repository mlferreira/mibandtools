using System;
using System.IO;
using System.Text;

namespace WatchFace.Parser.Models
{
    public class Header
    {
        public const int HeaderSize = 87;
        private const string DialSignature = "UIHH";

        public string Signature { get; private set; } = DialSignature;
        public uint Unknown { get; set; }
        public uint ParametersSize { get; set; }

        public bool IsValid => Signature == DialSignature;

        public void WriteTo(Stream stream)
        {
            var buffer = new byte[HeaderSize];
            for (var i = 0; i < buffer.Length; i++) buffer[i] = 0xff;

            Encoding.ASCII.GetBytes(Signature).CopyTo(buffer, 0);
            BitConverter.GetBytes(Unknown).CopyTo(buffer, 32);
            BitConverter.GetBytes(ParametersSize).CopyTo(buffer, 36);
            stream.Write(buffer, 0, HeaderSize);
        }

        public static Header ReadFrom(Stream stream)
        {
            var buffer = new byte[HeaderSize];
            stream.Read(buffer, 0, HeaderSize);

            return new Header
            {
                Signature = Encoding.ASCII.GetString(buffer, 0, 4),
                Unknown = BitConverter.ToUInt32(buffer, 29),
                ParametersSize = BitConverter.ToUInt32(buffer, 83)
            };
        }
    }
}