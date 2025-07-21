namespace Magestorm.Legacy.Spells
{
    [System.Serializable]
    public class Projectile : Spell
    {
        public Projectile()
        {
            type = SpellType.Projectile;
        }

        public Projectile(Spell spell)
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
        public int width;
        public int tall;
        public int image_timer_max;
        public int death_image_timer_max;
        public bool gravity;
        public int light_pattern;
        public int max_flicker;
        public int light_glow;
        public int sticky_light;
        public int duration_timer;
        public TransColor trans_color;
        public TransColor death_trans_color;
        public int effect_radius;
        public int miss_sound;
        public int min_damage;
        public int max_damage;
        public int damage_dice;
        public int damage_num_dice;
        public int damage_base;
        public int min_power_drain;
        public int max_power_drain;
        public int velocity;
        public int z_velocity;
        public int cast_angle;
        public int num_projectiles;
        public int projectile_spacing;
        public SpellProjectileType side_by_side;
        public int cast_distance;
        public int elevation;
        public int max_step;
        public bool translucent;
        public bool alignment_translucent;
        public bool death_translucent;
        public int random_death_position;
        public int center_death_image;
        public int death_effect;
        public int death_effect_range;
        public int death_effect_chance;
        public int death_spell_effect;
        public int creation_effect;//not used
        public int horizontal_spread;
        public int vertical_spread;
        public int sound;
        public int sound_range;
        public int death_sound_range;
        public int effect_sound_range;
        public int death_sound;
        public int effect_sound;
        public int death_frame_start;
        public SpellElementType element;
        public bool no_team;
        public int skill_used;
        public int bounce;

        public bool damage_by_distance_traveled;
        public bool area_effect_spell;
        public SpellFriendlyType friendly;
        public bool ethereal;
        
        public bool CanDamage
        {
            get
            {
                return damage_base > 0 || (damage_num_dice > 0 && damage_dice > 0) || max_damage > 0 || max_power_drain > 0;
            }
        }
    }
}