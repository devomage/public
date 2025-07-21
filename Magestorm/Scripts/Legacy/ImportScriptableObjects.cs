namespace Magestorm.Legacy
{
    using System.Collections;
    using System.Collections.Generic;
    using Unity.VisualScripting;
    using UnityEditor;
    using UnityEngine;

    /// <summary>
    /// Import from the source game files
    /// </summary>
    public class ImportScriptableObjects : MonoBehaviour
    {
        public string devPath = @"D:\MagestormDev";
        public string dataGamePath = "Legacy/Data/ScriptableObject/Game";
        public int m_ArenaIndex = 0;

        [ContextMenu("Import game from source")]
        public void ImportGameFromSource()
        {
            Magestorm.Legacy.Game game = Resources.Load<Game>(dataGamePath);

            game.ArenaList = DatUtility.DAT.ARENAS.Load($"{devPath}\\Arenas.dat");
            game.ImageList = DatUtility.DAT.IMAGE.Load($"{devPath}\\Images\\Image.dat");
            game.SoundList = DatUtility.DAT.MAIN.Load($"{devPath}\\Main.dat");
            DatUtility.DAT.SPELLS.Load_Spells($"{devPath}\\Spells.dat", out game.SpellList, out game.LawList, out game.LawListByProfession);
            game.TextureList = DatUtility.DAT.SYSTEM.Load($"{devPath}\\System.dat");

            game.ProfessionList.Clear();
            foreach (var key in game.LawListByProfession.Keys)
            {
                if (key == "magician" || key == "wizard") game.ProfessionList.Add(ProfessionType.Wizard);
                else if (key == "arcanist") game.ProfessionList.Add(ProfessionType.Arcanist);
                else if (key == "cleric") game.ProfessionList.Add(ProfessionType.Cleric);
                else if (key == "mentalist") game.ProfessionList.Add(ProfessionType.Mentalist);
            }

            EditorUtility.SetDirty(game);

            Debug.Log("Legacy Data: [ImportFromGame] complete");
        }

        [ContextMenu("Import maps from source")]
        public void ImportMapsFromSource()
        {
            // grids folder
            // Color.dat
            // Grid.dat
            // Misc.dat
            // Objects.dat
            // Preview.dat
            // Sounds.dat
            // Trigger.dat
            // World.dat

            for (int i = 0; i <= 9; i++)
            {
                var sourcePath = $"{devPath}/GRIDS/GRID{i:00}";
                var gamePath = $"Legacy/Data/ScriptableObject/GRIDS/GRID{i:00}";

                GameMap GameMap = Resources.Load<GameMap>(gamePath + "/GameMap");

                GameMap.List_Blocks = DatUtility.DAT.GRID.Load_Blocks($"{sourcePath}/Grid.dat");
                GameMap.List_ObjectLocations = DatUtility.DAT.GRID.Load_ObjectLocations($"{sourcePath}/Grid.dat");
                GameMap.List_Objects = DatUtility.DAT.OBJECTS.Load($"{sourcePath}/Objects.dat");
                GameMap.List_MapTextures = DatUtility.DAT.MISC.Load_Textures($"{sourcePath}/Misc.dat");
                GameMap.List_Thins = DatUtility.DAT.MISC.Load_Thins($"{sourcePath}/Misc.dat");
                GameMap.List_Tiles = DatUtility.DAT.MISC.Load_Tiles($"{sourcePath}/Misc.dat");
                GameMap.List_Triggers = DatUtility.DAT.TRIGGER.Load($"{sourcePath}/Trigger.dat");
                GameMap.m_World = DatUtility.DAT.WORLD.Load($"{sourcePath}/World.dat");

                EditorUtility.SetDirty(GameMap);
            }

            Debug.Log("Legacy Data: [ImportFromGame] complete");
        }

        [ContextMenu("Import triggers from source")]
        public void ImportTriggersFromSource()
        {
            var sourcePath = $"{devPath}/GRIDS/GRID{m_ArenaIndex:00}";
            var gamePath = $"Legacy/Data/ScriptableObject/GRIDS/GRID{m_ArenaIndex:00}";

            GameMap GameMap = Resources.Load<GameMap>(gamePath + "/GameMap");

            GameMap.List_Triggers = DatUtility.DAT.TRIGGER.Load($"{sourcePath}/Trigger.dat");

            EditorUtility.SetDirty(GameMap);

            Debug.Log($"Legacy Data: [ImportFromSource] import arena #{m_ArenaIndex} triggers ({GameMap.List_Triggers.Count}) complete");
        }
    }

}