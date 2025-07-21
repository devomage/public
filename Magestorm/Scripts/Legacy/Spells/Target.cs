namespace Magestorm.Legacy.Spells
{
    [System.Serializable]
    public class Target : Spell
    {
        public Target()
        {
            type = SpellType.Target;
        }

        public Target(Spell spell)
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

        public int min_damage;
        public int max_damage;
        public int damage_dice;
        public int damage_num_dice;
        public int damage_base;
        public int min_power_drain;
        public int max_power_drain;
        public int range;
        public int caster_spell_effect;
        public int target_spell_effect;
        public int effect_sound;
        public int effect_sound_range;
        public int miss_sound;
        public SpellElementType element;
        public SpellFriendlyType friendly;
        public bool group;

        public bool CanDamage
        {
            get
            {
                return damage_base > 0 || (damage_num_dice > 0 && damage_dice > 0) || max_damage > 0 || max_power_drain > 0;
            }
        }
    }
}