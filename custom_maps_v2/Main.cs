﻿using MelonLoader;
using HarmonyLib;

using Assets.Scripts.Unity.UI_New.InGame;
using Assets.Scripts.Unity;
using System.IO;
using Assets.Main.Scenes;
using UnityEngine;
using System.Linq;
using BTD_Mod_Helper.Extensions;
using Assets.Scripts.Data.MapSets;
using Assets.Scripts.Models.Map.Spawners;
using Assets.Scripts.Models.Map;
using UnhollowerBaseLib;
using Assets.Scripts.Data;
using BTD_Mod_Helper.Api;
using BTD_Mod_Helper;
using Assets.Scripts.Unity.Map;
using Assets.Scripts.Unity.Bridge;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Net;
using Il2CppSystem.Collections.Generic;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.ModOptions;
using Il2CppSystem.Reflection;
using Assets.Scripts.Unity.UI_New.Main.MapSelect;
using Assets.Scripts.Unity.Player;
using NinjaKiwi.Common;

[assembly: MelonInfo(typeof(custommaps.Main), "Custom Maps", "1.0.2", "Timotheeee1 & Greenphx")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace custommaps
{
    public class Main : BloonsMod
    {
        public override string MelonInfoCsURL => "https://raw.githubusercontent.com/Timotheeee/btd6_mods/master/custom_maps_v2/Main.cs";
        public override string LatestURL => "https://github.com/Timotheeee/btd6_mods/blob/master/custom_maps_v2/custommaps.dll?raw=true";
        public override void OnApplicationStart()
        {
            base.OnApplicationStart();
            MelonLogger.Msg("custom maps loaded");
        }
        static string LastMap = null;
        static bool isCustom(string map)
        {
            return mapList.Where(x => x.name == map).Count() > 0;
        }
        private readonly static ModSettingString Info = new ModSettingString("Restart your game to apply changes!")
        {
            displayName = "Restart your game to apply changes!",
        };
        private readonly static ModSettingBool MemeMaps = new ModSettingBool(true)
        {
            isButton = false,
            displayName = "Meme Maps",
        };
        private readonly static ModSettingBool OldMaps = new ModSettingBool(true)
        {
            isButton = false,
            displayName = "Old (BTD 1-3) Maps",
        };
        private readonly static ModSettingBool BTD4Maps = new ModSettingBool(true)
        {
            isButton = false,
            displayName = "BTD 4 Maps",
        };
        private readonly static ModSettingBool BTD5Maps = new ModSettingBool(true)
        {
            isButton = false,
            displayName = "BTD 5 Maps",
        };
        private readonly static ModSettingBool BTDBMaps = new ModSettingBool(true)
        {
            isButton = false,
            displayName = "BTD Battles Maps",
        };
        private readonly static ModSettingBool BMCMaps = new ModSettingBool(true)
        {
            isButton = false,
            displayName = "BMC Maps",
        };
        private readonly static ModSettingBool NewMaps = new ModSettingBool(true)
        {
            isButton = false,
            displayName = "New (Completely custom) Maps",
        };
        class MapData
        {
            public string name; //Map name without spaces or any special characters
            public MapDifficulty difficulty; //Map difficulty
            public PathModel[] paths; //Map paths, do MapClassName.pathmodel
            public PathSpawnerModel spawner; //Map paths, do MapClassName.spawner
            public Il2CppReferenceArray<AreaModel> areas; //Map paths, do MapClassName.areas
            public string mapMusic; //Map music, there are examples in mapList
            public string mapDisplayName; //Map name with spaces
            public string mapType; //Types: "Meme", "Old" "BTD 4", "BTD 5", "BTD B", "BMC" "New"

            public MapData(string name, MapDifficulty difficulty, PathModel[] paths, PathSpawnerModel spawner, Il2CppReferenceArray<AreaModel> areas, string mapMusic, string mapDisplayName, string mapType)
            {
                this.name = name;
                this.difficulty = difficulty;
                this.paths = paths;
                this.spawner = spawner;
                this.areas = areas;
                this.mapMusic = mapMusic;
                this.mapDisplayName = mapDisplayName;
                this.mapType = mapType;

            }
        }
        static MapData[] mapList = new MapData[]
        {
            new MapData("3TimesAround", MapDifficulty.Beginner, Maps._3TimesAround.pathmodel(), Maps._3TimesAround.spawner(), Maps._3TimesAround.areas(), "MusicBTD5JazzA", "3 Times Around", "BTD 5"),
            new MapData("SpaceTruckin", MapDifficulty.Beginner, Maps.SpaceTruckin.pathmodel(), Maps.SpaceTruckin.spawner(), Maps.SpaceTruckin.areas(), "MusicBTD5JazzA", "Space Truckin'", "BTD 5"),
            new MapData("BloonOfClubs", MapDifficulty.Intermediate, Maps.BloonOfClubs.pathmodel(), Maps.BloonOfClubs.spawner(), Maps.BloonOfClubs.areas(), "MusicBTD5JazzA", "Bloon Of Clubs", "BTD 5"),
            new MapData("BattleSands", MapDifficulty.Intermediate, Maps.BattleSands.pathmodel(), Maps.BattleSands.spawner(), Maps.BattleSands.areas(), "MusicDarkA", "Battle Sands", "BTD B"),
            new MapData("LightningScar", MapDifficulty.Advanced, Maps.LightningScar.pathmodel(), Maps.LightningScar.spawner(), Maps.LightningScar.areas(), "MusicBTD5JazzA", "Lightning Scar", "BTD 5"),
            new MapData("MonkeysInSpace", MapDifficulty.Advanced, Maps.MonkeysInSpace.pathmodel(), Maps.MonkeysInSpace.spawner(), Maps.MonkeysInSpace.areas(), "MusicDarkA", "Monkeys In Space", "New"),
            new MapData("BloontoniumLab", MapDifficulty.Expert, Maps.BloontoniumLab.pathmodel(), Maps.BloontoniumLab.spawner(), Maps.BloontoniumLab.areas(), "MusicBTD5JazzA", "Bloontonium Lab", "BTD 5"),
            new MapData("MainStreet", MapDifficulty.Expert, Maps.MainStreet.pathmodel(), Maps.MainStreet.spawner(), Maps.MainStreet.areas(), "MusicBTD5JazzA", "Main Street", "BTD 5"),
            new MapData("TarPits", MapDifficulty.Expert, Maps.TarPits.pathmodel(), Maps.TarPits.spawner(), Maps.TarPits.areas(), "MusicBTD5JazzA", "Tar Pits", "BTD 5"),
            new MapData("BloonsTD1", MapDifficulty.Beginner, Maps.BTD1.pathmodel(), Maps.BTD1.spawner(), Maps.BTD1.areas(), "MusicDarkA", "Bloons TD 1", "Old"), //Credits to K1d_5h31d0n for this map texture
            new MapData("OceanRoad", MapDifficulty.Beginner, Maps.OceanRoad.pathmodel(), Maps.OceanRoad.spawner(), Maps.OceanRoad.areas(), "MusicDarkA", "Ocean Road", "BTD 4"),
            new MapData("HighTech", MapDifficulty.Expert, Maps.HighTech.pathmodel(), Maps.HighTech.spawner(), Maps.HighTech.areas(), "MusicDarkA", "High Tech", "BTD 4"), //Credits to K1d_5h31d0n for this map texture
            new MapData("BloonDunes", MapDifficulty.Advanced, Maps.BloonDunes.pathmodel(), Maps.BloonDunes.spawner(), Maps.BloonDunes.areas(), "MusicDarkA", "Bloon Dunes", "Old"), //Credits to K1d_5h31d0n for this map texture
            new MapData("Brickout", MapDifficulty.Advanced, Maps.BrickoutData.pathmodel(), Maps.BrickoutData.spawner(), Maps.BrickoutData.areas(), "MusicDarkA", "Brickout", "New"),
            new MapData("PoolTable", MapDifficulty.Intermediate, Maps.PoolTable.pathmodel(), Maps.PoolTable.spawner(), Maps.PoolTable.areas(), "MusicDarkA", "Pool Table", "BTD 4"),
            new MapData("ConcreteAlley", MapDifficulty.Intermediate, Maps.ConcreteAlley.pathmodel(), Maps.ConcreteAlley.spawner(), Maps.ConcreteAlley.areas(), "MusicDarkA", "Concrete Alley", "BTD B"),
            new MapData("Riverside", MapDifficulty.Intermediate, Maps.Riverside.pathmodel(), Maps.Riverside.spawner(), Maps.Riverside.areas(), "MusicDarkA", "Riverside", "BTD B"),
            new MapData("Maze", MapDifficulty.Beginner, Maps.Maze.pathmodel(), Maps.Maze.spawner(), Maps.Maze.areas(), "MusicBTD5JazzA", "Maze", "BTD 5"),
            new MapData("Patch", MapDifficulty.Beginner, Maps.Patch.pathmodel(), Maps.Patch.spawner(), Maps.Patch.areas(), "MusicBTD5JazzA", "Patch", "BTD 5"),
            new MapData("SnakeRiver", MapDifficulty.Intermediate, Maps.SnakeRiver.pathmodel(), Maps.SnakeRiver.spawner(), Maps.SnakeRiver.areas(), "MusicBTD5JazzA", "Snake River", "BTD 5"),
            new MapData("AGame", MapDifficulty.Advanced, Maps.AGame.pathmodel(), Maps.AGame.spawner(), Maps.AGame.areas(), "MusicDarkA", "A-Game", "BTD B"),
            new MapData("IndoorPools", MapDifficulty.Advanced, Maps.IndoorPools.pathmodel(), Maps.IndoorPools.spawner(), Maps.IndoorPools.areas(), "MusicDarkA", "Indoor Pools", "BTD B"),
            new MapData("TreasureTrove", MapDifficulty.Expert, Maps.TreasureTrove.pathmodel(), Maps.TreasureTrove.spawner(), Maps.TreasureTrove.areas(), "MusicDarkA", "Treasure Trove", "BMC"),
            new MapData("Amogus", MapDifficulty.Expert, Maps.Amogus.pathmodel(), Maps.Amogus.spawner(), Maps.Amogus.areas(), "MusicDarkA", "Amogus", "Meme"),
            new MapData("BattlePark", MapDifficulty.Intermediate, Maps.BattlePark.pathmodel(), Maps.BattlePark.spawner(), Maps.BattlePark.areas(), "MusicDarkA", "Battle Park", "BTD B"),
            new MapData("BloonCircles", MapDifficulty.Intermediate, Maps.BloonCircles.pathmodel(), Maps.BloonCircles.spawner(), Maps.BloonCircles.areas(), "MusicDarkA", "Bloon Circles", "BTD B"),
            new MapData("Blooncano", MapDifficulty.Expert, Maps.Blooncano.pathmodel(), Maps.Blooncano.spawner(), Maps.Blooncano.areas(), "MusicDarkA", "Blooncano", "New"),
            new MapData("BloontoniumCore", MapDifficulty.Expert, Maps.BloontoniumCore.pathmodel(), Maps.BloontoniumCore.spawner(), Maps.BloontoniumCore.areas(), "MusicDarkA", "Bloontonium Core", "New"),
            new MapData("BrickWall", MapDifficulty.Beginner, Maps.BrickWall.pathmodel(), Maps.BrickWall.spawner(), Maps.BrickWall.areas(), "MusicBTD5JazzA", "Brick Wall", "BTD 5"),
            new MapData("Cannal", MapDifficulty.Expert, Maps.Cannal.pathmodel(), Maps.Cannal.spawner(), Maps.Cannal.areas(), "MusicDarkA", "Cannal", "New"),
            new MapData("Castle", MapDifficulty.Advanced, Maps.Castle.pathmodel(), Maps.Castle.spawner(), Maps.Castle.areas(), "MusicBTD5JazzA", "Castle", "BTD 5"),
            new MapData("Checkers", MapDifficulty.Beginner, Maps.Checkers.pathmodel(), Maps.Checkers.spawner(), Maps.Checkers.areas(), "MusicBTD5JazzA", "Checkers", "BTD 5"),
            new MapData("Crossover", MapDifficulty.Expert, Maps.Crossover.pathmodel(), Maps.Crossover.spawner(), Maps.Crossover.areas(), "MusicDarkA", "Crossover", "New"),
            new MapData("Epilogue", MapDifficulty.Expert, Maps.Epilogue.pathmodel(), Maps.Epilogue.spawner(), Maps.Epilogue.areas(), "MusicDarkA", "Epilogue", "New"),
            new MapData("ExpressShipping", MapDifficulty.Beginner, Maps.ExpressShipping.pathmodel(), Maps.ExpressShipping.spawner(), Maps.ExpressShipping.areas(), "MusicBTD5JazzA", "Express Shipping", "BTD 5"),
            new MapData("FloodedBazaar", MapDifficulty.Expert, Maps.FloodedBazaar.pathmodel(), Maps.FloodedBazaar.spawner(), Maps.FloodedBazaar.areas(), "MusicDarkA", "Flooded Bazaar", "New"),
            new MapData("Flower", MapDifficulty.Expert, Maps.Flower.pathmodel(), Maps.Flower.spawner(), Maps.Flower.areas(), "MusicDarkA", "Flower", "New"),
            new MapData("Grid", MapDifficulty.Expert, Maps.Grid.pathmodel(), Maps.Grid.spawner(), Maps.Grid.areas(), "MusicDarkA", "Grid", "Meme"),
            new MapData("Hairs", MapDifficulty.Expert, Maps.Hairs.pathmodel(), Maps.Hairs.spawner(), Maps.Hairs.areas(), "MusicDarkA", "Hairs", "Meme"),
            new MapData("Heartgate", MapDifficulty.Expert, Maps.Heartgate.pathmodel(), Maps.Heartgate.spawner(), Maps.Heartgate.areas(), "MusicDarkA", "Heartgate", "New"),
            new MapData("LongRange", MapDifficulty.Expert, Maps.LongRange.pathmodel(), Maps.LongRange.spawner(), Maps.LongRange.areas(), "MusicBTD5JazzA", "Long Range", "BTD 5"),
            new MapData("Lyne", MapDifficulty.Advanced, Maps.Lyne.pathmodel(), Maps.Lyne.spawner(), Maps.Lyne.areas(), "MusicDarkA", "Lyne", "New"),
            new MapData("MilkAndCookies", MapDifficulty.Beginner, Maps.MilkAndCookies.pathmodel(), Maps.MilkAndCookies.spawner(), Maps.MilkAndCookies.areas(), "MusicDarkA", "Milk And Cookies", "BTD 4"),
            new MapData("MinecraftDesert", MapDifficulty.Intermediate, Maps.MinecraftDesert.pathmodel(), Maps.MinecraftDesert.spawner(), Maps.MinecraftDesert.areas(), "MusicDarkA", "Minecraft Desert", "New"),
            new MapData("Mondrian", MapDifficulty.Intermediate, Maps.Mondrian.pathmodel(), Maps.Mondrian.spawner(), Maps.Mondrian.areas(), "MusicDarkA", "Mondrian", "BTD B"),
            new MapData("MonkeyLane", MapDifficulty.Beginner, Maps.MonkeyLane.pathmodel(), Maps.MonkeyLane.spawner(), Maps.MonkeyLane.areas(), "MusicBTD5JazzA", "Monkey Lane", "BTD 5"),
            new MapData("Offside", MapDifficulty.Intermediate, Maps.Offside.pathmodel(), Maps.Offside.spawner(), Maps.Offside.areas(), "MusicDarkA", "Offside", "BTD B"),
            new MapData("PvZRoof", MapDifficulty.Intermediate, Maps.PvZRoof.pathmodel(), Maps.PvZRoof.spawner(), Maps.PvZRoof.areas(), "MusicDarkA", "PvZ Roof", "New"),
            new MapData("RinksRevenge", MapDifficulty.Advanced, Maps.RinksRevenge.pathmodel(), Maps.RinksRevenge.spawner(), Maps.RinksRevenge.areas(), "MusicBTD5JazzA", "Rinks Revenge", "BTD 5"),
            new MapData("SkullPeak", MapDifficulty.Beginner, Maps.SkullPeak.pathmodel(), Maps.SkullPeak.spawner(), Maps.SkullPeak.areas(), "MusicBTD5JazzA", "Skull Peak", "BTD 5"),
            new MapData("Slons", MapDifficulty.Expert, Maps.Slons.pathmodel(), Maps.Slons.spawner(), Maps.Slons.areas(), "MusicDarkA", "Slons", "Meme"),
            new MapData("SnowMonkey", MapDifficulty.Beginner, Maps.SnowMonkey.pathmodel(), Maps.SnowMonkey.spawner(), Maps.SnowMonkey.areas(), "MusicDarkA", "Snow Monkey", "BTD 4"),
            new MapData("SprintTrack", MapDifficulty.Beginner, Maps.SprintTrack.pathmodel(), Maps.SprintTrack.spawner(), Maps.SprintTrack.areas(), "MusicBTD5JazzA", "Sprint Track", "BTD 5"),
            new MapData("TheRink", MapDifficulty.Beginner, Maps.TheRink.pathmodel(), Maps.TheRink.spawner(), Maps.TheRink.areas(), "MusicBTD5JazzA", "The Rink", "BTD 5"),
            new MapData("ToxicWaste", MapDifficulty.Expert, Maps.ToxicWaste.pathmodel(), Maps.ToxicWaste.spawner(), Maps.ToxicWaste.areas(), "MusicBTD5JazzA", "Toxic Waste", "BTD 5"),
            new MapData("TrueTrueExpert", MapDifficulty.Expert, Maps.TrueTrueExpert.pathmodel(), Maps.TrueTrueExpert.spawner(), Maps.TrueTrueExpert.areas(), "MusicDarkA", "True True Expert", "Meme"),
            new MapData("BTD6IRL", MapDifficulty.Expert, Maps.BTD6IRL.pathmodel(), Maps.BTD6IRL.spawner(), Maps.BTD6IRL.areas(), "MusicDarkA", "BTD 6 IRL", "Meme"),
            new MapData("TheSkeld", MapDifficulty.Expert, Maps.TheSkeld.pathmodel(), Maps.TheSkeld.spawner(), Maps.TheSkeld.areas(), "MusicDarkA", "The Skeld", "New"),
            new MapData("WaterHazard", MapDifficulty.Intermediate, Maps.WaterHazard.pathmodel(), Maps.WaterHazard.spawner(), Maps.WaterHazard.areas(), "MusicDarkA", "Water Hazard", "BTD 5"),
    };

        [HarmonyPatch(typeof(TitleScreen), "Start")]
        public class Awake_Patch
        {
            [HarmonyPostfix]
            public static void Postfix()
            {
                foreach (var mapdata in mapList)
                {
                    //Yes, there are more cleaner and easier ways, but each way I tried would somehow break the game
                    if (MemeMaps && mapdata.mapType == "Meme")
                    {
                        GameData._instance.mapSet.Maps.items = GameData._instance.mapSet.Maps.items.AddTo(new MapDetails
                        {
                            id = mapdata.name,
                            isBrowserOnly = false,
                            isDebug = false,
                            difficulty = mapdata.difficulty,
                            unlockDifficulty = MapDifficulty.Beginner,
                            mapMusic = mapdata.mapMusic,
                            mapSprite = ModContent.GetSpriteReference<Main>(mapdata.name),
                            coopMapDivisionType = CoopDivision.FREE_FOR_ALL,
                        }).ToArray();
                    }
                    if (OldMaps && mapdata.mapType == "Old")
                    {
                        GameData._instance.mapSet.Maps.items = GameData._instance.mapSet.Maps.items.AddTo(new MapDetails
                        {
                            id = mapdata.name,
                            isBrowserOnly = false,
                            isDebug = false,
                            difficulty = mapdata.difficulty,
                            unlockDifficulty = MapDifficulty.Beginner,
                            mapMusic = mapdata.mapMusic,
                            mapSprite = ModContent.GetSpriteReference<Main>(mapdata.name),
                            coopMapDivisionType = CoopDivision.FREE_FOR_ALL,
                        }).ToArray();
                    }
                    if (BTD4Maps && mapdata.mapType == "BTD 4")
                    {
                        GameData._instance.mapSet.Maps.items = GameData._instance.mapSet.Maps.items.AddTo(new MapDetails
                        {
                            id = mapdata.name,
                            isBrowserOnly = false,
                            isDebug = false,
                            difficulty = mapdata.difficulty,
                            unlockDifficulty = MapDifficulty.Beginner,
                            mapMusic = mapdata.mapMusic,
                            mapSprite = ModContent.GetSpriteReference<Main>(mapdata.name),
                            coopMapDivisionType = CoopDivision.FREE_FOR_ALL,
                        }).ToArray();
                    }
                    if (BTD5Maps && mapdata.mapType == "BTD 5")
                    {
                        GameData._instance.mapSet.Maps.items = GameData._instance.mapSet.Maps.items.AddTo(new MapDetails
                        {
                            id = mapdata.name,
                            isBrowserOnly = false,
                            isDebug = false,
                            difficulty = mapdata.difficulty,
                            unlockDifficulty = MapDifficulty.Beginner,
                            mapMusic = mapdata.mapMusic,
                            mapSprite = ModContent.GetSpriteReference<Main>(mapdata.name),
                            coopMapDivisionType = CoopDivision.FREE_FOR_ALL,
                        }).ToArray();
                    }
                    if (BTDBMaps && mapdata.mapType == "BTD B")
                    {
                        GameData._instance.mapSet.Maps.items = GameData._instance.mapSet.Maps.items.AddTo(new MapDetails
                        {
                            id = mapdata.name,
                            isBrowserOnly = false,
                            isDebug = false,
                            difficulty = mapdata.difficulty,
                            unlockDifficulty = MapDifficulty.Beginner,
                            mapMusic = mapdata.mapMusic,
                            mapSprite = ModContent.GetSpriteReference<Main>(mapdata.name),
                            coopMapDivisionType = CoopDivision.FREE_FOR_ALL,
                        }).ToArray();
                    }
                    if (BMCMaps && mapdata.mapType == "BMC")
                    {
                        GameData._instance.mapSet.Maps.items = GameData._instance.mapSet.Maps.items.AddTo(new MapDetails
                        {
                            id = mapdata.name,
                            isBrowserOnly = false,
                            isDebug = false,
                            difficulty = mapdata.difficulty,
                            unlockDifficulty = MapDifficulty.Beginner,
                            mapMusic = mapdata.mapMusic,
                            mapSprite = ModContent.GetSpriteReference<Main>(mapdata.name),
                            coopMapDivisionType = CoopDivision.FREE_FOR_ALL,
                        }).ToArray();
                    }
                    if (NewMaps && mapdata.mapType == "New")
                    {
                        GameData._instance.mapSet.Maps.items = GameData._instance.mapSet.Maps.items.AddTo(new MapDetails
                        {
                            id = mapdata.name,
                            isBrowserOnly = false,
                            isDebug = false,
                            difficulty = mapdata.difficulty,
                            unlockDifficulty = MapDifficulty.Beginner,
                            mapMusic = mapdata.mapMusic,
                            mapSprite = ModContent.GetSpriteReference<Main>(mapdata.name),
                            coopMapDivisionType = CoopDivision.FREE_FOR_ALL,
                        }).ToArray();
                    }
                    if (!LocalizationManager.Instance.textTable.ContainsKey(mapdata.name))
                    {
                        LocalizationManager.Instance.textTable.Add(mapdata.name, mapdata.mapDisplayName);
                    }
                }
            }
        }


        /*[HarmonyPatch(typeof(MapButton), "ShowMedal")]
        public class ShowMedal_Patch2
        {
            [HarmonyPrefix]
            public static bool Prefix(MapButton __instance, Btd6Player player, Animator medalAnimator, string mapId, string difficulty, string mode)
            {


                foreach (var mapData in mapList)
                {
                    player.UnlockMap(mapData.name);

                }

                return true;
            }
        }*/

        public override void OnUpdate()
        {
            base.OnUpdate();

            bool inAGame = InGame.instance != null && InGame.instance.bridge != null;
            if (inAGame)
            {
                if(Input.GetKeyDown(KeyCode.F9))
                {
                    foreach(var mapData in mapList)
                    {
                        Game.instance.GetBtd6Player().UnlockMap(mapData.name);
                        InGame.instance.Player.UnlockMap(mapData.name);
                    }
                }
            }
        }


        [HarmonyPatch(typeof(MapLoader), nameof(MapLoader.Load))]
        public class LoadMap
        {
            [HarmonyPrefix]
            internal static bool Fix(ref MapLoader __instance, ref string map, ref CoopDivision coopDivisionType, ref Il2CppSystem.Action<MapModel> loadedCallback)
            {
                LastMap = map;
                if (isCustom(LastMap))
                {
                    map = "MuddyPuddles";

                }

                return true;
            }
        }
        static bool shouldRun = true;


        [HarmonyPatch(typeof(UnityToSimulation), nameof(UnityToSimulation.InitMap))]
        internal class InitMap_Patch
        {
            [HarmonyPrefix]
            internal static bool Prefix(UnityToSimulation __instance, ref MapModel map)
            {

                if (!isCustom(LastMap)) return true;
                MapData mapdata = mapList.Where(x => x.name == LastMap).First();
                Texture2D tex = ModContent.GetTexture<Main>(mapdata.name);
                byte[] filedata = null;
                filedata = Resize(ImageConversion.EncodeToPNG(tex), 1652, 1064);
                float divx = 2;
                float divy = 1.21f;
                int marginx = 450;
                int marginy = 890;
                Bitmap old = new Bitmap(System.Drawing.Image.FromStream(new MemoryStream(filedata)));//new Bitmap(filePath);
                Bitmap newImage = new Bitmap(old.Width + marginx, old.Height + marginy);
                using (var graphics = System.Drawing.Graphics.FromImage(newImage))
                {
                    //graphics.Clear(paddingColor);
                    int x = (int)((newImage.Width - old.Width) / divx);
                    int y = (int)((newImage.Height - old.Height) / divy);
                    graphics.DrawImage(old, x, y);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                        filedata = ms.ToArray();
                    }
                }
                ImageConversion.LoadImage(tex, filedata);
                var ob2 = GameObject.Find("MuddyPuddlesTerrain");
                ob2.GetComponent<Renderer>().material.mainTexture = tex;
                foreach (var ob in UnityEngine.Object.FindObjectsOfType<GameObject>())
                {
                    if (ob.name.Contains("Festive") || ob.name.Contains("Rocket") || ob.name.Contains("Firework") || ob.name.Contains("Box") || ob.name.Contains("Candy") || ob.name.Contains("Gift") || ob.name.Contains("Snow") || ob.name.Contains("Ripples") || ob.name.Contains("Grass") || ob.name.Contains("Christmas") || ob.name.Contains("WhiteFlower") || ob.name.Contains("Tree") || ob.name.Contains("Rock") || ob.name.Contains("Shadow") || ob.name.Contains("WaterSplashes"))// || ob.name.Contains("Body")   || ob.name.Contains("Ouch") || ob.name.Contains("Statue")|| ob.name.Contains("Chute")  || ob.name.Contains("Jump") || ob.name.Contains("Timer") || ob.name.Contains("Wheel") || ob.name.Contains("Body") || ob.name.Contains("Axle") || ob.name.Contains("Leg") || ob.name.Contains("Clock") ||
                        if (ob.name != "MuddyPuddlesTerrain")
                            ob.transform.position = new Vector3(1000, 1000, 1000);
                }

                map.areas = mapdata.areas;
                map.spawner = mapdata.spawner;
                map.paths = mapdata.paths;

                if (GameObject.Find("Rain"))
                    GameObject.Find("Rain").active = false;
                map.name = mapdata.name;
                map.mapName = mapdata.name;
                return true;
            }

        }
        public static byte[] Resize(byte[] data, int width, int height)
        {
            using (var stream = new MemoryStream(data))
            {
                var image = System.Drawing.Image.FromStream(stream);

                //var height = (width * image.Height) / image.Width;
                //var thumbnail = image.GetThumbnailImage(width, height, null, IntPtr.Zero);
                Bitmap b = ResizeImage(image, width, height);//new Bitmap(image, 1652, 1064);
                //b.Save("test.png", ImageFormat.Png);

                using (var thumbnailStream = new MemoryStream())
                {
                    b.Save(thumbnailStream, ImageFormat.Png);
                    return thumbnailStream.ToArray();
                }
            }
        }
        public static Bitmap ResizeImage(System.Drawing.Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = System.Drawing.Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }




    }

}