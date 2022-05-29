using System;
using PathCreation;
using UnityEngine;

namespace Runner.Level.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;

        private PlayerAnimator _animator;
        private Rigidbody _rigidbody;
        private float _distanceTravelled;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<PlayerAnimator>();
        }

        public void Move(VertexPath pathCreatorPath)
        {
            _animator.MoveAnimation(1f);
            _distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreatorPath.GetPointAtDistance(_distanceTravelled, EndOfPathInstruction.Stop);
            transform.rotation = pathCreatorPath.GetRotationAtDistance(_distanceTravelled, EndOfPathInstruction.Stop);
        }

        public void Stop()
        {
            _animator.MoveAnimation(0f);
        }
    }
}