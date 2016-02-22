using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Trigger1_script : MonoBehaviour {

	int frame;

	void Start () 
	{
		UI_FRAMES.frames.Add(UI_FRAMES.GenerateFrame1("ramka1",300,150,"tytul","Użyleś magicznego świecącego orba należącego do wielkiego Maga Glutojajec !\n\n Lepiej zabieraj orba i zwiewaj!","OK",true));
		frame = UI_FRAMES.frames.Count-1;
	}

	void OnMouseDown()
	{
		UI_FRAMES.Activate(frame);

	}
}
