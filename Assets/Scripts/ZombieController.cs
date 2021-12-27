using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private Transform _attractionPoint;
    private float _speed = 1;
    private bool _isFalling = false;

    void Update()
    {
        if (_isFalling == false)
        {
            gameObject.GetComponent<Animator>().SetFloat("Speed", _speed);
            Vector3 direction = (_attractionPoint.position - transform.position);

            transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.position = Vector3.MoveTowards(transform.position, _attractionPoint.position, _speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _isFalling = true;
        gameObject.GetComponent<Animator>().SetFloat("Speed", 0);
        gameObject.GetComponent<Animator>().SetBool("isFall", true);
    }
}
