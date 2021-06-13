using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityMinas : MonoBehaviour {

    public Vector3 localGravity;
    public Rigidbody RBody;

    // Use this for initialization
    private void Start()
    {
        RBody.useGravity = false; //最初にrigidBodyの重力を使わなくする
        localGravity.y = 10;
        localGravity.x = Random.Range(-1, 3);
    }

    private void FixedUpdate()
    {
        SetLocalGravity(); //重力をAddForceでかけるメソッドを呼ぶ。FixedUpdateが好ましい。
    }

    private void SetLocalGravity()
    {
        RBody.AddForce(localGravity, ForceMode.Acceleration);
    }
}
