using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Projectile : MonoBehaviour
{

	public Character sourceChar;
	public GameObject sourceObj;

	public Character targetChar;
	public GameObject targetObj; 

	public float speed;

	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Vector3.Distance(transform.position,targetChar.transform.position) > 0.2f)
		{
			transform.position = Vector3.MoveTowards(transform.position,targetChar.transform.position,speed*Time.deltaTime);
		}else{
			Destroy(this.gameObject);
		}
	}
}

