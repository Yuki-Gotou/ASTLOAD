using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleDebris : MonoBehaviour {

    // private
    private float speed;
    private Rigidbody rb;

    //[SerializeField]
    private float moveSpeed_Min = 3.0f;
    //[SerializeField]
    private float moveSpeed_Max = 5.5f;

    private float roteVolu_Min = 30.0f;
    private float roteVolu_Max = 60.5f;

    // Use this for initialization
    void Start () {

        speed = Random.Range(moveSpeed_Min, moveSpeed_Max);
    }
	
	// Update is called once per frame
	void Update () {

        transform.position += transform.forward * speed * Time.deltaTime;
        //transform.Rotate(new Vector3(0, 0,Random.Range(roteVolu_Min, roteVolu_Max)) * Time.deltaTime, Space.World);
    }


    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //if(other.gameObject.tag == "OutSpace")
        //{
        //    Destroy(this.gameObject);
        //}

        string layerName = LayerMask.LayerToName(other.gameObject.layer);

        if(layerName == "OutSpace")
        {
            Destroy(this.gameObject);
        }

    }

}
