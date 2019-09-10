using System.Collections.Generic;
using UnityEngine;

class WaitState : StateBase
{
    const float rayRange = 100;
    string name;

    string current;
    HashSet<string> nexts;

    public WaitState(string name)
    {
        this.name = name;
        current = MainController.playerPositions[name];
        nexts = MainController.links[current];
    }

    public override void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, rayRange, LayerMask.GetMask("Trigger")))
            {
                var next = hit.transform.name;
                if (nexts.Contains(next))
                {
                    MainController.playerPositions[name] = next;
                    Transition(new MoveState(name));
                }
            }
        }
    }

    public override void OnButtonClick(string s)
    {
        var nextPlayer = name == "daichi" ? "takahiro" : "daichi";
        Transition(new PlayerChangeState(nextPlayer));
    }
}