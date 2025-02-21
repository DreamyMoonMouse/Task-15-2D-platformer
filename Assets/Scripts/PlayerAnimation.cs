using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    //[SerializeField] private float _fallSpeed = 2f;
    //[SerializeField] private float _turnDuration = 0.5f;
    
    private Animator _animator;
    // private bool _facingRight = true;
    // private bool _isTurning = false;
    // private Coroutine _currentTurnCoroutine;
    // private Coroutine _fallCoroutine;
    // private Transform _spriteTransform;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        //_spriteTransform = GetComponentInChildren<SpriteRenderer>().transform;
    }
    
    public void SetIsMoving(bool isMoving)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsMoving, isMoving);
    }

    public void SetIsDead(bool isDead)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsDead, isDead);
    }

    // public void UpdateAnimation(float horizontalInput)
    // {
    //     _animator.SetBool(PlayerAnimatorData.Params.IsMoving, Mathf.Abs(horizontalInput) > 0.01f);
    //     HandleFlip(horizontalInput);
    // }
    //
    // public void HandleFlip(float horizontalInput)
    // {
    //     if (_isTurning) return;
    //
    //     if (horizontalInput > 0 && !_facingRight)
    //     {
    //         Flip(true);
    //     }
    //     else if (horizontalInput < 0 && _facingRight)
    //     {
    //         Flip(false);
    //     }
    // }
    //
    // public void PlayDeathAnimation(bool isDead)
    // {
    //     var rigidbody = GetComponent<Rigidbody2D>();
    //     
    //     if (rigidbody != null)
    //     { 
    //         rigidbody.simulated = false;
    //     }
    //     
    //     _animator.SetBool(PlayerAnimatorData.Params.IsDead, isDead);
    //     
    //     if (isDead == false)
    //     {
    //         if (_fallCoroutine != null)
    //         {
    //             StopCoroutine(_fallCoroutine);
    //             _fallCoroutine = null;
    //         }
    //     }
    //     else
    //     {
    //         _fallCoroutine = StartCoroutine(FallAnimation());
    //     }
    // }
    //
    // private void Flip(bool isTurningRight)
    // {
    //     if (_currentTurnCoroutine != null)
    //     {
    //         StopCoroutine(_currentTurnCoroutine);
    //     }
    //
    //     _isTurning = true;
    //     _currentTurnCoroutine = StartCoroutine(Turn(isTurningRight));
    // }
    //
    // private IEnumerator Turn(bool isTurningRight)
    // {
    //     float currentAngle = _spriteTransform.rotation.eulerAngles.y;
    //     float targetAngle = isTurningRight ? 0f : 180f;
    //     float timeElapsed = 0f;
    //
    //     while (timeElapsed < _turnDuration)
    //     {
    //         float interpolationFactor = timeElapsed / _turnDuration;
    //         float newAngle = Mathf.Lerp(currentAngle, targetAngle, interpolationFactor);
    //         _spriteTransform.rotation = Quaternion.Euler(0f, newAngle, 0f);
    //         timeElapsed += Time.deltaTime;
    //         yield return null;
    //     }
    //
    //     _facingRight = isTurningRight;
    //     _isTurning = false;
    //     _currentTurnCoroutine = null;
    // }
    //
    // private IEnumerator FallAnimation()
    // {
    //     float scaleMultiplier = 1.5f;
    //     float deathLiftHeight = 1.5f;
    //     float fallBoundary = -10f;
    //     
    //     Vector3 originalScale = transform.localScale;
    //     transform.localScale = new Vector3(originalScale.x * scaleMultiplier, originalScale.y * scaleMultiplier, originalScale.z);
    //     Vector3 originalPosition = transform.position;
    //     transform.position = new Vector3(originalPosition.x, originalPosition.y + deathLiftHeight, originalPosition.z);
    //     yield return new WaitForSeconds(0.5f);
    //     
    //     while (transform.position.y > fallBoundary)
    //     {
    //         transform.position += Vector3.down * _fallSpeed * Time.deltaTime;
    //         yield return null;
    //     }
    //     
    //     transform.localScale = originalScale;
    //     _animator.SetBool(PlayerAnimatorData.Params.IsDead, false);
    // }
}