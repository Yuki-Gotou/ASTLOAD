using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlanet : MonoBehaviour {
	/*
		プレイヤーの周りに惑星を設置する
		複数にではなく一つだけ
		S,M,Lの惑星を選択させて設置も構想に入れっる
	*/
	[SerializeField]
	private GameObject[] Planet;		// ３種類の惑星オブジェクト情報
	private GameObject PPlanet;
	private MeshRenderer meshcolor;		// マテリアル情報格納用

	private int nPlanetNum;				// 惑星種類カウント
	private int nCntPushButton;			// 押した回数カウント
	private Vector3 position;			// 位置座標
	private Vector3 MousePosition;		// マウス座標


	public Vector3 GetPos;
	public int GetCntPush;

	//private Camera GameMainCamera;

	void Start () {
		nPlanetNum = 0;
		meshcolor = GetComponent<MeshRenderer>();
	}

	void Update () {

		MousePosition = Input.mousePosition;
		Camera GameMainCamera = Camera.main;

		Ray touchpointToRay = GameMainCamera.ScreenPointToRay (MousePosition);
		RaycastHit HitRay = new RaycastHit ();
		//  マウス左ボタンを押したらActive化する。
		if (Input.GetMouseButtonDown(0)) {
			Debug.Log("左ボタンが押されている");
			nCntPushButton++;
			GetCntPush = nCntPushButton;
			if (nCntPushButton == 1) {		// 1回以上だったら惑星を新しく生成しない
				if (Physics.Raycast (touchpointToRay, out HitRay, Mathf.Infinity)) {//Physics.Raycast(ray,out hit, Mathf.Infinity,layerMask)
					// マウスクリックした場所に星の座標を生成する 
					// 一回目押したとき生成のオブジェクトが見える
					PPlanet = Instantiate (Planet [nPlanetNum], new Vector3(HitRay.point.x,
					0.0f,
					HitRay.point.z), Quaternion.identity);
					PPlanet.name = "PPlanet";

					Debug.Log (HitRay.collider.gameObject.name);

					Debug.Log ("x:" + HitRay.point.x);
					Debug.Log ("y:" + HitRay.point.y);
					Debug.Log ("z:" + HitRay.point.y);
				} else {
					Debug.Log ("ダメ");
				}
			} else {
			}
		}
		 else if (Physics.Raycast (touchpointToRay, out HitRay, Mathf.Infinity)) {//Physics.Raycast(ray,out hit, Mathf.Infinity,layerMask)
			GetPos=new Vector3(HitRay.point.x,
				0.0f,
				HitRay.point.z);
			Debug.Log ("Position:"+GetPos);
		}
		// 設置するときは、←、→キーを押して選択して設置するものを選ぶ
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			nPlanetNum +=1;
			// ３より大きくならないようにする
			if(nPlanetNum>=2){
				nPlanetNum = 2;
			}
			Debug.Log (nPlanetNum);
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			nPlanetNum -= 1;
			// ゼロより小さくならないようにする。
			if(nPlanetNum<=0){
				nPlanetNum = 0;
			}
			Debug.Log (nPlanetNum);

		}
	}

}
