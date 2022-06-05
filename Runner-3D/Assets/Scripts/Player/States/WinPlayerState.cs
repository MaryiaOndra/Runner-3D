using System;
using Platform;
using UnityEngine;

namespace Player.States
{
    public class WinPlayerState: IPlayerStateBehaviour
    {
        private PlayerStateController _stateController;
        public event Action<State> OnSwitchState;
        public State State => State.Win;

        PlayerStateController IPlayerStateBehaviour.StateController => _stateController;

        public void EnterState(PlayerStateController stateController)
        {
            _stateController = stateController;
        }

        public void UpdateState()
        {
        }

        public void OnCollisionState(Collision collision)
        {

        }
    }
}