// ================================================================
// 
// cpp  : MySceneManager.cs
//
// ---------------------------------------------------------------- 
//
// 制作者   : 佐藤 晶斗
// 作成日時 : 2019/6/8
// 完成及びコメントの付与
//
// ----------------------------------------------------------------
// 
// ステージセレクトの管理用プログラム
// 
// ================================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MySceneManager : MonoBehaviour
{

    int OldSelect = 0;   // 前のセレクトの退避用
    float PlanetRotY;    // 惑星回転用変数

    // ----- 惑星のオブジェクト -----
    public GameObject Planet1;
    public GameObject Planet2;
    public GameObject Planet3;
    public GameObject Planet4;
    public GameObject Planet5;
    public GameObject Planet6;
    public GameObject Planet7;
    public GameObject Planet8;

    public GameObject SaturnRing;                   // STAGE6用、土星の環っか

    // ----- STAGE1テクスチャ -----
    public GameObject select1Logo;
    public GameObject select2Logo;
    public GameObject select3Logo;
    public GameObject select4Logo;
    public GameObject select5Logo;
    public GameObject select6Logo;
    public GameObject select7Logo;
    public GameObject select8Logo;

    // 惑星クリアフラグ（配列）
    public static bool[] bClearFlg = new bool[8];   // ステージクリアしたらフラグが立つ
                                                    // stage1をクリアすると[1]にtrueが入る

    // フェード用
    public FadeIn fadein;

    // 最大ステージ数（可変、現状MAX8）
    public int ActiveStage;

    // 現在のセレクト番号
    public int nSelect;

    // デバッグ用フラグ
    public bool g_Debug = false;

    // 上田
    private static bool stFlag = false;

    // Use this for initialization
    void Start()
    {
        if(!stFlag)
        {
            for (int i = 0; i < 8; i++)
            {
                bClearFlg[i] = false;
            }
            stFlag = true;
        }

        Planet2.SetActive(false);   // 初期値で非表示
        Planet3.SetActive(false);
        Planet4.SetActive(false);
        Planet5.SetActive(false);
        Planet6.SetActive(false);
        SaturnRing.SetActive(false);
        Planet7.SetActive(false);
        Planet8.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // ----------------------------------
        // カーソル処理
        // ----------------------------------
        if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("LeftButton"))
        {
            nSelect--;
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetButtonDown("RightButton"))
        {
            nSelect++;
        }

        // ----------------------------------
        // カーソルループ
        // ----------------------------------
        if (nSelect >= ActiveStage + 1)
            nSelect = ActiveStage;

        if (nSelect <= 0)
            nSelect = 1;

        // ----------------------------------------------
        // クリアフラグを立てるとステージが解放される
        // ----------------------------------------------
        if (bClearFlg[1] == true)       // STAGE1をクリアした！
        {
            if (ActiveStage < 2)
                ActiveStage += 1;       // 最大ステージ+1

            Planet2.SetActive(true);    // STAGE2オブジェクトの表示
        }

        if (bClearFlg[2] == true)
        {
            if (ActiveStage < 3)
                ActiveStage += 1;
            Planet3.SetActive(true);
        }

        if (bClearFlg[3] == true)
        {
            if (ActiveStage < 4)
                ActiveStage += 1;
            Planet4.SetActive(true);
        }

        if (bClearFlg[4] == true)
        {
            if (ActiveStage < 5)
                ActiveStage += 1;
            Planet5.SetActive(true);
        }

        if (bClearFlg[5] == true)
        {
            if (ActiveStage < 6)
                ActiveStage += 1;
            SaturnRing.SetActive(true);
            Planet6.SetActive(true);
        }

        if (bClearFlg[6] == true)
        {
            if (ActiveStage < 7)
                ActiveStage += 1;
            Planet7.SetActive(true);
        }

        if (bClearFlg[7] == true)
        {
            if (ActiveStage < 8)
                ActiveStage += 1;
            Planet8.SetActive(true);
        }


        // ----------------------------------------------
        // （デバッグ処理）ボタンを押すと解放される
        // ----------------------------------------------
        if (g_Debug)
        {
            if (Input.GetKey("1"))
            {
                bClearFlg[1] = true;
            }

            if (Input.GetKey("2"))
            {
                bClearFlg[2] = true;
            }

            if (Input.GetKey("3"))
            {
                bClearFlg[3] = true;
            }

            if (Input.GetKey("4"))
            {
                bClearFlg[4] = true;
            }

            if (Input.GetKey("5"))
            {
                bClearFlg[5] = true;
            }

            if (Input.GetKey("6"))
            {
                bClearFlg[6] = true;
            }

            if (Input.GetKey("7"))
            {
                bClearFlg[7] = true;
            }
        }

        // ----------------------------------
        // ステージセレクト処理
        // ----------------------------------
        if (Input.GetKey("space") || Input.GetKeyDown(KeyCode.Joystick1Button1))    // スペースキーでフラグが立つ
        {
            fadein.FadeInFlg = true;
        }

        if (fadein.FadeFinish == true)                   // スペースキーフラグが立っていたら
        {
            if (nSelect == 1)                          // ステージ1が選ばれていたら
            {
                SceneManager.LoadScene("Stage1");       // ステージ1に移動
            }

            if (bClearFlg[1] == true && nSelect == 2)  // 前のステージのクリアフラグが立っていて2が選ばれていたら
            {
                SceneManager.LoadScene("Stage2");       // ステージ2に移動
            }

            if (bClearFlg[2] == true && nSelect == 3)
            {
                SceneManager.LoadScene("Stage3");
            }

            if (bClearFlg[3] == true && nSelect == 4)
            {
                SceneManager.LoadScene("Stage4");
            }

            if (bClearFlg[4] == true && nSelect == 5)
            {
                SceneManager.LoadScene("Stage5");
            }

            if (bClearFlg[5] == true && nSelect == 6)
            {
                SceneManager.LoadScene("Stage6");
            }

            if (bClearFlg[6] == true && nSelect == 7)
            {
                SceneManager.LoadScene("Stage7");
            }

            if (bClearFlg[7] == true && nSelect == 8)
            {
                SceneManager.LoadScene("Stage8");
            }
        }

        PlanetRotY += 1.0f;             // 惑星を回転させる

        if (PlanetRotY >= 360.0f)       // 360度を超えたら0度に戻す
            PlanetRotY = 0.0f;

        if (OldSelect != nSelect)       // 別のステージを選択したら、回転角度を初期化
            PlanetRotY = 0.0f;

        OldSelect = nSelect;            // 過去のセレクト退避

        // ------------------------------------------
        // 選択したステージを拡大・回転処理
        // ------------------------------------------
        switch (nSelect)
        {
            case 1:
                Planet8.transform.localScale = new Vector3(300.0f, 300.0f, 300.0f);                     // 選択したステージの両隣を戻す
                Planet1.transform.localScale = new Vector3(330.0f, 330.0f, 330.0f);                     // 選択したステージを大きく
                Planet2.transform.localScale = new Vector3(300.0f, 300.0f, 300.0f);                     // 選択したステージの両隣を戻す

                Planet1.transform.localRotation = Quaternion.Euler(0.0f, PlanetRotY, 0.0f);             // 回転

                select8Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);   // 選択したテクスチャーの両隣の非表示
                select1Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);   // 表示
                select2Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);   // 選択したテクスチャーの両隣の非表示
                break;

            case 2:
                Planet1.transform.localScale = new Vector3(300.0f, 300.0f, 300.0f);
                Planet2.transform.localScale = new Vector3(330.0f, 330.0f, 330.0f);
                Planet3.transform.localScale = new Vector3(300.0f, 300.0f, 300.0f);
                Planet2.transform.localRotation = Quaternion.Euler(0.0f, PlanetRotY, 0.0f);
                select1Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                select2Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                select3Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                break;

            case 3:
                Planet2.transform.localScale = new Vector3(300.0f, 300.0f, 300.0f);
                Planet3.transform.localScale = new Vector3(330.0f, 330.0f, 330.0f);
                Planet4.transform.localScale = new Vector3(300.0f, 300.0f, 300.0f);
                Planet3.transform.localRotation = Quaternion.Euler(0.0f, PlanetRotY, 0.0f);
                select2Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                select3Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                select4Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                break;

            case 4:
                Planet3.transform.localScale = new Vector3(300.0f, 300.0f, 300.0f);
                Planet4.transform.localScale = new Vector3(330.0f, 330.0f, 330.0f);
                Planet5.transform.localScale = new Vector3(300.0f, 300.0f, 300.0f);
                Planet4.transform.localRotation = Quaternion.Euler(0.0f, PlanetRotY, 0.0f);
                select3Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                select4Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                select5Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                break;

            case 5:
                Planet4.transform.localScale = new Vector3(300.0f, 300.0f, 300.0f);
                Planet5.transform.localScale = new Vector3(330.0f, 330.0f, 330.0f);
                Planet6.transform.localScale = new Vector3(300.0f, 300.0f, 300.0f);
                Planet5.transform.localRotation = Quaternion.Euler(0.0f, PlanetRotY, 0.0f);
                select4Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                select5Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                select6Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                break;

            case 6:
                Planet5.transform.localScale = new Vector3(300.0f, 300.0f, 300.0f);
                Planet6.transform.localScale = new Vector3(330.0f, 330.0f, 330.0f);
                Planet7.transform.localScale = new Vector3(300.0f, 300.0f, 300.0f);
                Planet6.transform.localRotation = Quaternion.Euler(0.0f, PlanetRotY, 0.0f);
                select5Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                select6Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                select7Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                break;

            case 7:
                Planet6.transform.localScale = new Vector3(300.0f, 300.0f, 300.0f);
                Planet7.transform.localScale = new Vector3(330.0f, 330.0f, 330.0f);
                Planet8.transform.localScale = new Vector3(300.0f, 300.0f, 300.0f);
                Planet7.transform.localRotation = Quaternion.Euler(0.0f, PlanetRotY, 0.0f);
                select6Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                select7Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                select8Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                break;

            case 8:
                Planet7.transform.localScale = new Vector3(300.0f, 300.0f, 300.0f);
                Planet8.transform.localScale = new Vector3(330.0f, 330.0f, 330.0f);
                Planet1.transform.localScale = new Vector3(300.0f, 300.0f, 300.0f);
                Planet8.transform.localRotation = Quaternion.Euler(0.0f, PlanetRotY, 0.0f);
                select7Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                select8Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                select1Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                break;

            default:
                break;
        }
    }
}
