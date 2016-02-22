using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour 
{
	// sterowanie postacią i animacja ruchu

	private float speed; // base value
	public float speedMod;
	public Rigidbody rigidbody;
	public Animator animator;
	private float v;
	private float h;

	void Start () {
		speed = 5f;
		speedMod = 1f;
		rigidbody = GetComponent<Rigidbody>();
		animator = GetComponentInChildren<Animator>();
	}

	void Update () {
		GetInput();
		Move();
		SetAnimation();
	}

	private void GetInput()
	{
		h = Input.GetAxisRaw("Horizontal");
		v = Input.GetAxisRaw("Vertical");
	}

	private void Move()
	{

		Vector2 move = new Vector2(v,h).normalized;
		
		// ruch do tylu
		if(v<0) 
			move = new Vector2(move.x*0.5f,move.y);
		
		//spadanie
		if(Physics.Raycast(transform.position,-transform.up,1f))
		{
			rigidbody.velocity = transform.forward * move.x*speed + transform.right * move.y*speed + transform.up * rigidbody.velocity.y;
		}
	}

	private void SetAnimation()
	{
		if(v>0)
			animator.SetBool("running",true);
		else
			animator.SetBool("running",false);
		
		if(v<0)
			animator.SetBool("walkback",true);
		else
			animator.SetBool("walkback",false);
		
		if(h>0)
			animator.SetBool("walkright",true);
		else
			animator.SetBool("walkright",false);
		
		if(h<0)
			animator.SetBool("walkleft",true);
		else
			animator.SetBool("walkleft",false);
	}
}
