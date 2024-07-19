using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
   private static Stack<ICommand> undoStack = new Stack<ICommand>();
    public static void ExcuteCommand(ICommand command)
    {
        command.Execute();
        undoStack.Push(command);
    }
    public static void UndoCommand()
    {
        
        if(undoStack.Count > 0)
        {
            ICommand activeCommand = undoStack.Pop();
            activeCommand.Undo();
        }
    }
}
