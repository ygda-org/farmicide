using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleProgressBar : MonoBehaviour
{
    public Image outline;
    public void SetProgress(float percent){
        outline.fillAmount = percent;
    }
}
