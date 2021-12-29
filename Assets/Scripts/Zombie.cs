using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private Transform _attractionPoint;

    private float _speed = 1;
    private bool _isFalling = false;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_isFalling == false)
        {
            _animator.SetFloat("Speed", _speed);
            Vector3 direction = (_attractionPoint.position - transform.position);

            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.position = Vector3.MoveTowards(transform.position, _attractionPoint.position, _speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        const string AnimatorSpeed = "Speed";
        const string AnimatorIsFall = "isFall";

        _isFalling = true;
        _animator.SetFloat(AnimatorSpeed, 0);
        _animator.SetBool(AnimatorIsFall, true);
    }
}
