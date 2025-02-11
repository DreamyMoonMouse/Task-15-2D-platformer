using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerAnimation))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask _groundLayer;
    
    private PlayerAnimation _playerAnimation;
    private Rigidbody2D _rigidbody;
    private float _movementInput;
    private bool _isGrounded;

    private void Awake()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private void Start()
    {
        StartCoroutine(HandleInputCoroutine());
    }

    private void FixedUpdate()
    {
        MovePlayer();
        _playerAnimation.UpdateAnimation(_movementInput);
        _playerAnimation.HandleFlip(_movementInput);
    }

    private IEnumerator HandleInputCoroutine()
    {
        while (true)
        {
            _movementInput = Input.GetAxis("Horizontal");

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                Jump();
            }

            yield return null;
        }
    }

    private void MovePlayer()
    {
        _rigidbody.linearVelocity = new Vector2(_movementInput * _moveSpeed, _rigidbody.linearVelocity.y);
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
    }
}