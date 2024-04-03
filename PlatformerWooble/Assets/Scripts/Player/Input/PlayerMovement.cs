using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private int jumpAmount;
    [SerializeField] private PlayerStats stats;
    [SerializeField] private CheckFloor _checkFloor;
    private float jumpForce;
    private float horizontal;

    private void Start()
    {
        jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * rb2D.gravityScale));
    }

    private void Update()
    {
        rb2D.velocity = new Vector2(horizontal * speed, rb2D.velocity.y);
        if (_checkFloor.IsOnFloor)
        {
            jumpAmount = stats.AmountOfJump;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        if (context.canceled)
        {
            rb2D.velocity = Vector2.zero;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {

        }
        if (context.performed)
        {
            if (jumpAmount > 0)
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
                jumpAmount -= 1;
            }
        }
        if (context.canceled)
        {

        }
    }
}
