using System.Collections.Generic;
using Player.States;
using UnityEngine;

namespace Player
{
    public class RagdollController
    {
        private PlayerStateController _player;
        private List<Collider> _ragdollParts = new List<Collider>();
        
        public RagdollController(PlayerStateController player)
        {
            _player = player;
        }

        public void SetRagdollParts()
        {
            Collider[] colliders = _player.GetComponentsInChildren<Collider>();

            foreach (var collider in colliders)
            {
                if (collider.gameObject != _player.gameObject)
                {
                    collider.isTrigger = true;
                    _ragdollParts.Add(collider);
                }
            }
        }

        public void TurnOnRagdoll()
        {
            _player.Rigidbody.useGravity = false;
            _player.Rigidbody.velocity = Vector3.zero;
            _player.GetComponent<CapsuleCollider>().enabled = false;
            _player.AnimatorController.Animator.enabled = false;
            _player.AnimatorController.Animator.avatar = null;
            
            foreach (var collider in _ragdollParts)
            {
                collider.isTrigger = false;
                collider.attachedRigidbody.velocity = Vector3.zero;
            }
        }
    }
}