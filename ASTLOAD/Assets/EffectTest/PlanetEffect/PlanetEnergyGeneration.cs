using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetEnergyGeneration : MonoBehaviour {


    // private
    [SerializeField]
    private string targetObj = "Test_Player";      // ターゲットネーム
    private GameObject playerObj;                  // プレイヤーオブジェクト
    private GameObject supplyEffectPrefab;         // 供給エフェクト
    private GameObject planetEN;                   // 

    [SerializeField]
    private int responseFream = 20;
    private int freamCnt = 0;

    [SerializeField]
    private bool bSelected = false;

    private string childName;

    // Use this for initialization
    void Start () {

        // プレイヤー
        playerObj = GameObject.Find(targetObj);

        // モデル読み込み
        supplyEffectPrefab = (GameObject)Resources.Load("Prefabs/Effects/PlanetEnergySupply/SupplyEffect");

        // 子の設定
        childName = "SupplyEffect_" + this.transform.name;


    }

    // Update is called once per frame
    void Update () {

        if (!bSelected)
            return;

        freamCnt++;

        if(responseFream <= freamCnt)
        {

            freamCnt = 0;

            // 生成
            planetEN = Instantiate(supplyEffectPrefab, playerObj.transform.position, Quaternion.identity);
            planetEN.transform.parent = this.transform;
            planetEN.name = childName;
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == childName)
        {
            Destroy(other.gameObject);
        }
    }


    public void setPlanetEnergy(bool flag)
    {
        bSelected = flag;
    }


}
