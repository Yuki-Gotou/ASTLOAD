using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour {

	[SerializeField]
	private AudioClip Music1;

	private AudioSource MusicCustom;

	[SerializeField] private GameObject select1;
	[SerializeField] private GameObject select2;
    [SerializeField] private GameObject select3;
    [SerializeField] private GameObject select4;
    [SerializeField] private GameObject select5;
    [SerializeField] private GameObject select6;
    [SerializeField] private GameObject select7;
    [SerializeField] private GameObject select8;
    [SerializeField] private GameObject select1Logo;
    [SerializeField] private GameObject select2Logo;
    [SerializeField] private GameObject select3Logo;
    [SerializeField] private GameObject select4Logo;
    [SerializeField] private GameObject select5Logo;
    [SerializeField] private GameObject select6Logo;
    [SerializeField] private GameObject select7Logo;
    [SerializeField] private GameObject select8Logo;

    public GameObject SaturnRing;

    public int nSelect = 1;

    int OldSelect = 0;
    float y;        // 惑星回転用変数
    public int MaxStage = 8;

    //public SelectCamera SelectCameraScript;

	// Use this for initialization
	void Start () {

        select2.SetActive(true);
        select3.SetActive(true);
        select4.SetActive(true);
        select5.SetActive(true);
        select6.SetActive(true);
        select7.SetActive(true);
        select8.SetActive(true);

        SaturnRing.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {

        MySceneManager MySceneManagerObj = FindObjectOfType<MySceneManager>();


        //SelectCameraScript.bMoveShip

        // ステージセレクトの内部処理
        float h = Input.GetAxis("Horizontal");
        
        //if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("LeftButton"))
        if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("LeftButton"))
        {
            nSelect--;
            Debug.Log(nSelect);
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetButtonDown("RightButton"))
        {
            nSelect++;
            Debug.Log(nSelect);
        }

        //-- クリアフラグを立てるとステージが解放される(仮) --
        if (Input.GetKey("1"))
        {
            if(MaxStage < 2)
            MaxStage += 1;

            select2.SetActive(true);
        }

        if (Input.GetKey("2"))
        {
            if (MaxStage < 3)
                MaxStage += 1;
            select3.SetActive(true);
        }

        if (Input.GetKey("3"))
        {
            if (MaxStage < 4)
                MaxStage += 1;
            select4.SetActive(true);
        }

        if (Input.GetKey("4"))
        {
            if (MaxStage < 5)
                MaxStage += 1;
            select5.SetActive(true);
        }

        if (Input.GetKey("5"))
        {
            if (MaxStage < 6)
                MaxStage += 1;
            SaturnRing.SetActive(true);
            select6.SetActive(true);
        }

        if (Input.GetKey("6"))
        {
            if (MaxStage < 7)
                MaxStage += 1;
            select7.SetActive(true);
        }

        if (Input.GetKey("7"))
        {
            if (MaxStage < 8)
                MaxStage += 1;
            select8.SetActive(true);
        }

        if (nSelect >= MaxStage + 1)        // カーソルループ
            nSelect = MaxStage;
       
        if (nSelect <= 0)
            nSelect = 1;

        y += 1.0f;

        if (y >= 360.0f)
            y = 0.0f;

        if (OldSelect != nSelect)       // 別のステージを選択したら、回転角度を初期化
            y = 0.0f;

        OldSelect = nSelect;
		SelectScale(nSelect);
		
	}

	void SelectScale(int nSelect){

		// 画面に収まるように拡縮を行う
		switch (nSelect)
		{
		case 1:
			select8.transform.localScale = new Vector3(100.0f, 100.0f, 100.0f);    
			select1.transform.localScale = new Vector3(130.0f, 130.0f, 130.0f);     // 選択したステージを大きく
			select2.transform.localScale = new Vector3(100.0f, 100.0f, 100.0f);		// 以外を戻す
			select1.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
			select8Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
			select1Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			select2Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
			break;

		case 2:
			select1.transform.localScale = new Vector3(100.0f, 100.0f, 100.0f);
			select2.transform.localScale = new Vector3(130.0f, 130.0f, 130.0f);
			select3.transform.localScale = new Vector3(100.0f, 100.0f, 100.0f);
			select2.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
			select1Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
			select2Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			select3Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
			break;

		case 3:
			select2.transform.localScale = new Vector3(100.0f, 100.0f, 100.0f);
			select3.transform.localScale = new Vector3(130.0f, 130.0f, 130.0f);
			select4.transform.localScale = new Vector3(100.0f, 100.0f, 100.0f);
			select3.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
			select2Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
			select3Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			select4Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
			break;

		case 4:
			select3.transform.localScale = new Vector3(100.0f, 100.0f, 100.0f);
			select4.transform.localScale = new Vector3(130.0f, 130.0f, 130.0f);
			select5.transform.localScale = new Vector3(100.0f, 100.0f, 100.0f);
			select4.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
			select3Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
			select4Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			select5Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
			break;

		case 5:
			select4.transform.localScale = new Vector3(100.0f, 100.0f, 100.0f);
			select5.transform.localScale = new Vector3(130.0f, 130.0f, 130.0f);
			select6.transform.localScale = new Vector3(100.0f, 100.0f, 100.0f);
			select5.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
			select4Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
			select5Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			select6Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
			break;

		case 6:
			select5.transform.localScale = new Vector3(100.0f, 100.0f, 100.0f);
			select6.transform.localScale = new Vector3(130.0f, 130.0f, 130.0f);
			select7.transform.localScale = new Vector3(100.0f, 100.0f, 100.0f);
			select6.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
			select5Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
			select6Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			select7Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
			break;

		case 7:
			select6.transform.localScale = new Vector3(100.0f, 100.0f, 100.0f);
			select7.transform.localScale = new Vector3(130.0f, 130.0f, 130.0f);
			select8.transform.localScale = new Vector3(100.0f, 100.0f, 100.0f);
			select7.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
			select6Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
			select7Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			select8Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
			break;

		case 8:
			select7.transform.localScale = new Vector3(100.0f, 100.0f, 100.0f);
			select8.transform.localScale = new Vector3(130.0f, 130.0f, 130.0f);
			select1.transform.localScale = new Vector3(100.0f, 100.0f, 100.0f);
			select8.transform.localRotation = Quaternion.Euler(0.0f, y, 0.0f);
			select7Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
			select8Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
			select1Logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
			break;
		default:
			break;
		}
	}
		

    public int GetSelect()
    {
        return nSelect;
    }
}
