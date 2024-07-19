using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    PlayerController controller;
    Animator animator;

    const string CUTANIM = "Cut";

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        controller.OnCutting += CutTree;
    }
    private void CutTree()
    {
        animator.SetBool(CUTANIM, true);
    }
}
