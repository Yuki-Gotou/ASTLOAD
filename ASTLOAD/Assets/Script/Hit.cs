using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// ヒット確認
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.name);
    }
}
