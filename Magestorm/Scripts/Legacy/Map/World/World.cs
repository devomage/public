namespace Magestorm.Legacy.Map.World
{
    [System.Serializable]
    public class World
    {
        public System.Collections.Generic.List<MonsterDef> List_Monsters = new System.Collections.Generic.List<MonsterDef>();
        public System.Collections.Generic.List<TeamDef> List_Teams = new System.Collections.Generic.List<TeamDef>();

        //light
        public int light_ambient;
        public int light_outdoor;
        public int light_intensity;

        public System.Collections.Generic.List<PoolDef> List_Pools = new System.Collections.Generic.List<PoolDef>();
        public System.Collections.Generic.List<ShrineDef> List_Shrines = new System.Collections.Generic.List<ShrineDef>();

        //mini-map
        public int map_y_pos;
        public int map_x_pos;
        public int map_y_offset;
        public int map_x_offset;

        //public System.Collections.Generic.List<Legacy_MapBlock> List_Blocks = new System.Collections.Generic.List<Legacy_MapBlock>();
        //public System.Collections.Generic.List<Legacy_MapObjectLocation> List_ObjectLocations = new System.Collections.Generic.List<Legacy_MapObjectLocation>();
        //public System.Collections.Generic.List<Legacy_MapTexture> List_MapTextures = new System.Collections.Generic.List<Legacy_MapTexture>();
        //public System.Collections.Generic.List<Legacy_MapThin> List_Thins = new System.Collections.Generic.List<Legacy_MapThin>();
        //public System.Collections.Generic.List<Legacy_MapTile> List_Tiles = new System.Collections.Generic.List<Legacy_MapTile>();
        //public System.Collections.Generic.List<Legacy_MapObject> List_Objects = new System.Collections.Generic.List<Legacy_MapObject>();
        //public System.Collections.Generic.List<Legacy_MapTrigger> List_Triggers = new System.Collections.Generic.List<Legacy_MapTrigger>();

    }
}