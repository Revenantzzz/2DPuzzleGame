using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    const string ISCUTANIM = "IsCutting";
    const string ISMOVINGANIM = "IsMoving";
    const string MOVEANIM = "Move";
    PlayerController controller;
    Animator animator;

    enum MoveDir {Idle, Right, Left, Up, Down};
    Vector2 direction = Vector2.zero;
    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {       
        controller.OnChangeDiretion += MovingAnimation;
        controller.OnCutting += CutTree;
    }
    private void MovingAnimation(Vector2 direction)
    {
        switch (CheckMoveDirection(direction))
        {
            case MoveDir.Right:
                {
                    animator.SetFloat(MOVEANIM, .25f);
                    break;
                }
            case MoveDir.Left:
                {
                    animator.SetFloat(MOVEANIM, .5f);
                    break;
                }
            case MoveDir.Up:
                {
                    animator.SetFloat(MOVEANIM, 0.75f);
                    break;
                }
            case MoveDir.Down:
                {
                    animator.SetFloat(MOVEANIM, 1f);
                    break;
                }
            default:
                {
                    animator.SetFloat(MOVEANIM, 0);
                    break;
                }
        }
    }

    private MoveDir CheckMoveDirection(Vector2 dir)
    {      
        if(dir == Vector2.up) return MoveDir.Up;
        if(dir == Vector2.down) return MoveDir.Down;
        if(dir == Vector2.left) return MoveDir.Left;
        if(dir == Vector2.right) return MoveDir.Right;
        return MoveDir.Idle;
    }
    private void CutTree()
    {
        animator.SetBool(ISCUTANIM, true);
    }
}
