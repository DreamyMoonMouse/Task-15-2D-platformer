using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    
    public void SetIsMoving(bool isMoving)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsMoving, isMoving);
    }

    public void SetIsDead(bool isDead)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsDead, isDead);
    }
}