using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleLight : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ToggleOnOff () {
		bool curr = gameObject.GetComponent<Light> ().enabled;
		gameObject.GetComponent<Light> ().enabled = !curr;
	}
}
