using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingObject : MonoBehaviour {

    public bool ScallingMove;
    public RingSpher ringsphere;
    public SceneData scenedata;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {

        switch (scenedata.StageFlg)
        {
            case 0:
                this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                break;
            case 1:
                break;
            case 2:
                ringsphere.RingGo = false;
                break;
            case 3:
                break;
            case 4:
                ringsphere.RingGo = false;
                break;
            case 5:
                ringsphere.RingGo = false;
                break;
            default:
                break;
        }


        //if(ScallingMove==true)
        //      {
        //          Vector3 Scale;
        //          Scale = this.transform.localScale;
        //          Scale.x += 200;
        //          Scale.z += 200;
        //          this.transform.localScale = Scale;
        //      }

        //if(scenedata.StageFlg==1)
        //{
        //    transform.Rotate(new Vector3(0.0f, 5.0f, 0.0f));
        //}
        //if (scenedata.StageFlg == 2|| scenedata.StageFlg == 5|| scenedata.StageFlg == 4)
        //{
        //    ringsphere.RingGo = false;
        //}
        //if(scenedata.StageFlg==0)
        //{
        //    this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        //}
    }

    private void FixedUpdate()
    {
        if (ScallingMove == true)
        {
            Vector3 Scale;
            Scale = this.transform.localScale;
            Scale.x += 20;
            Scale.z += 20;
            this.transform.localScale = Scale;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (scenedata.StageFlg == 1)
        {
            if (other.name == "Player")
            {
                ScallingMove = false;
                ringsphere.RingGo = true;
            }
        }
    }
}
