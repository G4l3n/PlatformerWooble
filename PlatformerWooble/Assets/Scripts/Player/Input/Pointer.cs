using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    private Vector3 pointer;
    void Update()
    {
        pointer = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pointer.z = 0;
        transform.position = pointer;
    }
}
