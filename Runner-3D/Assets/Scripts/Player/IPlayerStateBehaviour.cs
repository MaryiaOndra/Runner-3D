using System;
using UnityEngine;

namespace Player
{
    public interface IPlayerStateBehaviour
    {
        public event Action<State> OnSwitchState;
        public State State { get;}
        protected PlayerStateController StateController { get; }
        public void EnterState(PlayerStateController stateController);
        public void UpdateState();
        public void OnCollisionState(Collision collision);
    }

    public enum State
    {
        Idle,
        Fall,
        Run,
        Win
    }
}