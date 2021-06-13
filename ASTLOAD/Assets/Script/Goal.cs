using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {

    public RectTransform EnergyBartransform;
    private Vector3 nowpos;
    private Vector3 FinishPos;
    //ゲームクリア時にtrue
    public bool GameClear;
    //エネルギーバー移動終了時にtrue
    public bool EnergyBurst;

    //
    public PlayerData playerdata;
    public float PlayerEnergy;
    public BarScript barscript;
    public RezultItemMake rezultitemmake;
    //

    public GameObject ResuleButton;

	// Use this for initialization
	void Start () {
        GameClear = false;
        FinishPos = new Vector3(343.0f, 388.0f, 0.0f);
        EnergyBurst = false;

        ResuleButton.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        if (GameClear==true)
        {
            Invoke("ActiveInvoke", 5.0f);
            SceneClear();
            EnergyBarMove();
            PlayerEnergy = playerdata.Energy;
        }

        if(EnergyBurst==true)
        {
            PlayerEnergy-=10;
            if (PlayerEnergy <= 0)
            {
                barscript.EnergyUpdater(PlayerEnergy);
                EnergyBurst = false;
                rezultitemmake.FinishEnergy = true;
                Debug.Log("終了");
                //SceneManager.LoadScene("StageSelect");
            }
            else
            {
                barscript.EnergyUpdater(PlayerEnergy);
                rezultitemmake.CreateFlg = true;
            }

            barscript.EnergyUpdater(PlayerEnergy);
        }

    }



    void EnergyBarMove()
    {
        nowpos = EnergyBartransform.transform.position;
        if (nowpos.x != FinishPos.x)
        {
            nowpos.x += 1.0f;
        }
        if (nowpos.y != FinishPos.y)
        {
            nowpos.y += 1.0f;
        }
        if(nowpos.x==FinishPos.x&& nowpos.y == FinishPos.y)
        {
            EnergyBurst = true;
            GameClear = false;
        }
        EnergyBartransform.transform.position = nowpos;

    }

    void SceneClear()
    {

        switch (SceneManager.GetActiveScene().name)
        {
            case "Stage1":
                MySceneManager.bClearFlg[1] = true;
                break;
            case "Stage2":
                MySceneManager.bClearFlg[2] = true;
                break;
            case "Stage3":
                MySceneManager.bClearFlg[3] = true;
                break;
            case "Stage4":
                MySceneManager.bClearFlg[4] = true;
                break;
            case "Stage5":
                MySceneManager.bClearFlg[5] = true;
                break;
            case "Stage6":
                MySceneManager.bClearFlg[6] = true;
                break;
            case "Stage7":
                MySceneManager.bClearFlg[7] = true;
                break;
            case "Stage8":
                MySceneManager.bClearFlg[8] = true;
                break;
        }


        
    }

    private void ActiveInvoke()
    {

        ResuleButton.SetActive(true);
    }


}
