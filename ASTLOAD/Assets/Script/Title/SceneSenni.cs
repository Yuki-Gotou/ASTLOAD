using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSenni : MonoBehaviour {

    public FadeIn fadein;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            //SceneManager.LoadScene("StageSelect");
            fadein.FadeInFlg = true;
        }

        if(fadein.FadeFinish==true)
        {
            SceneManager.LoadScene("StageSelect");
        }
    }
}
