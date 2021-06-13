using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    public SceneData scenedata;
    public GameObject StarData;
    public StarSelection starselection;
    public GameObject StarObject;

    //プレイヤーステータス
    public int Energy;
    public int MaxEnergy;

	public int MinusEnergy;		// Hitしたら減るエネルギー容量
    public int PlanetPower;     //

    public BarScript barscript;

	// Use this for initialization
	void Start () {
        MaxEnergy = 1000;
		Energy = MaxEnergy;
		MinusEnergy = 300;
        barscript.SetMaxEnergy(MaxEnergy);
    }

    // Update is called once per frame
    void Update () {

        switch (scenedata.StageFlg)
        {
            case 0:
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Joystick1Button1))
                {
                    scenedata.StageFlg = 1;
                }
                StarData.transform.position = transform.position;
                barscript.EnergyUpdater(Energy);
                break;
            case 1:
                if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.Joystick1Button1))
                {
                    if (PlanetPower > 0)
                    {
                        scenedata.StageFlg = 4;
                        PlanetPower = 0;
                        starselection.StarAnimationSize = StarObject.transform.localScale;
                    }
                    else
                    {
                        scenedata.StageFlg = 0;
                    }
                }
                StarData.transform.position = transform.position;
                Energy--;
                if (Energy <= 0)
                {
                    Energy = 0;
                    scenedata.StageFlg = 10;
                }
                barscript.EnergyUpdater(Energy);
                break;
            case 2:
                barscript.EnergyUpdater(Energy);
                break;
            case 3:
                break;
            case 4:
                StarData.transform.position = transform.position;
                barscript.EnergyUpdater(Energy);
                break;
            case 5:
                barscript.EnergyUpdater(Energy);
                break;
            default:
                break;
        }

        //Energy = Energy;	// 常にエネルギー更新
        //if (scenedata.StageFlg == 0)
        //{
        //    if (Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.Joystick1Button1))
        //    {
        //        scenedata.StageFlg = 1;
        //    }
        //}
        //if (scenedata.StageFlg == 1)
        //{
        //    if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.Joystick1Button1))
        //    {
        //        if (PlanetPower > 0)
        //        {
        //            scenedata.StageFlg = 4;
        //            PlanetPower = 0;
        //            starselection.StarAnimationSize = StarObject.transform.localScale;
        //        }
        //        else
        //        {
        //            scenedata.StageFlg = 0;
        //        }
        //    }
        //}

        //if (scenedata.StageFlg==0|| scenedata.StageFlg == 1|| scenedata.StageFlg == 4)
        //{
        //    StarData.transform.position = transform.position;
        //}

   //     if(scenedata.StageFlg==1)
   //     {
			//Energy--;
			//if(Energy<=0)
   //         {
			//	Energy = 0;
   //             scenedata.StageFlg = 10;
   //         }
			//barscript.EnergyUpdater(Energy);
   //     }
	}

    private void LateUpdate()
    {
		//Energy = Energy;	// 常にエネルギー更新
   //     if (scenedata.StageFlg == 0 || scenedata.StageFlg == 1 || scenedata.StageFlg == 2 || scenedata.StageFlg == 4 || scenedata.StageFlg == 5)
   //     {
			//barscript.EnergyUpdater(Energy);
   //     }
    }

    // ブラックホールに当たった時の処理
    private void OnTriggerEnter(Collider other)
	{
		// タグを見て当たっているかを決める。タグ名に注意
		if(other.tag == "BlackHoll")
		{
			Debug.Log("ブラックホールに当たってまあス");
			//Debug.Log (Energy);
            
			Energy = Energy - MinusEnergy;

		}
	}

}
