using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SceneHandler : MonoBehaviour
{
    public bool dontDestroy = false;
    public UnityEvent onStart;

    private void Start()
    {
        onStart.Invoke();
        if (dontDestroy) DontDestroyOnLoad(gameObject);
    }
}
