using UnityEngine;

class PlayerChangeState : StateBase
{
    const float speed = 20;

    string name;
    Camera camera;
    Vector3 target;
    CharacterController characterController;

    public PlayerChangeState(string name)
    {
        this.name = name;
        camera = Camera.main;
        target = MainController.playerObjects[name].transform.position + MainController.cameraOffset;
        characterController = camera.GetComponent<CharacterController>();
    }

    public override void Update()
    {
        var v = target - camera.transform.position;
        if (0.1 < v.sqrMagnitude)
        {
            characterController.Move(v.normalized * speed * Time.deltaTime);
        }
        else
        {
            camera.transform.position = target;
            Transition(new WaitState(name));
        }
    }
}