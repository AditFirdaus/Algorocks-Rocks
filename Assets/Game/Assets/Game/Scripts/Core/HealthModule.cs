using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthModule : MonoBehaviour
{
    [SerializeField] float _health = 10;
    public float health
    {
        set
        {
            _health = value;
            onHealthChange.Invoke(_health);
            if (_health <= 0) onHealthEmpty.Invoke();
        }
        get => _health;
    }

    public UnityEvent<float> onHealthChange;
    public UnityEvent onHealthEmpty;
}
