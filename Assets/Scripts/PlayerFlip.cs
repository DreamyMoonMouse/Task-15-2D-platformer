using UnityEngine;
using System.Collections;

public class PlayerFlip : MonoBehaviour
{
    [SerializeField] private float _turnDuration = 0.5f;
    
    private bool _facingRight = true;
    private bool _isTurning = false;
    private Coroutine _currentTurnCoroutine;
    private SpriteRenderer _spriteRenderer;
    private Transform _spriteTransform; 

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _spriteTransform = _spriteRenderer.transform; 
    }
    
    public void HandleFlip(float horizontalInput)
    {
        if (_isTurning) return;

        if (horizontalInput > 0 && !_facingRight)
        {
            Flip(true);
        }
        else if (horizontalInput < 0 && _facingRight)
        {
            Flip(false);
        }
    }
    

    private void Flip(bool isTurningRight)
    {
        if (_currentTurnCoroutine != null)
        {
            StopCoroutine(_currentTurnCoroutine);
        }
        
        _isTurning = true;
        _currentTurnCoroutine = StartCoroutine(Turn(isTurningRight));
    }

    private IEnumerator Turn(bool isTurningRight)
    {
        float currentAngle = _spriteTransform.rotation.eulerAngles.y; 
        float targetAngle = isTurningRight ? 0f : 180f;
        float timeElapsed = 0f; 
        
        while (timeElapsed < _turnDuration)
        {
            float t = timeElapsed / _turnDuration; 
            float newAngle = Mathf.Lerp(currentAngle, targetAngle, t);
            _spriteTransform.rotation = Quaternion.Euler(0f, newAngle, 0f); 
            timeElapsed += Time.deltaTime; 
            yield return null;
        }
        
        _facingRight = isTurningRight;  
        _isTurning = false;  
        _currentTurnCoroutine = null;
    }
}
