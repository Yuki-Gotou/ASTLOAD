using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GoalButton : MonoBehaviour {

    public FadeIn fadeInSC;

    private bool selectFlag = false;
    private bool titleFlag = false;
    public Button titleB;
    public Button selectB;

    //public GameObject tB;
    //public GameObject sB;


    // Use this for initialization
    void Start () {

        //EventSystem.current.SetSelectedGameObject(sB);
    }

    // Update is called once per frame
    void Update () {

        if (fadeInSC.FadeFinish)
        {

            if(selectFlag)
            {
                SceneManager.LoadScene("StageSelect");
            }
            if (titleFlag)
            {
                SceneManager.LoadScene("Title");
            }
            
        }


    }

    public void OnClick_StageSelect()
    {
        fadeInSC.FadeInFlg = true;
        selectFlag = true;

    }

    public void OnClick_Title()
    {
        fadeInSC.FadeInFlg = true;
        titleFlag = true;
    }



}
