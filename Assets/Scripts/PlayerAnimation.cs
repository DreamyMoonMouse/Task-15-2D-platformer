using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private const string IsMovingParameter = "IsMoving";
    
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void UpdateAnimation(float horizontalInput)
    {
        _animator.SetBool(IsMovingParameter, Mathf.Abs(horizontalInput) > 0.01f);
    }
}