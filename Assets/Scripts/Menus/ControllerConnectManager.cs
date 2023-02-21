using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ControllerConnectManager : MonoBehaviour
{
    public string mainGameSceneName;
    public GameObject playerCursorPrefab;

    // mostly for convenience
    public Dictionary<PlayerInput, GameObject> inputToCursor = new();

    public void OnPlayerJoined(PlayerInput playerInput) {
        // create an icon for the player to utilize in this screen
        GameObject tempCursor = Instantiate(playerCursorPrefab);
        inputToCursor.Add(playerInput, tempCursor);
        DontDestroyOnLoad(playerInput);
    }

    public void OnPlayerExited(PlayerInput playerInput) {
        // destroy the icon and the player input instance
        Destroy(inputToCursor[playerInput]);
        Destroy(playerInput);
    }

    public void OnGameStart() {
        SceneManager.LoadSceneAsync(mainGameSceneName, LoadSceneMode.Single);
    }
}