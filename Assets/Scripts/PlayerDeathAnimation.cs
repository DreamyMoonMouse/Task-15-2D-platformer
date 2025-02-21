using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerAnimation))]
public class PlayerDeathAnimation : MonoBehaviour
{
    [SerializeField] private float _fallSpeed = 2f;
    [SerializeField] private float _deathLiftHeight = 1.5f;
    [SerializeField] private float _fallBoundary = -10f;
    
    private Vector3 _originalScale;
    private Coroutine _fallCoroutine;
    private Rigidbody2D _rigidbody;
    private PlayerAnimation _playerAnimation;
    private bool _isDead = false;

    private void Awake()
    {
        _originalScale = transform.localScale;
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void OnEnable()
    {
        var playerDeath = GetComponentInParent<PlayerDeath>();
        
        if (playerDeath != null)
        {
            playerDeath.OnPlayerDeath += HandlePlayerDeath;
        }
    }

    private void OnDisable()
    {
        var playerDeath = GetComponentInParent<PlayerDeath>();
        
        if (playerDeath != null)
        {
            playerDeath.OnPlayerDeath -= HandlePlayerDeath;
        }
    }
    
    private void HandlePlayerDeath()
    {
        if (_isDead == false)
        {
            PlayDeathAnimation(true);
            _isDead = true;
        }
        else
        {
            PlayDeathAnimation(false);
            _isDead = false;
        }
    }
    private void PlayDeathAnimation(bool isDead)
    {
        if (_rigidbody != null)
        {
            _rigidbody.simulated = false;
        }
        
        _playerAnimation.SetIsDead(isDead);
        
        if (isDead == false)
        {
            if (_fallCoroutine != null)
            {
                StopCoroutine(_fallCoroutine);
                _fallCoroutine = null;
            }
        }
        else
        {
            _fallCoroutine = StartCoroutine(FallAnimation());
        }
    }

    private IEnumerator FallAnimation()
    {
        transform.localScale *= 1.5f;
        transform.position += Vector3.up * _deathLiftHeight;

        yield return new WaitForSeconds(0.5f);

        while (transform.position.y > _fallBoundary)
        {
            transform.position += Vector3.down * _fallSpeed * Time.deltaTime;
            yield return null;
        }
        
        transform.localScale = _originalScale;
        _playerAnimation.SetIsDead(false);
        
        if (_rigidbody != null)
        {
            _rigidbody.simulated = true;
        }
    }
}
