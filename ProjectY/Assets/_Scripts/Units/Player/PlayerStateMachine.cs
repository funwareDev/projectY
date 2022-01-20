using UnityEngine;
using PlayerStates;

[RequireComponent(typeof(Player))]
public class PlayerStateMachine : StateMachineMB
{
    public Player Player { get; private set; }

    public IdleState IdleState { get; private set; }
    public MovingState MovingState { get; private set; }
    public AttackingState AttackingState { get; private set; }
    public DeadState DeadState { get; private set; }

    private void OnEnable()
    {
        IdleState = new IdleState(this);
        MovingState = new MovingState(this);
        AttackingState = new AttackingState(this);
        DeadState = new DeadState(this);
    }

    private void Start()
    {
        ChangeState(IdleState);
    }
}
