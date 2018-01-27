using UnityEngine;
using UnityEngine.Audio;
using System;

public class SfxManager : MonoBehaviour {

	public Sound[] sounds;
	private float volume;
	public static SfxManager instance;

	// Use this for pre-initialization
	void Awake () {

		if (instance == null) {
			instance = this;
		}
		else {
			Destroy(gameObject);
		}

		foreach (Sound s in sounds) {
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetVolume(float value) {
		this.volume = value / 10f;
		Play("GameStart");
	}

	public void Play(string name) {
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if (s != null) {
			s.source.volume = volume;
			s.source.Play();
		}
	}
}
