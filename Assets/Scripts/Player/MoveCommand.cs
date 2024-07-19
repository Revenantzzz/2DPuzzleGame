using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : ICommand
{
    PlayerController controller;
    Vector2 movement;
    public CanPushObj pushedObj { get; set; }
    public MoveCommand(PlayerController controller, Vector2 movement, CanPushObj pushedObj)
    {
        this.controller = controller;
        this.movement = movement;
        this.pushedObj = pushedObj;
    }
    public void Execute()
    {
        controller.Move(movement, pushedObj);
    }

    public void Undo()
    {
        controller.Move(-movement, pushedObj);
    }
}
