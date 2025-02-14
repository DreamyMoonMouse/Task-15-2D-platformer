using UnityEngine;
using System.Collections.Generic;
using System;

public class CoinsPool : MonoBehaviour
{
    [SerializeField] private PlayerDeath _playerDeath;
    
    private int _collectedCoins = 0;
    private List<Coin> _coins = new List<Coin>();
    
    public event Action OnAllCoinsCollected;
    public event Action OnScoreUpdated;
    
    public int CollectedCoins => _collectedCoins;
    
    private void Awake()
    {
        foreach (Transform child in transform)
        {
            var coin = child.GetComponent<Coin>();
            
            if (coin != null)
            {
                _coins.Add(coin);
            }
        }
        
        CoinCollector.OnCoinCollected += HandleCoinCollected;
        _playerDeath.OnPlayerDeath += ResetAllCoins;
    }
    
    private void OnDestroy()
    {
        CoinCollector.OnCoinCollected -= HandleCoinCollected;
        _playerDeath.OnPlayerDeath -= ResetAllCoins;
    }

    private void HandleCoinCollected(Coin collectedCoin)
    {
        _collectedCoins++;
        OnScoreUpdated?.Invoke();
        
        if (_collectedCoins == _coins.Count)
        {
            OnAllCoinsCollected?.Invoke();
        }
    }

    private void ResetAllCoins()
    {
        foreach (var coin in _coins)
        {
            coin.ResetCoin();
        }
        
        _collectedCoins = 0;
        OnScoreUpdated?.Invoke();
    }
}
