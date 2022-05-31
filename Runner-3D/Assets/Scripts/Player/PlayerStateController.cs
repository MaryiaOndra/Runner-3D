using System;
using System.Collections;
using System.Collections.Generic;
using Player.States;
using UnityEngine;

namespace Player
{
    public class PlayerStateController : MonoBehaviour
    {
        private IPlayerStateBehaviour _currentState;
        private List<IPlayerStateBehaviour> _allStates = new List<IPlayerStateBehaviour>();

        private void Start()
        {
            CreateStates();
            InitStates();
            SwitchState(State.Idle);
        }

        private void CreateStates()
        {
            IdlePlayerState idlePlayerState = new IdlePlayerState();
            RunPlayerState runPlayerState = new RunPlayerState();
            FallPlayerState fallPlayerState = new FallPlayerState();
            WinPlayerState winPlayerState = new WinPlayerState();
            _allStates.Add(idlePlayerState);
            _allStates.Add(runPlayerState);
            _allStates.Add(fallPlayerState);
            _allStates.Add(winPlayerState);
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
