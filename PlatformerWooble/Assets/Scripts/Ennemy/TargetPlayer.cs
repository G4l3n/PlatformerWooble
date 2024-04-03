using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayer : MonoBehaviour
{
    public GameObject Target;
    public float DistanceBetween;
    public float speed;

    private float _distance;

    void Update()
    {
        _distance = Vector2.Distance(transform.position, Target.transform.position);
        Vector2 direction = Target.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        if(_distance < DistanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, Target.transform.position, speed * Time.deltaTime);
        }
    }
}
