namespace Magestorm.Legacy.Spells
{
    [System.Serializable]
    public class Teleport : Spell
    {
        public Teleport()
        {
            type = SpellType.Teleport;
        }

        public Teleport(Spell spell)
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

        public int teleport_type = 0;//Call Dead = 0, Teleport Test = 1, Call Dead = 2
        public int caster_spell_effect = 0;
    }
}