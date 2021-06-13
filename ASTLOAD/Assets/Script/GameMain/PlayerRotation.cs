using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {

    public GameObject Wakusei;
    public SceneData scenedata;

    public Vector3 WakuseiPos;
    public float WakuseiWaight;

    int Scenedataflg;

    // Use this for initialization
    void Start () {
        Scenedataflg = scenedata.StageFlg;

    }
	
	// Update is called once per frame
	void Update () {
        Scenedataflg = scenedata.StageFlg;
        //WakuseiWaight = 1.0f;
    }
    private void FixedUpdate()
    {

        switch(Scenedataflg)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                if (WakuseiPos.x != 0.0f)
                {
                    transform.RotateAround(WakuseiPos, Vector3.up, 2.0f * WakuseiWaight);
                }
                else
                {
                    scenedata.StageFlg = 0;
                }
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

        //if (Scenedataflg == 2)
        //{
        //    if (WakuseiPos.x != 0.0f)
        //    {
        //        transform.RotateAround(WakuseiPos, Vector3.up, 2.0f * WakuseiWaight);
        //    }
        //    else
        //    {
        //        scenedata.StageFlg = 0;
        //    }
        //}
    }
}
