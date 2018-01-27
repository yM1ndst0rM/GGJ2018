using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMasterVolume : MonoBehaviour {

	private Slider self;

	// Use this for initialization
	void Start () {
		self = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
		AudioListener.volume = self.value / self.maxValue;
	}
}
