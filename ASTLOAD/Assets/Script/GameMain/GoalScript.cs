using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour {

    public SceneData scenedata;
    public Goal goal;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.name=="Player")
        {
            scenedata.StageFlg = 3;
            goal.GameClear = true;
            //SceneManager.LoadScene("StageSelect");
        }
    }

}
