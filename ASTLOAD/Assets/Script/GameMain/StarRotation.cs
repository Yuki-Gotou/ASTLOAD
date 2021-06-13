using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRotation : MonoBehaviour {

    public SceneData scenedata;
    public Sound sound;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        switch (scenedata.StageFlg)
        {
            case 0:
                sound.SoundStop();
                break;
            case 1:
                transform.Rotate(new Vector3(0.0f, 2.0f, 0.0f));
                sound.PlayOneShot(0);
                break;
            case 2:
                transform.Rotate(new Vector3(0.0f, 2.0f, 0.0f));
                sound.PlayOneShot(0);
                break;
            case 3:
                sound.SoundStop();
                break;
            case 4:
                sound.SoundStop();
                break;
            case 5:
                sound.SoundStop();
                break;
            default:
                sound.SoundStop();
                break;
        }


        //if (scenedata.StageFlg == 1 || scenedata.StageFlg == 2)
        //{
        //    transform.Rotate(new Vector3(0.0f, 2.0f, 0.0f));
        //    sound.PlayOneShot(0);
        //}
        //else
        //{
        //    sound.SoundStop();
        //}
    }
}
