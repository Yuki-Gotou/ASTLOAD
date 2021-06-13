using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBar : MonoBehaviour {

    Vector3 Scale;
    public PlayerData playerData;
    public float MaxData;

    // Use this for initialization
    void Start () {
        MaxData = transform.localScale.x;

    }
	
	// Update is called once per frame
	void Update () {
        Scale = transform.localScale;
        Scale.x = MaxData* playerData.Energy / playerData.MaxEnergy;
        transform.localScale = Scale;
	}
}
