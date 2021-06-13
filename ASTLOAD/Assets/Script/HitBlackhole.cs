using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBlackhole : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	// プレイヤーに当たった時の処理
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			// 使用回数を超えた恒星は爆発
			Destroy(this.gameObject);
		}
	}
}
