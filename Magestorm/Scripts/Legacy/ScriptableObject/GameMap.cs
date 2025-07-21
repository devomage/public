namespace Magestorm.Legacy
{
    using Magestorm.Legacy.Map.Trigger;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    [CreateAssetMenu(fileName = "GameMap", menuName = "ScriptableObjects/GameMap", order = 2)]
    public class GameMap : ScriptableObject
    {
        public int m_Index = 0;

        public System.Collections.Generic.List<Magestorm.Legacy.Map.Block> List_Blocks;
        public System.Collections.Generic.List<Magestorm.Legacy.Map.ObjectLocation> List_ObjectLocations;
        public System.Collections.Generic.List<Magestorm.Legacy.Map.Object> List_Objects;
        public System.Collections.Generic.List<Magestorm.Legacy.Map.Texture> List_MapTextures;
        public System.Collections.Generic.List<Magestorm.Legacy.Map.Thin> List_Thins;
        public System.Collections.Generic.List<Magestorm.Legacy.Map.Tile> List_Tiles;
        public System.Collections.Generic.List<Magestorm.Legacy.Map.Trigger.Trigger> List_Triggers;
        public Magestorm.Legacy.Map.World.World m_World;
        public System.Collections.Generic.List<DeletedBlock> List_DeletedBlocks = new System.Collections.Generic.List<DeletedBlock>();

        [System.Serializable]
        public class DeletedBlock
        {
            public int x;
            public int z;
            public string blockname;
        }

        public void LoadBlocks()
        {
            //List_Blocks.Clear();

            //TextAsset textasset = Resources.Load<TextAsset>($"Legacy/Data/GRIDS/GRID{m_Index:00}/Blocks") as TextAsset;
            //DataNode file = DataNode.Read(textasset.bytes);

            //foreach (DataNode data in file.children)
            //{
            //    List_Blocks.Add(data.ToMapBlock());
            //}
        }

        internal Teleport GetTriggerTeleport(int index)
        {
            var v = List_Triggers.FirstOrDefault(i => i.index == index);
            if (v == null) return null;

            return (Teleport)v;
        }


        //var m_Index = 0;
        //var sourcePath = $"{devPath}/GRIDS/GRID{m_Index:00}";

        //var List_Blocks = Magestorm.Legacy.DatUtility.DAT.GRID.Load_Blocks($"{sourcePath}/Grid.dat");
        //var List_ObjectLocations = Magestorm.Legacy.DatUtility.DAT.GRID.Load_ObjectLocations($"{sourcePath}/Grid.dat");
        //var List_Objects = Magestorm.Legacy.DatUtility.DAT.OBJECTS.Load($"{sourcePath}/Objects.dat");
        //var List_MapTextures = Magestorm.Legacy.DatUtility.DAT.MISC.Load_Textures($"{sourcePath}/Misc.dat");
        //var List_Thins = Magestorm.Legacy.DatUtility.DAT.MISC.Load_Thins($"{sourcePath}/Misc.dat");
        //var List_Tiles = Magestorm.Legacy.DatUtility.DAT.MISC.Load_Tiles($"{sourcePath}/Misc.dat");
        //var List_Triggers = Magestorm.Legacy.DatUtility.DAT.TRIGGER.Load($"{sourcePath}/Trigger.dat");
        //var m_World = Magestorm.Legacy.DatUtility.DAT.WORLD.Load($"{sourcePath}/World.dat");
    }
}