using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Wakusei : MonoBehaviour {

    //当たり判定確認格納配列   0 StarPoint,1 Star
    public bool[] HitHantei;
    //
    public SceneData    scenedata;
    public GameObject   StarData;
    public Renderer ObjectRenderer;
    public PlayerRotation playerrotation;
    public Rotation WakuseiRotation;
    public PlayerData playerdata;

    bool ITIDODAKE;
    //
    public bool Powerflg;
    public int StarPower;

    //
    public int nPlanetId;
    PlanetData Planet_Earth;
    //
    public float WakuseiWaight;
    //

    //
    //public StarSelection starselection;
    //public GameObject StarObject;
    //

    //
    public RingScript ringscript;
    public RingObject RingMove;
    public RingRotation ringrotation;
    public RingSpher ringspher;
    public GameObject RingBase;

    //惑星爆破
    public bool WakuseiLost;
    //

    //
    //エネルギーチャージ演出
    public PlanetEnergyGeneration planetenergygeneration;

    // Use this for initialization
    void Start () {
        StarPower = 0;
        Powerflg = false;
        // Excelで作成した惑星データを読み込む
        Planet_Earth = Resources.Load("PlanetData") as PlanetData;
		//Planet_Earth.sheets[0].list[0].
		WakuseiWaight = Planet_Earth.sheets[0].list[nPlanetId-1].Weight;
        for(int i=0;i>1;i++)
        {
            HitHantei[i] = false;
        }
        ITIDODAKE = false;
    }

    // Update is called once per frame
    void Update () {

        switch (scenedata.StageFlg)
        {
            case 0:
                
                break;
            case 1:
                if (Powerflg == true)
                {
                    StarPower++;
                    playerdata.PlanetPower++;
                    //ringscript.RingGetFlg = true;
                    RingBase.transform.position = this.transform.position;
                    ringrotation.WakuseiPos = this.transform.position;
                    planetenergygeneration.setPlanetEnergy(true);
                    ringspher.RingGo = true;
                    if (ITIDODAKE == false)
                    {
                        RingMove.ScallingMove = true;
                        //ringrotation.WakuseiWaight = WakuseiWaight;
                        ITIDODAKE = true;
                        ringspher.WakuseiWaight = WakuseiWaight;
                    }
                }

                break;
            case 2:
                ringscript.RingGetFlg = false;
                ITIDODAKE = false;
                planetenergygeneration.setPlanetEnergy(false);
                if (StarPower > 0)
                {
                    StarData.transform.position = transform.position;
                    playerrotation.WakuseiPos = transform.position;
                }

                break;
            case 3:
                break;
            case 4:
                if (StarPower > 0)
                {
                    if (WakuseiLost == true)
                    {
                        scenedata.StageFlg = 0;
                    }
                    else
                    {
                        playerrotation.WakuseiWaight = WakuseiWaight;
                    }
                    //scenedata.StageFlg = 4;
                    //starselection.StarAnimationSize = StarObject.transform.localScale;
                    //Debug.Log("wakusei");
                    //Debug.Log(WakuseiWaight);
                }

                break;
            case 5:
                ringscript.RingGetFlg = false;
                ITIDODAKE = false;
                planetenergygeneration.setPlanetEnergy(false);
                if (StarPower > 0)
                {
                    StarData.transform.position = transform.position;
                    playerrotation.WakuseiPos = transform.position;
                }
                ringspher.RingGo = false;
                break;
            default:
                break;
        }


        //if (scenedata.StageFlg==1)
        //{
        //    if(Powerflg==true)
        //    {
        //        StarPower++;
        //        playerdata.PlanetPower++;
        //        //ringscript.RingGetFlg = true;
        //        Ring.transform.position = this.transform.position;
        //        ringrotation.WakuseiPos = this.transform.position;
        //        planetenergygeneration.setPlanetEnergy(true);
        //        if (ITIDODAKE == false)
        //        {
        //            RingMove.ScallingMove = true;
        //            //ringrotation.WakuseiWaight = WakuseiWaight;
        //            ITIDODAKE = true;
        //            ringspher.WakuseiWaight = WakuseiWaight;
        //        }
        //    }
        //}

        //if(scenedata.StageFlg==4)
        //{
        //    if(StarPower>0)
        //    {
        //        if(WakuseiLost==true)
        //        {
        //            scenedata.StageFlg = 0;
        //        }
        //        else
        //        {
        //            playerrotation.WakuseiWaight = WakuseiWaight;
        //        }
        //        //scenedata.StageFlg = 4;
        //        //starselection.StarAnimationSize = StarObject.transform.localScale;
        //        //Debug.Log("wakusei");
        //        //Debug.Log(WakuseiWaight);
        //    }
        //}

		//if(scenedata.StageFlg==2|| scenedata.StageFlg == 5)
  //      {
  //          ringscript.RingGetFlg = false;
  //          ITIDODAKE = false;
  //          planetenergygeneration.setPlanetEnergy(false);
  //          if (StarPower>0)
  //          {
  //              StarData.transform.position = transform.position;
  //              playerrotation.WakuseiPos = transform.position;
  //          }
  //      }


    }

    private void LateUpdate()
    {
        if (HitHantei[0] == true)
        {
            ObjectRenderer.material.SetColor("_EmissionColor", new Color(50, 0, 0));
            //gameObject.GetComponent<Renderer>().material.color = new Color(0, 0, 0);
        }
        else if (HitHantei[1] == true)
        {
            ObjectRenderer.material.SetColor("_EmissionColor", new Color(50, 50, 0));
            //gameObject.GetComponent<Renderer>().material.color = new Color(255, 0, 0);
        }
        else
        {
            ObjectRenderer.material.SetColor("_EmissionColor", new Color(0, 0, 0));
            //gameObject.GetComponent<Renderer>().material.color = new Color(255, 255, 255);
        }
    }

    private void FixedUpdate()
    {

        switch (scenedata.StageFlg)
        {
            case 0:
                if (HitHantei[0] == true)
                {
                    Powerflg = true;
                }
                else
                {
                    Powerflg = false;
                }
                HitHantei[0] = false;
                HitHantei[1] = false;
                break;
            case 1:
                break;
            case 2:
                if (Powerflg == true)
                {
                    if (StarPower > 0)
                    {
                        StarPower--;
                    }

                    if (StarPower <= 0)
                    {
                        scenedata.StageFlg = 0;
                    }
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


        //if (scenedata.StageFlg == 0)
        //{
        //    if (HitHantei[0] == true)
        //    {
        //        Powerflg = true;
        //    }
        //    else
        //    {
        //        Powerflg = false;
        //    }
        //    HitHantei[0] = false;
        //    HitHantei[1] = false;
        //}
        //if (scenedata.StageFlg == 2)
        //{
        //    if (Powerflg == true)
        //    {
        //        if (StarPower > 0)
        //        {
        //            StarPower--;
        //        }

        //        if (StarPower <= 0)
        //        {
        //            scenedata.StageFlg = 0;
        //        }
        //    }
        //}

    }

    private void OnTriggerStay(Collider other)
    {
        if(scenedata.StageFlg==0)
        {
            if (other.name == "StarPointer")
            {
                //Powerflg = true;
                HitHantei[0] = true;
                WakuseiRotation.KouseiSelect = true;
            }

            if(other.name== "glass_1" || other.name == "glass_3" || other.name == "glass_5" || other.name == "glass_2" || other.name == "glass_center" || other.name == "glass_4")
            {
                HitHantei[1] = true;
            }
            
        }
    }
}
