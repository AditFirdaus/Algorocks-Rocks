using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIModule : MonoBehaviour
{
    public bool active = true;
    public Animator animator;

    public string animationEnable = "Enable";
    public string animationDisable = "Disable";

    public UnityEvent onEventEnable;
    public UnityEvent onEventDisable;

    public UnityAction onActionDisable;

    public void Enable()
    {
        if (!active) return;
        animator.Play(animationEnable);
        onEventEnable.Invoke();
    }

    public void Disable()
    {
        if (!active) return;
        onActionDisable = null;

        animator.Play(animationDisable);
    }

    public void Disable(UnityAction action)
    {
        if (!active) return;
        onActionDisable = action;

        animator.Play(animationDisable);
    }
    void SetDisable()
    {
        Debug.Log(onActionDisable);

        onActionDisable?.Invoke();
        onEventDisable.Invoke();

        gameObject.SetActive(false);
    }
}
