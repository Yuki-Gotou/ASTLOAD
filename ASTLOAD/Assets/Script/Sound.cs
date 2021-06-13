using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {


    // 音の切り替えのために確保
    [SerializeField]    
    private AudioClip[] audioClip;
    // 音を複数再生するために確保
    [SerializeField]
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource.clip = audioClip[0];
	}

    // 重複しないで音を再生
    public void SoundPlay()
    {
        audioSource.Play();
    }

    // 重複して音を再生
    public void PlayOneShot()
    {
        audioSource.PlayOneShot(audioClip[0]);
    }

    public void PlayOneShot(int nClip)
    {
        audioSource.PlayOneShot(audioClip[nClip]);
    }

    // オブジェクト破棄時に一時オブジェクト生成して再生
    public void PlayClipAtPoint()
    {
        AudioSource.PlayClipAtPoint(audioClip[0], transform.position);
    }

    public void PlayClipAtPoint(int nClip)
    {
        AudioSource.PlayClipAtPoint(audioClip[nClip], transform.position);
    }

    public void SoundStop()
    {
        audioSource.Stop();
    }

}
