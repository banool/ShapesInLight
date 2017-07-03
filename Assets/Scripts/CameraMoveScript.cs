using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveScript : MonoBehaviour {

	float speed = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject active = this.gameObject;
		if (Input.GetKey ("left") || Input.GetKey ("a"))
			active.transform.localPosition -= active.transform.right * speed * Time.deltaTime;
		if (Input.GetKey ("right") || Input.GetKey ("d"))
			active.transform.localPosition += active.transform.right * speed * Time.deltaTime;
		if (Input.GetKey ("up") || Input.GetKey ("w"))
			active.transform.localPosition += active.transform.forward * speed * Time.deltaTime;
		if (Input.GetKey ("down") || Input.GetKey ("s"))
			active.transform.localPosition -= active.transform.forward * speed * Time.deltaTime;
		if (Input.GetKey ("space"))
			active.transform.localPosition += active.transform.up * speed * Time.deltaTime;
		if (Input.GetKey ("left shift"))
			active.transform.localPosition -= active.transform.up * speed * Time.deltaTime;
	}
}

