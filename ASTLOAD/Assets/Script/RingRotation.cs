using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingRotation : MonoBehaviour {

    public SceneData scenedata;
    public GameObject PlayerData;
    //public GameObject Wakusei;
    public Vector3 WakuseiPos;
    public PlayerRotation playerrotation;
    public float WakuseiWaight;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void LateUpdate()
    {

        switch (scenedata.StageFlg)
        {
            case 0:
                this.transform.position = PlayerData.transform.position;
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            default:
                break;
        }


        //if (scenedata.StageFlg == 0)
        //{
        //    this.transform.position = PlayerData.transform.position;
        //}
        //if(scenedata.StageFlg == 1)
        //{
        //    Debug.Log("リング");
        //    transform.RotateAround(WakuseiPos, Vector3.up, 2.0f * WakuseiWaight);
        //}
    }
}
