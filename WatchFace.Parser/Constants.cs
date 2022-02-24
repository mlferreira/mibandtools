namespace WatchFace.Parser
{
    public static class ConstantsMB6
    {
        /* .bin header */
        public static int HeaderSize = 87;
        public static string DialSignature = "UIHH";
        public static int SignatureSize = DialSignature.Length;
        public static int UnknownPosition = 29; // hex address 0x0000001D
        public static int ParametersSizePosition = 83; // hex address 0x00000053

        /* watch size */
        public static int ScreenWidth = 152;
        public static int ScreenHeight = 486;
    }
}