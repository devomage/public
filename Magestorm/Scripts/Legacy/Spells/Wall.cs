namespace Magestorm.Legacy.Spells
{
    [System.Serializable]
    public class Wall : Spell
    {
        public Wall()
        {
            type = SpellType.Wall;
        }

        public Wall(Spell spell)
        {
            type = spell.type;
            name = spell.name;
            fatigue = spell.fatigue;
            min_fatigue = spell.min_fatigue;
            cast_sound = spell.cast_sound;
            empty_sound = spell.empty_sound;

            index = spell.index;
            spell_icon = spell.spell_icon;
        }

        public int texturenum;
        public int length;
        public int wallheight;
        public int max_wallheight;
        public bool transparent;
        public TransColor trans_color;
        public int duration_timer;
        public int thick;
        public int cast_distance;
        public bool hug_floor;
        public int min_damage;
        public int max_damage;
        public int min_power_drain;
        public int max_power_drain;
        public int collision_velocity;
        public SpellElementType element;
        public int hit_points;
        public SpellFriendlyType friendly;

        public bool TileVertical = true;

        public bool CanDamage
        {
            get
            {
                return max_damage > 0 || max_power_drain > 0;
            }
        }
    }
}