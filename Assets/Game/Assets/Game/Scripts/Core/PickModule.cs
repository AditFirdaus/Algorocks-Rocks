using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickModule : MonoBehaviour
{
    public bool canPick = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        IPickable pickable = other.GetComponent<IPickable>();
        if (canPick && pickable != null)
        {
            pickable.Pick(this);
        }
    }
}

public interface IPickable
{
    public void Pick(PickModule pickModule);
}
