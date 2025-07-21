namespace Magestorm.Legacy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    [CreateAssetMenu(fileName = "Game", menuName = "ScriptableObjects/Game", order = 1)]
    public class Game : ScriptableObject
    {
        public System.Collections.Generic.List<Magestorm.Legacy.Arena> ArenaList = new System.Collections.Generic.List<Magestorm.Legacy.Arena>();
        public System.Collections.Generic.List<Magestorm.Legacy.Image> ImageList = new System.Collections.Generic.List<Magestorm.Legacy.Image>();
        public System.Collections.Generic.List<Magestorm.Legacy.Law> LawList = new System.Collections.Generic.List<Magestorm.Legacy.Law>();
        public System.Collections.Generic.List<ProfessionType> ProfessionList = new System.Collections.Generic.List<ProfessionType>();
        public System.Collections.Generic.Dictionary<string, List<int>> LawListByProfession = new System.Collections.Generic.Dictionary<string, List<int>>();
        public System.Collections.Generic.List<Magestorm.Legacy.Sound> SoundList = new System.Collections.Generic.List<Magestorm.Legacy.Sound>();
        public System.Collections.Generic.List<Magestorm.Legacy.Spells.Spell> SpellList = new System.Collections.Generic.List<Magestorm.Legacy.Spells.Spell>();
        public System.Collections.Generic.List<Magestorm.Legacy.Texture> TextureList = new System.Collections.Generic.List<Magestorm.Legacy.Texture>();

        internal Magestorm.Legacy.Sound GetSound(int index)
        {
            return SoundList.FirstOrDefault(i => i.index == index);
        }
    }
}