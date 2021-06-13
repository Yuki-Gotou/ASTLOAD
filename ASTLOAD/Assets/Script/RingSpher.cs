using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingSpher : MonoBehaviour {

    public GameObject RingBase;
    public bool RingGo;
    public float WakuseiWaight;

    public float RingStayPower;
    public float RingStayMove;

    public SceneData scenedata;

    // Use this for initialization
    void Start () {
        RingGo = false;
        RingStayMove=1.5f;
    }
	
	// Update is called once per frame
	void Update () {

	}

    private void FixedUpdate()
    {
        if(RingGo==true)
        {
            transform.RotateAround(RingBase.transform.position, Vector3.up, 4.0f * WakuseiWaight);
        }
    }

    private void LateUpdate()
    {
        if (RingGo == true)
        {
            this.transform.parent = RingBase.transform;
            //transform.RotateAround(RingBase.transform.position/*new Vector3(0.0f,0.0f,0.0f)*/, Vector3.up, 4.0f * WakuseiWaight);
            //Debug.Log(RingBase.transform.position);
        }
        //else if(scenedata.StageFlg==1)
        //{
        //    RingStayPower += RingStayMove;
        //}
        else
        {
            this.transform.parent = null;
        }
    }
}
