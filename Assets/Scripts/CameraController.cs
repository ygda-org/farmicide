using System.Collections;
// using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player1, player2;
    new public Camera camera;

    IEnumerator Shake(float intensity, float duration) {
        var initialPosition = camera.transform.position;
        var startTime = Time.fixedTime;

        while (startTime + duration > Time.fixedTime) {
            var randomPoint = new Vector3(Random.Range(-intensity, intensity), Random.Range(-intensity, intensity), initialPosition.z);
            camera.transform.position = randomPoint;
            yield return null;
        }
        camera.transform.position = initialPosition;
        print("hi");
    }
    public void ScreenShake(float intensity, float duration) {
        
        StartCoroutine(Shake(intensity, duration));
    }

    public void FollowPlayers() {

    }


    void Awake() {
        // ScreenShake(0.2f, 0.5f);
    }

    void Update() {
        // // FollowPlayers();
        // ScreenShake(0.05f, 0.1f);
    }
}
