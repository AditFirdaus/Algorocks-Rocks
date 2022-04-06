using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEffect : MonoBehaviour
{
    public string poolKey;
    public ParticleSystem particle;
    public UnityEvent onEventEnable;

    private void OnEnable()
    {
        particle.Play();
        onEventEnable.Invoke();
    }

    private void OnParticleSystemStopped()
    {
        PoolManager.Release(poolKey, gameObject);
    }
}
