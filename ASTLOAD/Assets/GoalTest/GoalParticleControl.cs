using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalParticleControl : MonoBehaviour {

    // private
    private GameObject goalParticlPrefab;   // プレハブ
    private GameObject goalParticlPrefab2;   // プレハブ

    [SerializeField] private int responseFream = 10;    // 生成時間(F)
    private int timeCnt = 0;                            // 時間

    [SerializeField] private float range_Min = 4.0f;    // 生成距離(最短)
    [SerializeField] private float range_Max = 5.0f;    // 生成距離(最長)
    [SerializeField] private float rangeY = 5.0f;    // 生成距離(最長)

    [SerializeField] private int maxGenerationNum = 150;    // 最大生成数

    [SerializeField] private float roteSpeed = 3.0f;    // 回転速度

    [SerializeField] private int No = 0;    // 



    // Use this for initialization
    void Start () {

        // モデル読み込み
        goalParticlPrefab = (GameObject)Resources.Load("Prefabs/GoalParticle");
        goalParticlPrefab2 = (GameObject)Resources.Load("Prefabs/GoalParticle1");

    }
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(new Vector3(0, roteSpeed, 0));

        ParticleUpdate();

    }

    // パーティクル更新
    private void ParticleUpdate()
    {

        // パーティクル数制限
        if(maxGenerationNum <= this.transform.childCount)
        {
            return;
        }


        // 時間
        timeCnt++;

        // パーティクル生成
        if (responseFream <= timeCnt)
        {
            // 時間リセット
            timeCnt = 0;

            // パーティクル生成位置
            float distanceX = Random.Range(range_Min, range_Max);
            float distanceZ = Random.Range(range_Min, range_Max);


            float angle = Random.Range(0.0f, 360.0f);
            //Mathf.Sin(Time.time);

            Vector3 pos = new Vector3(
                this.transform.position.x + distanceX * Mathf.Cos(angle),
                this.transform.position.y + rangeY,
                this.transform.position.z + distanceZ * Mathf.Sin(angle));

            // 生成
            GameObject goalParticle = null;
            switch (No)
            {
                case 0:
                    goalParticle = Instantiate(goalParticlPrefab, pos, Quaternion.identity);
                    break;
                case 1:
                    goalParticle = Instantiate(goalParticlPrefab2, pos, Quaternion.identity);
                    break;

            }
            goalParticle.transform.parent = this.transform;

        }
    }


}
