using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static Action OnActionStarted;
    public static Action OnPauseStarted;

    public void OnAction(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            OnActionStarted?.Invoke();
        }
    }

    public void OnPause(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            OnPauseStarted?.Invoke();
        }
    }
}
