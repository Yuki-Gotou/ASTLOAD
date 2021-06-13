using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RezultItemMake : MonoBehaviour {

    //エネルギー生成フラグ
    public bool CreateFlg;
    public GameObject Energy;
    //エネルギー生成終了及び爆破フラグ
    public bool FinishEnergy;

	// Use this for initialization
	void Start () {
        CreateFlg = false;
        FinishEnergy = false;
    }
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.T))
        {
            CreateFlg = true;
        }

		if(CreateFlg==true)
        {
            GameObject ProtoItem= Instantiate(Energy, this.transform);
            ProtoItem.transform.position = this.transform.position;

            CreateFlg = false;
        }
	}
}
