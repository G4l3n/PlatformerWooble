using UnityEngine;

public class CheckFloor : MonoBehaviour
{
    public RaycastHit2D _hit2D { get; private set; }
    [SerializeField] private Renderer _renderer;
    [SerializeField] private LayerMask _layerNotToCheck;
    public bool IsOnFloor { get; private set; }

    void Update()
    {
        _hit2D = Physics2D.Raycast(transform.position, Vector2.down, _renderer.bounds.size.magnitude/2, _layerNotToCheck);

        if (_hit2D.transform != null && _hit2D.transform.CompareTag("Floor"))
        {
            IsOnFloor = true;
        }
        if (_hit2D.transform == null)
        {
            IsOnFloor = false;
        }
    }
}
