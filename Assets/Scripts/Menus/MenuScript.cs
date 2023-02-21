using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void changeToWorld()
    {
        SceneManager.LoadScene("World");
    }

    public void changeToMulti()
    {
        SceneManager.LoadScene("MultiMenu");
    }
}
