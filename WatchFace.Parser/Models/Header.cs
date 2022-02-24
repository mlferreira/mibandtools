using System;
using System.IO;
using System.Text;

namespace WatchFace.Parser.Models
{
    public class Header
    {
        private static string DialSignature = ConstantsMB6.DialSignature;

        public string Signature { get; private set; } = DialSignature;
        public uint Unknown { get; set; }
        public uint ParametersSize { get; set; }

        public bool IsValid => Signature == DialSignature;

        public void WriteTo(Stream stream)
        {
            var buffer = new byte[ConstantsMB6.HeaderSize];
            for (var i = 0; i < buffer.Length; i++) buffer[i] = 0xff;

            Encoding.ASCII.GetBytes(Signature).CopyTo(buffer, 0);
            BitConverter.GetBytes(Unknown).CopyTo(buffer, ConstantsMB6.UnknownPosition);
            BitConverter.GetBytes(ParametersSize).CopyTo(buffer, ConstantsMB6.ParametersSizePosition);
            stream.Write(buffer, 0, ConstantsMB6.HeaderSize);
        }

        public static Header ReadFrom(Stream stream)
        {
            var buffer = new byte[ConstantsMB6.HeaderSize];
            stream.Read(buffer, 0, ConstantsMB6.HeaderSize);

            return new Header
            {
                Signature = Encoding.ASCII.GetString(buffer, 0, ConstantsMB6.SignatureSize),
                Unknown = BitConverter.ToUInt32(buffer, ConstantsMB6.UnknownPosition),
                ParametersSize = BitConverter.ToUInt32(buffer, ConstantsMB6.ParametersSizePosition)
            };
        }
    }
}