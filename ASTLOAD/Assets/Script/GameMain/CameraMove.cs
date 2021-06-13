using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    private enum CameraState
    {
        Wait,       // 待機モード(常に一定の距離を追従)
        Action      // アクションモード(回転アクション時にカメラの位置変更)
    }
    [SerializeField]
    private GameObject player;       //　プレイヤーゲームオブジェクトへの参照を格納する private 変数
    [SerializeField]
    private SceneData scenedata;	 //  シーン情報

    private Vector3 Playerpos;       //　プレイヤー座標格納するprivate変数 
    private Vector3 CameraFoward;    //　カメラの向きをセットする変数
    [SerializeField]
    private Vector3 ShiftPos = new Vector3(0.0f, 200.0f, 0.0f);    //　カメラのY座標をずらす変数
    private Vector3 ChangeRot = new Vector3(90.0f, 0.0f, 0.0f);    //　カメラの向きを変える
    private Vector3 offset;
    [SerializeField]
    private float RotSpeed = 5.0f;  // 回転速度
    [SerializeField]
    private float RotRate;          // 回転速度の割合
    private bool bflg;        		// 0 = なにもしない、1 = 前の座標を格納タイム
    private CameraState mode;		// カメラ状態遷移


    private float CameraPosY = 150.0f;  // アクション中のカメラのY座標

    // Use this for initialization
    void Start()
    {

        //プレイヤーとカメラ間の距離を取得してそのオフセット値を計算し、格納します。
        player = GameObject.FindGameObjectWithTag("Player");
        Playerpos = player.transform.position;
        offset = transform.position;
        // カメラの初期状態
        mode = CameraState.Wait;
        CameraFoward = this.transform.localRotation.eulerAngles;    //　カメラの最初の向き(角度)を取得


        RotRate = 0.5f;         // 速度レート

    }

    // Update is called once per frame
    void Update()
    {

        // ボタン入力で状態遷移変更
        if (scenedata.StageFlg == 1)
        {       // プレイヤーが能力使うキーがＡだと仮定して
            // カメラアクションモードに変更
            mode = CameraState.Action;
        }
        else
        {
			//	カメラ待機モードに変更
            mode = CameraState.Wait;
        }



    }
    // Update関数が呼ばれた後に呼び出すアップデート関数
    private void LateUpdate()
    {
		// 待機モード
        if (mode == CameraState.Wait)
        {
            // 毎フレーム、プレイヤー座標のずれを取得しカメラ座標に格納する
            transform.position += player.transform.position - Playerpos;
            Playerpos = player.transform.position;
            // 左キー
            if (Input.GetKey(KeyCode.Q))
            {
                // 左回転
                RotateCamera(RotRate * (-1));

            }
            // 右キー
            if (Input.GetKey(KeyCode.E))
            {
                // 右回転
                RotateCamera(RotRate);
            }

            // 前座標格納するかフラグ
			if (bflg == true)
            {
                // アクションに入る前の座標をセット
                transform.position = offset;
                transform.eulerAngles = CameraFoward;

				bflg = false;
            }

            // 今の座標を格納
            offset = transform.position;
            CameraFoward = transform.eulerAngles;

        }
        if (mode == CameraState.Action)		// アクションモード
        {

			// カメラ座標(x,z)をプレイヤーと一致させる、yは高めに設定する
            transform.position = new Vector3(
                player.transform.position.x,
                CameraPosY, 
                player.transform.position.z);

            // カメラの向きを下向きに
            transform.eulerAngles = ChangeRot;
			bflg = true;
        }

    }

    // キャラクターを軸にX方向にカメラが公転する
    void RotateCamera(float rate)
    {
        // プレイヤーオブジェクトの周りで回転する
        transform.RotateAround(Playerpos, Vector3.up,
           RotSpeed * rate);
    }

    void ActionCamera()
    {
        // カメラをプレイヤーと指定された星が見えるように、カメラ位置(x,z)をプレイヤーと同じにし
        // yの位置は星のサイズを基準に高く設定
        transform.position = player.transform.position;
    }


}

