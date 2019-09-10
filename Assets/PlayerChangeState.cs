using UnityEngine;

class PlayerChangeState : StateBase
{
    string name;

    public PlayerChangeState(string name)
    {
        this.name = name;
    }

    public override void Update()
    {
        Camera.main.transform.position = MainController.playerObjects[name].transform.position + MainController.cameraOffset;
        Transition(new WaitState(name));
    }
}