using System.IO;
using System;
using UnityEngine;
using System.Linq;
using Magestorm.Legacy.Spells;

namespace Magestorm.Legacy
{
    public static class DatUtility
    {
        public const string legacy_resources_folder = "/Magestorm/Resources/Legacy";
        public const string default_dev_folder = @"D:\MagestormDev";

        public static class DAT
        {
            public static class ARENAS
            {
                //public static TNet.DataNode ToDataNode(string path)
                //{
                //    System.Collections.Generic.List<Arena> list = Load(path);

                //    TNet.DataNode datanode = new TNet.DataNode("arenas");

                //    foreach (Arena arena in list)
                //    {
                //        datanode.SetHierarchy(arena.index.ToString(), arena);
                //    }

                //    return datanode;
                //}


                public static System.Collections.Generic.List<Arena> Load(string path)
                {
                    INIParser inifile = new INIParser();
                    inifile.Open(path);
                    inifile.Close();

                    return Loader(inifile);
                }

                //        public static System.Collections.Generic.List<Arena> Load(UnityEngine.TextAsset textasset)
                //        {
                //            INIParser inifile = new INIParser();
                //            inifile.Open(textasset);
                //            inifile.Close();

                //            return Loader(inifile);
                //        }

                private static System.Collections.Generic.List<Arena> Loader(INIParser inifile)
                {
                    System.Collections.Generic.List<Arena> list = new System.Collections.Generic.List<Arena>();

                    int arenadefs = int.Parse(inifile.ReadValue("arenadefs", "numarenas", "0"));

                    for (int i = 0; i < arenadefs; i++)
                    {
                        Arena arena = new Arena();

                        //public string name = "";
                        //public byte index;
                        //public byte MusicTrack;
                        //public bool enabled;
                        //public string description = "";
                        //public byte maxplayers;
                        //public ushort timelimit;
                        //public float expbonus;
                        //public TeamType[] teams = new TeamType[0];
                        //public string scenename = "";
                        //public MusicTrack music;

                        arena.name = inifile.ReadValue(string.Format("arena{0:00}", i), "name", "name_unknown").Trim();
                        arena.index = (byte)i;
                        //public byte MusicTrack;
                        arena.enabled = inifile.ReadValue(string.Format("arena{0:00}", i), "enabled", "0").Trim() == "1" ? true : false;
                        arena.description = inifile.ReadValue(string.Format("arena{0:00}", i), "description", "").Trim();
                        arena.maxplayers = byte.Parse(inifile.ReadValue(string.Format("arena{0:00}", i), "maxplayers", "99").Trim());
                        arena.timelimit = ushort.Parse(inifile.ReadValue(string.Format("arena{0:00}", i), "timelimit", "3600").Trim());
                        arena.expbonus = float.Parse(inifile.ReadValue(string.Format("arena{0:00}", i).Trim(), "expbonus", "0"));
                        //public TeamType[] teams = new TeamType[0];
                        //public string scenename = "";
                        //public MusicTrack music;

                        //arena.grid = inifile.ReadValue(string.Format("arena{0:00}", i), "grid", "0").Trim();
                        //arena.midi = inifile.ReadValue(string.Format("arena{0:00}", i), "midi", "catacomb.mid").Trim();
                        //arena.short_name = inifile.ReadValue(string.Format("arena{0:00}", i), "short_name", "short_name_unknown").Trim();
                        //arena.arenatype = int.Parse(inifile.ReadValue(string.Format("arena{0:00}", i), "type", "1").Trim());

                        list.Add(arena);
                    }

                    return list;
                }

                //        public static void Save(string path, System.Collections.Generic.List<Arena> list)
                //        {
                //            System.Collections.Generic.List<string> lines = new System.Collections.Generic.List<string>();

                //            lines.Add("[arenadefs]");
                //            lines.Add("numarenas=" + list.Count);
                //            lines.Add("numgrids=" + list.Count);
                //            lines.Add("default=0");

                //            lines.Add("");

                //            Arena last = list[list.Count - 1];

                //            foreach (Arena arena in list)
                //            {
                //                lines.Add(string.Format("[arena{0:00}]", arena.index));

                //                lines.Add("midi=" + arena.midi);
                //                lines.Add("enabled=" + (arena.enabled ? "1" : "0"));
                //                lines.Add("type=" + arena.arenatype);
                //                lines.Add("name=" + arena.name);
                //                lines.Add("short_name=" + arena.short_name);
                //                lines.Add("description=" + arena.description);
                //                lines.Add("grid=" + string.Format("grid{0:00}", arena.index));
                //                lines.Add("maxplayers=" + arena.maxplayers);
                //                lines.Add("timelimit=" + arena.timelimit);
                //                lines.Add("expbonus=" + arena.expbonus);

                //                if (arena != last) lines.Add("");
                //            }

                //            System.IO.File.WriteAllLines(path, lines.ToArray());
                //        }


            }

            public static class GRID
            {
                public static System.Collections.Generic.List<Map.Block> Load_Blocks(string path)
                {
                    System.Collections.Generic.List<Map.Block> list = new System.Collections.Generic.List<Map.Block>();

                    using (FileStream gridBuffer = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        for (int i = 1; i <= 16384; i++)
                        {
                            int pos = 0;

                            byte[] gridBytes = new byte[38];
                            gridBuffer.Read(gridBytes, 0, 38);

                            Map.Block block = new Map.Block();
                            block.index = i;

                            block.blockX = (int)Math.Floor((i - 1f) % 128f);
                            block.blockZ = (int)Math.Floor((i - 1f) / 128f);

                            block.unknown_00 = BitConverter.ToInt16(gridBytes, 0);
                            block.LowBoxTopMod = BitConverter.ToInt16(gridBytes, pos += 2);
                            block.LowSidesTextureId = BitConverter.ToInt16(gridBytes, pos += 2);
                            block.LowTopTextureId = BitConverter.ToInt16(gridBytes, pos += 2);
                            block.HighTextureId = BitConverter.ToInt16(gridBytes, pos += 2);
                            block.LowBoxTopZ = BitConverter.ToInt16(gridBytes, pos += 2);
                            block.MidBoxBottomZ = BitConverter.ToInt16(gridBytes, pos += 2);
                            block.MidBoxTopZ = BitConverter.ToInt16(gridBytes, pos += 2);
                            block.LowObjectId = BitConverter.ToInt16(gridBytes, pos += 2);
                            block.HighBoxBottomZ = BitConverter.ToInt16(gridBytes, pos += 2);
                            block.BlockType = BitConverter.ToInt16(gridBytes, pos += 2);
                            block.LowTopShape = BitConverter.ToInt16(gridBytes, pos += 2);
                            block.MidBottomShape = BitConverter.ToInt16(gridBytes, pos += 2);
                            block.MidSidesTextureId = BitConverter.ToInt16(gridBytes, pos += 2);
                            block.MidTopTextureId = BitConverter.ToInt16(gridBytes, pos += 2);
                            block.CeilingTextureId = BitConverter.ToInt16(gridBytes, pos += 2);
                            block.HighBoxTopZ = BitConverter.ToInt16(gridBytes, pos += 2);
                            block.unknown_17 = BitConverter.ToInt16(gridBytes, pos += 2);
                            block.unknown_18 = BitConverter.ToInt16(gridBytes, pos);

                            list.Add(block);
                        }

                        gridBuffer.Close();
                    }

                    return list;
                }

                //        public static System.Collections.Generic.List<Map.Block> Load_Blocks(TextAsset textasset)
                //        {
                //            System.Collections.Generic.List<Map.Block> list = new System.Collections.Generic.List<Map.Block>();

                //            using (BinaryReader gridBuffer = new BinaryReader(new MemoryStream(textasset.bytes)))
                //            {
                //                for (int i = 1; i <= 16384; i++)
                //                {
                //                    int pos = 0;

                //                    byte[] gridBytes = new byte[38];
                //                    gridBuffer.Read(gridBytes, 0, 38);

                //                    Map.Block block = new Map.Block();
                //                    block.index = i;

                //                    block.blockX = (int)Math.Floor((i - 1f) % 128f);
                //                    block.blockZ = (int)Math.Floor((i - 1f) / 128f);

                //                    block.unknown_00 = BitConverter.ToInt16(gridBytes, 0);
                //                    block.LowBoxTopMod = BitConverter.ToInt16(gridBytes, pos += 2);
                //                    block.LowSidesTextureId = BitConverter.ToInt16(gridBytes, pos += 2);
                //                    block.LowTopTextureId = BitConverter.ToInt16(gridBytes, pos += 2);
                //                    block.HighTextureId = BitConverter.ToInt16(gridBytes, pos += 2);
                //                    block.LowBoxTopZ = BitConverter.ToInt16(gridBytes, pos += 2);
                //                    block.MidBoxBottomZ = BitConverter.ToInt16(gridBytes, pos += 2);
                //                    block.MidBoxTopZ = BitConverter.ToInt16(gridBytes, pos += 2);
                //                    block.LowObjectId = BitConverter.ToInt16(gridBytes, pos += 2);
                //                    block.HighBoxTopZ = BitConverter.ToInt16(gridBytes, pos += 2);
                //                    block.BlockType = BitConverter.ToInt16(gridBytes, pos += 2);
                //                    block.LowTopShape = BitConverter.ToInt16(gridBytes, pos += 2);
                //                    block.MidBottomShape = BitConverter.ToInt16(gridBytes, pos += 2);
                //                    block.MidSidesTextureId = BitConverter.ToInt16(gridBytes, pos += 2);
                //                    block.MidTopTextureId = BitConverter.ToInt16(gridBytes, pos += 2);
                //                    block.CeilingTextureId = BitConverter.ToInt16(gridBytes, pos += 2);
                //                    block.HighBoxBottomZ = BitConverter.ToInt16(gridBytes, pos += 2);
                //                    block.unknown_17 = BitConverter.ToInt16(gridBytes, pos += 2);
                //                    block.unknown_18 = BitConverter.ToInt16(gridBytes, pos);

                //                    list.Add(block);
                //                }

                //                gridBuffer.Close();
                //            }

                //            return list;
                //        }

                public static System.Collections.Generic.List<Map.ObjectLocation> Load_ObjectLocations(string path)
                {
                    System.Collections.Generic.List<Map.ObjectLocation> list = new System.Collections.Generic.List<Map.ObjectLocation>();

                    using (FileStream gridBuffer = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        gridBuffer.Seek(622592 + 4, SeekOrigin.Begin);

                        for (int i = 1; i <= 997; i++)
                        {
                            int pos = 0;

                            byte[] gridBytes = new byte[16];
                            gridBuffer.Read(gridBytes, 0, 16);

                            Map.ObjectLocation loc = new Map.ObjectLocation();

                            loc.index = i;
                            loc.ObjectId = BitConverter.ToInt32(gridBytes, 0);
                            loc.X = BitConverter.ToInt32(gridBytes, pos += 4);
                            loc.Y = BitConverter.ToInt32(gridBytes, pos += 4);
                            loc.Z = BitConverter.ToInt32(gridBytes, pos + 4);

                            list.Add(loc);
                        }

                        gridBuffer.Close();
                    }

                    return list;
                }

                //        public static System.Collections.Generic.List<Map.ObjectLocation> Load_ObjectLocations(TextAsset textasset)
                //        {
                //            System.Collections.Generic.List<Map.ObjectLocation> list = new System.Collections.Generic.List<Map.ObjectLocation>();


                //            MemoryStream memoryStream = new MemoryStream(textasset.bytes);

                //            BinaryReader gridBuffer = new BinaryReader(memoryStream);

                //            memoryStream.Seek(622592 + 4, SeekOrigin.Begin);

                //            for (int i = 1; i <= 997; i++)
                //            {
                //                int pos = 0;

                //                byte[] gridBytes = new byte[16];
                //                gridBuffer.Read(gridBytes, 0, 16);

                //                Map.ObjectLocation loc = new Map.ObjectLocation();
                //                loc.index = i;
                //                loc.ObjectId = BitConverter.ToInt32(gridBytes, 0);
                //                loc.X = BitConverter.ToInt32(gridBytes, pos += 4);
                //                loc.Y = BitConverter.ToInt32(gridBytes, pos += 4);
                //                loc.Z = BitConverter.ToInt32(gridBytes, pos + 4);

                //                list.Add(loc);
                //            }

                //            gridBuffer.Close();

                //            return list;
                //        }

                //        public static void Save(string path, System.Collections.Generic.List<Map.Block> List_MapBlocks, System.Collections.Generic.List<Map.ObjectLocation> List_MapObjectLocations)
                //        {
                //            using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                //            {
                //                for (int i = 0; i < List_MapBlocks.Count; i++)
                //                {
                //                    Map.Block block = List_MapBlocks[i];

                //                    Byte[] gridBytes = BitConverter.GetBytes(block.unknown_00);
                //                    stream.Write(gridBytes, 0, 2);
                //                    gridBytes = BitConverter.GetBytes(block.LowBoxTopMod);
                //                    stream.Write(gridBytes, 0, 2);
                //                    gridBytes = BitConverter.GetBytes(block.LowSidesTextureId);
                //                    stream.Write(gridBytes, 0, 2);
                //                    gridBytes = BitConverter.GetBytes(block.LowTopTextureId);
                //                    stream.Write(gridBytes, 0, 2);
                //                    gridBytes = BitConverter.GetBytes(block.HighTextureId);
                //                    stream.Write(gridBytes, 0, 2);
                //                    gridBytes = BitConverter.GetBytes(block.LowBoxTopZ);
                //                    stream.Write(gridBytes, 0, 2);
                //                    gridBytes = BitConverter.GetBytes(block.MidBoxBottomZ);
                //                    stream.Write(gridBytes, 0, 2);
                //                    gridBytes = BitConverter.GetBytes(block.MidBoxTopZ);
                //                    stream.Write(gridBytes, 0, 2);
                //                    gridBytes = BitConverter.GetBytes(block.LowObjectId);
                //                    stream.Write(gridBytes, 0, 2);
                //                    gridBytes = BitConverter.GetBytes(block.HighBoxTopZ);
                //                    stream.Write(gridBytes, 0, 2);
                //                    gridBytes = BitConverter.GetBytes(block.BlockType);
                //                    stream.Write(gridBytes, 0, 2);
                //                    gridBytes = BitConverter.GetBytes(block.LowTopShape);
                //                    stream.Write(gridBytes, 0, 2);
                //                    gridBytes = BitConverter.GetBytes(block.MidBottomShape);
                //                    stream.Write(gridBytes, 0, 2);
                //                    gridBytes = BitConverter.GetBytes(block.MidSidesTextureId);
                //                    stream.Write(gridBytes, 0, 2);
                //                    gridBytes = BitConverter.GetBytes(block.MidTopTextureId);
                //                    stream.Write(gridBytes, 0, 2);
                //                    gridBytes = BitConverter.GetBytes(block.CeilingTextureId);
                //                    stream.Write(gridBytes, 0, 2);
                //                    gridBytes = BitConverter.GetBytes(block.HighBoxBottomZ);
                //                    stream.Write(gridBytes, 0, 2);
                //                    gridBytes = BitConverter.GetBytes(block.unknown_17);
                //                    stream.Write(gridBytes, 0, 2);
                //                    gridBytes = BitConverter.GetBytes(block.unknown_18);
                //                    stream.Write(gridBytes, 0, 2);
                //                }

                //                stream.Write(new byte[4], 0, 4);

                //                for (int i = 0; i < List_MapObjectLocations.Count; i++)
                //                {
                //                    Map.ObjectLocation loc = List_MapObjectLocations[i];

                //                    Byte[] gridBytes = BitConverter.GetBytes(loc.ObjectId);
                //                    stream.Write(gridBytes, 0, 4);
                //                    gridBytes = BitConverter.GetBytes(loc.X);
                //                    stream.Write(gridBytes, 0, 4);
                //                    gridBytes = BitConverter.GetBytes(loc.Y);
                //                    stream.Write(gridBytes, 0, 4);
                //                    gridBytes = BitConverter.GetBytes(loc.Z);
                //                    stream.Write(gridBytes, 0, 4);
                //                }

                //                stream.Write(new byte[48], 0, 48);
                //                stream.Close();
                //            }
                //        }
            }

            public static class IMAGE
            {
                //        public static System.Collections.Generic.List<Image> Load(TextAsset textasset)
                //        {
                //            INIParser inifile = new INIParser();
                //            inifile.Open(textasset);
                //            inifile.Close();

                //            return Loader(inifile);
                //        }

                public static System.Collections.Generic.List<Image> Load(string path)
                {
                    INIParser inifile = new INIParser();
                    inifile.Open(path);
                    inifile.Close();

                    return Loader(inifile);
                }

                //public static TNet.DataNode ToDataNode(string path)
                //{
                //    System.Collections.Generic.List<Image> list = Load(path);

                //    TNet.DataNode datanode = new TNet.DataNode("images");

                //    foreach (Image image in list)
                //    {
                //        datanode.SetHierarchy(image.index.ToString(), image);
                //    }

                //    return datanode;
                //}

                private static System.Collections.Generic.List<Image> Loader(INIParser inifile)
                {
                    System.Collections.Generic.List<Image> List_Images = new System.Collections.Generic.List<Image>();

                    int numimages = int.Parse(inifile.ReadValue("imagedefs", "numimages", "0"));

                    for (int i = 0; i < numimages; i++)
                    {
                        string file = inifile.ReadValue(string.Format("image{0:00}", i), "name", "");

                        //if (file.Contains(";")) file = file.Split(';')[0].Trim();
                        //if (file.Contains(".")) file = file.Split('.')[0].Trim();

                        Image image = new Image();

                        image.index = i;
                        image.name = file;
                        image.hpixels = int.Parse(inifile.ReadValue(string.Format("image{0:00}", i), "hpixels", "0"));
                        image.wpixels = int.Parse(inifile.ReadValue(string.Format("image{0:00}", i), "wpixels", "0"));
                        image.wbits = int.Parse(inifile.ReadValue(string.Format("image{0:00}", i), "wbits", "0"));
                        image.hbits = int.Parse(inifile.ReadValue(string.Format("image{0:00}", i), "hbits", "0"));

                        string numinseq = inifile.ReadValue(string.Format("image{0:00}", i), "numinseq", "0");
                        string imageseq = inifile.ReadValue(string.Format("image{0:00}", i), "imageseq", "0");

                        if (!string.IsNullOrEmpty(numinseq))
                        {
                            try
                            {
                                image.numinseq = int.Parse(numinseq);
                            }
                            catch (Exception ex)
                            {
                                Debug.Log(numinseq + " ----------->" + ex.Message);

                                //throw;
                            }
                        }

                        if (!string.IsNullOrEmpty(imageseq))
                        {
                            image.imageseq = imageseq.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
                        }

                        List_Images.Add(image);
                    }

                    inifile.Close();

                    return List_Images;
                }
            }

            public static class MAIN
            {
                //        public static System.Collections.Generic.List<Sound> Load(TextAsset textasset)
                //        {
                //            INIParser inifile = new INIParser();
                //            inifile.Open(textasset);
                //            inifile.Close();

                //            return Loader(inifile);
                //        }

                public static System.Collections.Generic.List<Sound> Load(string path)
                {
                    INIParser inifile = new INIParser();
                    inifile.Open(path);
                    inifile.Close();

                    return Loader(inifile);
                }

                //public static TNet.DataNode ToDataNode(string path)
                //{
                //    System.Collections.Generic.List<Sound> list = Load(path);

                //    TNet.DataNode datanode = new TNet.DataNode("sounds");

                //    foreach (Sound sound in list)
                //    {
                //        datanode.SetHierarchy(sound.index.ToString(), sound);
                //    }

                //    return datanode;
                //}

                private static System.Collections.Generic.List<Sound> Loader(INIParser inifile)
                {
                    System.Collections.Generic.List<Sound> list = new System.Collections.Generic.List<Sound>();

                    int numsounds = int.Parse(inifile.ReadValue("winsounds", "numsounds", "0"));

                    for (int i = 0; i < numsounds; i++)
                    {
                        Sound sound = new Sound();

                        string file = inifile.ReadValue(string.Format("winsound{0:00}", i), "file", "");
                        string volume = inifile.ReadValue(string.Format("winsound{0:00}", i), "volume", "0");

                        sound.index = i;
                        sound.file = file;
                        sound.volume = int.Parse(volume);

                        list.Add(sound);
                    }

                    inifile.Close();

                    return list;
                }
            }

            public static class MISC
            {
                public static System.Collections.Generic.List<Map.Thin> Load_Thins(string path)
                {
                    System.Collections.Generic.List<Map.Thin> list = new System.Collections.Generic.List<Map.Thin>();

                    FileStream thinBuffer = File.OpenRead(path);

                    for (int i = 1; i <= 250; i++)
                    {
                        int pos = 0;

                        byte[] thinBytes = new byte[92];
                        thinBuffer.Read(thinBytes, 0, 92);

                        Map.Thin thin = new Map.Thin();

                        thin.ThinId = i;

                        thin.unknown_00 = BitConverter.ToInt32(thinBytes, 0);
                        thin.unknown_01 = BitConverter.ToInt32(thinBytes, pos += 4);
                        thin.unknown_02 = BitConverter.ToInt32(thinBytes, pos += 4);
                        thin.unknown_03 = BitConverter.ToInt32(thinBytes, pos += 4);
                        thin.unknown_04 = BitConverter.ToInt32(thinBytes, pos += 4);

                        thin.X1 = BitConverter.ToInt32(thinBytes, pos += 4);
                        thin.Y1 = BitConverter.ToInt32(thinBytes, pos += 4);
                        thin.X2 = BitConverter.ToInt32(thinBytes, pos += 4);
                        thin.Y2 = BitConverter.ToInt32(thinBytes, pos += 4);
                        thin.TextureId = BitConverter.ToInt32(thinBytes, pos += 4);

                        thin.Width = BitConverter.ToInt32(thinBytes, pos += 4);
                        thin.Tall = BitConverter.ToInt32(thinBytes, pos += 4);

                        thin.transparency = BitConverter.ToInt32(thinBytes, pos += 4);
                        thin.triggerType = BitConverter.ToInt32(thinBytes, pos += 4);
                        thin.actionRequired = BitConverter.ToInt32(thinBytes, pos += 4);
                        thin.Trans_Table = BitConverter.ToInt32(thinBytes, pos += 4);

                        thin.TriggerId = BitConverter.ToInt32(thinBytes, pos += 4);

                        thin.unknown_17 = BitConverter.ToInt32(thinBytes, pos += 4);
                        thin.enabled = BitConverter.ToInt32(thinBytes, pos += 4);

                        thin.Z = BitConverter.ToInt32(thinBytes, pos += 4);

                        thin.ThinBrightness = BitConverter.ToInt32(thinBytes, pos += 4);
                        thin.BlockPlayers = BitConverter.ToInt32(thinBytes, pos += 4);
                        thin.BlockProjectiles = BitConverter.ToInt32(thinBytes, pos);

                        list.Add(thin);
                    }

                    thinBuffer.Close();

                    return list;
                }

                //        public static System.Collections.Generic.List<Map.Thin> Load_Thins(TextAsset textasset)
                //        {
                //            System.Collections.Generic.List<Map.Thin> list = new System.Collections.Generic.List<Map.Thin>();

                //            //FileStream thinBuffer = File.OpenRead(path);
                //            MemoryStream memoryStream = new MemoryStream(textasset.bytes);

                //            BinaryReader thinBuffer = new BinaryReader(memoryStream);

                //            for (int i = 1; i <= 250; i++)
                //            {
                //                int pos = 0;

                //                byte[] thinBytes = new byte[92];
                //                thinBuffer.Read(thinBytes, 0, 92);

                //                Map.Thin thin = new Map.Thin();

                //                thin.ThinId = i;

                //                thin.unknown_00 = BitConverter.ToInt32(thinBytes, 0);
                //                thin.unknown_01 = BitConverter.ToInt32(thinBytes, pos += 4);
                //                thin.unknown_02 = BitConverter.ToInt32(thinBytes, pos += 4);
                //                thin.unknown_03 = BitConverter.ToInt32(thinBytes, pos += 4);
                //                thin.unknown_04 = BitConverter.ToInt32(thinBytes, pos += 4);

                //                thin.X1 = BitConverter.ToInt32(thinBytes, pos += 4);
                //                thin.Y1 = BitConverter.ToInt32(thinBytes, pos += 4);
                //                thin.X2 = BitConverter.ToInt32(thinBytes, pos += 4);
                //                thin.Y2 = BitConverter.ToInt32(thinBytes, pos += 4);
                //                thin.TextureId = BitConverter.ToInt32(thinBytes, pos += 4);

                //                thin.Width = BitConverter.ToInt32(thinBytes, pos += 4);
                //                thin.Tall = BitConverter.ToInt32(thinBytes, pos += 4);

                //                thin.transparency = BitConverter.ToInt32(thinBytes, pos += 4);
                //                thin.triggerType = BitConverter.ToInt32(thinBytes, pos += 4);
                //                thin.actionRequired = BitConverter.ToInt32(thinBytes, pos += 4);
                //                thin.Trans_Table = BitConverter.ToInt32(thinBytes, pos += 4);

                //                thin.TriggerId = BitConverter.ToInt32(thinBytes, pos += 4);

                //                thin.unknown_17 = BitConverter.ToInt32(thinBytes, pos += 4);
                //                thin.enabled = BitConverter.ToInt32(thinBytes, pos += 4);

                //                thin.Z = BitConverter.ToInt32(thinBytes, pos += 4);

                //                thin.ThinBrightness = BitConverter.ToInt32(thinBytes, pos += 4);
                //                thin.BlockPlayers = BitConverter.ToInt32(thinBytes, pos += 4);
                //                thin.BlockProjectiles = BitConverter.ToInt32(thinBytes, pos);

                //                list.Add(thin);
                //            }

                //            thinBuffer.Close();

                //            return list;
                //        }

                public static System.Collections.Generic.List<Map.Texture> Load_Textures(string path)
                {
                    System.Collections.Generic.List<Map.Texture> list = new System.Collections.Generic.List<Map.Texture>();

                    list.Add(new Map.Texture());

                    FileStream textureBuffer = File.OpenRead(path);
                    textureBuffer.Seek(23000, SeekOrigin.Begin);

                    for (int i = 1; i <= 250; i++)
                    {
                        int pos = 0;

                        byte[] spellBytes = new byte[104];
                        textureBuffer.Read(spellBytes, 0, 104);

                        int TextureId = i;
                        int Width = BitConverter.ToInt32(spellBytes, pos += 60);
                        int Height = BitConverter.ToInt32(spellBytes, pos += 4);
                        int Timer = BitConverter.ToInt32(spellBytes, pos += 4);
                        int SoundId = BitConverter.ToInt32(spellBytes, pos += 4);
                        int NumFrames = BitConverter.ToInt32(spellBytes, pos += 4);
                        int Transparency = BitConverter.ToInt32(spellBytes, pos += 4);
                        int Unknown_07 = BitConverter.ToInt32(spellBytes, pos += 4);
                        int ColorTable = BitConverter.ToInt32(spellBytes, pos += 4);
                        int AnimationRandom = BitConverter.ToInt32(spellBytes, pos += 4);
                        int Unknown_10 = BitConverter.ToInt32(spellBytes, pos += 4);
                        int Unknown_11 = BitConverter.ToInt32(spellBytes, pos);

                        pos = 0;

                        byte[] id = new byte[20];
                        byte[] id0 = new byte[10];
                        byte[] id1 = new byte[10];
                        byte[] id2 = new byte[10];
                        byte[] id3 = new byte[10];

                        string s = "";

                        Array.Copy(spellBytes, 0, id, 0, 20);
                        Array.Copy(spellBytes, pos += 20, id0, 0, 10);
                        Array.Copy(spellBytes, pos += 10, id1, 0, 10);
                        Array.Copy(spellBytes, pos += 10, id2, 0, 10);
                        Array.Copy(spellBytes, pos += 10, id3, 0, 10);

                        s = System.Text.Encoding.UTF8.GetString(id).Trim();
                        string Identifier = s;

                        s = System.Text.Encoding.UTF8.GetString(id0).Trim();
                        string Name00 = s;

                        //var str = System.Text.Encoding.Default.GetString(result);
                        s = System.Text.Encoding.UTF8.GetString(id1).Trim();
                        string Name01 = s;

                        //if (Name01.Length < 5)
                        //{
                        //    foreach (char item in Name01.ToCharArray())
                        //    {
                        //        Debug.Log((int)item);
                        //    }
                        //}

                        s = System.Text.Encoding.UTF8.GetString(id2).Trim();
                        string Name02 = s;

                        s = System.Text.Encoding.UTF8.GetString(id3).Trim();
                        string Name03 = s;

                        if (Name01 == "0") Name01 = "";
                        if (Name02 == "0") Name02 = "";
                        if (Name03 == "0") Name03 = "";

                        //http://stackoverflow.com/questions/3387733/how-to-remove-0-from-a-string-in-c
                        //were causing &#x0;&#x0;&#x0;&#x0;&#x0;&#x0;&#x0;
                        Identifier = Identifier.Replace("\0", "");
                        Name00 = Name00.Replace("\0", "");
                        Name01 = Name01.Replace("\0", "");
                        Name02 = Name02.Replace("\0", "");
                        Name03 = Name03.Replace("\0", "");

                        if (Identifier.Length == 0)
                        {
                            // add to keep correct index
                            Map.Texture tex = new Map.Texture();
                            tex.TextureId = i;
                            list.Add(tex);

                            continue;
                        }

                        Map.Texture _tex = new Map.Texture();

                        _tex.AnimationRandom = AnimationRandom;
                        _tex.ColorTable = ColorTable;
                        _tex.Height = Height;
                        _tex.Identifier = Identifier;
                        _tex.Name00 = Name00;
                        _tex.Name01 = Name01;
                        _tex.Name02 = Name02;
                        _tex.Name03 = Name03;
                        _tex.NumFrames = NumFrames;
                        _tex.SoundId = SoundId;
                        _tex.TextureId = TextureId;
                        _tex.Timer = Timer;
                        _tex.Transparency = Transparency;
                        _tex.Unknown_07 = Unknown_07;
                        _tex.Unknown_10 = Unknown_10;
                        _tex.Unknown_11 = Unknown_11;
                        _tex.Width = Width;

                        list.Add(_tex);
                    }

                    textureBuffer.Close();

                    return list;
                }

                //        public static System.Collections.Generic.List<Map.Texture> Load_Textures(UnityEngine.TextAsset textasset)
                //        {
                //            System.Collections.Generic.List<Map.Texture> list = new System.Collections.Generic.List<Map.Texture>();

                //            MemoryStream memoryStream = new MemoryStream(textasset.bytes);

                //            BinaryReader textureBuffer = new BinaryReader(memoryStream);

                //            // index 0 is empty
                //            list.Add(new Map.Texture());
                //            //for (int i = 1; i <= 16384; i++)
                //            //{
                //            //    int pos = 0;

                //            //    byte[] gridBytes = new byte[38];
                //            //    gridBuffer.Read(gridBytes, 0, 38);

                //            //23000

                //            textureBuffer.Read(new byte[23000], 0, 23000);

                //            for (int i = 1; i <= 250; i++)
                //            {
                //                int pos = 0;

                //                byte[] spellBytes = new byte[104];
                //                textureBuffer.Read(spellBytes, 0, 104);

                //                int TextureId = i;
                //                int Width = BitConverter.ToInt32(spellBytes, pos += 60);
                //                int Height = BitConverter.ToInt32(spellBytes, pos += 4);
                //                int Timer = BitConverter.ToInt32(spellBytes, pos += 4);
                //                int SoundId = BitConverter.ToInt32(spellBytes, pos += 4);
                //                int NumFrames = BitConverter.ToInt32(spellBytes, pos += 4);
                //                int Transparency = BitConverter.ToInt32(spellBytes, pos += 4);
                //                int Unknown_07 = BitConverter.ToInt32(spellBytes, pos += 4);
                //                int ColorTable = BitConverter.ToInt32(spellBytes, pos += 4);
                //                int AnimationRandom = BitConverter.ToInt32(spellBytes, pos += 4);
                //                int Unknown_10 = BitConverter.ToInt32(spellBytes, pos += 4);
                //                int Unknown_11 = BitConverter.ToInt32(spellBytes, pos);

                //                pos = 0;

                //                char[] id = new char[20];
                //                char[] id0 = new char[10];
                //                char[] id1 = new char[10];
                //                char[] id2 = new char[10];
                //                char[] id3 = new char[10];

                //                string s = "";

                //                Array.Copy(spellBytes, 0, id, 0, 20);
                //                Array.Copy(spellBytes, pos += 20, id0, 0, 10);
                //                Array.Copy(spellBytes, pos += 10, id1, 0, 10);
                //                Array.Copy(spellBytes, pos += 10, id2, 0, 10);
                //                Array.Copy(spellBytes, pos += 10, id3, 0, 10);

                //                s = new string(id).Trim();
                //                string Identifier = s;

                //                s = new string(id0).Trim();
                //                string Name00 = s;

                //                s = new string(id1).Trim();
                //                string Name01 = s;

                //                s = new string(id2).Trim();
                //                string Name02 = s;

                //                s = new string(id3).Trim();
                //                string Name03 = s;

                //                //http://stackoverflow.com/questions/3387733/how-to-remove-0-from-a-string-in-c
                //                //were causing &#x0;&#x0;&#x0;&#x0;&#x0;&#x0;&#x0;
                //                Identifier = Identifier.Replace("\0", "");
                //                Name00 = Name00.Replace("\0", "");
                //                Name01 = Name01.Replace("\0", "");
                //                Name02 = Name02.Replace("\0", "");
                //                Name03 = Name03.Replace("\0", "");

                //                if (Identifier.Length == 0)
                //                {
                //                    // add to keep correct index
                //                    Map.Texture tex = new Map.Texture();
                //                    tex.TextureId = i;
                //                    list.Add(tex);

                //                    continue;
                //                }

                //                Map.Texture _tex = new Map.Texture();

                //                _tex.AnimationRandom = AnimationRandom;
                //                _tex.ColorTable = ColorTable;
                //                _tex.Height = Height;
                //                _tex.Identifier = Identifier;
                //                _tex.Name00 = Name00;
                //                _tex.Name01 = Name01;
                //                _tex.Name02 = Name02;
                //                _tex.Name03 = Name03;
                //                _tex.NumFrames = NumFrames;
                //                _tex.SoundId = SoundId;
                //                _tex.TextureId = TextureId;
                //                _tex.Timer = Timer;
                //                _tex.Transparency = Transparency;
                //                _tex.Unknown_07 = Unknown_07;
                //                _tex.Unknown_10 = Unknown_10;
                //                _tex.Unknown_11 = Unknown_11;
                //                _tex.Width = Width;

                //                if (!string.IsNullOrEmpty(Name01)) _tex.isAnimated = true;
                //                if (!string.IsNullOrEmpty(Name02)) _tex.isAnimated = true;
                //                if (!string.IsNullOrEmpty(Name03)) _tex.isAnimated = true;

                //                list.Add(_tex);
                //            }

                //            textureBuffer.Close();

                //            return list;
                //        }

                public static System.Collections.Generic.List<Map.Tile> Load_Tiles(string path)
                {
                    System.Collections.Generic.List<Map.Tile> list = new System.Collections.Generic.List<Map.Tile>();

                    list.Add(new Map.Tile());

                    FileStream tileBuffer = File.OpenRead(path);
                    tileBuffer.Seek(0x0BF68, SeekOrigin.Begin);

                    for (Int32 i = 1; i <= 100; i++)
                    {
                        Byte[] tileBytes = new Byte[256];
                        tileBuffer.Read(tileBytes, 0, 256);

                        Map.Tile tile = new Map.Tile();
                        tile.index = i;

                        Int32 pos = 0;

                        for (Int32 j = 0; j < 64; j++)
                        {
                            tile.TileBlocks.Add(new Map.TileBlock(BitConverter.ToInt16(tileBytes, pos + 2), BitConverter.ToInt16(tileBytes, pos), j));

                            pos = pos + 4;
                        }

                        list.Add(tile);
                    }

                    tileBuffer.Close();

                    return list;
                }

                //        public static System.Collections.Generic.List<Map.Tile> Load_Tiles(UnityEngine.TextAsset textasset)
                //        {
                //            System.Collections.Generic.List<Map.Tile> list = new System.Collections.Generic.List<Map.Tile>();

                //            list.Add(new Map.Tile());

                //            MemoryStream memorystream = new MemoryStream(textasset.bytes);
                //            BinaryReader tileBuffer = new BinaryReader(memorystream);

                //            memorystream.Seek(49000, SeekOrigin.Begin);

                //            for (Int32 i = 1; i <= 100; i++)
                //            {
                //                Byte[] tileBytes = new Byte[256];
                //                tileBuffer.Read(tileBytes, 0, 256);

                //                Map.Tile tile = new Map.Tile();
                //                tile.index = i;

                //                Int32 pos = 0;

                //                for (Int32 j = 0; j < 64; j++)
                //                {
                //                    tile.TileBlocks.Add(new Map.TileBlock(BitConverter.ToInt16(tileBytes, pos + 2), BitConverter.ToInt16(tileBytes, pos), j));

                //                    pos = pos + 4;
                //                }

                //                list.Add(tile);
                //            }

                //            tileBuffer.Close();

                //            return list;
                //        }
            }

            public static class OBJECTS
            {
                public static System.Collections.Generic.List<Map.Object> Load(string path)
                {
                    System.Collections.Generic.List<Map.Object> list = new System.Collections.Generic.List<Map.Object>();

                    list.Add(new Map.Object());

                    FileStream objectBuffer = File.OpenRead(path);

                    for (int i = 1; i <= 139; i++)
                    {
                        int pos = 0;

                        byte[] objectBytes = new byte[116];
                        objectBuffer.Read(objectBytes, 0, 116);

                        char[] id = new char[20];

                        Map.Object obj = new Map.Object();

                        obj.index = i;
                        obj.DefinitionId = BitConverter.ToInt32(objectBytes, 0);
                        obj.imageid = BitConverter.ToInt32(objectBytes, pos += 4);
                        obj.unknown_03 = BitConverter.ToInt32(objectBytes, pos += 4);
                        obj.unknown_04 = BitConverter.ToInt32(objectBytes, pos += 4);
                        obj.image_timer = BitConverter.ToInt32(objectBytes, pos += 4);
                        obj.width = BitConverter.ToInt32(objectBytes, pos += 4);
                        obj.height = BitConverter.ToInt32(objectBytes, pos += 4);
                        obj.unknown_08 = BitConverter.ToInt32(objectBytes, pos += 4);
                        obj.Transparency = BitConverter.ToInt32(objectBytes, pos += 4);
                        obj.Z = BitConverter.ToInt32(objectBytes, pos += 4);
                        obj.EffectSoundID = BitConverter.ToInt32(objectBytes, pos += 4);
                        obj.unused_01 = BitConverter.ToInt32(objectBytes, pos += 4);
                        obj.unknown_12 = BitConverter.ToInt32(objectBytes, pos += 4);
                        obj.LightingEffect = BitConverter.ToInt32(objectBytes, pos += 4);
                        obj.unknown_14 = BitConverter.ToInt32(objectBytes, pos += 4);
                        obj.Contrast = BitConverter.ToInt32(objectBytes, pos += 4);
                        obj.ObjectBrightness = BitConverter.ToInt32(objectBytes, pos += 4);
                        obj.SoundID = BitConverter.ToInt32(objectBytes, pos += 4);
                        obj.distance = BitConverter.ToInt32(objectBytes, pos += 4);
                        obj.unused_02 = BitConverter.ToInt32(objectBytes, pos += 4);
                        obj.unused_03 = BitConverter.ToInt32(objectBytes, pos += 4);
                        obj.unknown_19 = BitConverter.ToInt32(objectBytes, pos += 4);
                        obj.flicker1 = BitConverter.ToInt32(objectBytes, pos += 4);
                        obj.flicker2 = BitConverter.ToInt32(objectBytes, pos += 4);

                        Array.Copy(objectBytes, pos + 4, id, 0, 20);

                        string s = new string(id).Trim();
                        string Identifier = s.Replace("\0", "");

                        obj.Identifier = Identifier;

                        list.Add(obj);
                    }

                    objectBuffer.Close();

                    return list;
                }

                //        public static System.Collections.Generic.List<Map.Object> Load(TextAsset textasset)
                //        {
                //            System.Collections.Generic.List<Map.Object> list = new System.Collections.Generic.List<Map.Object>();

                //            Map.Object blank = new Map.Object();
                //            list.Add(blank);

                //            MemoryStream memoryStream = new MemoryStream(textasset.bytes);

                //            BinaryReader objectBuffer = new BinaryReader(memoryStream);

                //            for (int i = 1; i <= 139; i++)
                //            {
                //                int pos = 0;

                //                byte[] objectBytes = new byte[116];
                //                objectBuffer.Read(objectBytes, 0, 116);

                //                char[] id = new char[20];

                //                Map.Object obj = new Map.Object();

                //                obj.index = i;
                //                obj.DefinitionId = BitConverter.ToInt32(objectBytes, 0);
                //                obj.imageid = BitConverter.ToInt32(objectBytes, pos += 4);
                //                obj.unknown_03 = BitConverter.ToInt32(objectBytes, pos += 4);
                //                obj.unknown_04 = BitConverter.ToInt32(objectBytes, pos += 4);
                //                obj.image_timer = BitConverter.ToInt32(objectBytes, pos += 4);
                //                obj.width = BitConverter.ToInt32(objectBytes, pos += 4);
                //                obj.height = BitConverter.ToInt32(objectBytes, pos += 4);
                //                obj.unknown_08 = BitConverter.ToInt32(objectBytes, pos += 4);
                //                obj.Transparency = BitConverter.ToInt32(objectBytes, pos += 4);
                //                obj.Z = BitConverter.ToInt32(objectBytes, pos += 4);
                //                obj.EffectSoundID = BitConverter.ToInt32(objectBytes, pos += 4);
                //                obj.unused_01 = BitConverter.ToInt32(objectBytes, pos += 4);
                //                obj.unknown_12 = BitConverter.ToInt32(objectBytes, pos += 4);
                //                obj.LightingEffect = BitConverter.ToInt32(objectBytes, pos += 4);
                //                obj.unknown_14 = BitConverter.ToInt32(objectBytes, pos += 4);
                //                obj.Contrast = BitConverter.ToInt32(objectBytes, pos += 4);
                //                obj.ObjectBrightness = BitConverter.ToInt32(objectBytes, pos += 4);
                //                obj.SoundID = BitConverter.ToInt32(objectBytes, pos += 4);
                //                obj.distance = BitConverter.ToInt32(objectBytes, pos += 4);
                //                obj.unused_02 = BitConverter.ToInt32(objectBytes, pos += 4);
                //                obj.unused_03 = BitConverter.ToInt32(objectBytes, pos += 4);
                //                obj.unknown_19 = BitConverter.ToInt32(objectBytes, pos += 4);
                //                obj.flicker1 = BitConverter.ToInt32(objectBytes, pos += 4);
                //                obj.flicker2 = BitConverter.ToInt32(objectBytes, pos += 4);

                //                Array.Copy(objectBytes, pos + 4, id, 0, 20);

                //                string s = new string(id).Trim();
                //                string Identifier = s.Replace("\0", "");

                //                obj.Identifier = Identifier;

                //                list.Add(obj);
                //            }

                //            objectBuffer.Close();

                //            return list;
                //        }

                //        public static void Save(string path, System.Collections.Generic.List<Map.Object> list)
                //        {
                //            using (FileStream objectStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                //            {
                //                for (int i = 1; i <= 139; i++)
                //                {
                //                    Map.Object obj = list[i];

                //                    Byte[] objectBytes = BitConverter.GetBytes(obj.DefinitionId);
                //                    objectStream.Write(objectBytes, 0, 4);
                //                    objectBytes = BitConverter.GetBytes(obj.imageid);
                //                    objectStream.Write(objectBytes, 0, 4);
                //                    objectBytes = BitConverter.GetBytes(obj.unknown_03);
                //                    objectStream.Write(objectBytes, 0, 4);
                //                    objectBytes = BitConverter.GetBytes(obj.unknown_04);
                //                    objectStream.Write(objectBytes, 0, 4);
                //                    objectBytes = BitConverter.GetBytes(obj.image_timer);
                //                    objectStream.Write(objectBytes, 0, 4);
                //                    objectBytes = BitConverter.GetBytes(obj.width);
                //                    objectStream.Write(objectBytes, 0, 4);
                //                    objectBytes = BitConverter.GetBytes(obj.height);
                //                    objectStream.Write(objectBytes, 0, 4);
                //                    objectBytes = BitConverter.GetBytes(obj.unknown_08);
                //                    objectStream.Write(objectBytes, 0, 4);
                //                    objectBytes = BitConverter.GetBytes(obj.Transparency);
                //                    objectStream.Write(objectBytes, 0, 4);
                //                    objectBytes = BitConverter.GetBytes(obj.Z);
                //                    objectStream.Write(objectBytes, 0, 4);
                //                    objectBytes = BitConverter.GetBytes(obj.EffectSoundID);
                //                    objectStream.Write(objectBytes, 0, 4);
                //                    objectBytes = BitConverter.GetBytes(obj.unused_01);
                //                    objectStream.Write(objectBytes, 0, 4);
                //                    objectBytes = BitConverter.GetBytes(obj.unknown_12);
                //                    objectStream.Write(objectBytes, 0, 4);
                //                    objectBytes = BitConverter.GetBytes(obj.LightingEffect);
                //                    objectStream.Write(objectBytes, 0, 4);
                //                    objectBytes = BitConverter.GetBytes(obj.unknown_14);
                //                    objectStream.Write(objectBytes, 0, 4);
                //                    objectBytes = BitConverter.GetBytes(obj.Contrast);
                //                    objectStream.Write(objectBytes, 0, 4);
                //                    objectBytes = BitConverter.GetBytes(obj.ObjectBrightness);
                //                    objectStream.Write(objectBytes, 0, 4);
                //                    objectBytes = BitConverter.GetBytes(obj.SoundID);
                //                    objectStream.Write(objectBytes, 0, 4);
                //                    objectBytes = BitConverter.GetBytes(obj.distance);
                //                    objectStream.Write(objectBytes, 0, 4);
                //                    objectBytes = BitConverter.GetBytes(obj.unused_02);
                //                    objectStream.Write(objectBytes, 0, 4);
                //                    objectBytes = BitConverter.GetBytes(obj.unused_03);
                //                    objectStream.Write(objectBytes, 0, 4);
                //                    objectBytes = BitConverter.GetBytes(obj.unknown_19);
                //                    objectStream.Write(objectBytes, 0, 4);
                //                    objectBytes = BitConverter.GetBytes(obj.flicker1);
                //                    objectStream.Write(objectBytes, 0, 4);
                //                    objectBytes = BitConverter.GetBytes(obj.flicker2);
                //                    objectStream.Write(objectBytes, 0, 4);

                //                    objectStream.Write(Encoding.UTF8.GetBytes(GetChar(20, obj.Identifier)), 0, 20);
                //                }

                //                objectStream.Write(new byte[26], 0, 26);
                //                objectStream.Close();
                //            }
                //        }
            }

            public static class SPELLS
            {
                public static void Load_Spells(string path,
        out System.Collections.Generic.List<Spells.Spell> list,
        out System.Collections.Generic.List<Law> Laws,
        out System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<int>> Professions)
                {
                    list = new System.Collections.Generic.List<Spells.Spell>();
                    Laws = new System.Collections.Generic.List<Law>();
                    Professions = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<int>>();

                    INIParser ini = new INIParser();
                    ini.Open(path);

                    #region Spells

                    list.Clear();

                    Spells.Spell defaultspell = new Spells.Spell();
                    defaultspell.type = SpellType.None;
                    defaultspell.name = "Default Spell";
                    defaultspell.fatigue = 100;
                    defaultspell.min_fatigue = 10;
                    //spell.power = 100;
                    //spell.num_cast_sounds = 0;
                    defaultspell.cast_sound = 0;
                    //spell.cast_sound_2 = 0;
                    //spell.cast_sound_3 = 0;
                    //spell.cast_sound_4 = 0;
                    defaultspell.empty_sound = 0;
                    //spell.switch_sound = 0;
                    //spell.fire_timer = 0;
                    //spell.overlay = 0;

                    defaultspell.index = 0;
                    defaultspell.spell_icon = 0;

                    list.Add(defaultspell);

                    int numspells = ini.ReadValue("spelldefs", "numspells", 0);

                    for (int i = 1; i < numspells; i++)
                    {
                        string SectionName = string.Format("spell{0:00}", i);












                        string type = ini.ReadValue(SectionName, "type", "");

                        Spells.Spell spell = new Spells.Spell();

                        spell.name = ini.ReadValue(SectionName, "name", "");
                        spell.fatigue = ini.ReadValue(SectionName, "fatigue", 0);
                        spell.min_fatigue = ini.ReadValue(SectionName, "min_fatigue", 0);
                        spell.cast_sound = ini.ReadValue(SectionName, "cast_sound", 0);
                        spell.empty_sound = ini.ReadValue(SectionName, "empty_sound", 0);

                        spell.index = i;
                        spell.spell_icon = 0;

                        if (type == "projectile")
                        {
                            #region projectile

                            spell.type = SpellType.Projectile;

                            Spells.Projectile projectile = new Spells.Projectile(spell);

                            projectile.imagenum = ini.ReadValue(SectionName, "imagenum", 0);
                            projectile.death_imagenum = ini.ReadValue(SectionName, "death_imagenum", 0);
                            projectile.width = ini.ReadValue(SectionName, "width", 0);
                            projectile.tall = ini.ReadValue(SectionName, "tall", 0);
                            projectile.image_timer_max = ini.ReadValue(SectionName, "image_timer_max", 0);
                            projectile.death_image_timer_max = ini.ReadValue(SectionName, "death_image_timer_max", 0);
                            int value = ini.ReadValue(SectionName, "gravity", 0);
                            projectile.gravity = value == 1 ? true : false;
                            projectile.light_pattern = ini.ReadValue(SectionName, "light_pattern", 0);
                            projectile.max_flicker = ini.ReadValue(SectionName, "max_flicker", 0);
                            projectile.light_glow = ini.ReadValue(SectionName, "light_glow", 0);
                            projectile.sticky_light = ini.ReadValue(SectionName, "sticky_light", 0);
                            projectile.duration_timer = ini.ReadValue(SectionName, "duration_timer", 0);
                            projectile.trans_color = (TransColor)ini.ReadValue(SectionName, "trans_color", 0);
                            projectile.death_trans_color = (TransColor)ini.ReadValue(SectionName, "death_trans_color", 0);
                            projectile.effect_radius = ini.ReadValue(SectionName, "effect_radius", 0);
                            projectile.miss_sound = ini.ReadValue(SectionName, "miss_sound", 0);
                            projectile.min_damage = ini.ReadValue(SectionName, "min_damage", 0);
                            projectile.max_damage = ini.ReadValue(SectionName, "max_damage", 0);
                            projectile.damage_dice = ini.ReadValue(SectionName, "damage_dice", 0);
                            projectile.damage_num_dice = ini.ReadValue(SectionName, "damage_num_dice", 0);
                            projectile.damage_base = ini.ReadValue(SectionName, "damage_base", 0);
                            projectile.min_power_drain = ini.ReadValue(SectionName, "min_power_drain", 0);
                            projectile.max_power_drain = ini.ReadValue(SectionName, "max_power_drain", 0);
                            projectile.velocity = ini.ReadValue(SectionName, "velocity", 0);
                            projectile.z_velocity = ini.ReadValue(SectionName, "z_velocity", 0);
                            projectile.cast_angle = ini.ReadValue(SectionName, "cast_angle", 0);
                            projectile.num_projectiles = ini.ReadValue(SectionName, "num_projectiles", 0);
                            projectile.projectile_spacing = ini.ReadValue(SectionName, "projectile_spacing", 0);
                            projectile.side_by_side = (SpellProjectileType)ini.ReadValue(SectionName, "side_by_side", 0);
                            projectile.cast_distance = ini.ReadValue(SectionName, "cast_distance", 0);
                            projectile.elevation = ini.ReadValue(SectionName, "elevation", 0);
                            projectile.max_step = ini.ReadValue(SectionName, "max_step", 0);
                            value = ini.ReadValue(SectionName, "translucent", 0);
                            projectile.translucent = value == 1 ? true : false;
                            value = ini.ReadValue(SectionName, "alignment_translucent", 0);
                            projectile.alignment_translucent = value == 1 ? true : false;
                            value = ini.ReadValue(SectionName, "death_translucent", 0);
                            projectile.death_translucent = value == 1 ? true : false;
                            projectile.random_death_position = ini.ReadValue(SectionName, "random_death_position", 0);
                            projectile.center_death_image = ini.ReadValue(SectionName, "center_death_image", 0);
                            projectile.death_effect = ini.ReadValue(SectionName, "death_effect", 0);
                            projectile.death_effect_range = ini.ReadValue(SectionName, "death_effect_range", 0);
                            projectile.death_effect_chance = ini.ReadValue(SectionName, "death_effect_chance", 0);
                            projectile.death_spell_effect = ini.ReadValue(SectionName, "death_spell_effect", 0);
                            projectile.creation_effect = ini.ReadValue(SectionName, "creation_effect", 0);
                            projectile.horizontal_spread = ini.ReadValue(SectionName, "horizontal_spread", 0);
                            projectile.vertical_spread = ini.ReadValue(SectionName, "vertical_spread", 0);
                            projectile.sound = ini.ReadValue(SectionName, "sound", 0);
                            projectile.sound_range = ini.ReadValue(SectionName, "sound_range", 0);
                            projectile.death_sound_range = ini.ReadValue(SectionName, "death_sound_range", 0);
                            projectile.effect_sound_range = ini.ReadValue(SectionName, "effect_sound_range", 0);
                            projectile.death_sound = ini.ReadValue(SectionName, "death_sound", 0);
                            projectile.effect_sound = ini.ReadValue(SectionName, "effect_sound", 0);
                            projectile.death_frame_start = ini.ReadValue(SectionName, "death_frame_start", 0);
                            projectile.element = (SpellElementType)ini.ReadValue(SectionName, "element", 0);
                            value = ini.ReadValue(SectionName, "no_team", 0);
                            projectile.no_team = value == 1 ? true : false;
                            projectile.skill_used = ini.ReadValue(SectionName, "skill_used", 0);
                            projectile.bounce = ini.ReadValue(SectionName, "bounce", 0);
                            value = ini.ReadValue(SectionName, "damage_by_distance_traveled", 0);
                            projectile.damage_by_distance_traveled = value == 1 ? true : false;
                            value = ini.ReadValue(SectionName, "area_effect_spell", 0);
                            projectile.area_effect_spell = value == 1 ? true : false;
                            projectile.friendly = (SpellFriendlyType)ini.ReadValue(SectionName, "friendly", 0);
                            value = ini.ReadValue(SectionName, "ethereal", 0);
                            projectile.ethereal = value == 1 ? true : false;

                            list.Add(projectile);

                            #endregion
                        }
                        else if (type == "wall")
                        {
                            #region wall

                            spell.type = SpellType.Wall;

                            Spells.Wall wall = new Spells.Wall(spell);

                            wall.texturenum = ini.ReadValue(SectionName, "texturenum", 0);
                            wall.length = ini.ReadValue(SectionName, "length", 0);
                            wall.wallheight = ini.ReadValue(SectionName, "wallheight", 0);
                            wall.max_wallheight = ini.ReadValue(SectionName, "max_wallheight", 0);
                            int value = ini.ReadValue(SectionName, "transparent", 0);
                            wall.transparent = value == 1 ? true : false;
                            wall.trans_color = (TransColor)ini.ReadValue(SectionName, "trans_color", 0);
                            wall.duration_timer = ini.ReadValue(SectionName, "duration_timer", 0);
                            wall.thick = ini.ReadValue(SectionName, "thick", 0);
                            wall.cast_distance = ini.ReadValue(SectionName, "cast_distance", 0);
                            value = ini.ReadValue(SectionName, "hug_floor", 0);
                            wall.hug_floor = value == 1 ? true : false;
                            wall.min_damage = ini.ReadValue(SectionName, "min_damage", 0);
                            wall.max_damage = ini.ReadValue(SectionName, "max_damage", 0);
                            wall.min_power_drain = ini.ReadValue(SectionName, "min_power_drain", 0);
                            wall.max_power_drain = ini.ReadValue(SectionName, "max_power_drain", 0);
                            wall.collision_velocity = ini.ReadValue(SectionName, "collision_velocity", 0);
                            wall.element = (SpellElementType)ini.ReadValue(SectionName, "element", 0);
                            wall.hit_points = ini.ReadValue(SectionName, "hit_points", 0);
                            wall.friendly = (SpellFriendlyType)ini.ReadValue(SectionName, "friendly", 0);

                            list.Add(wall);

                            #endregion
                        }
                        else if (type == "healing")
                        {
                            #region healing

                            spell.type = SpellType.Healing;

                            Spells.Healing healing = new Spells.Healing(spell);

                            healing.min = ini.ReadValue(SectionName, "min", 0);
                            healing.max = ini.ReadValue(SectionName, "max", 0);

                            list.Add(healing);

                            #endregion
                        }
                        else if (type == "effect")
                        {
                            #region effect

                            spell.type = SpellType.Effect;

                            Spells.Effect effect = new Spells.Effect(spell);

                            effect.effect = (SpellEffectType)ini.ReadValue(SectionName, "effect", 0);
                            effect.duration_type = (SpellDurationType)ini.ReadValue(SectionName, "duration_type", 0);
                            effect.duration = ini.ReadValue(SectionName, "duration", 0);
                            effect.level = ini.ReadValue(SectionName, "level", 0);
                            effect.element = (SpellElementType)ini.ReadValue(SectionName, "element", 0);
                            effect.imagenum = ini.ReadValue(SectionName, "imagenum", 0);
                            effect.image_timer = ini.ReadValue(SectionName, "image_timer", 0);
                            effect.overlay_imagenum = ini.ReadValue(SectionName, "overlay_imagenum", 0);
                            effect.overlay_image_timer = ini.ReadValue(SectionName, "overlay_image_timer", 0);
                            effect.overlay_duration = ini.ReadValue(SectionName, "overlay_duration", 0);
                            effect.overlay_dur_type = (SpellOverlayDurationType)ini.ReadValue(SectionName, "overlay_dur_type", 0);
                            effect.overlay_height = ini.ReadValue(SectionName, "overlay_height", 0);
                            effect.overlay_opaque = ini.ReadValue(SectionName, "overlay_opaque", 0);
                            effect.overlay_glow = ini.ReadValue(SectionName, "overlay_glow", 0);
                            effect.overlay_trans_color = (TransColor)ini.ReadValue(SectionName, "overlay_trans_color", 0);

                            list.Add(effect);

                            #endregion
                        }
                        else if (type == "special")
                        {
                            spell.type = SpellType.Special;
                        }
                        else if (type == "bolt")
                        {
                            #region bolt

                            spell.type = SpellType.Bolt;

                            Spells.Bolt bolt = new Spells.Bolt(spell);

                            bolt.imagenum = ini.ReadValue(SectionName, "imagenum", 0);
                            bolt.death_imagenum = ini.ReadValue(SectionName, "death_imagenum", 0);
                            bolt.death_imagenum_chance = ini.ReadValue(SectionName, "death_imagenum_chance", 0);
                            bolt.effect_imagenum = ini.ReadValue(SectionName, "effect_imagenum", 0);
                            bolt.leading_edge_imagenum = ini.ReadValue(SectionName, "leading_edge_imagenum", 0);
                            bolt.width = ini.ReadValue(SectionName, "width", 0);
                            bolt.tall = ini.ReadValue(SectionName, "tall", 0);
                            bolt.image_timer_max = ini.ReadValue(SectionName, "image_timer_max", 0);
                            bolt.death_image_timer_max = ini.ReadValue(SectionName, "death_image_timer_max", 0);
                            bolt.effect_image_timer_max = ini.ReadValue(SectionName, "effect_image_timer_max", 0);
                            int value = ini.ReadValue(SectionName, "gravity", 0);
                            bolt.gravity = value == 1 ? true : false;
                            bolt.light_pattern = ini.ReadValue(SectionName, "light_pattern", 0);
                            bolt.max_flicker = ini.ReadValue(SectionName, "max_flicker", 0);
                            bolt.light_glow = ini.ReadValue(SectionName, "light_glow", 0);
                            bolt.sticky_light = ini.ReadValue(SectionName, "sticky_light", 0);
                            bolt.duration_timer = ini.ReadValue(SectionName, "duration_timer", 0);
                            bolt.trans_color = (TransColor)ini.ReadValue(SectionName, "trans_color", 0);
                            bolt.death_trans_color = (TransColor)ini.ReadValue(SectionName, "death_trans_color", 0);
                            bolt.effect_trans_color = (TransColor)ini.ReadValue(SectionName, "effect_trans_color", 0);
                            bolt.effect_radius = ini.ReadValue(SectionName, "effect_radius", 0);
                            bolt.min_damage = ini.ReadValue(SectionName, "min_damage", 0);
                            bolt.max_damage = ini.ReadValue(SectionName, "max_damage", 0);
                            bolt.damage_dice = ini.ReadValue(SectionName, "damage_dice", 0);
                            bolt.damage_num_dice = ini.ReadValue(SectionName, "damage_num_dice", 0);
                            bolt.damage_base = ini.ReadValue(SectionName, "damage_base", 0);
                            bolt.min_power_drain = ini.ReadValue(SectionName, "min_power_drain", 0);
                            bolt.max_power_drain = ini.ReadValue(SectionName, "max_power_drain", 0);
                            bolt.num_objects = ini.ReadValue(SectionName, "num_objects", 0);
                            bolt.object_spacing = ini.ReadValue(SectionName, "object_spacing", 0);
                            bolt.object_layout = ini.ReadValue(SectionName, "object_layout", 0);
                            bolt.cast_distance = ini.ReadValue(SectionName, "cast_distance", 0);
                            bolt.elevation = ini.ReadValue(SectionName, "elevation", 0);
                            value = ini.ReadValue(SectionName, "translucent", 0);
                            bolt.translucent = value == 1 ? true : false;
                            value = ini.ReadValue(SectionName, "death_translucent", 0);
                            bolt.death_translucent = value == 1 ? true : false;
                            value = ini.ReadValue(SectionName, "effect_translucent", 0);
                            bolt.effect_translucent = value == 1 ? true : false;
                            bolt.range = ini.ReadValue(SectionName, "range", 0);
                            bolt.max_timer = ini.ReadValue(SectionName, "max_timer", 0);
                            bolt.death_effect = ini.ReadValue(SectionName, "death_effect", 0);
                            bolt.death_effect_range = ini.ReadValue(SectionName, "death_effect_range", 0);
                            bolt.death_effect_chance = ini.ReadValue(SectionName, "death_effect_chance", 0);
                            bolt.death_spell_effect = ini.ReadValue(SectionName, "death_spell_effect", 0);
                            bolt.creation_effect = ini.ReadValue(SectionName, "creation_effect", 0);
                            bolt.bolt_death_effect = ini.ReadValue(SectionName, "bolt_death_effect", 0);
                            bolt.bolt_death_effect_range = ini.ReadValue(SectionName, "bolt_death_effect_range", 0);
                            bolt.bolt_death_effect_chance = ini.ReadValue(SectionName, "bolt_death_effect_chance", 0);
                            bolt.effect_sound = ini.ReadValue(SectionName, "effect_sound", 0);
                            bolt.effect_sound_range = ini.ReadValue(SectionName, "effect_sound_range", 0);
                            bolt.element = (SpellElementType)ini.ReadValue(SectionName, "element", 0);
                            bolt.skill_used = ini.ReadValue(SectionName, "skill_used", 0);
                            bolt.friendly = (SpellFriendlyType)ini.ReadValue(SectionName, "friendly", 0);
                            value = ini.ReadValue(SectionName, "hug_floor", 0);
                            bolt.hug_floor = value == 1 ? true : false;

                            list.Add(bolt);

                            #endregion
                        }
                        else if (type == "target")
                        {
                            #region target

                            spell.type = SpellType.Target;

                            Spells.Target target = new Spells.Target(spell);

                            target.min_damage = ini.ReadValue(SectionName, "min_damage", 0);
                            target.max_damage = ini.ReadValue(SectionName, "max_damage", 0);
                            target.damage_dice = ini.ReadValue(SectionName, "damage_dice", 0);
                            target.damage_num_dice = ini.ReadValue(SectionName, "damage_num_dice", 0);
                            target.damage_base = ini.ReadValue(SectionName, "damage_base", 0);
                            target.min_power_drain = ini.ReadValue(SectionName, "min_power_drain", 0);
                            target.max_power_drain = ini.ReadValue(SectionName, "max_power_drain", 0);
                            target.range = ini.ReadValue(SectionName, "range", 0);
                            target.caster_spell_effect = ini.ReadValue(SectionName, "caster_spell_effect", 0);
                            target.target_spell_effect = ini.ReadValue(SectionName, "target_spell_effect", 0);
                            target.effect_sound = ini.ReadValue(SectionName, "effect_sound", 0);
                            target.effect_sound_range = ini.ReadValue(SectionName, "effect_sound_range", 0);
                            target.miss_sound = ini.ReadValue(SectionName, "miss_sound", 0);
                            target.element = (SpellElementType)ini.ReadValue(SectionName, "element", 0);
                            target.friendly = (SpellFriendlyType)ini.ReadValue(SectionName, "friendly", 0);
                            int value = ini.ReadValue(SectionName, "group", 0);
                            target.group = value == 1 ? true : false;

                            list.Add(target);

                            #endregion
                        }
                        else if (type == "dispell")
                        {
                            #region dispell

                            spell.type = SpellType.Dispell;

                            Spells.Dispell dispell = new Spells.Dispell(spell);

                            dispell.dispell_type = ini.ReadValue(SectionName, "dispell_type", 0);
                            dispell.range = ini.ReadValue(SectionName, "range", 0);
                            dispell.level = ini.ReadValue(SectionName, "level", 0);
                            dispell.effect_sound = ini.ReadValue(SectionName, "effect_sound", 0);
                            dispell.effect_sound_range = ini.ReadValue(SectionName, "effect_sound_range", 0);

                            list.Add(dispell);

                            #endregion
                        }
                        else if (type == "teleport")
                        {
                            #region teleport

                            spell.type = SpellType.Teleport;

                            Spells.Teleport teleport = new Spells.Teleport(spell);

                            teleport.teleport_type = ini.ReadValue(SectionName, "teleport_type", 0);
                            teleport.caster_spell_effect = ini.ReadValue(SectionName, "caster_spell_effect", 0);

                            list.Add(teleport);

                            #endregion
                        }
                        else if (type == "rune")
                        {
                            #region rune

                            spell.type = SpellType.Rune;

                            Spells.Rune rune = new Spells.Rune(spell);

                            rune.imagenum = ini.ReadValue(SectionName, "imagenum", 0);
                            rune.death_imagenum = ini.ReadValue(SectionName, "death_imagenum", 0);
                            rune.width = ini.ReadValue(SectionName, "width", 0);
                            rune.tall = ini.ReadValue(SectionName, "tall", 0);
                            rune.image_timer_max = ini.ReadValue(SectionName, "image_timer_max", 0);
                            rune.death_image_timer_max = ini.ReadValue(SectionName, "death_image_timer_max", 0);
                            int value = ini.ReadValue(SectionName, "gravity", 0);
                            rune.gravity = value == 1 ? true : false;
                            rune.light_pattern = ini.ReadValue(SectionName, "light_pattern", 0);
                            rune.max_flicker = ini.ReadValue(SectionName, "max_flicker", 0);
                            rune.light_glow = ini.ReadValue(SectionName, "light_glow", 0);
                            rune.sticky_light = ini.ReadValue(SectionName, "sticky_light", 0);
                            rune.duration_timer = ini.ReadValue(SectionName, "duration_timer", 0);
                            rune.trans_color = (TransColor)ini.ReadValue(SectionName, "trans_color", 0);
                            rune.effect_radius = ini.ReadValue(SectionName, "effect_radius", 0);
                            rune.miss_sound = ini.ReadValue(SectionName, "miss_sound", 0);
                            rune.min_damage = ini.ReadValue(SectionName, "min_damage", 0);
                            rune.max_damage = ini.ReadValue(SectionName, "max_damage", 0);
                            rune.damage_dice = ini.ReadValue(SectionName, "damage_dice", 0);
                            rune.damage_num_dice = ini.ReadValue(SectionName, "damage_num_dice", 0);
                            rune.damage_base = ini.ReadValue(SectionName, "damage_base", 0);
                            rune.min_power_drain = ini.ReadValue(SectionName, "min_power_drain", 0);
                            rune.max_power_drain = ini.ReadValue(SectionName, "max_power_drain", 0);
                            rune.velocity = ini.ReadValue(SectionName, "velocity", 0);
                            rune.z_velocity = ini.ReadValue(SectionName, "z_velocity", 0);
                            rune.cast_angle = ini.ReadValue(SectionName, "cast_angle", 0);
                            rune.num_projectiles = ini.ReadValue(SectionName, "num_projectiles", 0);
                            rune.projectile_spacing = ini.ReadValue(SectionName, "projectile_spacing", 0);
                            rune.side_by_side = (SpellProjectileType)ini.ReadValue(SectionName, "side_by_side", 0);
                            rune.cast_distance = ini.ReadValue(SectionName, "cast_distance", 0);
                            rune.elevation = ini.ReadValue(SectionName, "elevation", 0);
                            rune.max_step = ini.ReadValue(SectionName, "max_step", 0);
                            value = ini.ReadValue(SectionName, "translucent", 0);
                            rune.translucent = value == 1 ? true : false;
                            value = ini.ReadValue(SectionName, "alignment_translucent", 0);
                            rune.alignment_translucent = value == 1 ? true : false;
                            value = ini.ReadValue(SectionName, "death_translucent", 0);
                            rune.death_translucent = value == 1 ? true : false;
                            rune.random_death_position = ini.ReadValue(SectionName, "random_death_position", 0);
                            rune.center_death_image = ini.ReadValue(SectionName, "center_death_image", 0);
                            rune.death_effect = ini.ReadValue(SectionName, "death_effect", 0);
                            rune.death_effect_range = ini.ReadValue(SectionName, "death_effect_range", 0);
                            rune.death_effect_chance = ini.ReadValue(SectionName, "death_effect_chance", 0);
                            rune.death_spell_effect = ini.ReadValue(SectionName, "death_spell_effect", 0);
                            rune.horizontal_spread = ini.ReadValue(SectionName, "horizontal_spread", 0);
                            rune.vertical_spread = ini.ReadValue(SectionName, "vertical_spread", 0);
                            rune.sound = ini.ReadValue(SectionName, "sound", 0);
                            rune.sound_range = ini.ReadValue(SectionName, "sound_range", 0);
                            rune.death_sound = ini.ReadValue(SectionName, "death_sound", 0);
                            rune.death_sound_range = ini.ReadValue(SectionName, "death_sound_range", 0);
                            rune.effect_sound = ini.ReadValue(SectionName, "effect_sound", 0);
                            rune.effect_sound_range = ini.ReadValue(SectionName, "effect_sound_range", 0);
                            rune.death_frame_start = ini.ReadValue(SectionName, "death_frame_start", 0);
                            rune.element = (SpellElementType)ini.ReadValue(SectionName, "element", 0);
                            value = ini.ReadValue(SectionName, "no_team", 0);
                            rune.no_team = value == 1 ? true : false;
                            rune.collision_velocity = ini.ReadValue(SectionName, "collision_velocity", 0);

                            rune.aura_caster_effect = ini.ReadValue(SectionName, "aura_caster_effect", 0);
                            rune.aura_target_effect = ini.ReadValue(SectionName, "aura_target_effect", 0);
                            rune.friendly = (SpellFriendlyType)ini.ReadValue(SectionName, "friendly", 0);
                            rune.aura_pulse_timer = ini.ReadValue(SectionName, "aura_pulse_timer", 0);
                            rune.aura_health = ini.ReadValue(SectionName, "aura_health", 0);
                            value = ini.ReadValue(SectionName, "aura_stackable", 0);
                            rune.aura_stackable = value == 1 ? true : false;

                            list.Add(rune);

                            #endregion
                        }
                        else Debug.Log(i + " = " + type);
                    }

                    #endregion

                    #region Laws

                    Laws.Clear();

                    int numlists = ini.ReadValue("listdefs", "numlists", 0);

                    for (int i = 0; i < numlists; i++)
                    {
                        string SectionName = string.Format("spelllist{0:00}", i);

                        Law law = new Law();
                        law.name = ini.ReadValue(SectionName, "name", "");

                        for (int ii = 1; ii < 50; ii++)
                        {
                            law.list.Add(ii, ini.ReadValue(SectionName, string.Format("level{0:00}", ii), 0));
                        }

                        Laws.Add(law);
                    }

                    #endregion

                    #region Professions

                    Professions.Clear();

                    foreach (ProfessionType profession in System.Enum.GetValues(typeof(ProfessionType)))
                    {
                        string SectionName = profession.ToString().ToLower();

                        System.Collections.Generic.List<int> laws = new System.Collections.Generic.List<int>();

                        if (SectionName == "wizard") SectionName = "magician";

                        for (int i = 0; i < 10; i++)
                        {
                            laws.Add(ini.ReadValue(SectionName, string.Format("list{0:00}", i), 0));
                        }

                        Professions.Add(SectionName, laws);
                    }

                    #endregion

                    ini.Close();
                }










                public static void Load_Spells_Laws(string path,
        out System.Collections.Generic.List<Law> Laws)
                {
                    Laws = new System.Collections.Generic.List<Law>();

                    INIParser ini = new INIParser();
                    ini.Open(path);

                    #region Laws

                    Laws.Clear();

                    int numlists = ini.ReadValue("listdefs", "numlists", 0);

                    for (int i = 0; i < numlists; i++)
                    {
                        string SectionName = string.Format("spelllist{0:00}", i);

                        Law law = new Law();
                        law.name = ini.ReadValue(SectionName, "name", "");

                        for (int ii = 1; ii < 50; ii++)
                        {
                            law.list.Add(ii, ini.ReadValue(SectionName, string.Format("level{0:00}", ii), 0));
                        }

                        Laws.Add(law);
                    }

                    #endregion

                    ini.Close();
                }
                public static void Load_Spells_Professions(string path,
        out System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<int>> Professions)
                {
                    Professions = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<int>>();

                    INIParser ini = new INIParser();
                    ini.Open(path);

                    #region Professions

                    Professions.Clear();

                    foreach (ProfessionType profession in System.Enum.GetValues(typeof(ProfessionType)))
                    {
                        string SectionName = profession.ToString().ToLower();

                        System.Collections.Generic.List<int> laws = new System.Collections.Generic.List<int>();

                        if (SectionName == "wizard") SectionName = "magician";

                        for (int i = 0; i < 10; i++)
                        {
                            laws.Add(ini.ReadValue(SectionName, string.Format("list{0:00}", i), 0));
                        }

                        Professions.Add(SectionName, laws);
                    }

                    #endregion

                    ini.Close();
                }










                public static void Load_Spells_Spells(string path,
        out System.Collections.Generic.List<Spells.Bolt> boltList,
        out System.Collections.Generic.List<Spells.Dispell> dispellList,
        out System.Collections.Generic.List<Spells.Effect> effectList,
        out System.Collections.Generic.List<Spells.Healing> healingList,
        out System.Collections.Generic.List<Spells.Projectile> projectileList,
        out System.Collections.Generic.List<Spells.Rune> runeList,
        out System.Collections.Generic.List<Spells.Target> targetList,
        out System.Collections.Generic.List<Spells.Teleport> teleportList,
        out System.Collections.Generic.List<Spells.Wall> wallList)
                {
                    boltList = new System.Collections.Generic.List<Spells.Bolt>();
                    dispellList = new System.Collections.Generic.List<Spells.Dispell>();
                    effectList = new System.Collections.Generic.List<Spells.Effect>();
                    healingList = new System.Collections.Generic.List<Spells.Healing>();
                    projectileList = new System.Collections.Generic.List<Spells.Projectile>();
                    runeList = new System.Collections.Generic.List<Spells.Rune>();
                    targetList = new System.Collections.Generic.List<Spells.Target>();
                    teleportList = new System.Collections.Generic.List<Spells.Teleport>();
                    wallList = new System.Collections.Generic.List<Spells.Wall>();

                    INIParser ini = new INIParser();
                    ini.Open(path);

                    #region Spells

                    Spells.Spell defaultspell = new Spells.Spell();
                    defaultspell.type = SpellType.None;
                    defaultspell.name = "Default Spell";
                    defaultspell.fatigue = 100;
                    defaultspell.min_fatigue = 10;
                    //spell.power = 100;
                    //spell.num_cast_sounds = 0;
                    defaultspell.cast_sound = 0;
                    //spell.cast_sound_2 = 0;
                    //spell.cast_sound_3 = 0;
                    //spell.cast_sound_4 = 0;
                    defaultspell.empty_sound = 0;
                    //spell.switch_sound = 0;
                    //spell.fire_timer = 0;
                    //spell.overlay = 0;

                    defaultspell.index = 0;
                    defaultspell.spell_icon = 0;

                    //list.Add(defaultspell);

                    int numspells = ini.ReadValue("spelldefs", "numspells", 0);

                    for (int i = 1; i < numspells; i++)
                    {
                        string SectionName = string.Format("spell{0:00}", i);












                        string type = ini.ReadValue(SectionName, "type", "");

                        Spells.Spell spell = new Spells.Spell();

                        spell.name = ini.ReadValue(SectionName, "name", "");
                        spell.fatigue = ini.ReadValue(SectionName, "fatigue", 0);
                        spell.min_fatigue = ini.ReadValue(SectionName, "min_fatigue", 0);
                        spell.cast_sound = ini.ReadValue(SectionName, "cast_sound", 0);
                        spell.empty_sound = ini.ReadValue(SectionName, "empty_sound", 0);

                        spell.index = i;
                        spell.spell_icon = 0;

                        if (type == "projectile")
                        {
                            #region projectile

                            spell.type = SpellType.Projectile;

                            Spells.Projectile projectile = new Spells.Projectile(spell);

                            projectile.imagenum = ini.ReadValue(SectionName, "imagenum", 0);
                            projectile.death_imagenum = ini.ReadValue(SectionName, "death_imagenum", 0);
                            projectile.width = ini.ReadValue(SectionName, "width", 0);
                            projectile.tall = ini.ReadValue(SectionName, "tall", 0);
                            projectile.image_timer_max = ini.ReadValue(SectionName, "image_timer_max", 0);
                            projectile.death_image_timer_max = ini.ReadValue(SectionName, "death_image_timer_max", 0);
                            int value = ini.ReadValue(SectionName, "gravity", 0);
                            projectile.gravity = value == 1 ? true : false;
                            projectile.light_pattern = ini.ReadValue(SectionName, "light_pattern", 0);
                            projectile.max_flicker = ini.ReadValue(SectionName, "max_flicker", 0);
                            projectile.light_glow = ini.ReadValue(SectionName, "light_glow", 0);
                            projectile.sticky_light = ini.ReadValue(SectionName, "sticky_light", 0);
                            projectile.duration_timer = ini.ReadValue(SectionName, "duration_timer", 0);
                            projectile.trans_color = (TransColor)ini.ReadValue(SectionName, "trans_color", 0);
                            projectile.death_trans_color = (TransColor)ini.ReadValue(SectionName, "death_trans_color", 0);
                            projectile.effect_radius = ini.ReadValue(SectionName, "effect_radius", 0);
                            projectile.miss_sound = ini.ReadValue(SectionName, "miss_sound", 0);
                            projectile.min_damage = ini.ReadValue(SectionName, "min_damage", 0);
                            projectile.max_damage = ini.ReadValue(SectionName, "max_damage", 0);
                            projectile.damage_dice = ini.ReadValue(SectionName, "damage_dice", 0);
                            projectile.damage_num_dice = ini.ReadValue(SectionName, "damage_num_dice", 0);
                            projectile.damage_base = ini.ReadValue(SectionName, "damage_base", 0);
                            projectile.min_power_drain = ini.ReadValue(SectionName, "min_power_drain", 0);
                            projectile.max_power_drain = ini.ReadValue(SectionName, "max_power_drain", 0);
                            projectile.velocity = ini.ReadValue(SectionName, "velocity", 0);
                            projectile.z_velocity = ini.ReadValue(SectionName, "z_velocity", 0);
                            projectile.cast_angle = ini.ReadValue(SectionName, "cast_angle", 0);
                            projectile.num_projectiles = ini.ReadValue(SectionName, "num_projectiles", 0);
                            projectile.projectile_spacing = ini.ReadValue(SectionName, "projectile_spacing", 0);
                            projectile.side_by_side = (SpellProjectileType)ini.ReadValue(SectionName, "side_by_side", 0);
                            projectile.cast_distance = ini.ReadValue(SectionName, "cast_distance", 0);
                            projectile.elevation = ini.ReadValue(SectionName, "elevation", 0);
                            projectile.max_step = ini.ReadValue(SectionName, "max_step", 0);
                            value = ini.ReadValue(SectionName, "translucent", 0);
                            projectile.translucent = value == 1 ? true : false;
                            value = ini.ReadValue(SectionName, "alignment_translucent", 0);
                            projectile.alignment_translucent = value == 1 ? true : false;
                            value = ini.ReadValue(SectionName, "death_translucent", 0);
                            projectile.death_translucent = value == 1 ? true : false;
                            projectile.random_death_position = ini.ReadValue(SectionName, "random_death_position", 0);
                            projectile.center_death_image = ini.ReadValue(SectionName, "center_death_image", 0);
                            projectile.death_effect = ini.ReadValue(SectionName, "death_effect", 0);
                            projectile.death_effect_range = ini.ReadValue(SectionName, "death_effect_range", 0);
                            projectile.death_effect_chance = ini.ReadValue(SectionName, "death_effect_chance", 0);
                            projectile.death_spell_effect = ini.ReadValue(SectionName, "death_spell_effect", 0);
                            projectile.creation_effect = ini.ReadValue(SectionName, "creation_effect", 0);
                            projectile.horizontal_spread = ini.ReadValue(SectionName, "horizontal_spread", 0);
                            projectile.vertical_spread = ini.ReadValue(SectionName, "vertical_spread", 0);
                            projectile.sound = ini.ReadValue(SectionName, "sound", 0);
                            projectile.sound_range = ini.ReadValue(SectionName, "sound_range", 0);
                            projectile.death_sound_range = ini.ReadValue(SectionName, "death_sound_range", 0);
                            projectile.effect_sound_range = ini.ReadValue(SectionName, "effect_sound_range", 0);
                            projectile.death_sound = ini.ReadValue(SectionName, "death_sound", 0);
                            projectile.effect_sound = ini.ReadValue(SectionName, "effect_sound", 0);
                            projectile.death_frame_start = ini.ReadValue(SectionName, "death_frame_start", 0);
                            projectile.element = (SpellElementType)ini.ReadValue(SectionName, "element", 0);
                            value = ini.ReadValue(SectionName, "no_team", 0);
                            projectile.no_team = value == 1 ? true : false;
                            projectile.skill_used = ini.ReadValue(SectionName, "skill_used", 0);
                            projectile.bounce = ini.ReadValue(SectionName, "bounce", 0);
                            value = ini.ReadValue(SectionName, "damage_by_distance_traveled", 0);
                            projectile.damage_by_distance_traveled = value == 1 ? true : false;
                            value = ini.ReadValue(SectionName, "area_effect_spell", 0);
                            projectile.area_effect_spell = value == 1 ? true : false;
                            projectile.friendly = (SpellFriendlyType)ini.ReadValue(SectionName, "friendly", 0);
                            value = ini.ReadValue(SectionName, "ethereal", 0);
                            projectile.ethereal = value == 1 ? true : false;

                            projectileList.Add(projectile);

                            #endregion
                        }
                        else if (type == "wall")
                        {
                            #region wall

                            spell.type = SpellType.Wall;

                            Spells.Wall wall = new Spells.Wall(spell);

                            wall.texturenum = ini.ReadValue(SectionName, "texturenum", 0);
                            wall.length = ini.ReadValue(SectionName, "length", 0);
                            wall.wallheight = ini.ReadValue(SectionName, "wallheight", 0);
                            wall.max_wallheight = ini.ReadValue(SectionName, "max_wallheight", 0);
                            int value = ini.ReadValue(SectionName, "transparent", 0);
                            wall.transparent = value == 1 ? true : false;
                            wall.trans_color = (TransColor)ini.ReadValue(SectionName, "trans_color", 0);
                            wall.duration_timer = ini.ReadValue(SectionName, "duration_timer", 0);
                            wall.thick = ini.ReadValue(SectionName, "thick", 0);
                            wall.cast_distance = ini.ReadValue(SectionName, "cast_distance", 0);
                            value = ini.ReadValue(SectionName, "hug_floor", 0);
                            wall.hug_floor = value == 1 ? true : false;
                            wall.min_damage = ini.ReadValue(SectionName, "min_damage", 0);
                            wall.max_damage = ini.ReadValue(SectionName, "max_damage", 0);
                            wall.min_power_drain = ini.ReadValue(SectionName, "min_power_drain", 0);
                            wall.max_power_drain = ini.ReadValue(SectionName, "max_power_drain", 0);
                            wall.collision_velocity = ini.ReadValue(SectionName, "collision_velocity", 0);
                            wall.element = (SpellElementType)ini.ReadValue(SectionName, "element", 0);
                            wall.hit_points = ini.ReadValue(SectionName, "hit_points", 0);
                            wall.friendly = (SpellFriendlyType)ini.ReadValue(SectionName, "friendly", 0);

                            wallList.Add(wall);

                            #endregion
                        }
                        else if (type == "healing")
                        {
                            #region healing

                            spell.type = SpellType.Healing;

                            Spells.Healing healing = new Spells.Healing(spell);

                            healing.min = ini.ReadValue(SectionName, "min", 0);
                            healing.max = ini.ReadValue(SectionName, "max", 0);

                            healingList.Add(healing);

                            #endregion
                        }
                        else if (type == "effect")
                        {
                            #region effect

                            spell.type = SpellType.Effect;

                            Spells.Effect effect = new Spells.Effect(spell);

                            effect.effect = (SpellEffectType)ini.ReadValue(SectionName, "effect", 0);
                            effect.duration_type = (SpellDurationType)ini.ReadValue(SectionName, "duration_type", 0);
                            effect.duration = ini.ReadValue(SectionName, "duration", 0);
                            effect.level = ini.ReadValue(SectionName, "level", 0);
                            effect.element = (SpellElementType)ini.ReadValue(SectionName, "element", 0);
                            effect.imagenum = ini.ReadValue(SectionName, "imagenum", 0);
                            effect.image_timer = ini.ReadValue(SectionName, "image_timer", 0);
                            effect.overlay_imagenum = ini.ReadValue(SectionName, "overlay_imagenum", 0);
                            effect.overlay_image_timer = ini.ReadValue(SectionName, "overlay_image_timer", 0);
                            effect.overlay_duration = ini.ReadValue(SectionName, "overlay_duration", 0);
                            effect.overlay_dur_type = (SpellOverlayDurationType)ini.ReadValue(SectionName, "overlay_dur_type", 0);
                            effect.overlay_height = ini.ReadValue(SectionName, "overlay_height", 0);
                            effect.overlay_opaque = ini.ReadValue(SectionName, "overlay_opaque", 0);
                            effect.overlay_glow = ini.ReadValue(SectionName, "overlay_glow", 0);
                            effect.overlay_trans_color = (TransColor)ini.ReadValue(SectionName, "overlay_trans_color", 0);

                            effectList.Add(effect);

                            #endregion
                        }
                        else if (type == "special")
                        {
                            spell.type = SpellType.Special;
                        }
                        else if (type == "bolt")
                        {
                            #region bolt

                            spell.type = SpellType.Bolt;

                            Spells.Bolt bolt = new Spells.Bolt(spell);

                            bolt.imagenum = ini.ReadValue(SectionName, "imagenum", 0);
                            bolt.death_imagenum = ini.ReadValue(SectionName, "death_imagenum", 0);
                            bolt.death_imagenum_chance = ini.ReadValue(SectionName, "death_imagenum_chance", 0);
                            bolt.effect_imagenum = ini.ReadValue(SectionName, "effect_imagenum", 0);
                            bolt.leading_edge_imagenum = ini.ReadValue(SectionName, "leading_edge_imagenum", 0);
                            bolt.width = ini.ReadValue(SectionName, "width", 0);
                            bolt.tall = ini.ReadValue(SectionName, "tall", 0);
                            bolt.image_timer_max = ini.ReadValue(SectionName, "image_timer_max", 0);
                            bolt.death_image_timer_max = ini.ReadValue(SectionName, "death_image_timer_max", 0);
                            bolt.effect_image_timer_max = ini.ReadValue(SectionName, "effect_image_timer_max", 0);
                            int value = ini.ReadValue(SectionName, "gravity", 0);
                            bolt.gravity = value == 1 ? true : false;
                            bolt.light_pattern = ini.ReadValue(SectionName, "light_pattern", 0);
                            bolt.max_flicker = ini.ReadValue(SectionName, "max_flicker", 0);
                            bolt.light_glow = ini.ReadValue(SectionName, "light_glow", 0);
                            bolt.sticky_light = ini.ReadValue(SectionName, "sticky_light", 0);
                            bolt.duration_timer = ini.ReadValue(SectionName, "duration_timer", 0);
                            bolt.trans_color = (TransColor)ini.ReadValue(SectionName, "trans_color", 0);
                            bolt.death_trans_color = (TransColor)ini.ReadValue(SectionName, "death_trans_color", 0);
                            bolt.effect_trans_color = (TransColor)ini.ReadValue(SectionName, "effect_trans_color", 0);
                            bolt.effect_radius = ini.ReadValue(SectionName, "effect_radius", 0);
                            bolt.min_damage = ini.ReadValue(SectionName, "min_damage", 0);
                            bolt.max_damage = ini.ReadValue(SectionName, "max_damage", 0);
                            bolt.damage_dice = ini.ReadValue(SectionName, "damage_dice", 0);
                            bolt.damage_num_dice = ini.ReadValue(SectionName, "damage_num_dice", 0);
                            bolt.damage_base = ini.ReadValue(SectionName, "damage_base", 0);
                            bolt.min_power_drain = ini.ReadValue(SectionName, "min_power_drain", 0);
                            bolt.max_power_drain = ini.ReadValue(SectionName, "max_power_drain", 0);
                            bolt.num_objects = ini.ReadValue(SectionName, "num_objects", 0);
                            bolt.object_spacing = ini.ReadValue(SectionName, "object_spacing", 0);
                            bolt.object_layout = ini.ReadValue(SectionName, "object_layout", 0);
                            bolt.cast_distance = ini.ReadValue(SectionName, "cast_distance", 0);
                            bolt.elevation = ini.ReadValue(SectionName, "elevation", 0);
                            value = ini.ReadValue(SectionName, "translucent", 0);
                            bolt.translucent = value == 1 ? true : false;
                            value = ini.ReadValue(SectionName, "death_translucent", 0);
                            bolt.death_translucent = value == 1 ? true : false;
                            value = ini.ReadValue(SectionName, "effect_translucent", 0);
                            bolt.effect_translucent = value == 1 ? true : false;
                            bolt.range = ini.ReadValue(SectionName, "range", 0);
                            bolt.max_timer = ini.ReadValue(SectionName, "max_timer", 0);
                            bolt.death_effect = ini.ReadValue(SectionName, "death_effect", 0);
                            bolt.death_effect_range = ini.ReadValue(SectionName, "death_effect_range", 0);
                            bolt.death_effect_chance = ini.ReadValue(SectionName, "death_effect_chance", 0);
                            bolt.death_spell_effect = ini.ReadValue(SectionName, "death_spell_effect", 0);
                            bolt.creation_effect = ini.ReadValue(SectionName, "creation_effect", 0);
                            bolt.bolt_death_effect = ini.ReadValue(SectionName, "bolt_death_effect", 0);
                            bolt.bolt_death_effect_range = ini.ReadValue(SectionName, "bolt_death_effect_range", 0);
                            bolt.bolt_death_effect_chance = ini.ReadValue(SectionName, "bolt_death_effect_chance", 0);
                            bolt.effect_sound = ini.ReadValue(SectionName, "effect_sound", 0);
                            bolt.effect_sound_range = ini.ReadValue(SectionName, "effect_sound_range", 0);
                            bolt.element = (SpellElementType)ini.ReadValue(SectionName, "element", 0);
                            bolt.skill_used = ini.ReadValue(SectionName, "skill_used", 0);
                            bolt.friendly = (SpellFriendlyType)ini.ReadValue(SectionName, "friendly", 0);
                            value = ini.ReadValue(SectionName, "hug_floor", 0);
                            bolt.hug_floor = value == 1 ? true : false;

                            boltList.Add(bolt);

                            #endregion
                        }
                        else if (type == "target")
                        {
                            #region target

                            spell.type = SpellType.Target;

                            Spells.Target target = new Spells.Target(spell);

                            target.min_damage = ini.ReadValue(SectionName, "min_damage", 0);
                            target.max_damage = ini.ReadValue(SectionName, "max_damage", 0);
                            target.damage_dice = ini.ReadValue(SectionName, "damage_dice", 0);
                            target.damage_num_dice = ini.ReadValue(SectionName, "damage_num_dice", 0);
                            target.damage_base = ini.ReadValue(SectionName, "damage_base", 0);
                            target.min_power_drain = ini.ReadValue(SectionName, "min_power_drain", 0);
                            target.max_power_drain = ini.ReadValue(SectionName, "max_power_drain", 0);
                            target.range = ini.ReadValue(SectionName, "range", 0);
                            target.caster_spell_effect = ini.ReadValue(SectionName, "caster_spell_effect", 0);
                            target.target_spell_effect = ini.ReadValue(SectionName, "target_spell_effect", 0);
                            target.effect_sound = ini.ReadValue(SectionName, "effect_sound", 0);
                            target.effect_sound_range = ini.ReadValue(SectionName, "effect_sound_range", 0);
                            target.miss_sound = ini.ReadValue(SectionName, "miss_sound", 0);
                            target.element = (SpellElementType)ini.ReadValue(SectionName, "element", 0);
                            target.friendly = (SpellFriendlyType)ini.ReadValue(SectionName, "friendly", 0);
                            int value = ini.ReadValue(SectionName, "group", 0);
                            target.group = value == 1 ? true : false;

                            targetList.Add(target);

                            #endregion
                        }
                        else if (type == "dispell")
                        {
                            #region dispell

                            spell.type = SpellType.Dispell;

                            Spells.Dispell dispell = new Spells.Dispell(spell);

                            dispell.dispell_type = ini.ReadValue(SectionName, "dispell_type", 0);
                            dispell.range = ini.ReadValue(SectionName, "range", 0);
                            dispell.level = ini.ReadValue(SectionName, "level", 0);
                            dispell.effect_sound = ini.ReadValue(SectionName, "effect_sound", 0);
                            dispell.effect_sound_range = ini.ReadValue(SectionName, "effect_sound_range", 0);

                            dispellList.Add(dispell);

                            #endregion
                        }
                        else if (type == "teleport")
                        {
                            #region teleport

                            spell.type = SpellType.Teleport;

                            Spells.Teleport teleport = new Spells.Teleport(spell);

                            teleport.teleport_type = ini.ReadValue(SectionName, "teleport_type", 0);
                            teleport.caster_spell_effect = ini.ReadValue(SectionName, "caster_spell_effect", 0);

                            teleportList.Add(teleport);

                            #endregion
                        }
                        else if (type == "rune")
                        {
                            #region rune

                            spell.type = SpellType.Rune;

                            Spells.Rune rune = new Spells.Rune(spell);

                            rune.imagenum = ini.ReadValue(SectionName, "imagenum", 0);
                            rune.death_imagenum = ini.ReadValue(SectionName, "death_imagenum", 0);
                            rune.width = ini.ReadValue(SectionName, "width", 0);
                            rune.tall = ini.ReadValue(SectionName, "tall", 0);
                            rune.image_timer_max = ini.ReadValue(SectionName, "image_timer_max", 0);
                            rune.death_image_timer_max = ini.ReadValue(SectionName, "death_image_timer_max", 0);
                            int value = ini.ReadValue(SectionName, "gravity", 0);
                            rune.gravity = value == 1 ? true : false;
                            rune.light_pattern = ini.ReadValue(SectionName, "light_pattern", 0);
                            rune.max_flicker = ini.ReadValue(SectionName, "max_flicker", 0);
                            rune.light_glow = ini.ReadValue(SectionName, "light_glow", 0);
                            rune.sticky_light = ini.ReadValue(SectionName, "sticky_light", 0);
                            rune.duration_timer = ini.ReadValue(SectionName, "duration_timer", 0);
                            rune.trans_color = (TransColor)ini.ReadValue(SectionName, "trans_color", 0);
                            rune.effect_radius = ini.ReadValue(SectionName, "effect_radius", 0);
                            rune.miss_sound = ini.ReadValue(SectionName, "miss_sound", 0);
                            rune.min_damage = ini.ReadValue(SectionName, "min_damage", 0);
                            rune.max_damage = ini.ReadValue(SectionName, "max_damage", 0);
                            rune.damage_dice = ini.ReadValue(SectionName, "damage_dice", 0);
                            rune.damage_num_dice = ini.ReadValue(SectionName, "damage_num_dice", 0);
                            rune.damage_base = ini.ReadValue(SectionName, "damage_base", 0);
                            rune.min_power_drain = ini.ReadValue(SectionName, "min_power_drain", 0);
                            rune.max_power_drain = ini.ReadValue(SectionName, "max_power_drain", 0);
                            rune.velocity = ini.ReadValue(SectionName, "velocity", 0);
                            rune.z_velocity = ini.ReadValue(SectionName, "z_velocity", 0);
                            rune.cast_angle = ini.ReadValue(SectionName, "cast_angle", 0);
                            rune.num_projectiles = ini.ReadValue(SectionName, "num_projectiles", 0);
                            rune.projectile_spacing = ini.ReadValue(SectionName, "projectile_spacing", 0);
                            rune.side_by_side = (SpellProjectileType)ini.ReadValue(SectionName, "side_by_side", 0);
                            rune.cast_distance = ini.ReadValue(SectionName, "cast_distance", 0);
                            rune.elevation = ini.ReadValue(SectionName, "elevation", 0);
                            rune.max_step = ini.ReadValue(SectionName, "max_step", 0);
                            value = ini.ReadValue(SectionName, "translucent", 0);
                            rune.translucent = value == 1 ? true : false;
                            value = ini.ReadValue(SectionName, "alignment_translucent", 0);
                            rune.alignment_translucent = value == 1 ? true : false;
                            value = ini.ReadValue(SectionName, "death_translucent", 0);
                            rune.death_translucent = value == 1 ? true : false;
                            rune.random_death_position = ini.ReadValue(SectionName, "random_death_position", 0);
                            rune.center_death_image = ini.ReadValue(SectionName, "center_death_image", 0);
                            rune.death_effect = ini.ReadValue(SectionName, "death_effect", 0);
                            rune.death_effect_range = ini.ReadValue(SectionName, "death_effect_range", 0);
                            rune.death_effect_chance = ini.ReadValue(SectionName, "death_effect_chance", 0);
                            rune.death_spell_effect = ini.ReadValue(SectionName, "death_spell_effect", 0);
                            rune.horizontal_spread = ini.ReadValue(SectionName, "horizontal_spread", 0);
                            rune.vertical_spread = ini.ReadValue(SectionName, "vertical_spread", 0);
                            rune.sound = ini.ReadValue(SectionName, "sound", 0);
                            rune.sound_range = ini.ReadValue(SectionName, "sound_range", 0);
                            rune.death_sound = ini.ReadValue(SectionName, "death_sound", 0);
                            rune.death_sound_range = ini.ReadValue(SectionName, "death_sound_range", 0);
                            rune.effect_sound = ini.ReadValue(SectionName, "effect_sound", 0);
                            rune.effect_sound_range = ini.ReadValue(SectionName, "effect_sound_range", 0);
                            rune.death_frame_start = ini.ReadValue(SectionName, "death_frame_start", 0);
                            rune.element = (SpellElementType)ini.ReadValue(SectionName, "element", 0);
                            value = ini.ReadValue(SectionName, "no_team", 0);
                            rune.no_team = value == 1 ? true : false;
                            rune.collision_velocity = ini.ReadValue(SectionName, "collision_velocity", 0);

                            rune.aura_caster_effect = ini.ReadValue(SectionName, "aura_caster_effect", 0);
                            rune.aura_target_effect = ini.ReadValue(SectionName, "aura_target_effect", 0);
                            rune.friendly = (SpellFriendlyType)ini.ReadValue(SectionName, "friendly", 0);
                            rune.aura_pulse_timer = ini.ReadValue(SectionName, "aura_pulse_timer", 0);
                            rune.aura_health = ini.ReadValue(SectionName, "aura_health", 0);
                            value = ini.ReadValue(SectionName, "aura_stackable", 0);
                            rune.aura_stackable = value == 1 ? true : false;

                            runeList.Add(rune);

                            #endregion
                        }
                        else Debug.Log(i + " = " + type);
                    }

                    #endregion

                    ini.Close();
                }










            }

            public static class SYSTEM
            {
                //public static TNet.DataNode ToDataNode(string path)
                //{
                //    System.Collections.Generic.List<Texture> list = Load(path);

                //    TNet.DataNode datanode = new TNet.DataNode("textures");

                //    foreach (Texture texture in list)
                //    {
                //        datanode.SetHierarchy(texture.index.ToString(), texture);
                //    }

                //    return datanode;
                //}

                public static System.Collections.Generic.List<Texture> Load(string path)
                {
                    System.Collections.Generic.List<Texture> list = new System.Collections.Generic.List<Texture>();

                    INIParser inifile = new INIParser();
                    inifile.Open(path);

                    int numtextures = int.Parse(inifile.ReadValue("textures", "numtextures", "0"));

                    for (int i = 1; i <= numtextures; i++)
                    {
                        string section = string.Format("texture{0:00}", i + 100);

                        Texture texture = new Texture();

                        texture.index = i + 100;

                        //public string name = "";
                        texture.wbits = int.Parse(inifile.ReadValue(section, "wbits", "0"));
                        texture.hbits = int.Parse(inifile.ReadValue(section, "hbits", "0"));
                        texture.translucent = int.Parse(inifile.ReadValue(section, "translucent", "0"));
                        texture.sound = int.Parse(inifile.ReadValue(section, "sound", "0"));
                        texture.timer = int.Parse(inifile.ReadValue(section, "timer", "0"));

                        int numframes = int.Parse(inifile.ReadValue(section, "numframes", "0"));
                        texture.numframes = numframes;

                        //public string[] files;
                        //texture.Name00 = inifile.ReadValue(section, "name00", "");
                        //texture.Name01 = inifile.ReadValue(section, "name01", "");
                        //texture.Name02 = inifile.ReadValue(section, "name02", "");
                        //texture.Name03 = inifile.ReadValue(section, "name03", "");
                        //texture.name04 = inifile.ReadValue(section, "name04", "");
                        //texture.name05 = inifile.ReadValue(section, "name05", "");
                        //texture.name06 = inifile.ReadValue(section, "name06", "");
                        //texture.name07 = inifile.ReadValue(section, "name07", "");
                        //texture.name08 = inifile.ReadValue(section, "name08", "");
                        //texture.name09 = inifile.ReadValue(section, "name09", "");

                        texture.color_table = int.Parse(inifile.ReadValue(section, "color_table", "0"));

                        list.Add(texture);
                    }

                    inifile.Close();

                    return list;
                }
            }

            public static class TRIGGER
            {
                //        public static System.Collections.Generic.List<Map.Trigger.Trigger> Load(TextAsset textasset)
                //        {
                //            INIParser inifile = new INIParser();
                //            inifile.Open(textasset);
                //            inifile.Close();

                //            return Loader(inifile);
                //        }

                public static System.Collections.Generic.List<Map.Trigger.Trigger> Load(string path)
                {
                    INIParser inifile = new INIParser();
                    inifile.Open(path);
                    inifile.Close();

                    return Loader(inifile);
                }

                private static System.Collections.Generic.List<Map.Trigger.Trigger> Loader(INIParser inifile)
                {
                    System.Collections.Generic.List<Map.Trigger.Trigger> list = new System.Collections.Generic.List<Map.Trigger.Trigger>();

                    list.Add(new Map.Trigger.Trigger());//0 is blank

                    int numtriggers = inifile.ReadValue("triggerdefs", "numtriggers", 0);

                    //Debug.Log(numtriggers);

                    for (int trigger_index = 1; trigger_index <= numtriggers; trigger_index++)
                    {
                        string section = string.Format("trigger{0:00}", trigger_index);

                        string type = inifile.ReadValue(section, "type", "");

                        if (type == "elevator")
                        {
                            Map.Trigger.Elevator elevator = new Map.Trigger.Elevator();
                            elevator.index = trigger_index;
                            elevator.type = "elevator";

                            elevator.texture_off = inifile.ReadValue(section, "texture_off", 0);
                            elevator.texture_on = inifile.ReadValue(section, "texture_on", 0);
                            elevator.reset_timer = inifile.ReadValue(section, "reset_timer", 0);
                            elevator.enabled = inifile.ReadValue(section, "enabled", false);
                            elevator.initial_state = inifile.ReadValue(section, "initial_state", false);
                            elevator.next_trigger = inifile.ReadValue(section, "next_trigger", 0);

                            elevator.off_height = inifile.ReadValue(section, "off_height", 0);
                            elevator.on_height = inifile.ReadValue(section, "on_height", 0);
                            elevator.x1 = inifile.ReadValue(section, "x1", 0);
                            elevator.y1 = inifile.ReadValue(section, "y1", 0);
                            elevator.x2 = inifile.ReadValue(section, "x2", 0);
                            elevator.y2 = inifile.ReadValue(section, "y2", 0);
                            elevator.speed = inifile.ReadValue(section, "speed", 0);
                            elevator.move_floor = inifile.ReadValue(section, "move_floor", false);
                            elevator.move_ceiling = inifile.ReadValue(section, "move_ceiling", false);
                            elevator.move_roof = inifile.ReadValue(section, "move_roof", false);
                            elevator.move_rooftop = inifile.ReadValue(section, "move_rooftop", false);
                            elevator.on_sound = inifile.ReadValue(section, "on_sound", 0);
                            elevator.off_sound = inifile.ReadValue(section, "off_sound", 0);

                            list.Add(elevator);
                        }
                        else if (type == "door")
                        {
                            Map.Trigger.Door door = new Map.Trigger.Door();

                            door.index = trigger_index;
                            door.type = "door";

                            door.texture_off = inifile.ReadValue(section, "texture_off", 0);
                            door.texture_on = inifile.ReadValue(section, "texture_on", 0);
                            door.reset_timer = inifile.ReadValue(section, "reset_timer", 0);
                            door.enabled = inifile.ReadValue(section, "enabled", false);
                            door.initial_state = inifile.ReadValue(section, "initial_state", false);
                            door.next_trigger = inifile.ReadValue(section, "next_trigger", 0);

                            door.slide_axis = inifile.ReadValue(section, "slide_axis", 0);
                            door.start_angle = inifile.ReadValue(section, "start_angle", 0);
                            door.end_angle = inifile.ReadValue(section, "end_angle", 0);
                            door.max_angle_rate = inifile.ReadValue(section, "max_angle_rate", 0);
                            door.on_sound = inifile.ReadValue(section, "on_sound", 0);
                            door.off_sound = inifile.ReadValue(section, "off_sound", 0);

                            door.slide_amount = inifile.ReadValue(section, "slide_amount", 0);
                            door.max_rate = inifile.ReadValue(section, "max_rate", 0);
                            door.disabled_text = inifile.ReadValue(section, "disabled_text", "");


                            list.Add(door);
                        }
                        else if (type == "teleport")
                        {
                            Map.Trigger.Teleport teleport = new Map.Trigger.Teleport();
                            teleport.index = trigger_index;
                            teleport.type = "teleport";

                            teleport.texture_off = inifile.ReadValue(section, "texture_off", 0);
                            teleport.texture_on = inifile.ReadValue(section, "texture_on", 0);
                            teleport.reset_timer = inifile.ReadValue(section, "reset_timer", 0);
                            teleport.enabled = inifile.ReadValue(section, "enabled", false);
                            teleport.initial_state = inifile.ReadValue(section, "initial_state", false);
                            teleport.next_trigger = inifile.ReadValue(section, "next_trigger", 0);

                            teleport.random = inifile.ReadValue(section, "random", 0);
                            teleport.team = inifile.ReadValue(section, "team", 0);
                            teleport.x0 = inifile.ReadValue(section, "x0", 0);
                            teleport.y0 = inifile.ReadValue(section, "y0", 0);
                            teleport.x1 = inifile.ReadValue(section, "x1", 0);
                            teleport.y1 = inifile.ReadValue(section, "y1", 0);
                            teleport.x2 = inifile.ReadValue(section, "x2", 0);
                            teleport.y2 = inifile.ReadValue(section, "y2", 0);
                            teleport.x3 = inifile.ReadValue(section, "x3", 0);
                            teleport.y3 = inifile.ReadValue(section, "y3", 0);
                            teleport.x4 = inifile.ReadValue(section, "x4", 0);
                            teleport.y4 = inifile.ReadValue(section, "y4", 0);

                            teleport.x5 = inifile.ReadValue(section, "x5", 0);
                            teleport.y5 = inifile.ReadValue(section, "y5", 0);
                            teleport.x6 = inifile.ReadValue(section, "x6", 0);
                            teleport.y6 = inifile.ReadValue(section, "y6", 0);
                            teleport.valhalla = inifile.ReadValue(section, "valhalla", false);

                            teleport.on_sound = inifile.ReadValue(section, "on_sound", 0);

                            list.Add(teleport);
                        }
                        else if (type == "null")
                        {
                            Map.Trigger.Remote remote = new Map.Trigger.Remote();
                            remote.index = trigger_index;
                            remote.type = "remote";

                            remote.texture_off = inifile.ReadValue(section, "texture_off", 0);
                            remote.texture_on = inifile.ReadValue(section, "texture_on", 0);
                            remote.reset_timer = inifile.ReadValue(section, "reset_timer", 0);
                            remote.enabled = inifile.ReadValue(section, "enabled", false);
                            remote.initial_state = inifile.ReadValue(section, "initial_state", false);
                            remote.next_trigger = inifile.ReadValue(section, "next_trigger", 0);

                            remote.next_trigger_timing = inifile.ReadValue(section, "next_trigger_timing", 0);
                            remote.on_text = inifile.ReadValue(section, "on_text", "");
                            remote.off_text = inifile.ReadValue(section, "off_text", "");

                            list.Add(remote);
                        }
                        else Debug.Log("type: " + type);
                    }

                    return list;
                }
            }

            public static class WORLD
            {
                public static Magestorm.Legacy.Map.World.World Load(string path)
                {
                    INIParser inifile = new INIParser();
                    inifile.Open(path);
                    inifile.Close();

                    return Loader(inifile);
                }

                //        public static World.World Load(UnityEngine.TextAsset textasset)
                //        {
                //            INIParser inifile = new INIParser();
                //            inifile.Open(textasset);
                //            inifile.Close();

                //            return Loader(inifile);
                //        }

                private static Map.World.World Loader(INIParser inifile)
                {
                    Map.World.World world = new Map.World.World();

                    #region Monster Def's

                    int nummongens = int.Parse(inifile.ReadValue("mongendefs", "nummongens", "0"));

                    for (int i = 0; i < nummongens; i++)
                    {
                        Map.World.MonsterDef m = new Map.World.MonsterDef();

                        m.obj = int.Parse(inifile.ReadValue(string.Format("mongen{0:00}", i), "object", "0").Trim());
                        m.maxnum = int.Parse(inifile.ReadValue(string.Format("mongen{0:00}", i), "maxnum", "0").Trim());
                        m.chance = int.Parse(inifile.ReadValue(string.Format("mongen{0:00}", i), "chance", "0").Trim());
                        m.timer = int.Parse(inifile.ReadValue(string.Format("mongen{0:00}", i), "timer", "0").Trim());
                        m.xmaze = int.Parse(inifile.ReadValue(string.Format("mongen{0:00}", i), "xmaze", "0").Trim());
                        m.ymaze = int.Parse(inifile.ReadValue(string.Format("mongen{0:00}", i), "ymaze", "0").Trim());
                        m.single = int.Parse(inifile.ReadValue(string.Format("mongen{0:00}", i), "single", "0").Trim());

                        world.List_Monsters.Add(m);
                    }

                    #endregion

                    #region Team Def's

                    foreach (TeamType team in System.Enum.GetValues(typeof(TeamType)))
                    {
                        string section = team.ToString().ToLower();

                        if (team == TeamType.Neutral)
                        {
                            section = "noteam";
                        }

                        string startx = inifile.ReadValue(section, "startx", "0").Trim();
                        string starty = inifile.ReadValue(section, "starty", "0").Trim();
                        string starta = inifile.ReadValue(section, "starta", "0").Trim();
                        string raisex = inifile.ReadValue(section, "raisex", "0").Trim();
                        string raisey = inifile.ReadValue(section, "raisey", "0").Trim();
                        string raisea = inifile.ReadValue(section, "raisea", "0").Trim();

                        if (!string.IsNullOrEmpty(startx))
                        {
                            Map.World.TeamDef portloc = new Map.World.TeamDef();

                            portloc.team = team;

                            if (!string.IsNullOrEmpty(startx)) portloc.startx = int.Parse(startx);
                            if (!string.IsNullOrEmpty(starty)) portloc.starty = int.Parse(starty);
                            if (!string.IsNullOrEmpty(starta)) portloc.starta = int.Parse(starta);

                            if (!string.IsNullOrEmpty(raisex)) portloc.raisex = int.Parse(raisex);
                            if (!string.IsNullOrEmpty(raisey)) portloc.raisey = int.Parse(raisey);
                            if (!string.IsNullOrEmpty(raisea)) portloc.raisea = int.Parse(raisea);

                            world.List_Teams.Add(portloc);
                        }
                    }

                    #endregion

                    #region Light

                    world.light_ambient = int.Parse(inifile.ReadValue("light", "ambient", "0").Trim());
                    world.light_outdoor = int.Parse(inifile.ReadValue("light", "outdoor", "0").Trim());
                    world.light_intensity = int.Parse(inifile.ReadValue("light", "intensity", "0").Trim());

                    #endregion

                    #region Pool Def's

                    int numearthblood = int.Parse(inifile.ReadValue("earthblooddefs", "numearthblood", "0"));

                    for (int i = 0; i < numearthblood; i++)
                    {
                        Map.World.PoolDef p = new Map.World.PoolDef();

                        p.power = int.Parse(inifile.ReadValue(string.Format("earthblood{0:00}", i), "power", "0").Trim());
                        p.neutraltexture = int.Parse(inifile.ReadValue(string.Format("earthblood{0:00}", i), "neutraltexture", "1").Trim());
                        p.ordertexture = int.Parse(inifile.ReadValue(string.Format("earthblood{0:00}", i), "ordertexture", "1").Trim());
                        p.chaostexture = int.Parse(inifile.ReadValue(string.Format("earthblood{0:00}", i), "chaostexture", "1").Trim());
                        p.balancetexture = int.Parse(inifile.ReadValue(string.Format("earthblood{0:00}", i), "balancetexture", "1").Trim());

                        world.List_Pools.Add(p);
                    }

                    #endregion

                    #region Shrine Def's

                    int numshrines = int.Parse(inifile.ReadValue("shrinedefs", "numshrines", "0"));

                    for (int i = 0; i < numshrines; i++)
                    {
                        Map.World.ShrineDef s = new Map.World.ShrineDef();

                        s.power = int.Parse(inifile.ReadValue(string.Format("shrine{0:00}", i), "power", "100").Trim());
                        string alignment = inifile.ReadValue(string.Format("shrine{0:00}", i), "alignment", "neutral").Trim();

                        if (alignment == "balance") s.alignment = TeamType.Balance;
                        else if (alignment == "chaos") s.alignment = TeamType.Chaos;
                        else if (alignment == "order") s.alignment = TeamType.Order;

                        s.bias = int.Parse(inifile.ReadValue(string.Format("shrine{0:00}", i), "bias", "100").Trim());

                        world.List_Shrines.Add(s);
                    }

                    #endregion

                    #region Map

                    world.map_y_pos = int.Parse(inifile.ReadValue("map", "map_y_pos", "0").Trim());
                    world.map_x_pos = int.Parse(inifile.ReadValue("map", "map_x_pos", "0").Trim());
                    world.map_y_offset = int.Parse(inifile.ReadValue("map", "map_y_offset", "0").Trim());
                    world.map_x_offset = int.Parse(inifile.ReadValue("map", "map_x_offset", "0").Trim());

                    #endregion

                    return world;
                }

                //        public static void Save(string path, World.World world)
                //        {
                //            System.Collections.Generic.List<string> lines = new System.Collections.Generic.List<string>();

                //            lines.Add(";");
                //            lines.Add(";");
                //            lines.Add(";           mapname");
                //            lines.Add(";");
                //            lines.Add(";");

                //            lines.Add("");

                //            lines.Add(";=========================================================================");
                //            lines.Add("; Monster Generators");
                //            lines.Add(";=========================================================================");
                //            lines.Add("[mongendefs]");
                //            lines.Add("nummongens=" + world.List_Monsters.Count);

                //            lines.Add("");

                //            int index = 0;

                //            foreach (World.MonsterDef def in world.List_Monsters)
                //            {
                //                lines.Add(string.Format("[mongen{0:00}]", index));
                //                lines.Add("object=" + def.obj);
                //                lines.Add("maxnum=" + def.maxnum);
                //                lines.Add("chance=" + def.chance);
                //                lines.Add("timer=" + def.timer);
                //                lines.Add("xmaze=" + def.xmaze);
                //                lines.Add("ymaze=" + def.ymaze);
                //                lines.Add("single=" + def.single);

                //                lines.Add("");

                //                index += 1;
                //            }

                //            lines.Add(";=========================================================================");
                //            lines.Add("; Teams");
                //            lines.Add(";=========================================================================");

                //            foreach (World.TeamDef def in world.List_Teams)
                //            {
                //                string team = def.team.ToString().ToLower();
                //                if (def.team == TeamType.Neutral) team = "noteam";

                //                lines.Add(string.Format("[{0}]", team));

                //                lines.Add("startx=" + def.startx);
                //                lines.Add("starty=" + def.starty);
                //                lines.Add("starta=" + def.starta);

                //                lines.Add("raisex=" + def.raisex);
                //                lines.Add("raisey=" + def.raisey);
                //                lines.Add("raisea=" + def.raisea);

                //                lines.Add("");
                //            }

                //            lines.Add(";=========================================================================");
                //            lines.Add("; Light");
                //            lines.Add(";=========================================================================");
                //            lines.Add("[light]");
                //            lines.Add("ambient=" + world.light_ambient);
                //            lines.Add("outdoor=" + world.light_outdoor);
                //            lines.Add("intensity=" + world.light_intensity);

                //            lines.Add("");

                //            lines.Add(";=========================================================================");
                //            lines.Add("; Earthblood Pools");
                //            lines.Add(";=========================================================================");
                //            lines.Add("[earthblooddefs]");
                //            lines.Add("numearthblood=" + world.List_Pools.Count);

                //            lines.Add("");

                //            index = 0;

                //            foreach (World.PoolDef def in world.List_Pools)
                //            {
                //                lines.Add(string.Format("[earthblood{0:00}]", index));
                //                lines.Add("power=" + def.power);
                //                lines.Add("neutraltexture=" + def.neutraltexture);
                //                lines.Add("ordertexture=" + def.ordertexture);
                //                lines.Add("chaostexture=" + def.chaostexture);
                //                lines.Add("balancetexture=" + def.balancetexture);

                //                lines.Add("");

                //                index += 1;
                //            }

                //            lines.Add(";=========================================================================");
                //            lines.Add("; Shrines");
                //            lines.Add(";=========================================================================");
                //            lines.Add("[shrinedefs]");
                //            lines.Add("numshrines=" + world.List_Shrines.Count);

                //            lines.Add("");

                //            index = 0;

                //            foreach (World.ShrineDef def in world.List_Shrines)
                //            {
                //                lines.Add(string.Format("[shrine{0:00}]", index));
                //                lines.Add("power=" + def.power);
                //                lines.Add("alignment=" + def.alignment.ToString().ToLower());
                //                lines.Add("bias=" + def.bias);

                //                lines.Add("");

                //                index += 1;
                //            }

                //            lines.Add(";=========================================================================");
                //            lines.Add("; Map");
                //            lines.Add(";=========================================================================");
                //            lines.Add("[map]");
                //            lines.Add("map_y_pos=" + world.map_y_pos);
                //            lines.Add("map_x_pos=" + world.map_x_pos);
                //            lines.Add("map_y_offset=" + world.map_y_offset);
                //            lines.Add("map_x_offset=" + world.map_x_offset);

                //            System.IO.File.WriteAllLines(path, lines.ToArray());
                //        }
            }

            private static char[] GetChar(int size, string target)
            {
                if (target.Length > 20)
                {
                    target = target.Substring(0, 20);
                }

                char[] arr = new Char[size];


                for (int ii = 0; ii < size; ii++)
                {
                    arr[ii] = (char)32;
                }

                for (int ii = 0; ii < target.Length; ii++)
                {
                    arr[ii] = (char)target[ii];
                }

                return arr;
            }
        }
    }
}