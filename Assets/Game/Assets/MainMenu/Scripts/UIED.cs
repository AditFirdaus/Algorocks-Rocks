using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIED : MonoBehaviour
{
    public UnityAction OnComplete;
    public Animator animator;

    public void ActionEnable(UnityAction OnCompleteAction = null)
    {
        this.OnComplete = OnCompleteAction;
        Enable();
    }

    public void ActionDisable(UnityAction OnCompleteAction = null)
    {
        this.OnComplete = OnCompleteAction;
        Disable();
    }

    public void Enable() => animator.Play("Enable");
    public void Disable() => animator.Play("Disable");

    public void InvokeComplete()
    {
        OnComplete?.Invoke();
    }
}
