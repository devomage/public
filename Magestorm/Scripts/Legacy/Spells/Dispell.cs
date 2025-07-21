namespace Magestorm.Legacy.Spells
{
    [System.Serializable]
    public class Dispell : Spell
    {
        public Dispell()
        {
            type = SpellType.Dispell;
        }

        public Dispell(Spell spell)
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

        public int dispell_type;
        public int range;
        public int level;
        public int effect_sound;
        public int effect_sound_range;
    }
}