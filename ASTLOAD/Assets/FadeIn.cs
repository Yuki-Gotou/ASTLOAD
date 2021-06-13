using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour {

    public FadeImage fadeimage;
    public bool FadeInFlg;
    public bool FadeFinish;

    public Fade fade;

	// Use this for initialization
	void Start () {
        FadeFinish = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (FadeInFlg == true)
        {
            fade.FadeIn(1.0f);
            FadeInFlg = false;
            Invoke("FlgOn", 2.0f);
            //fadeimage.cutoutRange += 0.01f;
            //if (fadeimage.cutoutRange >= 1.0f)
            //{
            //    FadeFinish = true;
            //}
        }
	}

    void FlgOn()
    {
        FadeFinish = true;
    }
}
