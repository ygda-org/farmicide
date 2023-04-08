using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    public PlayerScript player1, player2;
    public PlayerInputManager playerInputManager;
    public bool DEBUGMODE = true;

    public void InitializePlayerControls() {
        List<PlayerInput> connectedPlayers = new();
        
        if (DEBUGMODE) {
            // get a list of all of the input devices being used
            playerInputManager.EnableJoining();
            foreach (InputDevice inputDevice in InputSystem.devices) {
                connectedPlayers.Add(playerInputManager.JoinPlayer(
                -1,              // player index
                -1,              // split screen index
                null,            // control scheme
                inputDevice      // device to pair to the player
                ));
            }
            playerInputManager.DisableJoining();
        
            // remove all of the connectedPlayers that do not have a controller (I don't understand why I have to do this)
            connectedPlayers.RemoveAll(item => item == null);
        }

        // find all of the player controls that are already connected to the game
        else if (!DEBUGMODE) { 
            foreach (GameObject playerControls in GameObject.FindGameObjectsWithTag("Player Controls")) 
                connectedPlayers.Add(playerControls.GetComponent<PlayerInput>());
        }
        

        if (connectedPlayers.Count >= 2) {
            // initialize controls for these two players
            player1.OnPlayerJoined(connectedPlayers[0], enemyPlayer_: player2.gameObject, 1);
            player2.OnPlayerJoined(connectedPlayers[1], enemyPlayer_: player1.gameObject, 2);
        }

        else if (connectedPlayers.Count == 1) {
            // Debug 1 player mode
            print("DEBUG 1 PLAYER MODE");
            player1.OnPlayerJoined(connectedPlayers[0], player2.gameObject, 1);
        }
        
    }

    public void InitializePlayerControls(PlayerInput playerInput, InputAction.CallbackContext context, int playerNumber) {
        playerInputManager.JoinPlayerFromAction(context);

        if (playerNumber == 1) player1.OnPlayerJoined(playerInput, player2.gameObject, 1);
        if (playerNumber == 2) player2.OnPlayerJoined(playerInput, player1.gameObject, 2);
    }

    void Awake() {
        InitializePlayerControls();
    }

    void Update() {

    }
}
