using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerConnectManager : MonoBehaviour
{
    public void OnPlayerJoined(PlayerInput playerInput) {
        // create an icon for the player to utilize in this screen
        // DontDestroyOnLoad(playerInput); // will this work????
    }

    public void OnPlayerExited(PlayerInput playerInput) {
        // destroy the icon
        Destroy(playerInput);
    }
}