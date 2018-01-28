using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenTransitions : MonoBehaviour {

	private static string ZOOMED_OUT = "ZOOMED_OUT";
	private static string ZOOMED_IN = "ZOOMED_IN";
	private static string ZOOMING_OUT = "ZOOMING_OUT";
	private static string ZOOMING_IN = "ZOOMING_IN";

	Camera camera;
	public string state;

	// Use this for initialization
	void Start () {
		camera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if (state == ZOOMING_OUT) {
			camera.orthographicSize += 0.2f;
			if (camera.orthographicSize > 20) {
				state = ZOOMED_OUT;
				SceneManager.LoadScene("StartScene");
			}
		}
		if (state == ZOOMING_IN) {
			camera.orthographicSize -= 0.1f;
			if (camera.orthographicSize < 5) {
				camera.orthographicSize = 5;
				state = ZOOMED_IN;
			}
		}
	}

	public void ExitSettingsOnClick() {
		if (state == ZOOMED_IN) {
			state = ZOOMING_OUT;
		}
	}

}
