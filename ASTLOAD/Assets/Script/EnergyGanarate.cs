using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyGanarate : MonoBehaviour {

	public GameObject CoinGanarate;		// コイン(エネルギー生成)生成オブジェ

    public Rotation StarRotation;		// Rotationデータ取得

    public SceneData StepScene; 		// シーン情報

	public int nSelectCnt;				// 星選択回数カウント変数

    public Wakusei wakusei;				// 惑星オブジェ

	[SerializeField]
	private SupernovaExplosion SExp;	// 爆発エフェクト管理変数

    [SerializeField]
    private int MaxSelectCnt;			// 星選択最大使用回数
    [SerializeField]
    private float fMaxRange;	     	// ランダム生成する最大範囲値格納変数
	private float fMinRange;
	[SerializeField]
	private int nMaxRange;
	private int nMinRange;

	// Use this for initialization
	void Start () {
        nSelectCnt = 0;
		fMinRange = 1.0f;
		nMinRange = 1;
    }
	
	// Update is called once per frame
	void Update () {
    }
    private void LateUpdate()
    {
        //全部の星が恒星になった回数が3回(可変値)以上になって、アクションを終えたら　：変更前の仕様
		// ↓
		// それぞれの星が恒星になった回数が3回(可変値)以上になって、アクションを終えたら		：変更後の仕様
        if (nSelectCnt >= MaxSelectCnt && StepScene.StageFlg == 0)
        {
            // エネルギーを爆発した恒星を中心に散布
            Instantiate(CoinGanarate, transform.position*Random.Range(1.0f,fMaxRange), Quaternion.identity);

            // 使用回数を超えた恒星は爆発
            Destroy(this.gameObject);
        }
    }

	// ブラックホールに当たった時の処理
    private void OnTriggerEnter(Collider other)
    {
		if(other.tag == "BlackHoll")
        {
            // エネルギーを散布
			for(int i = 0;i<Random.Range(nMinRange,nMaxRange);i++){            
				Instantiate(CoinGanarate, transform.position * Random.Range(fMinRange, fMaxRange), Quaternion.identity);
			}
			// 爆発
			SExp.OnExplosionT ();
            wakusei.WakuseiLost = true;		// オブジェを消す
        }
    }



}
