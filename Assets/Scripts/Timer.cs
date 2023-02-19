using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class Timer : MonoBehaviour

{

    public float runTime = 10;

    float secondsRemaining;

    public bool timerIsRunning = false;

    int year;
    int season;
    int month;
    GameObject update;

    void Start()
    {
        secondsRemaining = runTime;
        update = GameObject.Find("Canvas/Time");
        timerIsRunning = true;
        year = 0;
        season = 0;
    }

    void Update()
    {

        if (timerIsRunning)

        {
            if (secondsRemaining > 0)
            {
                secondsRemaining -= Time.deltaTime;
            }

            else
            {
                secondsRemaining = runTime;

                if (month < 11) month++;
                else {
                    month = 0;
                    year++;
                }
                if (month != 0 && (month+1) % 3 == 0) season++;
                if(season > 3){ 
                    season = 0;
                }
                if (year == 6) Debug.Log("Game Over");

                update.GetComponent<UpdateTime>().year = year;
                update.GetComponent<UpdateTime>().season = season;
                update.GetComponent<UpdateTime>().month = month;

            }

        }

    }

}