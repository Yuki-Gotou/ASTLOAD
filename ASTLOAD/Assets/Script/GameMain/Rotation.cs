using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    public GameObject Player;
    public SceneData scenedata;
    //自分の惑星データステータス
    public Wakusei wakusei;
    //惑星が選択されているか
    public bool WakuseiSelect;
    public bool KouseiSelect;

    public Wakusei wakuseidata;

    public int HitCount;

	// Use this for initialization
	void Start () {
        WakuseiSelect = false;
        KouseiSelect = false;
        HitCount = 100;
    }
	
	// Update is called once per frame
	void Update () {

        //switch (scenedata.StageFlg)
        //{
        //    case 0:
        //        break;
        //    case 1:
        //        if (wakuseidata.HitHantei[0] == true || wakuseidata.HitHantei[1] == true)
        //        {
        //            transform.RotateAround(Player.transform.position, Vector3.up, 2.0f);
        //        }
        //        break;
        //    case 2:
        //        break;
        //    case 3:
        //        break;
        //    case 4:
        //        break;
        //    case 5:
        //        break;
        //    default:
        //        break;
        //}


        //if (scenedata.StageFlg==1)
        //{
        //    if (wakuseidata.HitHantei[0] == true|| wakuseidata.HitHantei[1] == true)
        //    {
        //        transform.RotateAround(Player.transform.position, Vector3.up, 2.0f);
        //    }
        //}
        
        HitCount++;
	}

    private void FixedUpdate()
    {
        switch (scenedata.StageFlg)
        {
            case 0:
                break;
            case 1:
                if (wakuseidata.HitHantei[0] == true || wakuseidata.HitHantei[1] == true)
                {
                    transform.RotateAround(Player.transform.position, Vector3.up, 2.0f);
                }
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

    }

    private void OnTriggerStay(Collider other)
    {
        switch (scenedata.StageFlg)
        {
            case 0:
                if (HitCount > 100)
                {


                    if (other.name == "Star")
                    {
                        WakuseiSelect = true;
                    }
                    else
                    {
                        WakuseiSelect = false;
                    }
                }
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

        //if (scenedata.StageFlg==0)
        //{
        //    if (HitCount > 100)
        //    {
                

        //        if (other.name == "Star")
        //        {
        //            WakuseiSelect = true;
        //        }
        //        else
        //        {
        //            WakuseiSelect = false;
        //        }
        //    }
        //}
    }
}
