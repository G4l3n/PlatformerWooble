using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public GameObject Spot;

    void FixedUpdate()
    {
        Spot.transform.position = this.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
            GameObject.Instantiate(Spot);
        }
    }
}
