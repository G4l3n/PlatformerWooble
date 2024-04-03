using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float _maxDistanceRay = 40f;
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] private Transform _pointer;
    [SerializeField] private LineRenderer _lineRenderer;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    public void ShootLaser()
    {
        _lineRenderer.enabled = true;
        if (Physics2D.Raycast(_shootingPoint.position, transform.right, _maxDistanceRay))
        {
            RaycastHit2D _2DHit = Physics2D.Raycast(_shootingPoint.position, transform.right);
            Draw2DRay(_shootingPoint.position, _2DHit.point);
            if (_2DHit.transform.CompareTag("Enemy"))
            {
                //dmg
                Debug.Log("piou piou");
            }
        }
        else 
        {
            Draw2DRay(_shootingPoint.position, _pointer.position);
        }
    }

    private void Draw2DRay(Vector2 startPosition, Vector2 endPosition)
    {
        _lineRenderer.SetPosition(0, startPosition);
        _lineRenderer.SetPosition(1, endPosition);
    }

    public void StopShooting()
    {
        _lineRenderer.enabled = false;
    }
}
