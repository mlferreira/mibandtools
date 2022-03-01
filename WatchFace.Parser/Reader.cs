using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using NLog;
using Resources.Models;
using WatchFace.Parser.Models;
using Header = WatchFace.Parser.Models.Header;
using Image = Resources.Models.Image;

namespace WatchFace.Parser
{
    public class Reader
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly Stream _stream;

        public Reader(Stream stream)
        {
            Logger.Debug("[Reader.cs] [constructor] stream: {0}", stream);
            _stream = stream;
        }

        public List<Parameter> Parameters { get; private set; }
        public List<IResource> Resources { get; private set; }
        public Bitmap[] Images => Resources.OfType<Image>().Select(i => i.Bitmap).ToArray();

        public void Read()
        {
            Logger.Debug("[Reader.cs] [Read()] Reading header...");
            var header = Header.ReadFrom(_stream);
            Logger.Debug("[Reader.cs] [Read()] Header was read:");
            Logger.Debug("Signature: {0}, Unknown: {1}, ParametersSize: {2}, IsValid: {3}", 
                header.Signature,
                header.Unknown,
                header.ParametersSize, 
                header.IsValid);
            if (!header.IsValid)
            {
                Logger.Error("[Reader.cs] [Read()] HEADER IS NOT VALID!");
                return;
            }

            Logger.Debug("[Reader.cs] [Read()] Reading parameter offsets...");
            var parametersStream = StreamBlock(_stream, (int) header.ParametersSize);
            Logger.Debug("[Reader.cs] [Read()] Parameter offsets were read from file");

            Logger.Debug("[Reader.cs] [Read()] Reading parameters descriptor...");
            var mainParam = Parameter.ReadFrom(parametersStream);
            Logger.Debug("[Reader.cs] [Read()] Parameters descriptor was read:");
            var parametrsTableLength = mainParam.Children[0].Value;
            var imagesCount = mainParam.Children[1].Value;
            Logger.Debug($"ParametrsTableLength: {parametrsTableLength}, ImagesCount: {imagesCount}");

            Logger.Debug("[Reader.cs] [Read()] Reading parameters locations...");
            var parametersLocations = Parameter.ReadList(parametersStream);
            Logger.Debug("[Reader.cs] [Read()] Watch face parameters locations were read:");

            Parameters = ReadParameters(parametrsTableLength, parametersLocations);
            Resources = new Resources.Reader(_stream).Read((uint) imagesCount);
        }

        private List<Parameter> ReadParameters(long coordinatesTableSize, ICollection<Parameter> parametersDescriptors)
        {
            var parametersStream = StreamBlock(_stream, (int) coordinatesTableSize);

            var result = new List<Parameter>(parametersDescriptors.Count);
            foreach (var parameterDescriptor in parametersDescriptors)
            {
                var descriptorOffset = parameterDescriptor.Children[0].Value;
                var descriptorLength = parameterDescriptor.Children[1].Value;
                Logger.Debug("[Reader.cs] [ReadParameters()] Reading descriptor for parameter {0}", parameterDescriptor.Id);
                Logger.Debug("[Reader.cs] [ReadParameters()] Descriptor offset: {0}, Descriptor length: {1}", descriptorOffset, descriptorLength);
                parametersStream.Seek(descriptorOffset, SeekOrigin.Begin);
                var descriptorStream = StreamBlock(parametersStream, (int) descriptorLength);
                Logger.Debug("[Reader.cs] [ReadParameters()] Parsing descriptor for parameter {0}...", parameterDescriptor.Id);
                result.Add(new Parameter(parameterDescriptor.Id, Parameter.ReadList(descriptorStream)));
            }
            return result;
        }

        private static Stream StreamBlock(Stream stream, int size)
        {
            var buffer = new byte[size];
            stream.Read(buffer, 0, buffer.Length);
            return new MemoryStream(buffer);
        }
    }
}