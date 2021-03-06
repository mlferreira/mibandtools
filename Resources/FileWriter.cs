using System;
using System.IO;
using NLog;
using Resources.Models;

namespace Resources
{
    public class FileWriter
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly BinaryWriter _binaryWriter;
        private readonly Stream _stream;

        public FileWriter(Stream stream)
        {
            _stream = stream;
            _binaryWriter = new BinaryWriter(stream);
        }

        public void Write(FileDescriptor descriptor)
        {
            if (descriptor.Version == null)
                throw new ArgumentException("Res file version required");

            if (descriptor.HasNewHeader)
                WriteNewHeader(descriptor);
            else
                WriteOldHeader(descriptor);

            Logger.Debug("Writing images...");
            new Writer(_stream).Write(descriptor.Resources);
        }

        private void WriteOldHeader(FileDescriptor descriptor)
        {
            var header = new Header
            {
                ResourcesCount = (uint)descriptor.Resources.Count,
                Version = descriptor.Version.Value
            };
            Logger.Debug("Writing resources header...");
            Logger.Debug("Signature: {0}, Version: {1}, ResourcesCount: {2}",
                header.Signature, header.Version, header.ResourcesCount
            );
            header.WriteTo(_binaryWriter);
        }

        private void WriteNewHeader(FileDescriptor descriptor)
        {
            var header = new NewHeader
            {
                ResourcesCount = descriptor.ResourcesCount.Value,
                Version = descriptor.Version.Value,
                Unknown = descriptor.Unknown.Value
            };
            Logger.Debug("Writing resources header...");
            Logger.Debug("Signature: {0}, Version: {1}, ResourcesCount: {2}, Unknown: {3}",
                header.Signature, header.Version, header.ResourcesCount, header.Unknown
            );
            header.WriteTo(_binaryWriter);
        }

    }
}