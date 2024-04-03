using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlipPlayer : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private bool asTurned;
    [SerializeField] private Transform _pointer;
    private float rotationZ;

    private void FixedUpdate()
    {
        Vector3 worldPosition = _pointer.position;
        Vector3 difference = worldPosition - transform.position;
        rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if (!asTurned)
        {
            if (rotationZ > 95 && rotationZ < 180)
            {
                Player.transform.Rotate(new Vector3(0, 180, 0));
                asTurned = true;
            }
            else if (rotationZ < -95 && rotationZ > -180)
            {
                Player.transform.Rotate(new Vector3(0, 180, 0));
                asTurned = true;
            }
        }
        else
        {
            if (rotationZ < 86 && rotationZ > 0)
            {
                Player.transform.Rotate(new Vector3(0, 180, 0));
                asTurned = false;
            }
            else if (rotationZ > -86 && rotationZ < 0)
            {
                Player.transform.Rotate(new Vector3(0, 180, 0));
                asTurned = false;
            }
        }
    }
}
