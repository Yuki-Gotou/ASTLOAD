using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lost : MonoBehaviour {

    public RezultItemMake rezultmake;
    public SupernovaExplosion supernovaexplosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(rezultmake.FinishEnergy==true)
        {
            Debug.Log("終わった");
            supernovaexplosion.OnExplosionT();
        }
	}
}
