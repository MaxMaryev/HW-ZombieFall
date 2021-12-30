using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private Transform _movePoint;

    private float _speed = 1;
    private bool _isFalling = false;
    private Animator _animator;
    private int _speedHash = Animator.StringToHash("Speed");
    private int _isFallHash = Animator.StringToHash("isFall");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_isFalling == false)
        {
            _animator.SetFloat(_speedHash, _speed);
            Vector3 direction = (_movePoint.position - transform.position);

            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.position = Vector3.MoveTowards(transform.position, _movePoint.position, _speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _isFalling = true;
        _animator.SetFloat(_speedHash, 0);
        _animator.SetBool(_isFallHash, true);
    }
}
