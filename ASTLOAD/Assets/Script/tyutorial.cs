using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tyutorial : MonoBehaviour {

    public GameObject gameobject;

	// Use this for initialization
	void Start () {
        gameobject.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("動くんですね");
		if(Input.GetKeyDown(KeyCode.P))
        {
            gameobject.gameObject.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            gameobject.gameObject.SetActive(false);
        }
	}
}
