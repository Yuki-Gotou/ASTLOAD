using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSelection : MonoBehaviour {

    bool Scale;
    bool Rotation;

    int ScaleMove;
    int RotationMove;

    int MaxScale;

    public SceneData scenedata;

    //
    public int StarAnimationMove;
    public Vector3 StarAnimationSize;
    //

    // Use this for initialization
    void Start () {
        Scale = false;
        Rotation = false;

        ScaleMove = 0;
        RotationMove = 3;

        MaxScale = 1000;
        StarAnimationMove = -40;
    }
	
	// Update is called once per frame
	void Update () {

        switch (scenedata.StageFlg)
        {
            case 0:
                //拡大縮小
                if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.Joystick1Button5))
                {
                    ScaleMove = 10;
                }
                else if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.Joystick1Button4))
                {
                    ScaleMove = -10;
                }

                if (Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.Joystick1Button2))
                {
                    Rotation = true;
                }
                else
                {
                    Rotation = false;
                }
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            default:
                break;
        }


        //if (scenedata.StageFlg == 0)
        //{
        //    //拡大縮小
        //    if (Input.GetKey(KeyCode.Z)||Input.GetKey(KeyCode.Joystick1Button5))
        //    {
        //        ScaleMove = 10;
        //    }
        //    else if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.Joystick1Button4))
        //    {
        //        ScaleMove = -10;
        //    }

        //    if (Input.GetKey(KeyCode.X)|| Input.GetKey(KeyCode.Joystick1Button2))
        //    {
        //        Rotation = true;
        //    }
        //    else
        //    {
        //        Rotation = false;
        //    }
        //}
	}

    private void FixedUpdate()
    {
        //if(Scale==true)
        //{
            Vector3 ScaleMath = transform.localScale;
            ScaleMath.x += ScaleMove;
            ScaleMath.z += ScaleMove;
            transform.localScale = ScaleMath;
        if(ScaleMath.x>=2000||ScaleMath.z<=100)
        {
            ScaleMove = ScaleMove * -1;
            ScaleMath.x += ScaleMove;
            ScaleMath.z += ScaleMove;
            transform.localScale = ScaleMath;
        }
        ScaleMove = 0;
        //}
        if (Rotation==true)
        {
            transform.Rotate(0.0f, RotationMove, 0.0f);
        }

        switch (scenedata.StageFlg)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                //Vector3 ScaleMath = transform.localScale;
                ScaleMath.x += StarAnimationMove;
                ScaleMath.z += StarAnimationMove;
                transform.localScale = ScaleMath;
                if (ScaleMath.z <= 100)
                {
                    StarAnimationMove = StarAnimationMove * -1;
                    scenedata.StageFlg = 5;
                }
                if (ScaleMath.z >= StarAnimationSize.z)
                {
                    StarAnimationMove = StarAnimationMove * -1;
                    scenedata.StageFlg = 2;
                }
                break;
            case 5:
                //Vector3 ScaleMath = transform.localScale;
                ScaleMath.x += StarAnimationMove;
                ScaleMath.z += StarAnimationMove;
                transform.localScale = ScaleMath;
                if (ScaleMath.z <= 100)
                {
                    StarAnimationMove = StarAnimationMove * -1;
                    scenedata.StageFlg = 5;
                }
                if (ScaleMath.z >= StarAnimationSize.z)
                {
                    StarAnimationMove = StarAnimationMove * -1;
                    scenedata.StageFlg = 2;
                }
                break;
            default:
                break;
        }


        //if (scenedata.StageFlg==4|| scenedata.StageFlg == 5)
        //{
        //    //Vector3 ScaleMath = transform.localScale;
        //    ScaleMath.x += StarAnimationMove;
        //    ScaleMath.z += StarAnimationMove;
        //    transform.localScale = ScaleMath;
        //    if (ScaleMath.z <= 100)
        //    {
        //        StarAnimationMove = StarAnimationMove * -1;
        //        scenedata.StageFlg = 5;
        //    }
        //    if(ScaleMath.z>= StarAnimationSize.z)
        //    {
        //        StarAnimationMove = StarAnimationMove * -1;
        //        scenedata.StageFlg = 2;
        //    }
        //}
    }
}
