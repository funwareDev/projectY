using UnityEngine;

namespace PlayerStates
{
    public class MovingState : BaseState
    {
        private PlayerStateMachine _playerStateMachine;

        public MovingState(PlayerStateMachine playerStateMachine)
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
