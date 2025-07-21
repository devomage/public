namespace Magestorm.Legacy.Map
{
    [System.Serializable]
    public class Block
    {
        public int index;
        public int blockX;
        public int blockZ;
        public int unknown_00;//                ?
        public int LowBoxTopMod;//              ?
        public int LowSidesTextureId;//         texture
        public int LowTopTextureId;//           texture
        public int HighTextureId;//             texture
        public int LowBoxTopZ;//                            block   LowBoxTopZ
        public int MidBoxBottomZ;//                         block   MidBoxBottomZ
        public int MidBoxTopZ;//                            block   MidBoxTopZ
        public int LowObjectId;//               object
        public int HighBoxBottomZ;//                        block   HighBoxBottomZ
        public int BlockType;//                 ?
        public int LowTopShape;//               shape
        public int MidBottomShape;//            shape
        public int MidSidesTextureId;//         texture
        public int MidTopTextureId;//           texture
        public int CeilingTextureId;//          texture
        public int HighBoxTopZ;//                           block   HighBoxTopZ
        public int unknown_17;//                ?
        public int unknown_18;//                ?

        public void ClearLow()
        {
            LowBoxTopZ = 0;
            LowObjectId = 0;
            LowSidesTextureId = 0;
            LowTopShape = 0;
            LowTopTextureId = 0;
            LowBoxTopMod = 0;
        }
        public void ClearMid()
        {
            MidBottomShape = 0;
            MidBoxBottomZ = 0;
            MidBoxTopZ = 0;
            MidSidesTextureId = 0;
            MidTopTextureId = 0;
        }
        public void ClearHigh()
        {
            HighBoxBottomZ = 0;
            HighBoxTopZ = 0;
            HighTextureId = 0;
        }
        public void ClearAll()
        {
            ClearLow();
            ClearMid();
            ClearHigh();

            BlockType = 0;
            CeilingTextureId = 0;
            unknown_00 = 0;
            unknown_17 = 0;
            unknown_18 = 0;
        }

        public bool HasNoTextures
        {
            get
            {
                return 
                    LowSidesTextureId == 0 &&
                    LowTopTextureId == 0 &&
                    HighTextureId == 0 &&
                    MidSidesTextureId == 0 &&
                    MidTopTextureId == 0 &&
                    CeilingTextureId == 0;
            }
        }
        public bool HasValue
        {
            get
            {
                return
                    LowBoxTopZ != 0 ||
                    MidBoxTopZ != 0 ||
                    MidBoxBottomZ != 0 ||
                    HighBoxBottomZ != 0 ||
                    HighBoxTopZ != 0 ||
                    BlockType != 0 ||
                    LowObjectId != 0 ||
                    LowTopShape != 0 ||
                    MidBottomShape != 0 ||
                    LowBoxTopMod != 0 ||
                    unknown_00 != 0 ||
                    unknown_17 != 0 ||
                    unknown_18 != 0;
            }
        }
        public int LowestPoint
        {
            get
            {
                int lowest = LowBoxTopZ;

                if (MidBoxBottomZ < lowest) lowest = MidBoxBottomZ;
                if (MidBoxTopZ < lowest) lowest = MidBoxTopZ;

                if (HighBoxBottomZ < lowest) lowest = HighBoxBottomZ;
                if (HighBoxTopZ < lowest) lowest = HighBoxTopZ;

                return lowest;
            }
        }
        public bool IsPool
        {
            get
            {
                return BlockType >= 120 && BlockType <= 139;
            }
        }
        public bool IsShrine
        {
            get
            {
                return BlockType >= 150 && BlockType <= 159;
            }
        }
        public bool IsBase
        {
            get
            {
                return BlockType >= 201 && BlockType <= 209;
            }
        }
        public bool IsValhalla
        {
            get
            {
                return BlockType == 210;
            }
        }
        public bool IsSafeZone
        {
            get
            {
                return BlockType == 211;
            }
        }
        public bool IsPerimeter
        {
            get
            {
                return BlockType == 250;
            }
        }
        public int pool_index
        {
            get
            {
                return BlockType - 120;
            }
        }
    }
    public enum BlockType
    {
        Default,

        Unknown_100 = 100,//Magestorm, Splat
        Unknown_101 = 101,//Magestorm, Splat, AO
        Unknown_102 = 102,//Magestorm: Town, Temple, Keep
        Unknown_110 = 110,//Splat

        Pool_120 = 120,//Magestorm
        Pool_121 = 121,
        Pool_122 = 122,
        Pool_123 = 123,
        Pool_124 = 124,
        Pool_125 = 125,
        Pool_126 = 126,
        Pool_127 = 127,
        Pool_128 = 128,
        Pool_129 = 129,
        Pool_130 = 130,
        Pool_131 = 131,
        Pool_132 = 132,
        Pool_133 = 133,
        Pool_134 = 134,
        Pool_135 = 135,
        Pool_136 = 136,
        Pool_137 = 137,
        Pool_138 = 138,
        Pool_139 = 139,

        Shrine_150 = 150,//Magestorm
        Shrine_151 = 151,
        Shrine_152 = 152,
        Shrine_153 = 153,
        Shrine_154 = 154,
        Shrine_155 = 155,
        Shrine_156 = 156,
        Shrine_157 = 157,
        Shrine_158 = 158,
        Shrine_159 = 159,

        Base_201 = 201,//Splat
        Base_202 = 202,
        Base_203 = 203,
        Base_204 = 204,
        Base_205 = 205,
        Base_206 = 206,
        Base_207 = 207,
        Base_208 = 208,
        Base_209 = 209,

        Valhalla = 210,//Magestorm

        SafeZone = 211,//Splat

        //anything beyond this (out of bounds) will appear as the first indexed texture.
        //the entire perimeter of your map should be encircled by this 
        Perimeter = 250
    }

    public enum BlockShape
    {
        None,
        CenterPointShort = 1,
        WestShortSlant,
        EastStairway,
        MediumFullArchEastWest,
        SmallWestHalfArch,
        SmallEastHalfArch,
        SmallNorthHalfArch,
        SmallSouthHalfArch,
        CenterPointLong = 9,
        CenterPointMid = 10,
        MediumFullArchNorthSouth,
        Cylinder,
        EastCurvedRamp,
        WestCurvedRamp,
        SouthCurvedRamp,
        NorthCurvedRamp,
        SouthEastCurvedRamp,
        NorthEastCurvedRamp,
        NorthWestCurvedRamp,
        SouthWestCurvedRamp,
        EastAndSouthCurvedRamp,
        EastAndNorthCurvedRamp,
        WestAndNorthCurvedRamp,
        WestAndSouthCurvedRamp,
        LargeWestHalfArch,
        LargeEastHalfArch,
        LargeNorthHalfArch,
        LargeSouthHalfArch,
        LargeWestAndNorthHalfArch,
        LargeWestAndSouthHalfArch,
        LargeEastndSouthHalfArch,
        LargeEastndNorthHalfArch,
        EastLongSlant,
        WestLongSlant,
        SouthLongSlant,
        NorthLongSlant,
        EastLowLongSlant = 37,
        WestLowLongSlant,
        SouthLowLongSlant,
        NorthLowLongSlant,
        EastHalfCutFullArch,
        WestHalfCutFullArch,
        SouthHalfCutFullArch,
        NorthHalfCutFullArch,
        WestFullVerticalHalfArch,
        EastFullVerticalHalfArch,
        NorthFullVerticalHalfArch,
        SouthFullVerticalHalfArch,
        SmallFullArchEastWest = 49,
        SmallFullArchNorthSouth = 50,
    }
}