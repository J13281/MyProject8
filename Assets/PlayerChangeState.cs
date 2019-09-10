class PlayerChangeState : StateBase
{
    string name;

    public PlayerChangeState(string name)
    {
        this.name = name;
    }

    public override void Update()
    {
        Transition(new WaitState(name));
    }
}