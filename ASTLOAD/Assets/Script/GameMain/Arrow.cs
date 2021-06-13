using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

	// ゴール
	[SerializeField] 
	private Transform Goal;

	// カーソル
	[SerializeField] 
	private Transform Cursor;

	void Update () 
	{
		Cursor.LookAt (Goal);		// キャラの向きをゴールの方に
	}
}
