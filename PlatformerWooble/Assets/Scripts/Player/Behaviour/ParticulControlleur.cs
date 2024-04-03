using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=52hW2y6D8sw
public class ParticulControlleur : MonoBehaviour
{
    [SerializeField]
    ParticleSystem _particleSystem;

    [Range(0, 10)]
    [SerializeField] int _occurAfterVelocity;

    [Range(0, 0.2f)]
    [SerializeField] float _dustFormationPeriod;

    [SerializeField]
    Rigidbody2D _rigidbody2;

    float _counter;


    private void Update()
    {
        _counter += Time.deltaTime;

        if(Mathf.Abs(_rigidbody2.velocity.x) > _occurAfterVelocity)
        {
            if(_counter > _dustFormationPeriod)
            {
                _particleSystem.Play();
                _counter = 0;
            }
        }
    }

}
