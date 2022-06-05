using System;
using System.Collections;
using System.Collections.Generic;
using Player.States;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(PlayerAnimatorController))]
    public class PlayerStateController : MonoBehaviour
    {
        private PlayerAnimatorController _animatorController;
        private IPlayerStateBehaviour _currentState;
        private List<IPlayerStateBehaviour> _allStates = new List<IPlayerStateBehaviour>();
        private RagdollController _ragdollController;
        private Rigidbody _rigidbody;
        
        public PlayerAnimatorController AnimatorController => _animatorController;
        public Rigidbody Rigidbody => _rigidbody;
        public RagdollController Ragdoll => _ragdollController;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animatorController = GetComponent<PlayerAnimatorController>();
            
            CreateStates();
            InitStates();
            SwitchState(State.Idle);
            _ragdollController = new RagdollController(this);
            _ragdollController.SetRagdollParts();
        }

        private void CreateStates()
        {
            IdlePlayerState idlePlayerState = new IdlePlayerState();
            RunPlayerState runPlayerState = new RunPlayerState();
            FallPlayerState fallPlayerState = new FallPlayerState();
            WinPlayerState winPlayerState = new WinPlayerState();
            
            _allStates = new List<IPlayerStateBehaviour>
            {
                idlePlayerState,
                runPlayerState,
                fallPlayerState,
                winPlayerState
            };
        }

        private void InitStates()
        {
            _allStates.ForEach(state => state.OnSwitchState += SwitchState);
        }

        private void Update()
        {
            _currentState.UpdateState();
        }

        private void OnCollisionEnter(Collision collision)
        {
            _currentState.OnCollisionState(collision);
        }

        private void SwitchState(State currentState)
        {
            IPlayerStateBehaviour newCurrentState = _allStates.Find(state => state.State == currentState);
            Debug.Log($"SWITCH STATE FROM :{_currentState?.State}: TO :{newCurrentState.State}: ");
            _currentState = newCurrentState;
            _currentState.EnterState(this);
        }

        private void OnDestroy()
        {
            _allStates.ForEach(state => state.OnSwitchState -= SwitchState);
        }
    }
}
