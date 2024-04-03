using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    public Switch Switch;

    public float Magazine = 0;
    [SerializeField]
    private int _max;
    [SerializeField]
    private int _add;


    void FixedUpdate()
    {
        if(Switch.Night == false)
        {
            if(Magazine < _max)
                Magazine += _add;
        }
    }
}
