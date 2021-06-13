using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleDebrisGenerate : MonoBehaviour {

    // private
    //private GameObject debrisPrefab;
    private int responseTime = 50;

    private List<GameObject> debrisList = new List<GameObject>();

    private int responseTime_Min = 30;
    private int responseTime_Max = 60;
    [SerializeField] private float debriRoteY_Min = 225.0f;
    [SerializeField] private float debriRoteY_Max = 315.0f;
    [SerializeField] private float debriSize_Min = 1.0f;
    [SerializeField] private float debriSize_Max = 5.0f;
    private float debriRoteZ_Min = 0.0f;
    private float debriRoteZ_Max = 360.0f;


    // Use this for initialization
    void Start()
    {

        // モデル読み込み
        //debrisPrefab = (GameObject)Resources.Load("Prefabs/debri");

        debrisList.Add((GameObject)Resources.Load("Prefabs/asteroid_1"));
        debrisList.Add((GameObject)Resources.Load("Prefabs/asteroid_2"));
        debrisList.Add((GameObject)Resources.Load("Prefabs/asteroid_3"));
        debrisList.Add((GameObject)Resources.Load("Prefabs/asteroid_4"));


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        responseTime--;

        if(responseTime <= 0)
        {
            responseTime = Random.Range(responseTime_Min, responseTime_Max);
            Quaternion q1 = Quaternion.Euler(
                0.0f,
                Random.Range(debriRoteY_Min, debriRoteY_Max),
                Random.Range(debriRoteZ_Min, debriRoteZ_Max));
            float debriPosZ = Random.Range(-18.0f, 16.0f);
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, debriPosZ);
            GameObject debri = Instantiate(debrisList[Random.Range(0,4)], pos, q1);
            float NumSize = Random.Range(debriSize_Min, debriSize_Max);
            debri.transform.localScale = new Vector3(NumSize * debri.transform.localScale.x, NumSize * debri.transform.localScale.y, NumSize * debri.transform.localScale.z);
            debri.transform.parent = this.transform;
        }

    }
}
