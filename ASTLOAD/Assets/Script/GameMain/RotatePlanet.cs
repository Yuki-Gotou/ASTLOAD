using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class RotatePlanet : MonoBehaviour
{
    /*
     *ゲーム内の回す対象となる惑星の制作
     *プレイヤーを回すことのできるプログラムの制作
     *回す時間は所持エネルギー量に合わせて。
     *エネルギーを貯める容器の変数、最大値を定義する変数  **
     *public変数で用意                                       
     *惑星はエネルギーの最大値で3種類に変化
     *元は全て同じ。
     *
     */
    // 惑星の制作
    //GameObject Game_Planets[];

    // プラネットの行動状態
    private enum PlanetState
    {
        Wait,         // 動かない
        Rotate       // 対象に向けて移動中
    };

    // 惑星のID = IDごとに惑星データが違う
    public int nPlanetId;

    // プレイヤーのオブジェクト
  //  public GameObject PlayerObj; // プレイヤーオブジェクト情報取得変数

    private float PlanetEnergy;     // 惑星のエネルギー量
    
    PlanetData Planet_Earth;

    private PlanetState mode;

    // Use this for initialization
    void Start()
    {
        
        // Excelで作成した惑星データを読み込む
        Planet_Earth = Resources.Load("PlanetData") as PlanetData;
        // Editorの方で指定された惑星Idの最大エネルギー量を代入
        PlanetEnergy = Planet_Earth.sheets[0].list[nPlanetId - 1].MaxEnergy;

        // ちゃんと読み込まれた確認
        for (int i = 0; i < 3; i++)
        {
            Debug.Log(Planet_Earth.sheets[0].list[i].id);           // 惑星ID 
            Debug.Log(Planet_Earth.sheets[0].list[i].name);         // 惑星ネーム
            Debug.Log(Planet_Earth.sheets[0].list[i].Size);         // 惑星の大きさ
            Debug.Log(Planet_Earth.sheets[0].list[i].MaxEnergy);    // 惑星の最大エネルギー量
            Debug.Log(Planet_Earth.sheets[0].list[i].Weight);       // 惑星の重さ
			//Debug.Log(Planet_Earth.sheets[0].list[i].judge);      // 惑星の重量補正
        }
        //Planet_Earth.sheets[0].list[0].id
    }

    // Update is called once per frame
    void Update()
    {

        // この星のエネルギーがなくなるまで
        if(PlanetEnergy >= 0.0f)
        {
            MovePlanet();       //  星は回転する
        }
        
    }

    // サーチ範囲に入ったら、プレイヤー
    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            mode = PlanetState.Rotate;
        }
    }

    // 星ごとのIDで動かすものを決める。
    void MovePlanet()
    {
         // 任意のオブジェクトの周りで回転させる
         transform.RotateAround(GameObject.FindGameObjectWithTag("Player").transform.position, Vector3.up, 
             0.5f* Planet_Earth.sheets[0].list[nPlanetId - 1].Weight);

         // 回転と同時にエネルギー消費
         PlanetEnergy -= 1.0f;
         
        //Planet_Earth.sheets[0].list[0].Size

    }
       
}
