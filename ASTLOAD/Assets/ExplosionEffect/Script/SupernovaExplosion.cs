using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***************************************
 * 超新星爆発エフェクト
 * 1膨張しながら赤く変色
 * 2縮小
 * 3爆発しオブジェクトは消去

***************************************/
public class SupernovaExplosion : MonoBehaviour
{
    /// 開始色
    public Color colorStart;
    /// 終了色
    public Color colorEnd;


    //開始サイズ
    public Vector3 SiseStart;
    //終了サイズ
    public Vector3 SiseEnd;


    //最大サイズ
    public float MaxSize;
    //最小サイズ
    public float MimSize;

    /// フレームあたりの変化量
    public float rate = 0.001f;

    public Renderer ObjectRenderer;
    public float Time;

    //ステップ用
    public int ExplosionStep;

    //爆発フラグ
    public bool ExplosionFlg;
    public bool StepFlg;
    public bool SetFlg;

    public GameObject ExplosionPrefab;

    void Start()
    {
        ExplosionFlg = false;
        ExplosionStep = 0;
        colorStart = Color.black/*ObjectRenderer.material.color*/;
        //赤の色へ変化;
        colorEnd = Color.red;

        ExplosionPrefab.SetActive(false);

        //デバック用
        MaxSize = 1.5f;
        MimSize = 0.05f; ExplosionFlg = true;

        //ExplosionStep = 1;      //ステップを第一段階へ
        //SetFlg = true;
    }

    //グラデーションのポジションを管理する値 0f〜1f
    void Update()
    {
        switch (ExplosionStep)
        {
            case 1://膨張しつつ赤く変色

                //一度だけ走らせたい処理
                if (SetFlg)
                {
                    Time = 0;
                    SiseStart = transform.localScale;
                    SiseEnd = transform.localScale * MaxSize;
                    SetFlg = false;
                }
                //毎フレーム走らせたい処理
                if (Time < 1)
                {
                    transform.localScale = Vector3.Lerp(SiseStart, SiseEnd, Time);
                    //ObjectRenderer.material.color = Color.Lerp(colorStart, colorEnd, Time);
                    ObjectRenderer.material.SetColor("_EmissionColor", Color.Lerp(colorStart, colorEnd, Time));
                    Time += rate;
                }
                //終了確認
                //if (transform.localScale == SiseEnd)
                else
                {
                    ExplosionStep = 2;
                    SetFlg = true;
                }
                break;
            
            case 2://縮小しつつ光量アップ

                //一度だけ走らせたい処理
                if (SetFlg)
                {
                    Time = 0;
                    SiseStart = transform.localScale;
                    SiseEnd = transform.localScale * MimSize;
                    SetFlg = false;
                }
                //毎フレーム走らせたい処理
                if (Time < 1)
                {
                    transform.localScale = Vector3.Lerp(SiseStart, SiseEnd, Time);
                    Time += rate * 2;
                }
                //終了確認
                //if(transform.localScale == SiseEnd)
                else
                {
                    ExplosionStep = 3;
                    SetFlg = true;
                }
                break;
            //ステップ3　爆発
            case 3:
                ExplosionPrefab.transform.parent = null;
                ExplosionPrefab.SetActive(true);
                //Instantiate(ExplosionPrefab, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
                    ObjectRenderer.gameObject.SetActive(false);
                    Debug.Log("爆発");
                break;
        }

    }

	public void OnExplosion()
	{
		ExplosionFlg = true;

		ExplosionStep = 1;      //ステップを第一段階へ
		SetFlg = true;
	}
	public void OnExplosionT()
	{
		ExplosionFlg = true;

		ExplosionStep = 3;      //ステップを第一段階へ
		SetFlg = true;
	}
}

