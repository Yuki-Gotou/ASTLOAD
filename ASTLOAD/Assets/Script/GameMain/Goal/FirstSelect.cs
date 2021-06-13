using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FirstSelect : MonoBehaviour {

    public GameObject sB;

    // Use this for initialization
    void Start () {
        EventSystem.current.SetSelectedGameObject(sB);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
