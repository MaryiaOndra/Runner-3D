using System;
using System.Collections;
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
            _stateController.StartCoroutine(FallEffect());
        }

        private IEnumerator FallEffect()
        {
            Debug.Log("FALL!!!");
            _stateController.Rigidbody.AddForce(Vector3.right, ForceMode.Impulse);
            _stateController.Ragdoll.TurnOnRagdoll();
            yield return new WaitForSeconds(3f);
            Debug.Log("Return To  safe point");
        }

        public void UpdateState()
        {
        }

        public void OnCollisionState(Collision collision)
        {
        }
    }
}