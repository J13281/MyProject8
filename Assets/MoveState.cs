using UnityEngine;

class MoveState : StateBase
{
    const float speed = 200;

    string name;

    GameObject player;
    Vector3 target;
    Animator animator;

    CharacterController characterController;

    public MoveState(string name)
    {
        this.name = name;
        player = MainController.playerObjects[name];
        target = MainController.points[MainController.playerPositions[name]];
        characterController = player.GetComponent<CharacterController>();
        animator = player.GetComponent<Animator>();

        characterController.enabled = true;
    }

    public override void Update()
    {
        var diff = target - player.transform.position;

        Camera.main.transform.position = player.transform.position + MainController.cameraOffset;

        animator.SetFloat("speed", diff.sqrMagnitude);
        if (0.01 < diff.sqrMagnitude)
        {
            var moveDirection = diff.normalized;
            player.transform.rotation = Quaternion.RotateTowards(
                player.transform.rotation,
                Quaternion.LookRotation(new Vector3(moveDirection.x, 0, moveDirection.z)),
                300 * Time.deltaTime);


            characterController.SimpleMove(diff.normalized * speed * Time.deltaTime);
        }
        else
        {
            characterController.enabled = false;
            Transition(new WaitState(name));
        }
    }
}