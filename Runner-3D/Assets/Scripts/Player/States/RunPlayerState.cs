using System;
using UnityEngine;

namespace Player.States
{
    public class RunPlayerState : IPlayerStateBehaviour
    {
        private PlayerStateController _stateController;
        public event Action<State> OnSwitchState;
        public State State => State.Run;

        PlayerStateController IPlayerStateBehaviour.StateController => _stateController;

        public void EnterState(PlayerStateController stateController)
        {
            _stateController = stateController;
        }

        public void UpdateState()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnSwitchState(State.Fall);
            }
        }

        public void OnCollisionState(Collision collision)
        {
            //throw new System.NotImplementedException();
        }
    }
}