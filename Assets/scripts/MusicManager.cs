using UnityEngine;
using UnityEngine.Audio;
using System;

public class MusicManager : MonoBehaviour {

	public Sound[] sounds;
	public static MusicManager instance;

	private float volume;
	private Sound currentlyPlaying;

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
		if (currentlyPlaying != null) {
			currentlyPlaying.source.volume = volume;
		}
		Play("MainMenu");
	}

	public void Play(string name) {
		Sound s = Array.Find(sounds, sound => sound.name == name);
		if (s != null && (currentlyPlaying == null || currentlyPlaying.name != name)) {
			s.source.volume = volume;
			s.source.Play();
		}
	}
}
