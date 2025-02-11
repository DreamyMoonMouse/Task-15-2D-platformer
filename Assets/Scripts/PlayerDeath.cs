using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(PlayerAnimation), typeof(Rigidbody2D))]
public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private Canvas _restartCanvas;
    [SerializeField] private Transform _startPosition;
    
    private PlayerAnimation _playerAnimation;
    private bool _isDead = false;
    
    public static event Action OnPlayerDeath;

    private void Awake()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
        _restartCanvas.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<EnemyMarker>(out _) && !_isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        if (_isDead) return;
        
        float delay = 1.5f;
        _isDead = true;
        _playerAnimation.PlayDeathAnimation(_isDead);
        StartCoroutine(ShowRestartButtonAfterDelay(delay)); 
        OnPlayerDeath?.Invoke();
    }

    private IEnumerator ShowRestartButtonAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        if (_restartCanvas != null)
        {
            _restartCanvas.gameObject.SetActive(true);
        }
    }

    private void RestartGame()
    {
        Time.timeScale = 1f;
        var rigidbody = GetComponent<Rigidbody2D>();
        _isDead = false;
        
        if (_restartCanvas != null)
        {
            _restartCanvas.gameObject.SetActive(false);
        }
        
        _playerAnimation.PlayDeathAnimation(false);
        
        if (rigidbody != null)
        {
            rigidbody.simulated = true;
        }
        
        Respawn();
    }
    
    private void Respawn()
    {
        float size = 1f;
        transform.position = _startPosition.position;
        transform.localScale = new Vector3(size, size, size);
    }
}