using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetEnergy : MonoBehaviour {

    // private
    private float speed;
    GameObject parent;

    // Use this for initialization
    void Start () {

        // 移動速度
        parent = transform.parent.gameObject;
        float dis = Vector3.Distance(this.gameObject.transform.position, parent.transform.position);
        speed = dis * 0.8f;

        // ターゲットを向く
        this.transform.LookAt(parent.transform);

    }
	
	// Update is called once per frame
	void Update () {

        // 移動
        transform.position += transform.forward * speed * Time.deltaTime;

    }

    

}
