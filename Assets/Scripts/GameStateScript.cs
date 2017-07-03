using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateScript : MonoBehaviour {

	public Light firstLight;
	public Camera mainCamera;

	List<Light> lights;

	List<Vector3> defaultLocations;
	List<Vector3> defaultRotations;

	int currentPerspective = -1;

	Vector3 cameraPosition;
	Quaternion cameraRotation;

	float speed = 1.0f;
		
	// Use this for initialization
	void Start () {
		lights = new List<Light> ();
		cameraPosition = mainCamera.transform.position;
		cameraRotation = mainCamera.transform.rotation;

		defaultLocations = new List<Vector3>();
		defaultRotations = new List<Vector3>();
		// Left
		defaultLocations.Add(new Vector3(-2,2,0));
		defaultRotations.Add(new Vector3(45,90,0));
		// Right
		defaultLocations.Add(new Vector3(2,2,0));
		defaultRotations.Add(new Vector3(45,270,0));
		// Back
		defaultLocations.Add(new Vector3(0,2,2));
		defaultRotations.Add(new Vector3(135,0,-180));

		if (defaultLocations.Count != defaultRotations.Count)
			throw new UnityException("# of locations and rotations not equal");
	}

	public void CreateLight () {
		int target = lights.Count;
		if (lights.Count >= defaultLocations.Count)
			target = 0;
		Light fresh = Instantiate (firstLight,defaultLocations [target],Quaternion.Euler(defaultRotations [target]));
		fresh.gameObject.SetActive (true);
		lights.Add(fresh);
	}

	public void DeleteLight () {
		if (lights.Count == 0)
			return;
		Light target = lights [lights.Count - 1];
		lights.RemoveAt (lights.Count-1);
		Destroy (target);
		// GetNextPerspective() will push this back to -1.
		currentPerspective = -2;
	}
	
	// Update is called once per frame
	void Update () {
		// Handle switching perspectives.
		if (Input.GetKeyDown ("tab")) {
			GetNextPerspective ();
			print (currentPerspective);
			if (currentPerspective == -1) {
				mainCamera.gameObject.transform.SetPositionAndRotation (cameraPosition, cameraRotation);
			} else {
				if (currentPerspective == 0) {
					cameraPosition = mainCamera.gameObject.transform.position;
					cameraRotation = mainCamera.gameObject.transform.rotation;
				}
				mainCamera.gameObject.transform.SetPositionAndRotation (
					lights [currentPerspective].gameObject.transform.position,
					lights [currentPerspective].gameObject.transform.rotation);
			}
		}
		// Handle movement
		GameObject activeLight;
		if (currentPerspective >= 0) {
			activeLight = lights [currentPerspective].gameObject;
			if (Input.GetKey ("left") || Input.GetKey ("a"))
				activeLight.transform.localPosition -= activeLight.transform.right * speed * Time.deltaTime;
			if (Input.GetKey ("right") || Input.GetKey ("d"))
				activeLight.transform.localPosition += activeLight.transform.right * speed * Time.deltaTime;
			if (Input.GetKey ("up") || Input.GetKey ("w"))
				activeLight.transform.localPosition += activeLight.transform.forward * speed * Time.deltaTime;
			if (Input.GetKey ("down") || Input.GetKey ("s"))
				activeLight.transform.localPosition -= activeLight.transform.forward * speed * Time.deltaTime;
			if (Input.GetKey ("space"))
				activeLight.transform.localPosition += activeLight.transform.up * speed * Time.deltaTime;
			if (Input.GetKey ("left shift"))
				activeLight.transform.localPosition -= activeLight.transform.up * speed * Time.deltaTime;
		}
	}

	void GetNextPerspective () {
		// -1 means the main camera.
		currentPerspective += 1;
		if (currentPerspective >= lights.Count || currentPerspective < -1)
			currentPerspective = -1;
	}

	private void moveForward(float speed) {
		transform.localPosition += transform.forward * speed * Time.deltaTime;
	}

	private void moveBack(float speed) {
		transform.localPosition -= transform.forward * speed * Time.deltaTime;
	}

	private void moveRight(float speed) {
		transform.localPosition += transform.right * speed * Time.deltaTime;
	}

	private void moveLeft(float speed) {
		transform.localPosition -= transform.right * speed * Time.deltaTime;
	}

}