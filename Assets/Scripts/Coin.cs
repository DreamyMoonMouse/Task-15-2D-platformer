using UnityEngine;
using System;

public class Coin : MonoBehaviour
{
    public static event Action<Coin> OnCoinCollected;
    
    private Vector3 _initialPosition;

    private void Awake()
    {
        _initialPosition = transform.position;
    }
    
    public void ResetCoin()
    {
        transform.position = _initialPosition;
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        
        if (player != null)
        {
            gameObject.SetActive(false);
            OnCoinCollected?.Invoke(this);
        }
    }
}
