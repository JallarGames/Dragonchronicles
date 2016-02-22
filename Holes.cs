using UnityEngine;
using System.Collections;

public class Holes : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		GameObject.Find("Hole").GetComponent<Renderer>().material.renderQueue = 10;
		GameObject.Find("Plane").GetComponent<Renderer>().material.renderQueue = 1;
		GameObject.Find("Plane2").GetComponent<Renderer>().material.renderQueue = 1;
	}

	void Update () {
	
	}
}
