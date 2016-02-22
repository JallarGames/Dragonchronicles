using UnityEngine;
using System.Collections;

public class CastBar: MonoBehaviour
{
	private string text;
	private float progress;
	private Character character;
	
	void Start()
	{
		gameObject.SetActive(false);
	}
	
	void Update()
	{
		if(character.IsCasting())
		{
			gameObject.SetActive(true);
			character.SetCastBarValues(out text, out progress);
		}else{
			gameObject.SetActive(false);
		}
		
		//zmiany w pasku gui
	}
}