using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;


public class UI_RectInOut : MonoBehaviour {

    [SerializeField] Transform target;
    [SerializeField] Camera targetCamera;
    [SerializeField] Image icon;
    
    private Rect rect = new Rect(0, 0, 1, 1);
    private Rect canvasRect;


    // Use this for initialization
    void Start () {

        // UIを画面内に収める
        canvasRect = ((RectTransform)icon.canvas.transform).rect;

        canvasRect.Set(
            canvasRect.x      + icon.rectTransform.rect.width  * 0.5f,
            canvasRect.y      + icon.rectTransform.rect.height * 0.5f,
            canvasRect.width  - icon.rectTransform.rect.width,
            canvasRect.height - icon.rectTransform.rect.height
        );
    }
	
	// Update is called once per frame
	void Update () {

        var viewport = targetCamera.WorldToViewportPoint(target.position);

        if (rect.Contains(viewport)) {

            icon.enabled = false;
        }

        else {
            // 変数宣言
            float mag;                  // カメラの正規化視線ベクトルの地面までの倍率
            Vector3 floorRayPos;        // 地面にレイが当たった場所の座標
            Vector3 TargetAngle;        // レイが当たった場所からの角度
            Vector3 CameraUpVec;        // カメラのアップベクトル

            Ray CameraRay;
            RaycastHit CameraRaycastHit;

            icon.enabled = true;

            // 画面内で対象を追跡
            viewport.x = Mathf.Clamp01(viewport.x);
            viewport.y = Mathf.Clamp01(viewport.y);

            // 試作
            //icon.transform.LookAt(target);
            //icon.transform.Rotate();
            //Vector3 diff = (icon.gameObject.transform.position - target.transform.position);
            //target.transform.rotation = Quaternion.FromToRotation(Vector3.up, diff);

            // 一番近い挙動
            //Vector3 diff = (target.transform.position - icon.transform.position);
            //icon.transform.rotation = Quaternion.FromToRotation(Vector3.up, diff);

            // カメラからのレイを取得
            CameraRay = targetCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f));

            // レイが地面に当たった時の座標を求める
            mag = CameraRay.origin.y / CameraRay.direction.y;
            floorRayPos = new Vector3(CameraRay.origin.x - CameraRay.direction.x * mag, 0.0f, CameraRay.origin.z - CameraRay.direction.z * mag);
            
            // レイが地面に当たったところからのゴールまでのベクトルを求める
            TargetAngle = target.transform.position - floorRayPos;
            TargetAngle.Normalize();

            // flooeRayPosとカメラのアップベクトルとの差角をとる
            CameraUpVec = new Vector3(targetCamera.transform.up.x, 0.0f, targetCamera.transform.up.z);
            CameraUpVec.Normalize();
            
            // UIの回転
            //icon.rectTransform.rotation.z = Quaternion.FromToRotation(CameraRay.direction, TargetAngle - CameraUpVec);
            icon.rectTransform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, Mathf.Atan2(-(TargetAngle.x - CameraUpVec.x), TargetAngle.z - CameraUpVec.z) * 360.0f / Mathf.PI + 180.0f));
            //icon.rectTransform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -Mathf.Atan2(TargetAngle.x, TargetAngle.z) * 180 / Mathf.PI));
            //icon.transform.Rotate(Vector3.up, Vector3.Angle(TargetAngle, CameraUpVec));

            icon.rectTransform.anchoredPosition = Rect.NormalizedToPoint(canvasRect, viewport);
        }
    }
}
