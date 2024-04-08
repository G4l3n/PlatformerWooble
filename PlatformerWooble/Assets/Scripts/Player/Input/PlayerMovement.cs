using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private int jumpAmount;
    [SerializeField] private PlayerStats stats;
    [SerializeField] private CheckFloor _checkFloor;
    [SerializeField] private float durationOfLerp;
    [SerializeField] private Animator _playerAnim;

    private float jumpForce;
    private float horizontal;

    //public ParticleSystem Dust;

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
        _playerAnim.SetFloat("PlayerSpeed", Mathf.Abs(rb2D.velocity.x));
        Debug.Log(_playerAnim.GetFloat("PlayerSpeed"));
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        if (context.canceled)
        {
            //Dust.Play();
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
                _playerAnim.SetBool("IsGrounded", false);
                Debug.Log("jump");
            }
        }
        if (context.canceled)
        {

        }
    }


    //private IEnumerator MoveStart(float floatToLerp, float maxFloat, float duration)
    //{
    //    float _actualTime = 0;
    //    Vector2 startPosition = transform.position;
    //    while (_actualTime < duration)
    //    {
    //        floatToLerp = Mathf.Lerp(0, maxFloat, _actualTime / duration);
    //        _actualTime += Time.deltaTime;
    //        yield return null;
    //    }
    //    _playerSpeed = horizontal;
    //    yield return null;
    //}
}
