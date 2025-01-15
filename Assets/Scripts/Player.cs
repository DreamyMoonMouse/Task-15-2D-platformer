using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMovement _movement;
    private PlayerFlip _flip;
    private PlayerAnimation _animation;

    private void Awake()
    {
        _movement = GetComponent<PlayerMovement>();
        _flip = GetComponent<PlayerFlip>();
        _animation = GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        float horizontalInput = _movement.GetHorizontalInput();
        _flip.HandleFlip(horizontalInput);
        _animation.UpdateAnimation(horizontalInput);
    }
}
