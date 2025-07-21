namespace Magestorm.Legacy.Spells
{
    #region spells

    public enum SpellType
    {
        None,
        Projectile,
        Wall,
        Healing,
        Effect,
        Special,
        Bolt,
        Target,
        Dispell,
        Teleport,
        Rune,
    }
    public enum SpellProjectileType
    {
        Tandem,
        HorizontalLine,
        VerticalLine,
        Spiral,
        DoubleRow,
    }
    public enum SpellElementType
    {
        None,
        Fire,
        Cold,
        Light,
        Void,
        Holy,
        Earth,
        Nature,
        Air,
        Mana,
    }
    public enum SpellFriendlyType
    {
        NonFriendly,
        Friendly,
        FriendlyDead,
    }
    public enum SpellEffectType
    {
        None,
        Presence,
        Light,
        Bless,
        Resist,
        Bleed,
        Prayer,
        Leaping,
        Levitate,
        Deserter,
        Fly,
        Hinder,
        Insta_Pool,
        Insta_Shrine,
        Resurrect,
        Healing,
        Speed,
        HealingReduction,
        Ley_Lock,
        TargetResist,
        Expulse,
        DamageOverTime,
    }
    public enum SpellDurationType
    {
        Timer = 0,
        Trigger = 1,
    }
    public enum SpellOverlayDurationType
    {
        None = 0,
        Single = 1,
        Repeat = 2,
    }

    #endregion

    [System.Serializable]
    public class Spell
    {
        public SpellType type = SpellType.None;
        public string name;
        public int fatigue = 100;
        public int min_fatigue = 10;
        //public int power = 0;
        //public int num_cast_sounds = 0;
        public int cast_sound;
        //public int cast_sound_2 = 0;
        //public int cast_sound_3 = 0;
        //public int cast_sound_4 = 0;
        public int empty_sound;
        //public int switch_sound = 0;
        //public int fire_timer = 0;
        //public int overlay = 0;

        //additions/changes
        public int index;
        public int spell_icon = 0;


        //internal static int GetMinLevel(int lawindex)
        //{
        //    for (int level = 1; level < 50; level++)
        //    {
        //        int spellid = Laws[lawindex].level[level];

        //        if (spellid > 0) return level;
        //    }

        //    return 1;
        //}

        //public static int GetMaxLevel(int lawindex)
        //{
        //    int maxlevel = 0;

        //    for (int level = 1; level < 50; level++)
        //    {
        //        int spellid = Laws[lawindex].level[level];

        //        if (spellid > 0 && level > maxlevel) maxlevel = level;
        //    }

        //    return maxlevel;
        //}

        //public static void Load(UnityEngine.TextAsset textasset)
        //{
        //    //UnityEngine.Debug.Log("WEPP_Spell.Load()");
        //    //,
        //    //out System.Collections.Generic.List<WEPP_Spell> list,
        //    //out System.Collections.Generic.List<WEPP_SpellLaw> Laws,
        //    //out System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<int>> Professions

        //    Spells = new System.Collections.Generic.List<MSSpell>();
        //    Laws = new System.Collections.Generic.List<MSSpell_Law>();
        //    Professions = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<int>>();
        //    //Descs = new System.Collections.Generic.List<string>();

        //    INIParser ini = new INIParser();
        //    ini.Open(textasset);

        //    #region Spells

        //    Spells.Clear();

        //    MSSpell defaultspell = new MSSpell();
        //    defaultspell.type = SpellType.None;
        //    defaultspell.name = "Default Spell";
        //    defaultspell.fatigue = 100;
        //    defaultspell.min_fatigue = 10;
        //    //spell.power = 100;
        //    //spell.num_cast_sounds = 0;
        //    defaultspell.cast_sound = 0;
        //    //spell.cast_sound_2 = 0;
        //    //spell.cast_sound_3 = 0;
        //    //spell.cast_sound_4 = 0;
        //    defaultspell.empty_sound = 0;
        //    //spell.switch_sound = 0;
        //    //spell.fire_timer = 0;
        //    //spell.overlay = 0;

        //    defaultspell.index = 0;
        //    defaultspell.spell_icon = 0;

        //    Spells.Add(defaultspell);

        //    int numspells = ini.ReadValue("spelldefs", "numspells", 0);

        //    for (int i = 1; i < numspells; i++)
        //    {
        //        string SectionName = string.Format("spell{0:00}", i);












        //        string type = ini.ReadValue(SectionName, "type", "");

        //        MSSpell spell = new MSSpell();

        //        spell.name = ini.ReadValue(SectionName, "name", "");
        //        spell.fatigue = ini.ReadValue(SectionName, "fatigue", 0);
        //        spell.min_fatigue = ini.ReadValue(SectionName, "min_fatigue", 0);
        //        spell.cast_sound = ini.ReadValue(SectionName, "cast_sound", 0);
        //        spell.empty_sound = ini.ReadValue(SectionName, "empty_sound", 0);

        //        spell.index = i;
        //        spell.spell_icon = ini.ReadValue(SectionName, "icon", 0); ;

        //        if (type == "projectile")
        //        {
        //            #region projectile

        //            spell.type = SpellType.Projectile;

        //            MSSpell_Projectile projectile = new MSSpell_Projectile(spell);

        //            projectile.imagenum = ini.ReadValue(SectionName, "imagenum", 0);
        //            projectile.death_imagenum = ini.ReadValue(SectionName, "death_imagenum", 0);
        //            projectile.width = ini.ReadValue(SectionName, "width", 0);
        //            projectile.tall = ini.ReadValue(SectionName, "tall", 0);
        //            projectile.image_timer_max = ini.ReadValue(SectionName, "image_timer_max", 0);
        //            projectile.death_image_timer_max = ini.ReadValue(SectionName, "death_image_timer_max", 0);
        //            int value = ini.ReadValue(SectionName, "gravity", 0);
        //            projectile.gravity = value == 1 ? true : false;
        //            //projectile.light_pattern = ini.ReadValue(SectionName, "light_pattern", 0);
        //            //projectile.max_flicker = ini.ReadValue(SectionName, "max_flicker", 0);
        //            //projectile.light_glow = ini.ReadValue(SectionName, "light_glow", 0);
        //            //projectile.sticky_light = ini.ReadValue(SectionName, "sticky_light", 0);
        //            projectile.duration_timer = ini.ReadValue(SectionName, "duration_timer", 0);
        //            projectile.trans_color = (SpellTransColor)ini.ReadValue(SectionName, "trans_color", 0);
        //            projectile.death_trans_color = (SpellTransColor)ini.ReadValue(SectionName, "death_trans_color", 0);
        //            projectile.effect_radius = ini.ReadValue(SectionName, "effect_radius", 0);
        //            projectile.miss_sound = ini.ReadValue(SectionName, "miss_sound", 0);
        //            projectile.min_damage = ini.ReadValue(SectionName, "min_damage", 0);
        //            projectile.max_damage = ini.ReadValue(SectionName, "max_damage", 0);
        //            projectile.damage_dice = ini.ReadValue(SectionName, "damage_dice", 0);
        //            projectile.damage_num_dice = ini.ReadValue(SectionName, "damage_num_dice", 0);
        //            projectile.damage_base = ini.ReadValue(SectionName, "damage_base", 0);
        //            projectile.min_power_drain = ini.ReadValue(SectionName, "min_power_drain", 0);
        //            projectile.max_power_drain = ini.ReadValue(SectionName, "max_power_drain", 0);
        //            projectile.velocity = ini.ReadValue(SectionName, "velocity", 0);
        //            projectile.z_velocity = ini.ReadValue(SectionName, "z_velocity", 0);
        //            projectile.cast_angle = ini.ReadValue(SectionName, "cast_angle", 0);
        //            projectile.num_projectiles = ini.ReadValue(SectionName, "num_projectiles", 0);
        //            projectile.projectile_spacing = ini.ReadValue(SectionName, "projectile_spacing", 0);
        //            projectile.side_by_side = (SpellProjectileType)ini.ReadValue(SectionName, "side_by_side", 0);
        //            projectile.cast_distance = ini.ReadValue(SectionName, "cast_distance", 0);
        //            projectile.elevation = ini.ReadValue(SectionName, "elevation", 0);
        //            projectile.max_step = ini.ReadValue(SectionName, "max_step", 0);
        //            value = ini.ReadValue(SectionName, "translucent", 0);
        //            projectile.translucent = value == 1 ? true : false;
        //            value = ini.ReadValue(SectionName, "alignment_translucent", 0);
        //            projectile.alignment_translucent = value == 1 ? true : false;
        //            value = ini.ReadValue(SectionName, "death_translucent", 0);
        //            projectile.death_translucent = value == 1 ? true : false;
        //            projectile.random_death_position = ini.ReadValue(SectionName, "random_death_position", 0);
        //            projectile.center_death_image = ini.ReadValue(SectionName, "center_death_image", 0);
        //            projectile.death_effect = ini.ReadValue(SectionName, "death_effect", 0);
        //            projectile.death_effect_range = ini.ReadValue(SectionName, "death_effect_range", 0);
        //            projectile.death_effect_chance = ini.ReadValue(SectionName, "death_effect_chance", 0);
        //            projectile.death_spell_effect = ini.ReadValue(SectionName, "death_spell_effect", 0);
        //            projectile.creation_effect = ini.ReadValue(SectionName, "creation_effect", 0);
        //            projectile.horizontal_spread = ini.ReadValue(SectionName, "horizontal_spread", 0);
        //            projectile.vertical_spread = ini.ReadValue(SectionName, "vertical_spread", 0);
        //            //projectile.sound = ini.ReadValue(SectionName, "sound", 0);
        //            //projectile.sound_range = ini.ReadValue(SectionName, "sound_range", 0);
        //            projectile.death_sound_range = ini.ReadValue(SectionName, "death_sound_range", 0);
        //            projectile.effect_sound_range = ini.ReadValue(SectionName, "effect_sound_range", 0);
        //            projectile.death_sound = ini.ReadValue(SectionName, "death_sound", 0);
        //            projectile.effect_sound = ini.ReadValue(SectionName, "effect_sound", 0);
        //            projectile.death_frame_start = ini.ReadValue(SectionName, "death_frame_start", 0);
        //            projectile.element = (SpellElementType)ini.ReadValue(SectionName, "element", 0);
        //            value = ini.ReadValue(SectionName, "no_team", 0);
        //            projectile.no_team = value == 1 ? true : false;
        //            //projectile.skill_used = ini.ReadValue(SectionName, "skill_used", 0);
        //            projectile.bounce = ini.ReadValue(SectionName, "bounce", 0);
        //            value = ini.ReadValue(SectionName, "damage_by_distance_traveled", 0);
        //            projectile.damage_by_distance_traveled = value == 1 ? true : false;
        //            value = ini.ReadValue(SectionName, "area_effect_spell", 0);
        //            projectile.area_effect_spell = value == 1 ? true : false;
        //            projectile.friendly = (SpellFriendlyType)ini.ReadValue(SectionName, "friendly", 0);
        //            value = ini.ReadValue(SectionName, "ethereal", 0);
        //            projectile.ethereal = value == 1 ? true : false;

        //            Spells.Add(projectile);

        //            #endregion
        //        }
        //        else if (type == "wall")
        //        {
        //            #region wall

        //            spell.type = SpellType.Wall;

        //            MSSpell_Wall wall = new MSSpell_Wall(spell);

        //            wall.texturenum = ini.ReadValue(SectionName, "texturenum", 0);
        //            wall.length = ini.ReadValue(SectionName, "length", 0);
        //            wall.wallheight = ini.ReadValue(SectionName, "wallheight", 0);
        //            wall.max_wallheight = ini.ReadValue(SectionName, "max_wallheight", 0);
        //            int value = ini.ReadValue(SectionName, "transparent", 0);
        //            wall.transparent = value == 1 ? true : false;
        //            wall.trans_color = (SpellTransColor)ini.ReadValue(SectionName, "trans_color", 0);
        //            wall.duration_timer = ini.ReadValue(SectionName, "duration_timer", 0);
        //            wall.thick = ini.ReadValue(SectionName, "thick", 0);
        //            wall.cast_distance = ini.ReadValue(SectionName, "cast_distance", 0);
        //            value = ini.ReadValue(SectionName, "hug_floor", 0);
        //            wall.hug_floor = value == 1 ? true : false;
        //            wall.min_damage = ini.ReadValue(SectionName, "min_damage", 0);
        //            wall.max_damage = ini.ReadValue(SectionName, "max_damage", 0);
        //            wall.min_power_drain = ini.ReadValue(SectionName, "min_power_drain", 0);
        //            wall.max_power_drain = ini.ReadValue(SectionName, "max_power_drain", 0);
        //            wall.collision_velocity = ini.ReadValue(SectionName, "collision_velocity", 0);
        //            wall.element = (SpellElementType)ini.ReadValue(SectionName, "element", 0);
        //            wall.hit_points = ini.ReadValue(SectionName, "hit_points", 0);
        //            wall.friendly = (SpellFriendlyType)ini.ReadValue(SectionName, "friendly", 0);

        //            Spells.Add(wall);

        //            #endregion
        //        }
        //        else if (type == "healing")
        //        {
        //            #region healing

        //            spell.type = SpellType.Healing;

        //            WEPP_Spell_Healing healing = new WEPP_Spell_Healing(spell);

        //            healing.min = ini.ReadValue(SectionName, "min", 0);
        //            healing.max = ini.ReadValue(SectionName, "max", 0);

        //            Spells.Add(healing);

        //            #endregion
        //        }
        //        else if (type == "effect")
        //        {
        //            #region effect

        //            spell.type = SpellType.Effect;

        //            MSSpell_Effect effect = new MSSpell_Effect(spell);

        //            effect.effect = (SpellEffectType)ini.ReadValue(SectionName, "effect", 0);
        //            effect.duration_type = (SpellDurationType)ini.ReadValue(SectionName, "duration_type", 0);
        //            effect.duration = ini.ReadValue(SectionName, "duration", 0);
        //            effect.level = ini.ReadValue(SectionName, "level", 0);
        //            effect.element = (SpellElementType)ini.ReadValue(SectionName, "element", 0);
        //            effect.imagenum = ini.ReadValue(SectionName, "imagenum", 0);
        //            effect.image_timer = ini.ReadValue(SectionName, "image_timer", 0);
        //            effect.overlay_imagenum = ini.ReadValue(SectionName, "overlay_imagenum", 0);
        //            effect.overlay_image_timer = ini.ReadValue(SectionName, "overlay_image_timer", 0);
        //            effect.overlay_duration = ini.ReadValue(SectionName, "overlay_duration", 0);
        //            effect.overlay_dur_type = (SpellOverlayDurationType)ini.ReadValue(SectionName, "overlay_dur_type", 0);
        //            effect.overlay_height = ini.ReadValue(SectionName, "overlay_height", 0);
        //            effect.overlay_opaque = ini.ReadValue(SectionName, "overlay_opaque", 0);
        //            effect.overlay_glow = ini.ReadValue(SectionName, "overlay_glow", 0);
        //            effect.overlay_trans_color = (SpellTransColor)ini.ReadValue(SectionName, "overlay_trans_color", 0);

        //            Spells.Add(effect);

        //            #endregion
        //        }
        //        else if (type == "special")
        //        {
        //            spell.type = SpellType.Special;
        //        }
        //        else if (type == "bolt")
        //        {
        //            #region bolt

        //            spell.type = SpellType.Bolt;

        //            MSSpell_Bolt bolt = new MSSpell_Bolt(spell);

        //            bolt.imagenum = ini.ReadValue(SectionName, "imagenum", 0);
        //            bolt.death_imagenum = ini.ReadValue(SectionName, "death_imagenum", 0);
        //            bolt.death_imagenum_chance = ini.ReadValue(SectionName, "death_imagenum_chance", 0);
        //            bolt.effect_imagenum = ini.ReadValue(SectionName, "effect_imagenum", 0);
        //            bolt.leading_edge_imagenum = ini.ReadValue(SectionName, "leading_edge_imagenum", 0);
        //            bolt.width = ini.ReadValue(SectionName, "width", 0);
        //            bolt.tall = ini.ReadValue(SectionName, "tall", 0);
        //            bolt.image_timer_max = ini.ReadValue(SectionName, "image_timer_max", 0);
        //            bolt.death_image_timer_max = ini.ReadValue(SectionName, "death_image_timer_max", 0);
        //            bolt.effect_image_timer_max = ini.ReadValue(SectionName, "effect_image_timer_max", 0);
        //            int value = ini.ReadValue(SectionName, "gravity", 0);
        //            bolt.gravity = value == 1 ? true : false;
        //            bolt.duration_timer = ini.ReadValue(SectionName, "duration_timer", 0);
        //            bolt.trans_color = (SpellTransColor)ini.ReadValue(SectionName, "trans_color", 0);
        //            bolt.death_trans_color = (SpellTransColor)ini.ReadValue(SectionName, "death_trans_color", 0);
        //            bolt.effect_trans_color = (SpellTransColor)ini.ReadValue(SectionName, "effect_trans_color", 0);
        //            bolt.effect_radius = ini.ReadValue(SectionName, "effect_radius", 0);
        //            bolt.min_damage = ini.ReadValue(SectionName, "min_damage", 0);
        //            bolt.max_damage = ini.ReadValue(SectionName, "max_damage", 0);
        //            bolt.damage_dice = ini.ReadValue(SectionName, "damage_dice", 0);
        //            bolt.damage_num_dice = ini.ReadValue(SectionName, "damage_num_dice", 0);
        //            bolt.damage_base = ini.ReadValue(SectionName, "damage_base", 0);
        //            bolt.min_power_drain = ini.ReadValue(SectionName, "min_power_drain", 0);
        //            bolt.max_power_drain = ini.ReadValue(SectionName, "max_power_drain", 0);
        //            bolt.num_objects = ini.ReadValue(SectionName, "num_objects", 0);
        //            bolt.object_spacing = ini.ReadValue(SectionName, "object_spacing", 0);
        //            bolt.object_layout = ini.ReadValue(SectionName, "object_layout", 0);
        //            bolt.cast_distance = ini.ReadValue(SectionName, "cast_distance", 0);
        //            bolt.elevation = ini.ReadValue(SectionName, "elevation", 0);
        //            value = ini.ReadValue(SectionName, "translucent", 0);
        //            bolt.translucent = value == 1 ? true : false;
        //            value = ini.ReadValue(SectionName, "death_translucent", 0);
        //            bolt.death_translucent = value == 1 ? true : false;
        //            value = ini.ReadValue(SectionName, "effect_translucent", 0);
        //            bolt.effect_translucent = value == 1 ? true : false;
        //            bolt.range = ini.ReadValue(SectionName, "range", 0);
        //            bolt.max_timer = ini.ReadValue(SectionName, "max_timer", 0);
        //            bolt.death_effect = ini.ReadValue(SectionName, "death_effect", 0);
        //            bolt.death_effect_range = ini.ReadValue(SectionName, "death_effect_range", 0);
        //            bolt.death_effect_chance = ini.ReadValue(SectionName, "death_effect_chance", 0);
        //            bolt.death_spell_effect = ini.ReadValue(SectionName, "death_spell_effect", 0);
        //            bolt.creation_effect = ini.ReadValue(SectionName, "creation_effect", 0);
        //            bolt.bolt_death_effect = ini.ReadValue(SectionName, "bolt_death_effect", 0);
        //            bolt.bolt_death_effect_range = ini.ReadValue(SectionName, "bolt_death_effect_range", 0);
        //            bolt.bolt_death_effect_chance = ini.ReadValue(SectionName, "bolt_death_effect_chance", 0);
        //            bolt.effect_sound = ini.ReadValue(SectionName, "effect_sound", 0);
        //            bolt.effect_sound_range = ini.ReadValue(SectionName, "effect_sound_range", 0);
        //            bolt.element = (SpellElementType)ini.ReadValue(SectionName, "element", 0);

        //            bolt.friendly = (SpellFriendlyType)ini.ReadValue(SectionName, "friendly", 0);
        //            value = ini.ReadValue(SectionName, "hug_floor", 0);
        //            bolt.hug_floor = value == 1 ? true : false;

        //            Spells.Add(bolt);

        //            #endregion
        //        }
        //        else if (type == "target")
        //        {
        //            #region target

        //            spell.type = SpellType.Target;

        //            MSSpell_Target target = new MSSpell_Target(spell);

        //            target.min_damage = ini.ReadValue(SectionName, "min_damage", 0);
        //            target.max_damage = ini.ReadValue(SectionName, "max_damage", 0);
        //            target.damage_dice = ini.ReadValue(SectionName, "damage_dice", 0);
        //            target.damage_num_dice = ini.ReadValue(SectionName, "damage_num_dice", 0);
        //            target.damage_base = ini.ReadValue(SectionName, "damage_base", 0);
        //            target.min_power_drain = ini.ReadValue(SectionName, "min_power_drain", 0);
        //            target.max_power_drain = ini.ReadValue(SectionName, "max_power_drain", 0);
        //            target.range = ini.ReadValue(SectionName, "range", 0);
        //            target.caster_spell_effect = ini.ReadValue(SectionName, "caster_spell_effect", 0);
        //            target.target_spell_effect = ini.ReadValue(SectionName, "target_spell_effect", 0);
        //            target.effect_sound = ini.ReadValue(SectionName, "effect_sound", 0);
        //            target.effect_sound_range = ini.ReadValue(SectionName, "effect_sound_range", 0);
        //            target.miss_sound = ini.ReadValue(SectionName, "miss_sound", 0);
        //            target.element = (SpellElementType)ini.ReadValue(SectionName, "element", 0);
        //            target.friendly = (SpellFriendlyType)ini.ReadValue(SectionName, "friendly", 0);
        //            int value = ini.ReadValue(SectionName, "group", 0);
        //            target.group = value == 1 ? true : false;

        //            Spells.Add(target);

        //            #endregion
        //        }
        //        else if (type == "dispell")
        //        {
        //            #region dispell

        //            spell.type = SpellType.Dispell;

        //            MSSpell_Dispell dispell = new MSSpell_Dispell(spell);

        //            dispell.dispell_type = ini.ReadValue(SectionName, "dispell_type", 0);
        //            dispell.range = ini.ReadValue(SectionName, "range", 0);
        //            dispell.level = ini.ReadValue(SectionName, "level", 0);
        //            dispell.effect_sound = ini.ReadValue(SectionName, "effect_sound", 0);
        //            dispell.effect_sound_range = ini.ReadValue(SectionName, "effect_sound_range", 0);

        //            Spells.Add(dispell);

        //            #endregion
        //        }
        //        else if (type == "teleport")
        //        {
        //            #region teleport

        //            spell.type = SpellType.Teleport;

        //            MSSpell_Teleport teleport = new MSSpell_Teleport(spell);

        //            teleport.teleport_type = ini.ReadValue(SectionName, "teleport_type", 0);
        //            teleport.caster_spell_effect = ini.ReadValue(SectionName, "caster_spell_effect", 0);

        //            Spells.Add(teleport);

        //            #endregion
        //        }
        //        else if (type == "rune")
        //        {
        //            #region rune

        //            spell.type = SpellType.Rune;

        //            MSSpell_Rune rune = new MSSpell_Rune(spell);

        //            rune.imagenum = ini.ReadValue(SectionName, "imagenum", 0);
        //            rune.death_imagenum = ini.ReadValue(SectionName, "death_imagenum", 0);
        //            rune.width = ini.ReadValue(SectionName, "width", 0);
        //            rune.tall = ini.ReadValue(SectionName, "tall", 0);
        //            rune.image_timer_max = ini.ReadValue(SectionName, "image_timer_max", 0);
        //            rune.death_image_timer_max = ini.ReadValue(SectionName, "death_image_timer_max", 0);
        //            int value = ini.ReadValue(SectionName, "gravity", 0);
        //            rune.gravity = value == 1 ? true : false;
        //            rune.duration_timer = ini.ReadValue(SectionName, "duration_timer", 0);
        //            rune.trans_color = (SpellTransColor)ini.ReadValue(SectionName, "trans_color", 0);
        //            rune.effect_radius = ini.ReadValue(SectionName, "effect_radius", 0);
        //            rune.miss_sound = ini.ReadValue(SectionName, "miss_sound", 0);
        //            rune.min_damage = ini.ReadValue(SectionName, "min_damage", 0);
        //            rune.max_damage = ini.ReadValue(SectionName, "max_damage", 0);
        //            rune.damage_dice = ini.ReadValue(SectionName, "damage_dice", 0);
        //            rune.damage_num_dice = ini.ReadValue(SectionName, "damage_num_dice", 0);
        //            rune.damage_base = ini.ReadValue(SectionName, "damage_base", 0);
        //            rune.min_power_drain = ini.ReadValue(SectionName, "min_power_drain", 0);
        //            rune.max_power_drain = ini.ReadValue(SectionName, "max_power_drain", 0);
        //            rune.velocity = ini.ReadValue(SectionName, "velocity", 0);
        //            rune.z_velocity = ini.ReadValue(SectionName, "z_velocity", 0);
        //            rune.cast_angle = ini.ReadValue(SectionName, "cast_angle", 0);
        //            rune.num_projectiles = ini.ReadValue(SectionName, "num_projectiles", 0);
        //            rune.projectile_spacing = ini.ReadValue(SectionName, "projectile_spacing", 0);
        //            rune.side_by_side = (SpellProjectileType)ini.ReadValue(SectionName, "side_by_side", 0);
        //            rune.cast_distance = ini.ReadValue(SectionName, "cast_distance", 0);
        //            rune.elevation = ini.ReadValue(SectionName, "elevation", 0);
        //            rune.max_step = ini.ReadValue(SectionName, "max_step", 0);
        //            value = ini.ReadValue(SectionName, "translucent", 0);
        //            rune.translucent = value == 1 ? true : false;
        //            value = ini.ReadValue(SectionName, "alignment_translucent", 0);
        //            rune.alignment_translucent = value == 1 ? true : false;
        //            value = ini.ReadValue(SectionName, "death_translucent", 0);
        //            rune.death_translucent = value == 1 ? true : false;
        //            rune.random_death_position = ini.ReadValue(SectionName, "random_death_position", 0);
        //            rune.center_death_image = ini.ReadValue(SectionName, "center_death_image", 0);
        //            rune.death_effect = ini.ReadValue(SectionName, "death_effect", 0);
        //            rune.death_effect_range = ini.ReadValue(SectionName, "death_effect_range", 0);
        //            rune.death_effect_chance = ini.ReadValue(SectionName, "death_effect_chance", 0);
        //            rune.death_spell_effect = ini.ReadValue(SectionName, "death_spell_effect", 0);
        //            rune.horizontal_spread = ini.ReadValue(SectionName, "horizontal_spread", 0);
        //            rune.vertical_spread = ini.ReadValue(SectionName, "vertical_spread", 0);

        //            rune.death_sound = ini.ReadValue(SectionName, "death_sound", 0);
        //            rune.death_sound_range = ini.ReadValue(SectionName, "death_sound_range", 0);
        //            rune.effect_sound = ini.ReadValue(SectionName, "effect_sound", 0);
        //            rune.effect_sound_range = ini.ReadValue(SectionName, "effect_sound_range", 0);
        //            rune.death_frame_start = ini.ReadValue(SectionName, "death_frame_start", 0);
        //            rune.element = (SpellElementType)ini.ReadValue(SectionName, "element", 0);
        //            value = ini.ReadValue(SectionName, "no_team", 0);
        //            rune.no_team = value == 1 ? true : false;
        //            rune.collision_velocity = ini.ReadValue(SectionName, "collision_velocity", 0);

        //            rune.aura_caster_effect = ini.ReadValue(SectionName, "aura_caster_effect", 0);
        //            rune.aura_target_effect = ini.ReadValue(SectionName, "aura_target_effect", 0);
        //            rune.friendly = (SpellFriendlyType)ini.ReadValue(SectionName, "friendly", 0);
        //            rune.aura_pulse_timer = ini.ReadValue(SectionName, "aura_pulse_timer", 0);
        //            rune.aura_health = ini.ReadValue(SectionName, "aura_health", 0);
        //            value = ini.ReadValue(SectionName, "aura_stackable", 0);
        //            rune.aura_stackable = value == 1 ? true : false;

        //            Spells.Add(rune);

        //            #endregion
        //        }
        //        else UnityEngine.Debug.Log(i + " = " + type);
        //    }

        //    #endregion

        //    #region Laws

        //    Laws.Clear();

        //    int numlists = ini.ReadValue("listdefs", "numlists", 0);

        //    for (int i = 0; i < numlists; i++)
        //    {
        //        string SectionName = string.Format("spelllist{0:00}", i);

        //        MSSpell_Law law = new MSSpell_Law();
        //        law.name = ini.ReadValue(SectionName, "name", "");

        //        for (int ii = 1; ii < 50; ii++)
        //        {
        //            law.level.Add(ii, ini.ReadValue(SectionName, string.Format("level{0:00}", ii), 0));
        //        }

        //        Laws.Add(law);
        //    }

        //    #endregion

        //    #region Professions

        //    Professions.Clear();
        //    //Descs.Clear();

        //    foreach (MSTORM_ProfessionType profession in System.Enum.GetValues(typeof(MSTORM_ProfessionType)))
        //    {
        //        string SectionName = profession.ToString();

        //        System.Collections.Generic.List<int> laws = new System.Collections.Generic.List<int>();

        //        for (int i = 0; i < 10; i++)
        //        {
        //            laws.Add(ini.ReadValue(SectionName, string.Format("list{0:00}", i), 0));
        //        }

        //        Professions.Add(SectionName, laws);
        //        //Descs.Add(ini.ReadValue(SectionName, "description", ""));
        //    }

        //    #endregion

        //    ini.Close();
        //}

        //internal static void CreateSpellList()
        //{
        //    TNet.DataNode SpellList = new TNet.DataNode("SpellList");

        //    foreach (MSSpell spell in Spells)
        //    {
        //        TNet.DataNode node = new TNet.DataNode(spell.index.ToString());

        //        node.SetHierarchy("index", spell.index);
        //        node.SetHierarchy("type", spell.type);
        //        node.SetHierarchy("name", spell.name);
        //        node.SetHierarchy("fatigue", spell.fatigue);
        //        node.SetHierarchy("min_fatigue", spell.min_fatigue);
        //        node.SetHierarchy("cast_sound", spell.cast_sound);
        //        node.SetHierarchy("empty_sound", spell.empty_sound);
        //        node.SetHierarchy("spell_icon", spell.spell_icon);

        //        switch (spell.type)
        //        {
        //            case SpellType.None:
        //                break;
        //            case SpellType.Projectile:

        //                #region Projectile

        //                MSSpell_Projectile Projectile = (MSSpell_Projectile)spell;

        //                //creation
        //                node.SetHierarchy("creation_effect", Projectile.creation_effect);

        //                node.SetHierarchy("cast_distance", Projectile.cast_distance);
        //                node.SetHierarchy("elevation", Projectile.elevation);

        //                node.SetHierarchy("imagenum", Projectile.imagenum);
        //                node.SetHierarchy("image_timer_max", Projectile.image_timer_max);
        //                node.SetHierarchy("trans_color", Projectile.trans_color);
        //                node.SetHierarchy("translucent", Projectile.translucent);

        //                node.SetHierarchy("num_projectiles", Projectile.num_projectiles);

        //                node.SetHierarchy("width", Projectile.width);
        //                node.SetHierarchy("tall", Projectile.tall);

        //                node.SetHierarchy("side_by_side", Projectile.side_by_side);
        //                node.SetHierarchy("projectile_spacing", Projectile.projectile_spacing);

        //                node.SetHierarchy("velocity", Projectile.velocity);
        //                node.SetHierarchy("z_velocity", Projectile.z_velocity);
        //                node.SetHierarchy("cast_angle", Projectile.cast_angle);

        //                node.SetHierarchy("gravity", Projectile.gravity);
        //                node.SetHierarchy("max_step", Projectile.max_step);

        //                node.SetHierarchy("duration_timer", Projectile.duration_timer);
        //                node.SetHierarchy("ethereal", Projectile.ethereal);

        //                //impact
        //                node.SetHierarchy("miss_sound", Projectile.miss_sound);
        //                node.SetHierarchy("effect_radius", Projectile.effect_radius);

        //                node.SetHierarchy("death_imagenum", Projectile.death_imagenum);
        //                node.SetHierarchy("death_image_timer_max", Projectile.death_image_timer_max);
        //                node.SetHierarchy("death_trans_color", Projectile.death_trans_color);
        //                node.SetHierarchy("death_translucent", Projectile.death_translucent);
        //                node.SetHierarchy("death_frame_start", Projectile.death_frame_start);
        //                node.SetHierarchy("death_sound", Projectile.death_sound);
        //                node.SetHierarchy("death_sound_range", Projectile.death_sound_range);

        //                node.SetHierarchy("random_death_position", Projectile.random_death_position);
        //                node.SetHierarchy("center_death_image", Projectile.center_death_image);
        //                node.SetHierarchy("bounce", Projectile.bounce);

        //                //damage
        //                node.SetHierarchy("element", Projectile.element);

        //                node.SetHierarchy("min_damage", Projectile.min_damage);
        //                node.SetHierarchy("max_damage", Projectile.max_damage);
        //                node.SetHierarchy("damage_dice", Projectile.damage_dice);
        //                node.SetHierarchy("damage_num_dice", Projectile.damage_num_dice);
        //                node.SetHierarchy("damage_base", Projectile.damage_base);
        //                node.SetHierarchy("min_power_drain", Projectile.min_power_drain);
        //                node.SetHierarchy("max_power_drain", Projectile.max_power_drain);

        //                node.SetHierarchy("damage_by_distance_traveled", Projectile.damage_by_distance_traveled);
        //                node.SetHierarchy("area_effect_spell", Projectile.area_effect_spell);

        //                node.SetHierarchy("death_spell_effect", Projectile.death_spell_effect);

        //                //who can it hit?
        //                node.SetHierarchy("alignment_translucent", Projectile.alignment_translucent);
        //                node.SetHierarchy("no_team", Projectile.no_team);
        //                node.SetHierarchy("friendly", Projectile.friendly);

        //                node.SetHierarchy("death_effect", Projectile.death_effect);
        //                node.SetHierarchy("death_effect_range", Projectile.death_effect_range);
        //                node.SetHierarchy("death_effect_chance", Projectile.death_effect_chance);
        //                node.SetHierarchy("horizontal_spread", Projectile.horizontal_spread);
        //                node.SetHierarchy("vertical_spread", Projectile.vertical_spread);
        //                node.SetHierarchy("effect_sound", Projectile.effect_sound);
        //                node.SetHierarchy("effect_sound_range", Projectile.effect_sound_range);

        //                #endregion

        //                break;
        //            case SpellType.Wall:

        //                #region Wall

        //                MSSpell_Wall Wall = (MSSpell_Wall)spell;

        //                node.SetHierarchy("texturenum", Wall.texturenum);
        //                node.SetHierarchy("length", Wall.length);
        //                node.SetHierarchy("wallheight", Wall.wallheight);
        //                node.SetHierarchy("max_wallheight", Wall.max_wallheight);
        //                node.SetHierarchy("transparent", Wall.transparent);
        //                node.SetHierarchy("trans_color", Wall.trans_color);
        //                node.SetHierarchy("duration_timer", Wall.duration_timer);
        //                node.SetHierarchy("thick", Wall.thick);
        //                node.SetHierarchy("cast_distance", Wall.cast_distance);
        //                node.SetHierarchy("hug_floor", Wall.hug_floor);
        //                node.SetHierarchy("min_damage", Wall.min_damage);
        //                node.SetHierarchy("max_damage", Wall.max_damage);
        //                node.SetHierarchy("min_power_drain", Wall.min_power_drain);
        //                node.SetHierarchy("max_power_drain", Wall.max_power_drain);
        //                node.SetHierarchy("collision_velocity", Wall.collision_velocity);
        //                node.SetHierarchy("element", Wall.element);
        //                node.SetHierarchy("hit_points", Wall.hit_points);
        //                node.SetHierarchy("friendly", Wall.friendly);

        //                #endregion

        //                break;
        //            case SpellType.Healing:

        //                #region Healing

        //                WEPP_Spell_Healing Healing = (WEPP_Spell_Healing)spell;

        //                node.SetHierarchy("min", Healing.min);
        //                node.SetHierarchy("max", Healing.max);

        //                #endregion

        //                break;
        //            case SpellType.Effect:

        //                #region Effect

        //                MSSpell_Effect Effect = (MSSpell_Effect)spell;

        //                node.SetHierarchy("effect", Effect.effect);
        //                node.SetHierarchy("duration_type", Effect.duration_type);
        //                node.SetHierarchy("duration", Effect.duration);
        //                node.SetHierarchy("level", Effect.level);
        //                node.SetHierarchy("element", Effect.element);
        //                node.SetHierarchy("imagenum", Effect.imagenum);
        //                node.SetHierarchy("image_timer", Effect.image_timer);
        //                node.SetHierarchy("overlay_imagenum", Effect.overlay_imagenum);
        //                node.SetHierarchy("overlay_image_timer", Effect.overlay_image_timer);
        //                node.SetHierarchy("overlay_duration", Effect.overlay_duration);
        //                node.SetHierarchy("overlay_dur_type", Effect.overlay_dur_type);
        //                node.SetHierarchy("overlay_height", Effect.overlay_height);
        //                node.SetHierarchy("overlay_opaque", Effect.overlay_opaque);
        //                node.SetHierarchy("overlay_glow", Effect.overlay_glow);
        //                node.SetHierarchy("overlay_trans_color", Effect.overlay_trans_color);

        //                #endregion

        //                break;
        //            case SpellType.Special:
        //                break;
        //            case SpellType.Bolt:

        //                #region Bolt

        //                MSSpell_Bolt Bolt = (MSSpell_Bolt)spell;

        //                //creation
        //                node.SetHierarchy("creation_effect", Bolt.creation_effect);

        //                node.SetHierarchy("cast_distance", Bolt.cast_distance);
        //                node.SetHierarchy("elevation", Bolt.elevation);

        //                node.SetHierarchy("imagenum", Bolt.imagenum);
        //                node.SetHierarchy("image_timer_max", Bolt.image_timer_max);
        //                node.SetHierarchy("trans_color", Bolt.trans_color);
        //                node.SetHierarchy("translucent", Bolt.translucent);
        //                node.SetHierarchy("leading_edge_imagenum", Bolt.leading_edge_imagenum);

        //                node.SetHierarchy("width", Bolt.width);
        //                node.SetHierarchy("tall", Bolt.tall);

        //                node.SetHierarchy("hug_floor", Bolt.hug_floor);

        //                node.SetHierarchy("num_objects", Bolt.num_objects);
        //                node.SetHierarchy("object_spacing", Bolt.object_spacing);
        //                node.SetHierarchy("object_layout", Bolt.object_layout);

        //                node.SetHierarchy("range", Bolt.range);
        //                node.SetHierarchy("max_timer", Bolt.max_timer);

        //                node.SetHierarchy("gravity", Bolt.gravity);

        //                node.SetHierarchy("duration_timer", Bolt.duration_timer);

        //                //impact
        //                node.SetHierarchy("effect_radius", Bolt.effect_radius);

        //                node.SetHierarchy("death_imagenum", Bolt.death_imagenum);
        //                node.SetHierarchy("death_imagenum_chance", Bolt.death_imagenum_chance);
        //                node.SetHierarchy("death_image_timer_max", Bolt.death_image_timer_max);
        //                node.SetHierarchy("death_translucent", Bolt.death_translucent);
        //                node.SetHierarchy("death_trans_color", Bolt.death_trans_color);

        //                //damage
        //                node.SetHierarchy("element", Bolt.element);

        //                node.SetHierarchy("min_damage", Bolt.min_damage);
        //                node.SetHierarchy("max_damage", Bolt.max_damage);
        //                node.SetHierarchy("damage_dice", Bolt.damage_dice);
        //                node.SetHierarchy("damage_num_dice", Bolt.damage_num_dice);
        //                node.SetHierarchy("damage_base", Bolt.damage_base);
        //                node.SetHierarchy("min_power_drain", Bolt.min_power_drain);
        //                node.SetHierarchy("max_power_drain", Bolt.max_power_drain);

        //                node.SetHierarchy("death_spell_effect", Bolt.death_spell_effect);

        //                //who can it hit?
        //                node.SetHierarchy("friendly", Bolt.friendly);

        //                node.SetHierarchy("death_effect", Bolt.death_effect);
        //                node.SetHierarchy("death_effect_range", Bolt.death_effect_range);
        //                node.SetHierarchy("death_effect_chance", Bolt.death_effect_chance);

        //                node.SetHierarchy("effect_imagenum", Bolt.effect_imagenum);
        //                node.SetHierarchy("effect_image_timer_max", Bolt.effect_image_timer_max);
        //                node.SetHierarchy("effect_translucent", Bolt.effect_translucent);
        //                node.SetHierarchy("effect_trans_color", Bolt.effect_trans_color);

        //                node.SetHierarchy("effect_sound", Bolt.effect_sound);
        //                node.SetHierarchy("effect_sound_range", Bolt.effect_sound_range);

        //                node.SetHierarchy("bolt_death_effect", Bolt.bolt_death_effect);
        //                node.SetHierarchy("bolt_death_effect_range", Bolt.bolt_death_effect_range);
        //                node.SetHierarchy("bolt_death_effect_chance", Bolt.bolt_death_effect_chance);

        //                #endregion

        //                break;
        //            case SpellType.Target:

        //                #region Target

        //                MSSpell_Target Target = (MSSpell_Target)spell;

        //                node.SetHierarchy("min_damage", Target.min_damage);
        //                node.SetHierarchy("max_damage", Target.max_damage);
        //                node.SetHierarchy("damage_dice", Target.damage_dice);
        //                node.SetHierarchy("damage_num_dice", Target.damage_num_dice);
        //                node.SetHierarchy("damage_base", Target.damage_base);
        //                node.SetHierarchy("min_power_drain", Target.min_power_drain);
        //                node.SetHierarchy("max_power_drain", Target.max_power_drain);
        //                node.SetHierarchy("range", Target.range);
        //                node.SetHierarchy("caster_spell_effect", Target.caster_spell_effect);
        //                node.SetHierarchy("target_spell_effect", Target.target_spell_effect);
        //                node.SetHierarchy("effect_sound", Target.effect_sound);
        //                node.SetHierarchy("effect_sound_range", Target.effect_sound_range);
        //                node.SetHierarchy("miss_sound", Target.miss_sound);
        //                node.SetHierarchy("element", Target.element);
        //                node.SetHierarchy("friendly", Target.friendly);
        //                node.SetHierarchy("group", Target.group);

        //                #endregion

        //                break;
        //            case SpellType.Dispell:

        //                #region Dispell

        //                MSSpell_Dispell Dispell = (MSSpell_Dispell)spell;

        //                node.SetHierarchy("dispell_type", Dispell.dispell_type);
        //                node.SetHierarchy("range", Dispell.range);
        //                node.SetHierarchy("level", Dispell.level);
        //                node.SetHierarchy("effect_sound", Dispell.effect_sound);
        //                node.SetHierarchy("effect_sound_range", Dispell.effect_sound_range);

        //                #endregion

        //                break;
        //            case SpellType.Teleport:

        //                #region Teleport

        //                MSSpell_Teleport Teleport = (MSSpell_Teleport)spell;

        //                node.SetHierarchy("teleport_type", Teleport.teleport_type);
        //                node.SetHierarchy("caster_spell_effect", Teleport.caster_spell_effect);

        //                #endregion

        //                break;
        //            case SpellType.Rune:

        //                #region Rune

        //                MSSpell_Rune Rune = (MSSpell_Rune)spell;

        //                //creation
        //                node.SetHierarchy("cast_distance", Rune.cast_distance);
        //                node.SetHierarchy("elevation", Rune.elevation);

        //                node.SetHierarchy("imagenum", Rune.imagenum);
        //                node.SetHierarchy("image_timer_max", Rune.image_timer_max);
        //                node.SetHierarchy("trans_color", Rune.trans_color);
        //                node.SetHierarchy("translucent", Rune.translucent);

        //                node.SetHierarchy("num_projectiles", Rune.num_projectiles);

        //                node.SetHierarchy("width", Rune.width);
        //                node.SetHierarchy("tall", Rune.tall);

        //                node.SetHierarchy("side_by_side", Rune.side_by_side);
        //                node.SetHierarchy("projectile_spacing", Rune.projectile_spacing);

        //                node.SetHierarchy("velocity", Rune.velocity);
        //                node.SetHierarchy("z_velocity", Rune.z_velocity);
        //                node.SetHierarchy("cast_angle", Rune.cast_angle);

        //                node.SetHierarchy("gravity", Rune.gravity);
        //                node.SetHierarchy("max_step", Rune.max_step);

        //                node.SetHierarchy("duration_timer", Rune.duration_timer);

        //                //impact
        //                node.SetHierarchy("collision_velocity", Rune.collision_velocity);

        //                node.SetHierarchy("miss_sound", Rune.miss_sound);
        //                node.SetHierarchy("effect_radius", Rune.effect_radius);

        //                node.SetHierarchy("death_imagenum", Rune.death_imagenum);
        //                node.SetHierarchy("death_image_timer_max", Rune.death_image_timer_max);
        //                node.SetHierarchy("death_translucent", Rune.death_translucent);
        //                node.SetHierarchy("death_frame_start", Rune.death_frame_start);
        //                node.SetHierarchy("death_sound", Rune.death_sound);
        //                node.SetHierarchy("death_sound_range", Rune.death_sound_range);

        //                node.SetHierarchy("random_death_position", Rune.random_death_position);
        //                node.SetHierarchy("center_death_image", Rune.center_death_image);

        //                //damage
        //                node.SetHierarchy("element", Rune.element);

        //                node.SetHierarchy("min_damage", Rune.min_damage);
        //                node.SetHierarchy("max_damage", Rune.max_damage);
        //                node.SetHierarchy("damage_dice", Rune.damage_dice);
        //                node.SetHierarchy("damage_num_dice", Rune.damage_num_dice);
        //                node.SetHierarchy("damage_base", Rune.damage_base);
        //                node.SetHierarchy("min_power_drain", Rune.min_power_drain);
        //                node.SetHierarchy("max_power_drain", Rune.max_power_drain);

        //                node.SetHierarchy("death_spell_effect", Rune.death_spell_effect);

        //                //who can it hit?
        //                node.SetHierarchy("alignment_translucent", Rune.alignment_translucent);
        //                node.SetHierarchy("no_team", Rune.no_team);
        //                node.SetHierarchy("friendly", Rune.friendly);

        //                node.SetHierarchy("death_effect", Rune.death_effect);
        //                node.SetHierarchy("death_effect_range", Rune.death_effect_range);
        //                node.SetHierarchy("death_effect_chance", Rune.death_effect_chance);
        //                node.SetHierarchy("horizontal_spread", Rune.horizontal_spread);
        //                node.SetHierarchy("vertical_spread", Rune.vertical_spread);
        //                node.SetHierarchy("effect_sound", Rune.effect_sound);
        //                node.SetHierarchy("effect_sound_range", Rune.effect_sound_range);

        //                //aura
        //                node.SetHierarchy("aura_caster_effect", Rune.aura_caster_effect);
        //                node.SetHierarchy("aura_target_effect", Rune.aura_target_effect);
        //                node.SetHierarchy("aura_pulse_timer", Rune.aura_pulse_timer);
        //                node.SetHierarchy("aura_health", Rune.aura_health);
        //                node.SetHierarchy("aura_stackable", Rune.aura_stackable);

        //                #endregion

        //                break;
        //            default:
        //                break;
        //        }

        //        SpellList.SetHierarchy(spell.index.ToString(), node);
        //    }

        //    SpellList.Write("Assets/SPELLS.txt", TNet.DataNode.SaveType.Text);
        //}

        ////internal static void CreateLawList()
        ////{
        ////    TNet.DataNode LawList = new TNet.DataNode("LawList");

        ////    int index = 0;

        ////    foreach (MSSpell_Law law in Laws)
        ////    {
        ////        //UnityEngine.Debug.Log(law.name);

        ////        //List<int> list = Professions[key];
        ////        //list.RemoveAll(i => i == 0);

        ////        TNet.DataNode node = new TNet.DataNode(index.ToString());
        ////        node.SetHierarchy("name", law.name);

        ////        foreach (int key in law.level.Keys)
        ////        {
        ////            int value = law.level[key];

        ////            if (value != 0)
        ////            {
        ////                node.SetHierarchy("level/" + key, value);
        ////            }
        ////        }

        ////        LawList.SetHierarchy(index.ToString(), node);

        ////        index += 1;
        ////    }

        ////    LawList.Write("Assets/LAWS.txt", TNet.DataNode.SaveType.Text);
        ////}

        ////internal static void CreateProfessionList()
        ////{
        ////    TNet.DataNode ProfessionList = new TNet.DataNode("ProfessionList");

        ////    foreach (string key in Professions.Keys)
        ////    {
        ////        List<int> list = Professions[key];
        ////        list.RemoveAll(i => i == 0);

        ////        TNet.DataNode node = new TNet.DataNode(key);
        ////        node.SetHierarchy("description", "asdf");
        ////        node.SetHierarchy("laws", list);

        ////        ProfessionList.SetHierarchy(key, node);
        ////    }

        ////    ProfessionList.Write("Assets/ProfessionList.txt");
        ////}

        //internal static List<int> GetLaws(MSTORM_ProfessionType profession)
        //{
        //    if (!Professions.ContainsKey(profession.ToString().ToLower()))
        //    {
        //        UnityEngine.Debug.Log("no key: " + profession);
        //        return null;
        //    }

        //    List<int> laws = new List<int>();

        //    foreach (int law in Professions[profession.ToString().ToLower()])
        //    {
        //        if (law != 0) laws.Add(law);
        //    }

        //    return laws;
        //}

        //internal static int GetLawIndex(int spellindex, MSTORM_ProfessionType profession)
        //{
        //    foreach (int lawindex in MSSpell.Professions[profession.ToString().ToLower()])
        //    {
        //        if (lawindex != 0)
        //        {
        //            MSSpell_Law spelllaw = MSSpell.Laws[lawindex];

        //            for (int level = 1; level < 50; level++)
        //            {
        //                if (spelllaw.level[level] == spellindex) return lawindex;
        //            }
        //        }
        //    }

        //    return 0;
        //}

        //internal static int GetSpellLevel(int lawindex, int spellindex)
        //{
        //    MSSpell_Law law = Laws[lawindex];
        //    //UnityEngine.Debug.Log(law.name);
        //    return law.level.FirstOrDefault(i => i.Value == spellindex).Key;
        //}
    }

    //[System.Serializable]
    //public class MSSpell_Law
    //{
    //    public string name;
    //    public System.Collections.Generic.Dictionary<int, int> level = new System.Collections.Generic.Dictionary<int, int>();
    //}

}