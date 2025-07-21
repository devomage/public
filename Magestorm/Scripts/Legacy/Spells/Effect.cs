namespace Magestorm.Legacy.Spells
{
    [System.Serializable]
    public class Effect : Spell
    {
        public Effect()
        {
            type = SpellType.Effect;
        }

        public Effect(Spell spell)
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

        public SpellEffectType effect;
        public SpellDurationType duration_type;
        public int duration;
        public int level;
        public SpellElementType element;
        public int imagenum;
        public int image_timer;
        public int overlay_imagenum;
        public int overlay_image_timer;
        public int overlay_duration;
        public SpellOverlayDurationType overlay_dur_type;
        public int overlay_height;
        public int overlay_opaque;
        public int overlay_glow;
        public TransColor overlay_trans_color;

    }
}