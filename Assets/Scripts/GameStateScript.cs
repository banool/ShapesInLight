using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateScript : MonoBehaviour {

	public Light firstLight;

	List<Light> lights;

	List<Vector3> defaultLocations;
	List<Vector3> defaultRotations;
		
	// Use this for initialization
	void Start () {
		lights = new List<Light> ();

		defaultLocations = new List<Vector3>();
		defaultRotations = new List<Vector3>();
		// Left
		defaultLocations.Add(new Vector3(-2,2,0));
		defaultRotations.Add(new Vector3(45,90,-45));
		// Right
		defaultLocations.Add(new Vector3(2,2,0));
		defaultRotations.Add(new Vector3(45,270,45));
		// Back
		defaultLocations.Add(new Vector3(0,2,2));
		defaultRotations.Add(new Vector3(135,0,0));

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
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
