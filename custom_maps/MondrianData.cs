﻿using MelonLoader;
using Harmony;

using Assets.Scripts.Unity.UI_New.InGame.Races;
using Assets.Scripts.Simulation.Towers.Weapons;

using Assets.Scripts.Simulation;
using Assets.Scripts.Unity.UI_New.InGame;

using Assets.Scripts.Unity.UI_New.Main;

using Assets.Scripts.Simulation.Bloons;
using Assets.Scripts.Models.Towers;

using Assets.Scripts.Unity;




using Assets.Scripts.Simulation.Towers;


using Assets.Scripts.Utils;


//using Il2CppSystem.Collections;


using Assets.Scripts.Unity.UI_New.Popups;
using System.Reflection;
using Assets.Scripts.Models;
using System.Collections.Generic;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Assets.Scripts.Models.GenericBehaviors;
using System;
using System.Linq;
using Assets.Scripts.Models.ServerEvents;
using Assets.Scripts.Data.Cosmetics.Pets;
using Assets.Main.Scenes;
using UnhollowerBaseLib;

using Assets.Scripts.Models.Rounds;
using Assets.Scripts.Models.Store;
using Assets.Scripts.Unity.Bridge;
using Assets.Scripts.Models.Map;
using UnityEngine;
using System.IO;
using UnhollowerRuntimeLib;
using Assets.Scripts.Models.Map.Spawners;

namespace custom_maps
{
    class MondrianData
    {

        public static System.Random r = new System.Random();
        public static Il2CppReferenceArray<PointInfo> track1()
        {
            List<PointInfo> list = new List<PointInfo>();
            list.Add(new PointInfo() { bloonScale = 1, bloonsInvulnerable = false, distance = 1, id = r.NextDouble() + "", moabScale = 1, moabsInvulnerable = false, rotation = 0, point = new Assets.Scripts.Simulation.SMath.Vector3(-146.8519f, 5.962958f) });
            list.Add(new PointInfo() { bloonScale = 1, bloonsInvulnerable = false, distance = 1, id = r.NextDouble() + "", moabScale = 1, moabsInvulnerable = false, rotation = 0, point = new Assets.Scripts.Simulation.SMath.Vector3(-102.2222f, 5.324084f) });
            list.Add(new PointInfo() { bloonScale = 1, bloonsInvulnerable = false, distance = 1, id = r.NextDouble() + "", moabScale = 1, moabsInvulnerable = false, rotation = 0, point = new Assets.Scripts.Simulation.SMath.Vector3(-101.2963f, -53.2407f) });
            list.Add(new PointInfo() { bloonScale = 1, bloonsInvulnerable = false, distance = 1, id = r.NextDouble() + "", moabScale = 1, moabsInvulnerable = false, rotation = 0, point = new Assets.Scripts.Simulation.SMath.Vector3(45.92593f, -51.53704f) });
            list.Add(new PointInfo() { bloonScale = 1, bloonsInvulnerable = false, distance = 1, id = r.NextDouble() + "", moabScale = 1, moabsInvulnerable = false, rotation = 0, point = new Assets.Scripts.Simulation.SMath.Vector3(46.29631f, 49.40746f) });
            list.Add(new PointInfo() { bloonScale = 1, bloonsInvulnerable = false, distance = 1, id = r.NextDouble() + "", moabScale = 1, moabsInvulnerable = false, rotation = 0, point = new Assets.Scripts.Simulation.SMath.Vector3(-53.70371f, 47.27774f) });
            list.Add(new PointInfo() { bloonScale = 1, bloonsInvulnerable = false, distance = 1, id = r.NextDouble() + "", moabScale = 1, moabsInvulnerable = false, rotation = 0, point = new Assets.Scripts.Simulation.SMath.Vector3(-55.00001f, -52.81479f) });
            list.Add(new PointInfo() { bloonScale = 1, bloonsInvulnerable = false, distance = 1, id = r.NextDouble() + "", moabScale = 1, moabsInvulnerable = false, rotation = 0, point = new Assets.Scripts.Simulation.SMath.Vector3(45.37038f, -51.53704f) });
            list.Add(new PointInfo() { bloonScale = 1, bloonsInvulnerable = false, distance = 1, id = r.NextDouble() + "", moabScale = 1, moabsInvulnerable = false, rotation = 0, point = new Assets.Scripts.Simulation.SMath.Vector3(45.37038f, 91.57408f) });
            list.Add(new PointInfo() { bloonScale = 1, bloonsInvulnerable = false, distance = 1, id = r.NextDouble() + "", moabScale = 1, moabsInvulnerable = false, rotation = 0, point = new Assets.Scripts.Simulation.SMath.Vector3(-99.44446f, 89.23154f) });
            list.Add(new PointInfo() { bloonScale = 1, bloonsInvulnerable = false, distance = 1, id = r.NextDouble() + "", moabScale = 1, moabsInvulnerable = false, rotation = 0, point = new Assets.Scripts.Simulation.SMath.Vector3(-100.5556f, 43.65746f) });
            list.Add(new PointInfo() { bloonScale = 1, bloonsInvulnerable = false, distance = 1, id = r.NextDouble() + "", moabScale = 1, moabsInvulnerable = false, rotation = 0, point = new Assets.Scripts.Simulation.SMath.Vector3(-146.6667f, 43.44451f) });
            return list.ToArray();
        }
        public static Il2CppReferenceArray<PointInfo> track2()
        {
            List<PointInfo> list = new List<PointInfo>();
            list.Add(new PointInfo() { bloonScale = 1, bloonsInvulnerable = false, distance = 1, id = r.NextDouble() + "", moabScale = 1, moabsInvulnerable = false, rotation = 0, point = new Assets.Scripts.Simulation.SMath.Vector3(147.5926f, -52.17591f) });
            list.Add(new PointInfo() { bloonScale = 1, bloonsInvulnerable = false, distance = 1, id = r.NextDouble() + "", moabScale = 1, moabsInvulnerable = false, rotation = 0, point = new Assets.Scripts.Simulation.SMath.Vector3(93.33334f, -53.87958f) });
            list.Add(new PointInfo() { bloonScale = 1, bloonsInvulnerable = false, distance = 1, id = r.NextDouble() + "", moabScale = 1, moabsInvulnerable = false, rotation = 0, point = new Assets.Scripts.Simulation.SMath.Vector3(92.5926f, -97.11112f) });
            list.Add(new PointInfo() { bloonScale = 1, bloonsInvulnerable = false, distance = 1, id = r.NextDouble() + "", moabScale = 1, moabsInvulnerable = false, rotation = 0, point = new Assets.Scripts.Simulation.SMath.Vector3(-54.44445f, -96.89817f) });
            list.Add(new PointInfo() { bloonScale = 1, bloonsInvulnerable = false, distance = 1, id = r.NextDouble() + "", moabScale = 1, moabsInvulnerable = false, rotation = 0, point = new Assets.Scripts.Simulation.SMath.Vector3(-53.88889f, 45.57409f) });
            list.Add(new PointInfo() { bloonScale = 1, bloonsInvulnerable = false, distance = 1, id = r.NextDouble() + "", moabScale = 1, moabsInvulnerable = false, rotation = 0, point = new Assets.Scripts.Simulation.SMath.Vector3(46.11111f, 46.42591f) });
            list.Add(new PointInfo() { bloonScale = 1, bloonsInvulnerable = false, distance = 1, id = r.NextDouble() + "", moabScale = 1, moabsInvulnerable = false, rotation = 0, point = new Assets.Scripts.Simulation.SMath.Vector3(45.92593f, -54.09253f) });
            list.Add(new PointInfo() { bloonScale = 1, bloonsInvulnerable = false, distance = 1, id = r.NextDouble() + "", moabScale = 1, moabsInvulnerable = false, rotation = 0, point = new Assets.Scripts.Simulation.SMath.Vector3(-55.18519f, -53.87958f) });
            list.Add(new PointInfo() { bloonScale = 1, bloonsInvulnerable = false, distance = 1, id = r.NextDouble() + "", moabScale = 1, moabsInvulnerable = false, rotation = 0, point = new Assets.Scripts.Simulation.SMath.Vector3(-53.88889f, 44.5093f) });
            list.Add(new PointInfo() { bloonScale = 1, bloonsInvulnerable = false, distance = 1, id = r.NextDouble() + "", moabScale = 1, moabsInvulnerable = false, rotation = 0, point = new Assets.Scripts.Simulation.SMath.Vector3(92.22222f, 44.5093f) });
            list.Add(new PointInfo() { bloonScale = 1, bloonsInvulnerable = false, distance = 1, id = r.NextDouble() + "", moabScale = 1, moabsInvulnerable = false, rotation = 0, point = new Assets.Scripts.Simulation.SMath.Vector3(92.77778f, -15.7593f) });
            list.Add(new PointInfo() { bloonScale = 1, bloonsInvulnerable = false, distance = 1, id = r.NextDouble() + "", moabScale = 1, moabsInvulnerable = false, rotation = 0, point = new Assets.Scripts.Simulation.SMath.Vector3(147.7778f, -15.12028f) });
            return list.ToArray();
        }






        public static Il2CppReferenceArray<AreaModel> areas()
        {
            List<AreaModel> newareas = new List<AreaModel>();
            var area0 = new Il2CppSystem.Collections.Generic.List<Assets.Scripts.Simulation.SMath.Vector2>();
            area0.Add(new Assets.Scripts.Simulation.SMath.Vector2(-147.2222f, -114.787f));
            area0.Add(new Assets.Scripts.Simulation.SMath.Vector2(148.5185f, -114.787f));
            area0.Add(new Assets.Scripts.Simulation.SMath.Vector2(147.7778f, 115f));
            area0.Add(new Assets.Scripts.Simulation.SMath.Vector2(-146.8519f, 114.5741f));
            newareas.Add(new AreaModel("lol0", new Assets.Scripts.Simulation.SMath.Polygon(area0), 10, (AreaType)2));
            var area1 = new Il2CppSystem.Collections.Generic.List<Assets.Scripts.Simulation.SMath.Vector2>();
            area1.Add(new Assets.Scripts.Simulation.SMath.Vector2(-146.8519f, 1.277887f));
            area1.Add(new Assets.Scripts.Simulation.SMath.Vector2(-110.9259f, 0.851831f));
            area1.Add(new Assets.Scripts.Simulation.SMath.Vector2(-110.5556f, -57.92591f));
            area1.Add(new Assets.Scripts.Simulation.SMath.Vector2(-108.7037f, -62.61113f));
            area1.Add(new Assets.Scripts.Simulation.SMath.Vector2(-104.2593f, -65.80549f));
            area1.Add(new Assets.Scripts.Simulation.SMath.Vector2(50.55557f, -65.80549f));
            area1.Add(new Assets.Scripts.Simulation.SMath.Vector2(54.44445f, -63.03704f));
            area1.Add(new Assets.Scripts.Simulation.SMath.Vector2(57.22224f, -57.92591f));
            area1.Add(new Assets.Scripts.Simulation.SMath.Vector2(57.22224f, 104.3518f));
            area1.Add(new Assets.Scripts.Simulation.SMath.Vector2(55.00001f, 110.3148f));
            area1.Add(new Assets.Scripts.Simulation.SMath.Vector2(49.25926f, 113.9352f));
            area1.Add(new Assets.Scripts.Simulation.SMath.Vector2(-102.963f, 114.1482f));
            area1.Add(new Assets.Scripts.Simulation.SMath.Vector2(-106.8519f, 112.4445f));
            area1.Add(new Assets.Scripts.Simulation.SMath.Vector2(-109.4445f, 107.3334f));
            area1.Add(new Assets.Scripts.Simulation.SMath.Vector2(-110.7408f, 64.31479f));
            area1.Add(new Assets.Scripts.Simulation.SMath.Vector2(-147.5926f, 64.10183f));
            area1.Add(new Assets.Scripts.Simulation.SMath.Vector2(-147.4074f, 39.18521f));
            area1.Add(new Assets.Scripts.Simulation.SMath.Vector2(-111.4815f, 39.61113f));
            area1.Add(new Assets.Scripts.Simulation.SMath.Vector2(-111.4815f, 25.34254f));
            area1.Add(new Assets.Scripts.Simulation.SMath.Vector2(-146.8519f, 24.06479f));
            area1.Add(new Assets.Scripts.Simulation.SMath.Vector2(-146.8519f, 2.342676f));
            area1.Add(new Assets.Scripts.Simulation.SMath.Vector2(-111.1111f, 1.703662f));
            area1.Add(new Assets.Scripts.Simulation.SMath.Vector2(-92.5926f, -44.93507f));
            area1.Add(new Assets.Scripts.Simulation.SMath.Vector2(36.48148f, -42.59253f));
            area1.Add(new Assets.Scripts.Simulation.SMath.Vector2(37.03704f, 91.14817f));
            area1.Add(new Assets.Scripts.Simulation.SMath.Vector2(-89.07408f, 90.50929f));
            newareas.Add(new AreaModel("lol1", new Assets.Scripts.Simulation.SMath.Polygon(area1), 100f, AreaType.unplaceable, 0f, null, null, null, false, false, default));
            var area2 = new Il2CppSystem.Collections.Generic.List<Assets.Scripts.Simulation.SMath.Vector2>();
            area2.Add(new Assets.Scripts.Simulation.SMath.Vector2(147.963f, -63.88887f));
            area2.Add(new Assets.Scripts.Simulation.SMath.Vector2(105f, -64.10183f));
            area2.Add(new Assets.Scripts.Simulation.SMath.Vector2(103.3333f, -108.1852f));
            area2.Add(new Assets.Scripts.Simulation.SMath.Vector2(96.66668f, -113.9352f));
            area2.Add(new Assets.Scripts.Simulation.SMath.Vector2(-57.03704f, -113.9352f));
            area2.Add(new Assets.Scripts.Simulation.SMath.Vector2(-59.62963f, -112.4444f));
            area2.Add(new Assets.Scripts.Simulation.SMath.Vector2(-63.51852f, -108.1852f));
            area2.Add(new Assets.Scripts.Simulation.SMath.Vector2(-65.00001f, -100.9445f));
            area2.Add(new Assets.Scripts.Simulation.SMath.Vector2(-64.07408f, 58.9907f));
            area2.Add(new Assets.Scripts.Simulation.SMath.Vector2(-61.11112f, 62.18521f));
            area2.Add(new Assets.Scripts.Simulation.SMath.Vector2(-57.59259f, 65.16662f));
            area2.Add(new Assets.Scripts.Simulation.SMath.Vector2(-54.81482f, 66.4445f));
            area2.Add(new Assets.Scripts.Simulation.SMath.Vector2(96.4815f, 66.4445f));
            area2.Add(new Assets.Scripts.Simulation.SMath.Vector2(101.8519f, 62.61113f));
            area2.Add(new Assets.Scripts.Simulation.SMath.Vector2(104.2593f, 55.15746f));
            area2.Add(new Assets.Scripts.Simulation.SMath.Vector2(105f, -1.703662f));
            area2.Add(new Assets.Scripts.Simulation.SMath.Vector2(148.1482f, -2.129578f));
            area2.Add(new Assets.Scripts.Simulation.SMath.Vector2(147.7778f, -25.76845f));
            area2.Add(new Assets.Scripts.Simulation.SMath.Vector2(105f, -26.19437f));
            area2.Add(new Assets.Scripts.Simulation.SMath.Vector2(105.1852f, -39.82409f));
            area2.Add(new Assets.Scripts.Simulation.SMath.Vector2(149.6296f, -40.67591f));
            area2.Add(new Assets.Scripts.Simulation.SMath.Vector2(148.3333f, -62.39803f));
            area2.Add(new Assets.Scripts.Simulation.SMath.Vector2(84.25926f, -64.31479f));
            area2.Add(new Assets.Scripts.Simulation.SMath.Vector2(84.44446f, -91.14803f));
            area2.Add(new Assets.Scripts.Simulation.SMath.Vector2(-43.14816f, -90.72225f));
            area2.Add(new Assets.Scripts.Simulation.SMath.Vector2(-43.14816f, 42.80549f));
            area2.Add(new Assets.Scripts.Simulation.SMath.Vector2(83.33334f, 42.59253f));
            area2.Add(new Assets.Scripts.Simulation.SMath.Vector2(82.96297f, -91.78704f));
            newareas.Add(new AreaModel("lol2", new Assets.Scripts.Simulation.SMath.Polygon(area2), 100f, AreaType.unplaceable, 0f, null, null, null, false, false, default));
            var area3 = new Il2CppSystem.Collections.Generic.List<Assets.Scripts.Simulation.SMath.Vector2>();
            area3.Add(new Assets.Scripts.Simulation.SMath.Vector2(101.2963f, -3.407465f));
            area3.Add(new Assets.Scripts.Simulation.SMath.Vector2(84.44446f, -2.981409f));
            area3.Add(new Assets.Scripts.Simulation.SMath.Vector2(84.62964f, -92.85183f));
            area3.Add(new Assets.Scripts.Simulation.SMath.Vector2(101.2963f, -92.63887f));
            area3.Add(new Assets.Scripts.Simulation.SMath.Vector2(100.5556f, -4.046197f));
            newareas.Add(new AreaModel("lol0", new Assets.Scripts.Simulation.SMath.Polygon(area3), 100f, AreaType.unplaceable, 0f, null, null, null, false, false, default));
            var area4 = new Il2CppSystem.Collections.Generic.List<Assets.Scripts.Simulation.SMath.Vector2>();
            area4.Add(new Assets.Scripts.Simulation.SMath.Vector2(-146.6667f, 1.91662f));
            area4.Add(new Assets.Scripts.Simulation.SMath.Vector2(-110.9259f, 1.91662f));
            area4.Add(new Assets.Scripts.Simulation.SMath.Vector2(-110.1852f, -44.93507f));
            area4.Add(new Assets.Scripts.Simulation.SMath.Vector2(-89.07408f, -45.14817f));
            area4.Add(new Assets.Scripts.Simulation.SMath.Vector2(-89.81483f, 89.87042f));
            area4.Add(new Assets.Scripts.Simulation.SMath.Vector2(-110.1852f, 90.08338f));
            area4.Add(new Assets.Scripts.Simulation.SMath.Vector2(-110.1852f, 62.82408f));
            area4.Add(new Assets.Scripts.Simulation.SMath.Vector2(-146.6667f, 61.97225f));
            area4.Add(new Assets.Scripts.Simulation.SMath.Vector2(-147.5926f, 40.88887f));
            area4.Add(new Assets.Scripts.Simulation.SMath.Vector2(-110f, 39.82409f));
            area4.Add(new Assets.Scripts.Simulation.SMath.Vector2(-109.2593f, 24.7038f));
            area4.Add(new Assets.Scripts.Simulation.SMath.Vector2(-146.6667f, 23.85197f));
            area4.Add(new Assets.Scripts.Simulation.SMath.Vector2(-146.8519f, 2.342676f));
            newareas.Add(new AreaModel("lol1", new Assets.Scripts.Simulation.SMath.Polygon(area4), 100f, AreaType.unplaceable, 0f, null, null, null, false, false, default));

            return newareas.ToArray();


        }

        public static PathSpawnerModel spawner()
        {
            return new PathSpawnerModel("", new SplitterModel("", new string[]
                    {
                        "Path1",
                        "Path2",
                    }), new SplitterModel("", new string[]
                    {
                        "Path1",
                        "Path2",
                    }));
        }

        public static PathModel[] pathmodel()
        {
            return new PathModel[]
                    {
                        new PathModel("Path1", track1(), true, false, new Assets.Scripts.Simulation.SMath.Vector3(), new Assets.Scripts.Simulation.SMath.Vector3(), null, null),
                        new PathModel("Path2", track2(), true, false, new Assets.Scripts.Simulation.SMath.Vector3(), new Assets.Scripts.Simulation.SMath.Vector3(), null, null),
                    };
        }


    }
}