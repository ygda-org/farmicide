using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using Identification;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;

    // is it correct to use InputBinding here?
    public Dictionary<int, InputBinding> controlBindings = new();
    public int currentSkin;

}


namespace Identification {

    public enum ActionIDs {
        Interact = 0,
        Shoot = 1,
        Move = 2,
        Aim = 3,
        AimClockWise = 4,
        AimCounterClockWise = 5
    }

    public enum Skins {
        Default = 0,

    }
}
