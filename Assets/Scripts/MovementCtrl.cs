using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCtrl : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _vector;

    [SerializeField] private AnimationCurve _ease;
    [SerializeField] private float _ease_t;
    [SerializeField] private IEnumerator _ease_enum;

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
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, angle, transform.rotation.eulerAngles.z);
    }

    public void Rotate(Transform lookAt, bool alongY)
    {
        if (alongY)
            transform.LookAt(new Vector3(lookAt.position.x, transform.position.y, lookAt.position.z));
        else 
            transform.LookAt(lookAt);
    }
    
    public virtual void Move()
    {
        _ease_enum = Ease();
        StopCoroutine(_ease_enum);
        StartCoroutine(_ease_enum);
    }

    protected virtual IEnumerator Ease()
    {
        Vector3 velA = _rb.velocity;
        Vector3 velB = new(_vector.x * _speed, velA.y, _vector.y * _speed);
        Vector3 velT = velA;
        
        for (float t = 0; t < 1; t += _ease_t)
        {
            velT = velA + (velB - velA) * _ease.Evaluate(t);
            _rb.velocity = velT;
            yield return new WaitForEndOfFrame();
        }

        _rb.velocity = velB;
    }
}
