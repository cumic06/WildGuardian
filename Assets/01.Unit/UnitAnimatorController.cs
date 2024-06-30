using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimatorCommand
{
    public void SetAnimation(AnimationType animationType, bool active);
}

public enum AnimationType
{
    Move,
    Attack
}


public class UnitAnimatorController : MonoBehaviour, IAnimatorCommand
{
    protected Animator animator;
    protected static readonly int isAttack = Animator.StringToHash("isAttack");
    protected static readonly int isMove = Animator.StringToHash("isMove");

    protected void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public virtual void SetAnimation(AnimationType animationType, bool active)
    {
        switch (animationType)
        {
            case AnimationType.Move:
                animator.SetBool(isMove, active);
                animator.SetBool(isAttack, false);
                break;
            case AnimationType.Attack:
                animator.SetTrigger(isAttack);
                animator.SetBool(isMove, false);
                break;
        }
    }
}