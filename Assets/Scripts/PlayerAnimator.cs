using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        if (_animator == null) _animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _animator.SetFloat("Speed", _rigidbody.velocity.magnitude);
    }
}
