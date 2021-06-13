using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    // コインの行動状態
    private enum CoinState
    {
        Wait,       // 動かない
        Chase       // 対象に向けて移動中
    };
    

    //移動スピード
    public float speed;

    // マテリアル情報格納用
    MeshRenderer meshcolor;

    // α値
    Color colorAlpha;
    


    // コインの状態遷移格納用
    private CoinState mode;

    // プレイヤー情報
    public PlayerData playerdata;
    [SerializeField]
	private int EnergyPlus;

    //	サウンド
    public Sound sound;


    void Start()
    {
		// 初期化宣言
        mode = CoinState.Wait;
        meshcolor = GetComponent<MeshRenderer>();
        colorAlpha = new Color(0.0f, 0.0f, 0.0f, 0.1f);
    }


    // 当たったら
    private void OnTriggerStay(Collider other)
    {
        // 追従モード
        if (other.name == "Player")
        {
            mode = CoinState.Chase;
        }
    }

    // 当たらなかったら
    private void OnTriggerExit(Collider other)
    {
        // 止まる
        mode = CoinState.Wait;
        
    }

    // Update is called once per frame
    void Update()
    {
        // 常に座標を取得　
        Vector3 tmp = GameObject.FindGameObjectWithTag("Player").transform.position;
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(tmp.x, tmp.y, tmp.z);

        // 待機状態
        if(mode == CoinState.Wait)
        {
			// 何もしない
        }

        // チェイスモード
        if (mode == CoinState.Chase)
        {

            // 少しづつ透明に
            meshcolor.material.color -= colorAlpha;

            Vector3 direction = tmp - transform.position;
            direction.Normalize();
            
            //SearchObjに向かって進む
            transform.position += direction * speed * 0.1f;
            
        }


        // 透明になったら
        if (meshcolor.material.color.a <= 0.0f)
        {
			// エネルギーをプレイヤーデータに足す
            playerdata.Energy += EnergyPlus;
            sound.PlayClipAtPoint(0);			// SEを鳴らす
            // すぐに自分を削除
            Destroy(this.gameObject);
        }

    }

    

}
