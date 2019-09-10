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
            new { key = "A", x = 6, y = 0, z = -6 },
            new { key = "B", x = 2, y = 0, z = -6 },
            new { key = "C", x = 6, y = 0, z = -2 },
            new { key = "D", x = 2, y = 0, z = -2 },
            new { key = "E", x = -2, y = 0, z = -2 },
            new { key = "F", x = 2, y = 0, z = 2 },
            new { key = "G", x = -2, y = 0, z = 2 },
            new { key = "H", x = -6, y = 0, z = 2 },
            new { key = "I", x = -2, y = 0, z = 6 },
            new { key = "J", x = -6, y = 0, z = 6 },
        };

        var links_source = new[] {
            new { source = "A", target = "B" },
            new { source = "A", target = "C" },
            new { source = "B", target = "D" },
            new { source = "C", target = "D" },
            new { source = "D", target = "E" },
            new { source = "D", target = "F" },
            new { source = "E", target = "G" },
            new { source = "F", target = "G" },
            new { source = "G", target = "H" },
            new { source = "G", target = "I" },
            new { source = "H", target = "J" },
            new { source = "I", target = "J" },
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