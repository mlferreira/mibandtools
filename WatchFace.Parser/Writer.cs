using System.Collections.Generic;
using System.Drawing;
using System.IO;
using NLog;
using Resources.Models;
using WatchFace.Parser.Models;
using Header = WatchFace.Parser.Models.Header;

namespace WatchFace.Parser
{
    public class Writer
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly List<IResource> _images;

        private readonly Stream _stream;

        public Writer(Stream stream, List<IResource> images)
        {
            _stream = stream;
            _images = images;
        }

        public void Write(IList<Parameter> descriptor)
        {
            Logger.Debug("Encoding parameters...");
            var encodedParameters = new Dictionary<byte, MemoryStream>(descriptor.Count);
            foreach (var parameter in descriptor)
            {
                Logger.Debug("Parameter: {0}", parameter.Id);
                var memoryStream = new MemoryStream();
                foreach (var child in parameter.Children)
                    child.Write(memoryStream);
                encodedParameters[parameter.Id] = memoryStream;
            }

            Logger.Debug("Encoding offsets and lengths...");
            var parametersPositions = new List<Parameter>(descriptor.Count + 1);
            var offset = (long) 0;
            foreach (var encodedParameter in encodedParameters)
            {
                var encodedParameterId = encodedParameter.Key;
                var encodedParameterLength = encodedParameter.Value.Length;
                parametersPositions.Add(new Parameter(encodedParameterId, new List<Parameter>
                {
                    new Parameter(1, offset),
                    new Parameter(2, encodedParameterLength)
                }));
                offset += encodedParameterLength;
            }
            parametersPositions.Insert(0, new Parameter(1, new List<Parameter>
            {
                new Parameter(1, offset),
                new Parameter(2, _images.Count)
            }));

            var encodedParametersPositions = new MemoryStream();
            foreach (var parametersPosition in parametersPositions)
                parametersPosition.Write(encodedParametersPositions);

            Logger.Debug("Writing header...");
            var header = new Header
            {
                ParametersSize = (uint) encodedParametersPositions.Length,
                Unknown = 0x159 // Maybe some kind of layers (the bigger number needed for more complex watch faces)
            };
            header.WriteTo(_stream);

            Logger.Debug("Writing parameters offsets and lengths...");
            encodedParametersPositions.Seek(0, SeekOrigin.Begin);
            encodedParametersPositions.WriteTo(_stream);

            Logger.Debug("Writing parameters...");
            foreach (var encodedParameter in encodedParameters)
            {
                var stream = encodedParameter.Value;
                stream.Seek(0, SeekOrigin.Begin);
                stream.WriteTo(_stream);
            }
            Logger.Debug("Writing images...");
            new Resources.Writer(_stream).Write(_images);
        }
    }
}