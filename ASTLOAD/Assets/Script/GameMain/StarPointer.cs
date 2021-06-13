using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPointer : MonoBehaviour {

    public GameObject starpointer;
    public GameObject Star;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = starpointer.transform.position+ Star.transform.position;

    }
}
