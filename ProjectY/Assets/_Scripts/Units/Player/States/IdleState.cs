using UnityEngine;

namespace PlayerStates
{
    public class IdleState : BaseState
    {
        private PlayerStateMachine _playerStateMachine;

        public IdleState(PlayerStateMachine playerStateMachine) 
        {
            _playerStateMachine = playerStateMachine;
        }
        public void Enter()
        {
            Debug.Log("Entered idle state");
        }

        public void Exit()
        {

        }

        public void FixedTick()
        {

        }

        public void Tick()
        {
            throw new System.NotImplementedException();
        }
    }
}

