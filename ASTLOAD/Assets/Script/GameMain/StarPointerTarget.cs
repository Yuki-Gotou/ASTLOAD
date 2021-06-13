using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPointerTarget : MonoBehaviour {

    public GameObject Star;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Star.transform.position = transform.position;
    }
}
