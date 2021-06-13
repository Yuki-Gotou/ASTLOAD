// ================================================================
// 
// cpp  : SelectCamera.cs
//
// ---------------------------------------------------------------- 
//
// 制作者   : 佐藤 晶斗
// 作成日時 : 2019/6/13
// 完成及びコメントの付与
//
// ----------------------------------------------------------------
// 
// オブジェクトの移動を管理するプログラム
// 
// ================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCamera : MonoBehaviour
{

    const float fAng = 45.0f;   // 定数
    static float RearrotY;      // カメラ操作用
    static float CameraPosY;    // カメラの高さ
    static float SpaceShipPosY; // スペースシップの高さ

    float dynamicRotY;  // 実数

    public GameObject StageSelect;
    MySceneManager MySceneManagerCS;

    static bool bLotateFlgL = false;        // tureの間左に動く
    static bool bLotateFlgR = false;        // tureの間右に動く

    private GameObject MainCamera;
    private GameObject SpaceShip;

    const float Rotate_speed = 4.0f;        // スペースシップの移動速度 (左右)
    const float CameraUp_speed = 2.5f;      // カメラの移動速度(上下)

    bool flgR = false;
    bool flgL = false;

    // Use this for initialization
    void Start()
    {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        SpaceShip = GameObject.FindGameObjectWithTag("SpaceShip");
        RearrotY = 0.0f;        // 仮数
        dynamicRotY = 0.0f;     // 実数

        CameraPosY = 271.0f;
        SpaceShipPosY = 230.0f;
    }

    // Update is called once per frame
    void Update()
    {
        MySceneManager StageSelectObj = StageSelect.GetComponent<MySceneManager>();

        Camera camera = Camera.main;
        camera.gameObject.transform.position = new Vector3(464, CameraPosY, -750);
        camera.gameObject.transform.rotation = Quaternion.Euler(0.0f, dynamicRotY, 0.0f);  // カメラの操作
        Vector3 ShipPosY = SpaceShip.transform.position;

        ShipPosY.y = SpaceShipPosY;

        SpaceShip.transform.position = ShipPosY;

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!flgL)                  // 現在選択しているステージが１じゃなかったら
            {                           // 左に進める
                bLotateFlgL = true;     // 左フラグセット
                bLotateFlgR = false;     // 右フラグセット

                RearrotY = RearrotY - fAng;     // 左に戻る
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (!flgR)                     // 現在選択しているステージが現在の最大ステージじゃなかったら
            {                              // 右に進める
                bLotateFlgL = false;     // 左フラグセット
                bLotateFlgR = true;     // 右フラグセット

                RearrotY = RearrotY + fAng;     // 右に進む
            }
        }

        // ----- 現在選べるステージより先に行けないようにする -----
        if (StageSelectObj.nSelect == 1)
            flgL = true;                // trueの間左に移動できない

        else
            flgL = false;

        if (StageSelectObj.nSelect == StageSelectObj.ActiveStage)   // activstage=現在選択できる最大ステージ
            flgR = true;                                            // tureの間右に移動できない

        else
            flgR = false;

        // ----- カメラ移動 -----
        if (bLotateFlgR == true)
        {
            if (dynamicRotY <= RearrotY)
            {
                SpaceShipPosY += 2.5f;
                dynamicRotY += 2.0f;
                CameraPosY += CameraUp_speed;
            }
            else
            {
                bLotateFlgR = false;
            }

        }
        else
        if (bLotateFlgL == true)    // 左が押されたら
        {
            if (dynamicRotY >= RearrotY)
            {
                SpaceShipPosY -= 2.5f;
                dynamicRotY -= 2.0f;
                CameraPosY -= CameraUp_speed;
            }
            else
            {
                bLotateFlgL = false;
            }
        }

        // ================================================
        if (bLotateFlgR == true)                // 右が押された
            RotateCamera(Rotate_speed);         // スペースシップを右に移動

        if (bLotateFlgL == true)                // 左が押された
            RotateCamera(-1.0f * Rotate_speed); // スペースシップを右に移動

    }

    // プレイヤーがカメラを軸に公転する関数
    void RotateCamera(float rate)
    {
        // カメラを軸に回転する
        transform.RotateAround(MainCamera.transform.position, Vector3.up,
        0.5f * rate);
    }
}
