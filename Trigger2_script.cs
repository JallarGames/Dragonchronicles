using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Trigger2_script : MonoBehaviour {
	
	int frame;
	
	void Start () 
	{
		UI_FRAMES.frames.Add(UI_FRAMES.GenerateFrame1("ramka1",300,150,"tytul","To na tyle historyji o magu.","OK",true));
		frame = UI_FRAMES.frames.Count-1;
	}
	
	void OnMouseDown()
	{
		UI_FRAMES.Activate(frame);
		
	}
}
