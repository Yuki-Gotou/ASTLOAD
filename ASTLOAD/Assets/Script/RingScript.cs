using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingScript : MonoBehaviour {

    public bool RingGetFlg;
    public GameObject Ring;

	// Use this for initialization
	void Start () {
        RingGetFlg = false;
    }
	
	// Update is called once per frame
	void Update () {
		if(RingGetFlg==true)
        {
            Ring.transform.position = this.transform.position;
        }
	}
}
