using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimatorController : MonoBehaviour
{
    private readonly int _moveId = Animator.StringToHash("MoveSpeed");
    public Animator Animator => _animator;
    private Animator _animator;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void MoveAnimation(float speed)
    {
        _animator.SetFloat(_moveId, speed);
    }
}
