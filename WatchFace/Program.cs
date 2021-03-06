using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using BumpKit;
using Newtonsoft.Json;
using NLog;
using NLog.Config;
using NLog.Targets;
using Resources;
using Resources.Models;
using WatchFace.Parser;
using WatchFace.Parser.Models;
using WatchFace.Parser.Utils;
using Image = System.Drawing.Image;
using Reader = WatchFace.Parser.Reader;
using Writer = WatchFace.Parser.Writer;

namespace WatchFace
{
    internal class Program
    {
        private const string AppName = "WatchFace";

        private static readonly bool IsRunningOnMono = Type.GetType("Mono.Runtime") != null;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private static void Main(string[] args)
        {
            if (args.Length == 0 || args[0] == null)
            {
                Console.WriteLine(
                    "{0}.exe unpacks and packs Mi Band 6 downloadable watch faces and resource files.", AppName);
                Console.WriteLine();
                Console.WriteLine("Usage examples:");
                Console.WriteLine("  {0}.exe watchface.bin   - unpacks watchface images and config", AppName);
                Console.WriteLine("  {0}.exe watchface.json  - packs config and referenced images to bin file",
                    AppName);
                // Console.WriteLine("  {0}.exe mili_chaohu.res - unpacks resource file images", AppName);
                // Console.WriteLine("  {0}.exe mili_chaohu     - packs folder content to res file", AppName);
                return;
            }

            if (args.Length > 1)
                Console.WriteLine("Multiple files unpacking.");

            foreach (var inputFileName in args)
            {
                var isDirectory = Directory.Exists(inputFileName);
                var isFile = File.Exists(inputFileName);
                if (!isDirectory && !isFile)
                {
                    Console.WriteLine("File or directory '{0}' doesn't exists.", inputFileName);
                    continue;
                }

                if (isDirectory)
                {
                    Console.WriteLine("Processing directory '{0}'", inputFileName);
                    try
                    {
                        PackResources(inputFileName);
                    }
                    catch (Exception e)
                    {
                        Logger.Fatal(e);
                    }

                    continue;
                }

                Console.WriteLine("Processing file '{0}'", inputFileName);
                var inputFileExtension = Path.GetExtension(inputFileName);
                try
                {
                    switch (inputFileExtension)
                    {
                        case ".bin":
                            UnpackWatchFace(inputFileName);
                            break;
                        case ".json":
                            PackWatchFace(inputFileName);
                            break;
                        case ".res":
                            UnpackResources(inputFileName);
                            break;
                        default:
                            Console.WriteLine("The app doesn't support files with extension {0}.", inputFileExtension);
                            Console.WriteLine("Only 'bin', 'res' and 'json' files are supported at this time.");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Logger.Fatal(e);
                }
            }
        }

        private static void PackWatchFace(string inputFileName)
        {
            var baseName = Path.GetFileNameWithoutExtension(inputFileName);
            var outputDirectory = Path.GetDirectoryName(inputFileName);
            var outputFileName = Path.Combine(outputDirectory, baseName + "_packed.bin");
            SetupLogger(Path.ChangeExtension(outputFileName, ".log"));

            var watchFace = ReadWatchFaceConfig(inputFileName);
            if (watchFace == null) return;

            var imagesDirectory = Path.GetDirectoryName(inputFileName);
            try
            {
                WriteWatchFace(outputDirectory, outputFileName, imagesDirectory, watchFace);
            }
            catch (Exception)
            {
                File.Delete(outputFileName);
                throw;
            }
        }

        private static void UnpackWatchFace(string inputFileName)
        {
            var outputDirectory = CreateOutputDirectory(inputFileName);
            var baseName = Path.GetFileNameWithoutExtension(inputFileName);
            SetupLogger(Path.Combine(outputDirectory, $"{baseName}.log"));

            var reader = ReadWatchFace(inputFileName);
            if (reader == null) return;

            var watchFace = ParseResources(reader);
            if (watchFace == null) return;

            GeneratePreviews(reader.Parameters, reader.Images, outputDirectory, baseName);

            Logger.Debug("Exporting resources to '{0}'", outputDirectory);
            var reDescriptor = new FileDescriptor {Resources = reader.Resources};
            new Extractor(reDescriptor).Extract(outputDirectory);
            ExportWatchFaceConfig(watchFace, Path.Combine(outputDirectory, $"{baseName}.json"));
        }

        private static void PackResources(string inputDirectory)
        {
            var outputDirectory = Path.GetDirectoryName(inputDirectory);
            var baseName = Path.GetFileName(inputDirectory);
            var outputFileName = Path.Combine(outputDirectory, $"{baseName}_packed.res");
            var logFileName = Path.Combine(outputDirectory, $"{baseName}_packing.log");
            SetupLogger(logFileName);

            FileDescriptor resDescriptor;
            var headerFileName = Path.Combine(inputDirectory, "header.json");
            var versionFileName = Path.Combine(inputDirectory, "version");
            if (File.Exists(headerFileName))
            {
                resDescriptor = ReadResConfig(headerFileName);
            }
            else if (File.Exists(versionFileName))
            {
                resDescriptor = new FileDescriptor();
                using (var stream = File.OpenRead(versionFileName))
                using (var reader = new BinaryReader(stream))
                {
                    resDescriptor.Version = reader.ReadByte();
                }
            }
            else
            {
                throw new ArgumentException(
                    "File 'header.json' or 'version' should exists in the folder with unpacked images. Res-file couldn't be created"
                );
            }

            var i = 0;
            var images = new List<IResource>();
            while (resDescriptor.ResourcesCount == null || i < resDescriptor.ResourcesCount.Value)
            {
                try
                {
                    var resource = ImageLoader.LoadResourceForNumber(inputDirectory, i);
                    images.Add(resource);
                }
                catch (FileNotFoundException)
                {
                    Logger.Info("All images with sequenced names are loaded. Latest loaded image: {0}", i - 1);
                    break;
                }

                i++;
            }

            if (resDescriptor.ResourcesCount != null && resDescriptor.ResourcesCount.Value != images.Count)
                throw new ArgumentException(
                    $"The .res-file should contain {resDescriptor.ResourcesCount.Value} images but was loaded {images.Count} images.");

            resDescriptor.Resources = images;

            using (var stream = File.OpenWrite(outputFileName))
            {
                new FileWriter(stream).Write(resDescriptor);
            }
        }

        private static void UnpackResources(string inputFileName)
        {
            var outputDirectory = CreateOutputDirectory(inputFileName);
            var baseName = Path.GetFileNameWithoutExtension(inputFileName);

            SetupLogger(Path.Combine(outputDirectory, $"{baseName}_unpacking.log"));

            FileDescriptor resDescriptor;
            using (var stream = File.OpenRead(inputFileName))
            {
                resDescriptor = FileReader.Read(stream);
            }

            ExportResConfig(resDescriptor, Path.Combine(outputDirectory, "header.json"));
            new Extractor(resDescriptor).Extract(outputDirectory);
        }

        private static void WriteWatchFace(string outputDirectory, string outputFileName, string imagesDirectory, Parser.WatchFace watchFace)
        {
            try
            {
                Logger.Debug("Reading referenced images from '{0}'", imagesDirectory);
                var imagesReader = new ResourcesLoader(imagesDirectory);
                imagesReader.Process(watchFace);

                Logger.Trace("Building parameters for watch face...");
                var descriptor = ParametersConverter.Build(watchFace);

                var baseFilename = Path.GetFileNameWithoutExtension(outputFileName);
                GeneratePreviews(descriptor, imagesReader.Images, outputDirectory, baseFilename);

                Logger.Debug("Writing watch face to '{0}'", outputFileName);
                using (var fileStream = File.OpenWrite(outputFileName))
                {
                    var writer = new Writer(fileStream, imagesReader.Resources);
                    writer.Write(descriptor);
                    fileStream.Flush();
                }
            }
            catch (Exception e)
            {
                Logger.Fatal(e);
                File.Delete(outputFileName);
            }
        }

        private static Reader ReadWatchFace(string inputFileName)
        {
            Logger.Debug("[Program.cs] [ReadWatchFace] Opening watch face '{0}'", inputFileName);
            try
            {
                using (var fileStream = File.OpenRead(inputFileName))
                {
                    var reader = new Reader(fileStream);
                    Logger.Debug("[Program.cs] [ReadWatchFace] Reading parameters...");
                    reader.Read();
                    Logger.Debug("[Program.cs] [ReadWatchFace] reader.Parameters: {0}", reader.Parameters);
                    Logger.Debug("[Program.cs] [ReadWatchFace] reader.Images: {0}", reader.Images);
                    Logger.Debug("[Program.cs] [ReadWatchFace] reader.Resources: {0}", reader.Resources);
                    return reader;
                }
            }
            catch (Exception e)
            {
                Logger.Fatal(e);
                return null;
            }
        }

        private static Parser.WatchFace ParseResources(Reader reader)
        {
            Logger.Debug("[Program.cs] [ParseResources] Parsing parameters...");
            try
            {
                return ParametersConverter.Parse<Parser.WatchFace>(reader.Parameters);
            }
            catch (Exception e)
            {
                Logger.Fatal(e);
                return null;
            }
        }

        private static string CreateOutputDirectory(string originalFileName)
        {
            var path = Path.GetDirectoryName(originalFileName);
            var name = Path.GetFileNameWithoutExtension(originalFileName);
            var unpackedPath = Path.Combine(path, $"{name}");
            if (!Directory.Exists(unpackedPath)) Directory.CreateDirectory(unpackedPath);
            return unpackedPath;
        }

        private static Parser.WatchFace ReadWatchFaceConfig(string jsonFileName)
        {
            Logger.Debug("[Program.cs] [ReadWatchFaceConfig] Reading config...");
            try
            {
                using (var fileStream = File.OpenRead(jsonFileName))
                using (var reader = new StreamReader(fileStream))
                {
                    return JsonConvert.DeserializeObject<Parser.WatchFace>(reader.ReadToEnd(),
                        new JsonSerializerSettings
                        {
                            MissingMemberHandling = MissingMemberHandling.Error,
                            NullValueHandling = NullValueHandling.Ignore
                        });
                }
            }
            catch (Exception e)
            {
                Logger.Fatal(e);
                return null;
            }
        }

        private static FileDescriptor ReadResConfig(string jsonFileName)
        {
            Logger.Debug("Reading resources config...");
            try
            {
                using (var fileStream = File.OpenRead(jsonFileName))
                using (var reader = new StreamReader(fileStream))
                {
                    return JsonConvert.DeserializeObject<FileDescriptor>(reader.ReadToEnd(),
                        new JsonSerializerSettings
                        {
                            MissingMemberHandling = MissingMemberHandling.Error,
                            NullValueHandling = NullValueHandling.Ignore
                        });
                }
            }
            catch (Exception e)
            {
                Logger.Fatal(e);
                return null;
            }
        }

        private static void ExportWatchFaceConfig(Parser.WatchFace watchFace, string jsonFileName)
        {
            Logger.Debug("Exporting config...");
            try
            {
                using (var fileStream = File.OpenWrite(jsonFileName))
                using (var writer = new StreamWriter(fileStream))
                {
                    writer.Write(JsonConvert.SerializeObject(watchFace, Formatting.Indented,
                        new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore}));
                    writer.Flush();
                }
            }
            catch (Exception e)
            {
                Logger.Fatal(e);
            }
        }

        private static void ExportResConfig(FileDescriptor resDescriptor, string jsonFileName)
        {
            Logger.Debug("Exporting resources config...");
            try
            {
                using (var fileStream = File.OpenWrite(jsonFileName))
                using (var writer = new StreamWriter(fileStream))
                {
                    writer.Write(JsonConvert.SerializeObject(resDescriptor, Formatting.Indented,
                        new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore}));
                    writer.Flush();
                }
            }
            catch (Exception e)
            {
                Logger.Fatal(e);
            }
        }

        private static void SetupLogger(string logFileName)
        {
            var config = new LoggingConfiguration();

            var fileTarget = new FileTarget
            {
                FileName = logFileName,
                Layout = "${level}|${message}",
                KeepFileOpen = true,
                ConcurrentWrites = false,
                OpenFileCacheTimeout = 30
            };
            config.AddTarget("file", fileTarget);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Trace, fileTarget));

            var consoleTarget = new ColoredConsoleTarget {Layout = @"${message}"};
            config.AddTarget("console", consoleTarget);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, consoleTarget));

            LogManager.Configuration = config;
        }

        private static void GeneratePreviews(List<Parameter> parameters, Bitmap[] images, string outputDirectory, string baseName)
        {
            Logger.Debug("Generating previews...");

            var states = GetPreviewStates();
            var staticPreview = PreviewGenerator.CreateImage(parameters, images, new WatchState());
            staticPreview.Save(Path.Combine(outputDirectory, $"{baseName}_static.png"), ImageFormat.Png);

            var previewImages = PreviewGenerator.CreateAnimation(parameters, images, states);

            if (IsRunningOnMono)
            {
                var i = 0;
                foreach (var previewImage in previewImages)
                {
                    previewImage.Save(Path.Combine(outputDirectory, $"{baseName}_animated_{i}.png"), ImageFormat.Png);
                    i++;
                }
            }
            else
            {
                using (var gifOutput = File.OpenWrite(Path.Combine(outputDirectory, $"{baseName}_animated.gif")))
                using (var encoder = new GifEncoder(gifOutput))
                {
                    foreach (var previewImage in previewImages)
                        encoder.AddFrame(previewImage, frameDelay: TimeSpan.FromSeconds(1));
                }
            }
        }

        private static IEnumerable<WatchState> GetPreviewStates()
        {
            var appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var previewStatesPath = Path.Combine(appPath, "PreviewStates.json");

            if (File.Exists(previewStatesPath))
                using (var stream = File.OpenRead(previewStatesPath))
                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<WatchState>>(json);
                }

            var previewStates = GenerateSampleStates();
            using (var stream = File.OpenWrite(previewStatesPath))
            using (var writer = new StreamWriter(stream))
            {
                var json = JsonConvert.SerializeObject(previewStates, Formatting.Indented);
                writer.Write(json);
                writer.Flush();
            }

            return previewStates;
        }

        private static IEnumerable<WatchState> GenerateSampleStates()
        {
            var time = DateTime.Now;
            var states = new List<WatchState>();

            for (var i = 0; i < 10; i++)
            {
                var num = i + 1;
                var watchState = new WatchState
                {
                    BatteryLevel = 100 - i * 10,
                    Pulse = 60 + num * 2,
                    Steps = num * 1000,
                    Calories = num * 75,
                    Distance = num * 700,
                    Bluetooth = num > 1 && num < 6,
                    Unlocked = num > 2 && num < 7,
                    Alarm = num > 3 && num < 8,
                    DoNotDisturb = num > 4 && num < 9,

                    DayTemperature = -15 + 2 * i,
                    NightTemperature = -24 + i * 4,
                };

                if (num < 3)
                {
                    watchState.AirQuality = AirCondition.Unknown;
                    watchState.AirQualityIndex = null;

                    watchState.CurrentWeather = WeatherCondition.Unknown;
                    watchState.CurrentTemperature = null;
                }
                else
                {
                    var index = num - 2;
                    watchState.AirQuality = (AirCondition) index;
                    watchState.CurrentWeather = (WeatherCondition) index;

                    watchState.AirQualityIndex = index * 50 - 25;
                    watchState.CurrentTemperature = -10 + i * 6;
                }

                watchState.Time = new DateTime(time.Year, num, num * 2 + 5, i * 2, i * 6, i);
                states.Add(watchState);
            }

            return states;
        }
    }
}