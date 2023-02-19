using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    public PlayerScript player1, player2;
    public PlayerInputManager playerInputManager;
    public void InitializePlayerControls() {
        playerInputManager.EnableJoining();

        // get a list of all of the input devices being used
        List<PlayerInput> connectedPlayers = new();
        foreach (InputDevice inputDevice in InputSystem.devices) {
            connectedPlayers.Add(playerInputManager.JoinPlayer(
            -1,              // player index
            -1,              // split screen index
            null,           // control scheme
            inputDevice     // device to pair to the player
            ));
        }
        
        // remove all of the connectedPlayers that do not have a controller
        connectedPlayers.RemoveAll(item => item == null);

        print(connectedPlayers.Count);

        if (connectedPlayers.Count >= 2) {
            // initialize controls for these two players
            player1.OnPlayerJoined(connectedPlayers[0], 1);
            player2.OnPlayerJoined(connectedPlayers[1], 2);
        }

        else if (connectedPlayers.Count == 1) {
            // Debug 1 player mode
            print("DEBUG 1 PLAYER MODE");
            player1.OnPlayerJoined(connectedPlayers[0], 1);
        }

        // delete the waste created by connecting a controller (unity makes me do this, I am sorry)
        // foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Empty"))
        //     Destroy(gameObject);
        
        playerInputManager.DisableJoining();
    }

    void Awake() {
        InitializePlayerControls();
    }
}
