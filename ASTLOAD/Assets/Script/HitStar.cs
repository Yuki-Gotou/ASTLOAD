using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStar : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// ヒット確認
	private void OnTriggerEnter(Collider other){
		// 惑星に当たったら
		if (other.tag == "Planet") {
			Debug.Log(this.transform.name);
		}
	}

}
