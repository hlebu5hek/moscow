using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCtrl : MonoBehaviour
{
    public GameObject body;

    [SerializeField] protected Rigidbody _rb;
    [SerializeField] protected float _speed;
    [SerializeField] protected Vector2 _vector;
    [SerializeField] protected Transform target;

    [SerializeField] protected AnimationCurve _ease;
    [SerializeField] protected float _ease_t;
    [SerializeField] protected IEnumerator _ease_enum;

    public float Speed { get; private set; }

    protected virtual void Awake()
    {
        target.SetParent(null);
    }

    public virtual void SetVector(Vector2 _v)
    {
        _vector = _v;
    }

    public virtual void SetSpeed(float _s)
    {
        _speed = _s;
    }

    protected virtual void AddVector(Vector2 _v)
    {
        _vector += _v;
    }

    protected void Rotate(float angle)
    {
        transform.rotation =
            Quaternion.Euler(transform.rotation.eulerAngles.x, angle, transform.rotation.eulerAngles.z);
    }

    public void Rotate(Transform lookAt, bool alongY)
    {
        if (alongY)
            body.transform.LookAt(new Vector3(lookAt.position.x, transform.position.y, lookAt.position.z));
        else
            body.transform.LookAt(lookAt);
    }


    public virtual void Move()
    {
        _ease_enum = EaseW();
        StopCoroutine(_ease_enum);
        StartCoroutine(_ease_enum);
    }

    protected virtual IEnumerator EaseW()
    {
        Vector3 velA = _rb.velocity;
        Vector3 lookAtA = target.position;

        Vector3 velB = new(_vector.normalized.x * _speed, velA.y, _vector.normalized.y * _speed);
        Vector3 lookAtB = new(_vector.normalized.x + transform.position.x, transform.position.y, _vector.normalized.y + transform.position.z);

        for (float t = 0; t < 1; t += _ease_t)
        {
            Vector3 velT = velA + (velB - velA) * _ease.Evaluate(t);
            target.position = lookAtA + (lookAtB - lookAtA) * _ease.Evaluate(t);

            _rb.velocity = velT;
            if (_vector != Vector2.zero) transform.LookAt(target);

            yield return new WaitForEndOfFrame();
        }

        target.position = lookAtB;
        if (_vector != Vector2.zero) transform.LookAt(target);
        _rb.velocity = velB;
    }
}