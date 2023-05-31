using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InteractableObjectEvent : UnityEvent<Player> {}

public class Interactable : MonoBehaviour
{
    public string hint;
    public InteractableObjectEvent onInteract;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player;
        if (other.gameObject.TryGetComponent(out player))
        {
            var _target = GetComponent<Target>();
            if(!_target || _target.owner == player) player.Focus(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Player player;
        if (other.gameObject.TryGetComponent(out player))
        {
            if (player.focus == this)
            {
                player.Focus(null); // TODO: implement focus queueing
            }
        }
    }
}
