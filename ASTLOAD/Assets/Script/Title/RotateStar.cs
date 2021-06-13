using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStar : MonoBehaviour {

	//private Vector3 vecplus;

	// Use this for initialization
	void Start () {
		//vecplus = new Vector3 (0.0f, 1.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		// transformを取得
		Transform myTransform = this.transform;

		// ローカル座標基準で、現在の回転量へ加算する
		myTransform.Rotate(0.0f, -1.0f, 0.0f);
		MoveStar();
	}

	// 星ごとのIDで動かすものを決める。
	void MoveStar()
	{
		// 任意のオブジェクトの周りで回転させる
		transform.RotateAround(GameObject.FindGameObjectWithTag("Player").transform.position, Vector3.up, 
			0.5f* 1.2f);

	}
}
