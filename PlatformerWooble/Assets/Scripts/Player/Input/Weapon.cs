using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform _pointer;
    [SerializeField] private Rigidbody2D _pointerRb2D;
    [SerializeField] private float _pointerSpeed;
    [SerializeField] private Pointer _pointerScript;
    [SerializeField] private Laser _laser;
    [SerializeField] private Reload _reload;
    [SerializeField] private Switch _switch;
    [SerializeField] private UnityEvent _shooting;
    [HideInInspector] public float AmountToShoot = 1f;
    private bool _isShooting;
    private float _pointerHorizontal;
    private float _pointerVertical;

    private void Update()
    {
        _pointerRb2D.velocity = new Vector2(_pointerHorizontal * _pointerSpeed, _pointerVertical * _pointerSpeed);
        if (_isShooting)
        {
            if (_reload.Magazine > 0 && _switch.Night)
            {
                _laser.ShootLaser();
                _reload.Magazine -= AmountToShoot * 100 * Time.deltaTime;
                _shooting?.Invoke();
            }
            else
            {
                _laser.StopShooting();
            }
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
            _laser._shooting = false;
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

    public void OnSwitch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _switch.Switching();
        }
    }
}
