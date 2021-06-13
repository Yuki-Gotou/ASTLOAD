using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSetPlanet : MonoBehaviour {
	[SerializeField]
	private SetPlanet setPlanet;
	private int nCntPushButton;			// 押した回数カウント

	private Color colorA;
	// Use this for initialization
	void Start () {

		colorA = new Color(1.0f, 1.0f, 1.0f, 0.3f);
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Renderer> ().material.color = colorA;
		nCntPushButton = setPlanet.GetCntPush;
		if (nCntPushButton == 1) {
			// 生成するプラネットと交代して消える
			Destroy(this.gameObject);
		} else {
			this.transform.position = setPlanet.GetPos;
		}
	}
}
