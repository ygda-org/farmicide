using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatScript : MonoBehaviour
{

    public Sprite stage0;
    public Sprite stage1;
    public Sprite stage2;
    public Sprite stage3;

    public SpriteRenderer sr;

    GameObject time;
    int m;

    void changeSprite(Sprite sprite) {
        sr.sprite = sprite;
    }

    void Start()
    {
        time = GameObject.Find("Timer/Canvas/Time");
        m = time.GetComponent<UpdateTime>().month;
        if (m == 9 || m == 10) changeSprite(stage0);
        //else Destroy(this);
    }

    void Update()
    {
        m = time.GetComponent<UpdateTime>().month;
        if (m == 3) changeSprite(stage1);
        if (m == 4) changeSprite(stage2);
        if (m == 5) changeSprite(stage3);
    }
} 