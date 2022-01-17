using UnityEngine;

namespace PlayerStates
{
    public class DeadState : BaseState
    {
        private PlayerStateMachine _playerStateMachine;

        public DeadState(PlayerStateMachine playerStateMachine)
        {
            _playerStateMachine = playerStateMachine;
        }

        public void Enter()
        {
            throw new System.NotImplementedException();
        }

        public void Exit()
        {
            throw new System.NotImplementedException();
        }

        public void FixedTick()
        {
            throw new System.NotImplementedException();
        }

        public void Tick()
        {
            throw new System.NotImplementedException();
        }
    }
}

