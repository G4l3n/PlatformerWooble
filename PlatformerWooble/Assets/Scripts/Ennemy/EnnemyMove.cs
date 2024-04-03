using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyMove : MonoBehaviour
{
    public GameObject PointA;
    public GameObject PointB;
    public Rigidbody2D Rigidbody;
    private Transform _currentPoint;
    public float speed;

    


    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        _currentPoint = PointB.transform;
    }

    void Update()
    {
        Vector2 point = _currentPoint.position - transform.position;
        if(_currentPoint == PointB.transform)
        {
            Rigidbody.velocity = new Vector2(speed, 0);
        }
        else
        {
            Rigidbody.velocity = new Vector2(-speed, 0);
        }

        
        if (Vector2.Distance(transform.position, _currentPoint.position) < 0.5f && _currentPoint == PointB.transform)
        {
            _currentPoint = PointA.transform;
        }
        if (Vector2.Distance(transform.position, _currentPoint.position) < 0.5f && _currentPoint == PointA.transform)
        {
            _currentPoint = PointB.transform;
        }
    }
}
