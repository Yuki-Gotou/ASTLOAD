using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicScale : MonoBehaviour {

	[SerializeField]
	private float Rate = 1.1f;
	[SerializeField]
	private float Time = 0.2f;

	[SerializeField]
	private AudioSource MusicSource;

	private Vector3 baseScale;

	void Start()
	{
		this.baseScale = this.gameObject.transform.localScale;
	}

	void Update()
	{
		//this.baseScale.x = MusicSource. * 2;
		this.baseScale.y = MusicSource.volume * 2;
	}
}
