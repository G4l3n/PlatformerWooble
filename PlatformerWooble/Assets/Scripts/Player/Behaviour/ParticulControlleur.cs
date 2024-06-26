using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=52hW2y6D8sw
public class ParticulControlleur : MonoBehaviour
{
    [SerializeField]
    ParticleSystem _particleSystem;

    //[SerializeField]
    //ParticleSystem _fallSystem;

    [Range(0, 10)]
    [SerializeField] int _occurAfterVelocity;

    [Range(0, 0.2f)]
    [SerializeField] float _dustFormationPeriod;

    [SerializeField]
    Rigidbody2D _rigidbody2;

    float _counter;
    //bool _isOnGround;

    private void Update()
    {
        _counter += Time.deltaTime;

        if(/*_isOnGround &&*/ Mathf.Abs(_rigidbody2.velocity.x) > _occurAfterVelocity)
        {
            if(_counter > _dustFormationPeriod)
            {
                _particleSystem.Play();
                _counter = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            //_fallSystem.Play();
            //_isOnGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Floor"))
        {
            //_isOnGround = false;
        }
    }
}
