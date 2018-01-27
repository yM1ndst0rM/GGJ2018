using UnityEngine;
using System;
using UnityEngine.Audio;

[System.Serializable]
public class Sound : System.Object {

	public string name;
	public AudioClip clip;

	[HideInInspector]
	public AudioSource source;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
