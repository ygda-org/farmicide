using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateTime : MonoBehaviour
{

    public int year;
    public int season;
    public int month;

    public TMP_Text text;
    string[] seasons = { "Winter", "Spring", "Summer", "Fall" };
    string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

    void Update()
    {
        string s = seasons[season];
        string m = months[month];
        text.text = "Year " + year + " " + s + " " + m;
    }
}
