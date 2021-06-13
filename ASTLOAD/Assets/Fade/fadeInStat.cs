using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeInStat : MonoBehaviour {

    public GameObject gameobject;
    public float timeOut;
    public float timeElapsed;
    public bool flg;
    // Use this for initialization

    void Awake()
    {
        gameobject.GetComponent<Fade>().CutoutRangeMAX();
        //gameobject.GetComponent<Fade>().FadeIn(0.001f);

    }
    void Start () {
        flg = true;

    }

    // Update is called once per frame
    void Update () {
            timeElapsed += Time.deltaTime;


        if (timeElapsed >= timeOut && flg) 
        {
            gameobject.GetComponent<Fade>().FadeOut(1.0f);
            flg = false;
        }
    }
}
