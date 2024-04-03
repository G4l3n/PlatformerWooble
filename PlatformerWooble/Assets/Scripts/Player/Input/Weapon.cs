using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _pointer;
    [SerializeField] private Rigidbody2D _pointerRb2D;
    [SerializeField] private float _pointerSpeed;
    [SerializeField] private Pointer _pointerScript;
    [SerializeField] private Laser _laser;
    private bool _isShooting;
    private float _pointerHorizontal;
    private float _pointerVertical;

    private void Update()
    {
        _pointerRb2D.velocity = new Vector2(_pointerHorizontal * _pointerSpeed, _pointerVertical * _pointerSpeed);
        if (_isShooting)
        {
            _laser.ShootLaser();
        }
        else
        {
            _laser.StopShooting();
        }
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _isShooting = true;
        }
        if (context.canceled)
        {
            _isShooting = false;
        }
    }

    public void OnMoveMouse(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _pointerScript.enabled = true;
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Debug.Log("fze");
        _pointerScript.enabled = false;
        _pointerHorizontal = context.ReadValue<Vector2>().x;
        _pointerVertical = context.ReadValue<Vector2>().y;
        if (context.canceled)
        {
            return;
        }
    }
}
