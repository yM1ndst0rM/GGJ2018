using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenTransitions : MonoBehaviour {

	private static string READY = "READY";
	private static string ZOOMING_OUT = "ZOOMING_OUT";
	private static string ZOOMING_IN = "ZOOMING_IN";

	float zoomStep = 5;
	float defaultCameraSize;
	float durationInSeconds = 2;
	float animationStartTime = 0;
	float fromSize;
	float toSize;

	Camera camera;
	string state;
	string nextScene;

	void Awake() {
		camera = GetComponent<Camera>();
		defaultCameraSize = camera.orthographicSize;
	}

	// Use this for initialization
	void Start () {
		state = READY;
		ZoomIn();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("state is " + state);
		if (state == ZOOMING_OUT || state == ZOOMING_IN) {
			var elapsed = Mathf.Clamp(Time.time - animationStartTime, 0, 1);
			camera.orthographicSize = Mathf.Lerp(fromSize, toSize, state == ZOOMING_OUT ? CircleInInterp(elapsed): CircleOutInterp(elapsed));
			if (elapsed >= 1) {
				state = READY;
			}
		}
		else if (state == READY) {
			SceneManager.LoadScene(nextScene);
		}
	}

	public void ZoomOut() {
		if (state == READY) {
			fromSize = defaultCameraSize + zoomStep;
			toSize = defaultCameraSize;
			animationStartTime = Time.time;
			state = ZOOMING_OUT;
		}
	}

	public void ZoomIn() {
		if (state == READY) {
			fromSize = defaultCameraSize + zoomStep;
			toSize = defaultCameraSize;
			animationStartTime = Time.time;
			state = ZOOMING_IN;
		}
	}

	public void ToGame() {
		TransitionToScene("StartScene", true);
	}

	public void ToSettings() {
		TransitionToScene("SettingsScene", true);
	}

	public void ToTitle() {
		TransitionToScene("TitleScene", false);
	}

	private void TransitionToScene(string sceneName, bool fromTitle) {
		nextScene = sceneName;
		if (fromTitle) {
			ZoomInAgain();
		} else {
			ZoomOut();
		}
	}

	private void ZoomInAgain() {
		if (state == READY) {
			fromSize = defaultCameraSize;
			toSize = defaultCameraSize - zoomStep/2f;
			animationStartTime = Time.time;
			state = ZOOMING_IN;
		}
	}

	private float CircleOutInterp(float a) {
		a--;
		return Mathf.Sqrt(1 - a * a);
		
	}

	private float CircleInInterp(float a) {
		return Mathf.Sqrt(1 - a * a);
	}

}
 