using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPlanetText : MonoBehaviour {

	[SerializeField]
	private GameObject score_Obj;
	private int nPlanetNum;				// 惑星種類カウント
	// Use this for initialization
	void Start () {
		nPlanetNum = 0;
	}
	
	// Update is called once per frame
	void Update () {
		Text score_Text = score_Obj.GetComponent<Text> ();
		 


		// 設置するときは、←、→キーを押して選択して設置するものを選ぶ
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			nPlanetNum +=1;
			Debug.Log (nPlanetNum);
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			nPlanetNum -= 1;
			Debug.Log (nPlanetNum);
		}
		// ３より大きくならないようにする
		if(nPlanetNum>=2){
			nPlanetNum = 2;
			score_Text.text = "Planet:L";
		}
		if (nPlanetNum == 1) {
			score_Text.text = "Planet:M";
		}
		// ゼロより小さくならないようにする。
		if(nPlanetNum<=0){
			nPlanetNum = 0;
			score_Text.text = "Planet:S";
		}

	}
}
