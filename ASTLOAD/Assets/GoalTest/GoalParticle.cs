using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalParticle : MonoBehaviour {

    // public


    // private
    private GameObject parent;
    private float speed;

    // 速度
    [SerializeField] private float speedVole_Min = 2.0f;
    [SerializeField] private float speedVole_Max = 3.0f;
    [SerializeField] private float fallSpeed = 0.1f;

    // 生存時間
    [SerializeField] private int lifeTime = 80;


    // Use this for initialization
    void Start () {

        parent = transform.parent.gameObject;
        speed = Random.Range(speedVole_Min, speedVole_Max);


    }
	
	// Update is called once per frame
	void Update () {

        // ゴールを向く
        this.transform.LookAt(parent.transform);

        // 位置更新
        transform.position += transform.forward * speed * Time.deltaTime;
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y - fallSpeed,
            transform.position.z);

        // 生存時間
        lifeTime--;
        if (lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }

    }
}
