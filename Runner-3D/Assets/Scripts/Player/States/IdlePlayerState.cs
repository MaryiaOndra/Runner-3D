using System;
using Platform;
using UnityEngine;

namespace Player.States
{
    public class IdlePlayerState : IPlayerStateBehaviour
    {
        private PlayerStateController _stateController;
        public event Action<State> OnSwitchState;
        public State State => State.Idle;

        PlayerStateController IPlayerStateBehaviour.StateController => _stateController;

        public void EnterState(PlayerStateController stateController)
        {
            _stateController = stateController;
        }

        public void UpdateState()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                OnSwitchState(State.Run);
            }
        }

        public void OnCollisionState(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(typeof(Obstacle) , out _))
            {
                Debug.Log("IDLE: Obstacle hit!!");
                OnSwitchState(State.Fall);
            }
        }
    }
}