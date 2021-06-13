using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;



public class BarScript : MonoBehaviour {

    public Image ImgGreen;
    private float MaxEnergy;

    // Use this for initialization
    void Start() {

    }


    public void SetMaxEnergy(float max) {
        MaxEnergy = max;
    }
    
    public void EnergyUpdater(float current) {

        //ImageというコンポーネントのfillAmountを取得して操作する
        ImgGreen.fillAmount = current / MaxEnergy;
    }
}
