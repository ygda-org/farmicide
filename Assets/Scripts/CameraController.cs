using System.Collections;
using System.Threading;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player1, player2;
    new public Camera camera;

    IEnumerator Shake(float intensity, float speed, float duration) {
        var initialPosition = camera.transform.position;
        var startTime = Time.fixedTime;

        while (startTime + duration > Time.fixedTime) {
            var randomPoint = new Vector3(Random.Range(-intensity, intensity), Random.Range(-intensity, intensity), initialPosition.z);
            camera.transform.position = randomPoint;
            
            int timeOut = (int)(1/speed)*1000;
            Thread.Sleep(timeOut);
            yield return null;
        }
        camera.transform.position = initialPosition;
    }
    public void ScreenShake(float intensity, float speed, float duration) {
        
        StartCoroutine(Shake(intensity, speed, duration));
    }

    public void FollowPlayers() {

    }


    void Awake() {
        ScreenShake(0.2f, 100f, 0.5f);
    }

    void Update() {
        // // FollowPlayers();
        // ScreenShake(0.05f, 0.1f);
    }
}
