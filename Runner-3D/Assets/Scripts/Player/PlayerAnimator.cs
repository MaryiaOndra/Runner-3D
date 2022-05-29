using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private readonly int _moveId = Animator.StringToHash("MoveSpeed");

    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void MoveAnimation(float speed)
    {
        Debug.Log("Speed:" + speed);
        _animator.SetFloat(_moveId, speed);
    }
}
