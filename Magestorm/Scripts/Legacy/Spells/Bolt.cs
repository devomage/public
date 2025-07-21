namespace Magestorm.Legacy.Spells
{
    [System.Serializable]
    public class Bolt : Spell
    {
        public Bolt()
        {
            type = SpellType.Bolt;
        }

        public Bolt(Spell spell)
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

        public int imagenum;
        public int death_imagenum;
        public int death_imagenum_chance;
        public int effect_imagenum;
        public int leading_edge_imagenum;
        public int width;
        public int tall;
        public int image_timer_max;
        public int death_image_timer_max;
        public int effect_image_timer_max;
        public bool gravity;

        public int duration_timer;
        public TransColor trans_color;
        public TransColor death_trans_color;
        public TransColor effect_trans_color;
        public int effect_radius;
        public int min_damage;
        public int max_damage;
        public int damage_dice;
        public int damage_num_dice;
        public int damage_base;
        public int min_power_drain;
        public int max_power_drain;
        public int num_objects;
        public int object_spacing;
        public int object_layout;
        public int cast_distance;
        public int elevation;
        public bool translucent;
        public bool death_translucent;
        public bool effect_translucent;
        public int range;
        public int max_timer;
        public int death_effect;
        public int death_effect_range;
        public int death_effect_chance;
        public int death_spell_effect;
        public int creation_effect;
        public int bolt_death_effect;
        public int bolt_death_effect_range;
        public int bolt_death_effect_chance;
        public int effect_sound;
        public int effect_sound_range;
        public SpellElementType element;

        public SpellFriendlyType friendly;
        public bool hug_floor;
        public int light_pattern;
        public int max_flicker;
        public int light_glow;
        public int sticky_light;
        public int skill_used;
        public bool CanDamage
        {
            get
            {
                return damage_base > 0 || (damage_num_dice > 0 && damage_dice > 0) || max_damage > 0 || max_power_drain > 0;
            }
        }
    }
}