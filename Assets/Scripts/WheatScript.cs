using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatScript : MonoBehaviour
{

    public Sprite stage0;
    public Sprite stage1;
    public Sprite stage2;
    public Sprite stage3;
    public int cost = 1;
    public int profit = 5;
    public float time = 10f; 

    public SpriteRenderer sr;

    //GameObject time;
    public float m;

    void changeSprite(Sprite sprite) {
        sr.sprite = sprite;
    }


    void Start()
    {
        //time = GameObject.Find("Timer/Canvas/Time");
        //m = time.GetComponent<UpdateTime>().month;
        //if (m == 9 || m == 10) changeSprite(stage0);
        changeSprite(stage0);
        m = time;
        //else Destroy(this);
    }

    void Update()
    {
        m = m - Time.deltaTime * 5;
        if (m <= 0) changeSprite(stage3);
        else if (m <= time / 4) changeSprite(stage2);
        else if (m <= 3* time / 4) changeSprite(stage1);
        
        
    }
} 