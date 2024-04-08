using UnityEngine;

public class CheckFloor : MonoBehaviour
{
    public RaycastHit2D _hit2D { get; private set; }
    [SerializeField] private Renderer _renderer;
    [SerializeField] private LayerMask _layerNotToCheck;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private Collider2D _player;
    public bool IsOnFloor { get; private set; }

    void Update()
    {
        _hit2D = Physics2D.Raycast(_player.bounds.min, Vector2.down, 0.01f, _layerNotToCheck);

        if (_hit2D.transform != null && _hit2D.transform.CompareTag("Floor"))
        {
            IsOnFloor = true;
            _playerAnimator.SetBool("IsGrounded", true);
        }
        if (_hit2D.transform == null)
        {
            IsOnFloor = false;
        }
        Debug.Log("floor = " + IsOnFloor);
        Debug.Log("grounded = " + _playerAnimator.GetBool("IsGrounded"));
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(_player.bounds.min, Vector2.down, Color.red, 0.01f);
    }
}
