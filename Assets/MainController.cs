using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class MainController : MonoBehaviour
{
    public static Vector3 cameraOffset = new Vector3(0, 8, 4);

    public static Dictionary<string, Vector3> points;
    public static Dictionary<string, HashSet<string>> links;
    public static Dictionary<string, string> playerPositions;

    public static Dictionary<string, GameObject> playerObjects;
    public static StateBase current;

    public void Start()
    {
        Program.LoadTestData(out points, out links, out playerPositions);

        playerObjects = new Dictionary<string, GameObject>();

        var playerPrefab = Resources.Load("playerPrefab") as GameObject;
        foreach (var item in playerPositions)
        {
            var obj = Instantiate(playerPrefab);
            obj.name = item.Key;
            obj.transform.position = points[playerPositions[item.Key]];
            playerObjects[item.Key] = obj;
        }

        var triggerPrefab = Resources.Load("triggerPrefab") as GameObject;
        foreach (var item in points)
        {
            var obj = Instantiate(triggerPrefab);
            obj.name = item.Key;
            obj.transform.position = item.Value;
        }

        current = new PlayerChangeState("daichi");
    }

    public void Update()
    {
        current.Update();
        if (current.IsComplate)
        {
            current = current.nextState;
        }
    }
}
