namespace Magestorm.Legacy.Spells
{
    [System.Serializable]
    public class Healing : Spell
    {
        public Healing()
        {
            type = SpellType.Healing;
        }

        public Healing(Spell spell)
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

        public int min = 0;
        public int max = 0;
    }
}