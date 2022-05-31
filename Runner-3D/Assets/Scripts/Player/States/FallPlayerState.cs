using System;
using UnityEngine;

namespace Player.States
{
    public class FallPlayerState : IPlayerStateBehaviour
    {
        private PlayerStateController _stateController;
        public event Action<State> OnSwitchState;
        public State State => State.Fall;

        PlayerStateController IPlayerStateBehaviour.StateController => _stateController;

        public void EnterState(PlayerStateController stateController)
        {
            _stateController = stateController;
        }

        public void UpdateState()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnSwitchState(State.Win);
            }
        }

        public void OnCollisionState(Collision collision)
        {
            throw new System.NotImplementedException();
        }
    }
}