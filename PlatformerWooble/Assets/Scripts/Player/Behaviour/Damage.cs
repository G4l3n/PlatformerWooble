using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    List<GameObject> _healt;

    void Update()
    {
        if (_healt.Count == 0)
        {
            Debug.Log("MORT");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ennemy"))
        {
            for (int i = 0; i < _healt.Count; i--)
            {
                _healt.RemoveAt(i);
            }
        }
    }

}
