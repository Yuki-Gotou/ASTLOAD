using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDpwn : MonoBehaviour {

    public float PlanetMove;

	// Use this for initialization
	void Start () {
        PlanetMove = Random.Range(-0.1f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos;
        pos = this.transform.position;
        pos.y += PlanetMove;
        if(pos.y>=3.0f)
        {
            pos.y = 3.0f;
            PlanetMove = PlanetMove * -1.0f;
        }
        if (pos.y <= -3.0f)
        {
            pos.y = -3.0f;
            PlanetMove = PlanetMove * -1.0f;
        }
        this.transform.position = pos;
    }
}
