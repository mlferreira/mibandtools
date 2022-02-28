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
    
    public static class ConstantsMB5
    {
        /* .bin header */
        public static int HeaderSize = 87; // TODO
        public static string DialSignature = "UIHH"; // TODO
        public static int SignatureSize = DialSignature.Length;
        public static int UnknownPosition = 29; // TODO
        public static int ParametersSizePosition = 83; // TODO

        /* watch size */
        public static int ScreenWidth = 126;
        public static int ScreenHeight = 294;
    }
    public static class ConstantsMB4
    {
        /* .bin header */
        public static int HeaderSize = 87; // TODO
        public static string DialSignature = "UIHH"; // TODO
        public static int SignatureSize = DialSignature.Length;
        public static int UnknownPosition = 29; // TODO
        public static int ParametersSizePosition = 83; // TODO

        /* watch size */
        public static int ScreenWidth = 120;
        public static int ScreenHeight = 240;
    }
    
    public static class ConstantsAmazfitBip
    {
        /* .bin header */
        public static int HeaderSize = 40;
        public static string DialSignature = "HMDIAL\0";
        public static int SignatureSize = DialSignature.Length;
        public static int UnknownPosition = 32; 
        public static int ParametersSizePosition = 36; 

        /* watch size */
        public static int ScreenWidth = 172;
        public static int ScreenHeight = 172;
    }
}