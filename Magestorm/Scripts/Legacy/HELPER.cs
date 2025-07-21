using System;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Magestorm.Legacy
{
    public static class HELPER
    {
        public static Color GetTransColor(TransColor color)
        {
            Color c = Color.white;

            switch (color)
            {
                case TransColor.Black: c = Color.black; break;
                //case SpellTransColor.Blood: c = NGUIMath.HexToColor(0x8A0707); break;
                case TransColor.Blue: c = Color.blue; break;
                case TransColor.Cold: c = new Color(63f / 255f, 255f / 255f, 255f / 255f); break;
                case TransColor.Earth: c = new Color(129f / 255f, 88f / 255f, 40f / 255f); break;
                //case SpellTransColor.Explosion: c = NGUIMath.HexToColor(0xe0ffbeff); break;
                case TransColor.Green: c = Color.green; break;
                case TransColor.Heat: c = new Color(236f / 255f, 127f / 255f, 3f / 255f); break;
                case TransColor.Light: c = new Color(129f / 255f, 88f / 255f, 226f / 255f); break;
                //case SpellTransColor.Poison: c = NGUIMath.HexToColor(0x7376fdff); break;
                case TransColor.Purple: c = new Color(253f / 255f, 50f / 255f, 222f / 255f); break;
                case TransColor.Red: c = Color.red; break;
                //case SpellTransColor.Smoke: c = NGUIMath.HexToColor(0xff9000ff); break;
                case TransColor.White: c = Color.white; break;
                case TransColor.Yellow: c = Color.yellow; break;
            }
            return c;
        }
        //public static Color GetTeamColor(TeamType team)
        //{
        //    if (team == TeamType.Neutral) return WebColors.Silver;//Color.white;
        //    if (team == TeamType.Balance) return WebColors.LawnGreen; //new Color(21f / 255f, 1, 44f / 255f, 1);
        //    if (team == TeamType.Chaos) return WebColors.Crimson;//new Color(1, 44f / 255f, 21f / 255f);
        //    if (team == TeamType.Order) return WebColors.DodgerBlue;//return new Color(30f / 255f, 144f / 255f, 255f / 255f);
        //    if (team == TeamType.Yellow) return Color.yellow;
        //    if (team == TeamType.System) return WebColors.Gold;//Color.yellow;
        //    if (team == TeamType.Moderator)
        //    {
        //        Color modcolor = new Color(1, 105f / 255f, 180f / 255f);
        //        modcolor.a = 224f / 255f;

        //        return modcolor;
        //    }
        //    //if (team == TeamType.AI) return WebColors.darkorange;

        //    return Color.white;
        //}
        public static int SortByNameReverse(Transform a, Transform b) { return string.Compare(b.name, a.name); }

        public static string ToDHMS(this int seconds)
        {
            System.TimeSpan span = new System.TimeSpan(0, 0, 0, seconds);

            return string.Format("{0}D {1}H {2}M {3}S", span.Days, span.Hours, span.Minutes, span.Seconds, span.Milliseconds);
        }

        //public static System.Collections.Generic. Dictionary<StatisticType, int> GetStatisticList()
        //{
        //    int max = Localization.dictionary.Keys.Count(i => i.StartsWith("StatisticType"));

        //    System.Collections.Generic.Dictionary<StatisticType, int> list = new System.Collections.Generic.Dictionary<StatisticType, int>();

        //    for (int i = 0; i < max; i++) { list.Add((StatisticType)i, 0); }

        //    return list;
        //}

        //public static System.Collections.Generic.Dictionary<AttributeType, IntInt> GetAttributeList()
        //{
        //    int max = Localization.dictionary.Keys.Count(i => i.StartsWith("AttributeType"));

        //    System.Collections.Generic.Dictionary<AttributeType, IntInt> list = new System.Collections.Generic.Dictionary<AttributeType, IntInt>();

        //    for (int i = 0; i < max; i++) { list.Add((AttributeType)i, new IntInt { value = 20, valueMax = 20 }); }
            
        //    return list;
        //}

        public static long ToUnixTime(this System.DateTime date)
        {
            var epoch = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
            return System.Convert.ToInt64((date - epoch).TotalSeconds);
        }

        public static int[] GetIntList(this string csv)
        {
            //return commaString.Split(',').Select(s => int.Parse(s)).ToArray();

            if (string.IsNullOrEmpty(csv)) return new int[0];

            int mos = 0;
            return csv.Split(',')
                                .Where(m => int.TryParse(m, out mos))
                                .Select(m => int.Parse(m))
                                .ToArray();
        }
        public static string GetCommaList(this int[] arr)
        {
            if (arr.Length == 0) return "";

            return string.Join(",", arr);
        }
        //public static int CharacterSlotsRemaining(int startCount, System.Collections.Generic.List<GameKit.Character> list)
        //{
        //    int characterRemaining = startCount;

        //    if (list.Count > 0)
        //    {
        //        if (list.Count <= startCount)
        //        {
        //            characterRemaining = startCount - list.Count;
        //        }
        //        else characterRemaining = 0;
        //    }

        //    return characterRemaining;
        //}
        //public static int BonusSlotUsed(int startCount, System.Collections.Generic.List<GameKit.Character> list)
        //{
        //    int microUsed = 0;

        //    if (list.Count > 0)
        //    {
        //        if (list.Count > startCount)
        //        {
        //            microUsed = list.Count - startCount;
        //        }
        //        //else characterRemaining = GameManager.StartCharacterCount - list.children.Count;
        //    }

        //    return microUsed;
        //}

        public static int BonusSlotCount(int startCount, int account_max_characters)
        {
            return account_max_characters - startCount;//Account.max_characters
        }
        //public static string GetMatchType(MatchType match_type)
        //{
        //    if (match_type == MatchType.Conquest) return "Conquest";
        //    else if (match_type == MatchType.CTF) return "Capture the Flag";
        //    //else if (match_type == MS_MatchType.Death_Match) return "Death Match";

        //    return match_type.ToString().Replace("_", " ");
        //}
        //public static string GetMatchTypeTooltipText(MatchType matchtype, bool is_private = false)
        //{
        //    string s = "";

        //    if (matchtype == MatchType.Conquest)
        //    {
        //        s += "1.[3CF03CFF] Victory:[-] Destroy all opposing shrines while your shrine remains 100%.";
        //        s += "\n2.[3CF03CFF] Victory is cancelled:[-]\n~~ if an opposing shrine is restored to 100% before the countdown reaches zero.\n~~ if the winning shrine is damaged.\n";
        //    }
        //    else if (matchtype == MatchType.CTF)
        //    {
        //        s += "1.[3CF03CFF] To score:[-] Carry an opposing team flag to your team base.  You can't score if an opposing team has your team flag.";
        //        s += "\n2.[3CF03CFF]  Victory:[-] Score/Kills/Damage determines the winner.";
        //    }
        //    //else if (selected_matchtype == MatchType.Death_Match)
        //    //{
        //    //    s += "1. When you die you are removed from the match.";
        //    //    s += "\n2.[3CF03CFF] Victory:[-] Kill all opposing team players.";
        //    //}
        //    //else Debug.Log(matchtype);

        //    if (is_private)
        //    {
        //        s += "\n3.[3CF03CFF] Bonus:[-] No bonus in a private match.";
        //    }
        //    else
        //    {
        //        s += "\n3.[3CF03CFF] Bonus:[-] Every 5 minutes the win bonus increases by 8.5%.";
        //    }

        //    return s;
        //}

        public static void ExitApplication()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
                                        //Application.OpenURL($"webplayerQuitURL");
#elif STANDALONE

#else
                                        //Application.Quit();
#endif
        }

        /// <summary>
        /// Get the ordinal value of positive integers.
        /// </summary>
        /// <remarks>
        /// Only works for english-based cultures.
        /// Code from: http://stackoverflow.com/questions/20156/is-there-a-quick-way-to-create-ordinals-in-c/31066#31066
        /// With help: http://www.wisegeek.com/what-is-an-ordinal-number.htm
        /// </remarks>
        /// <param name="number">The number.</param>
        /// <returns>Ordinal value of positive integers, or <see cref="int.ToString"/> if less than 1.</returns>
        public static string Ordinal(int number)
        {
            const string TH = "th";
            string s = number.ToString();

            // Negative and zero have no ordinal representation
            if (number < 1)
            {
                return s;
            }

            number %= 100;
            if ((number >= 11) && (number <= 13))
            {
                return s + TH;
            }

            switch (number % 10)
            {
                case 1: return s + "st";
                case 2: return s + "nd";
                case 3: return s + "rd";
                default: return s + TH;
            }
        }

        internal static string RemoveStringAt(this string source, int index)
        {
            System.Collections.Generic.List<string> list = source.Split(',').ToList();

            if (list.Count - 1 <= index)
            {
                list.RemoveAt(index);
            }

            string sList = string.Join(",", list.ToArray());
            if (sList == null || list.Count == 0) sList = "";
            if (list.Count == 1) sList = list[0];
            if (sList.StartsWith(","))
            {
                string s = sList;

                sList = s.Substring(1, s.Length - 1);
            }

            return sList;
        }

        public static DateTime FromUnixTime(this long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }

        /// <summary>
        /// Use CreateFolder in 'Start()'.  TNetManager Awake() must be called first.
        /// </summary>
        public static bool CreateFolder(string folder)
        {
            string path = GetDocumentsPath() + folder;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);

#if UNITY_EDITOR
            UnityEngine.Debug.LogWarning(folder + " folder created");
#endif

                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the path to a file in My Documents or OSX equivalent.
        /// </summary>

        static public string GetDocumentsPath(string path = null)
        {
#if !UNITY_WEBPLAYER && !UNITY_FLASH && !UNITY_METRO && !UNITY_WP8 && !UNITY_WP_8_1
            try
            {
                if (!string.IsNullOrEmpty(applicationDirectory))
                {
                    var docs = Path.Combine(persistentDataPath, applicationDirectory).Replace("\\", "/");
                    path = string.IsNullOrEmpty(path) ? docs : Path.Combine(docs, path);
                }

                if (!string.IsNullOrEmpty(path)) path = path.Replace("\\", "/");
            }
            catch (System.Exception ex)
            {
#if UNITY_EDITOR
                UnityEngine.Debug.LogError(ex.Message.Trim() + "\n" + path + "\n" + ex.StackTrace.Replace("\r\n", "\n"));
#else
				//UnityEngine.Debug.LogError(ex.Message + " (" + path + ")", ex.StackTrace.Replace("\r\n", "\n"), false);
#endif
                return null;
            }
#endif
            return path;
        }

        /// <summary>
        /// Application directory to use in My Documents. Generally should be the name of your game.
        /// If not set, current directory will be used instead.
        /// </summary>

        static public string applicationDirectory = null;


        /// <summary>
        /// Path to the persistent data path.
        /// </summary>

        static public string persistentDataPath
        {
            get
            {
                if (mBasePath == null)
                {
#if !UNITY_EDITOR && (UNITY_ANDROID || UNITY_IPHONE || UNITY_WEBPLAYER || UNITY_WINRT || UNITY_FLASH)
					mBasePath = UnityEngine.Application.persistentDataPath;
#else
                    mBasePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
#endif
                    mBasePath = mBasePath.Replace("\\", "/");
                }
                return mBasePath;
            }
            set
            {
                mBasePath = value;
            }
        }



        static string mBasePath = null;






















































        public static int calculateXP(int playerlevel, int moblevel, MS_ExpFrom exp_from, bool elite = false, bool rested = false, float fine_tuner = 1)
        {
            double xp = 0;
            int zd = 5;

            if (playerlevel < moblevel)
            {
                if (moblevel - playerlevel > 4)
                {
                    moblevel = playerlevel + 4;
                }

                xp = (playerlevel * 5 + 45) * (1 + 0.05 * (moblevel - playerlevel));
            }
            else if (playerlevel == moblevel)
            {
                xp = playerlevel * 5 + 45;
            }
            else if (playerlevel > moblevel)
            {
                if (moblevel <= calculateGrayLevel(playerlevel))
                {
                    xp = 0;
                }
                else
                {
                    zd = getZD(playerlevel);
                    xp = (playerlevel * 5 + 45) * (1 - (playerlevel - moblevel) / zd);
                }
            }

            if (elite == true)
            {
                xp *= 2;
            }

            if (rested == true)
            {
                xp *= 2;
            }

            double xp2 = xp;

            System.Random rand = new System.Random();
            float percentage = 0.35f;
            if (playerlevel >= 10) percentage = 0.40f;
            if (playerlevel >= 20) percentage = 0.55f;

            float v = rand.Next((int)(xp2 - (xp2 * percentage)), (int)xp2);


            v *= fine_tuner;


            switch (exp_from)
            {
                case MS_ExpFrom.Kill:
                    percentage = 1;
                    break;
                case MS_ExpFrom.Combat:
                    percentage = 1;
                    break;
                case MS_ExpFrom.Shrine:
                    percentage = 0.85f;
                    break;
                case MS_ExpFrom.Pool:
                    percentage = 0.60f;
                    break;
                default:
                    percentage = 0.01f;
                    break;
            }

            v *= percentage;

            if (exp_from == MS_ExpFrom.Kill)
            {
                v *= Mathf.PI;
            }

            return Mathf.RoundToInt(v);
        }
        private static int getZD(int lvl)
        {
            if (lvl <= 7)
            {
                return 5;
            }
            if (lvl <= 9)
            {
                return 6;
            }
            if (lvl <= 11)
            {
                return 7;
            }
            if (lvl <= 15)
            {
                return 8;
            }
            if (lvl <= 19)
            {
                return 9;
            }
            if (lvl <= 29)
            {
                return 11;
            }
            if (lvl <= 39)
            {
                return 12;
            }
            if (lvl <= 44)
            {
                return 13;
            }
            if (lvl <= 49)
            {
                return 14;
            }
            if (lvl <= 54)
            {
                return 15;
            }
            if (lvl <= 59)
            {
                return 16;
            }
            else
            {
                return 17; // Approx.
            }
        }
        private static int calculateGrayLevel(int playerlevel)
        {
            if (playerlevel <= 5)
            {
                return 0;
            }
            else if (playerlevel >= 6 && playerlevel <= 39)
            {
                return playerlevel - 5 - Mathf.FloorToInt(playerlevel / 10);
            }
            else if (playerlevel >= 40 && playerlevel <= 60)
            {
                return playerlevel - 1 - Mathf.FloorToInt(playerlevel / 5);
            }

            return 0;
        }
    }
    public enum MS_ExpFrom
    {
        Unknown = 0,
        Combat = 1,
        Shrine = 2,
        Pool = 3,
        Kill = 4,
        Pickup1 = 5,
        Pickup2 = 6,
        Pickup3 = 7,
        Pickup4 = 8,
    }
}