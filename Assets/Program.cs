using System;
using System.Collections.Generic;
using UnityEngine;

class Program
{
    public static void LoadTestData(
        out Dictionary<string, Vector3> points,
        out Dictionary<string, HashSet<string>> links,
        out Dictionary<string, string> playerPositions)
    {
        /* testdata */
        var points_source = new[] {
            new { key = "A", x = 2, y = 0, z = -4 },
            new { key = "B", x = -4, y = 0, z = -4 },
            new { key = "C", x = 4, y = 0, z = 1 },
            new { key = "D", x = -2, y = 0, z = 1 },
        };

        var links_source = new[] {
            new { source = "C", target = "A" },
            new { source = "A", target = "D" },
            new { source = "D", target = "B" },
        };

        var players_source = new[] {
            new { name = "daichi", pos = "A" },
            new { name = "takahiro", pos = "B" },
        };
        /* testdata */


        points = new Dictionary<string, Vector3>();

        foreach (var item in points_source)
            points[item.key] = new Vector3(item.x, item.y, item.z);

        links = new Dictionary<string, HashSet<string>>();

        foreach (var item in points_source)
            links[item.key] = new HashSet<string>();

        foreach (var item in links_source)
        {
            links[item.source].Add(item.target);
            links[item.target].Add(item.source);
        }

        playerPositions = new Dictionary<string, string>();
        foreach (var item in players_source)
            playerPositions[item.name] = item.pos;
    }
}