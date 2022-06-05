using System;
using Platform;
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
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                OnSwitchState(State.Idle);
            }
        }

        public void OnCollisionState(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(typeof(Obstacle) , out _))
            {
                Debug.Log("RUN: Obstacle hit!!");
                OnSwitchState(State.Fall);
            }
            else if (collision.gameObject.TryGetComponent<Finish>(out _))
            {
                OnSwitchState(State.Win);
            }
        }
    }
}