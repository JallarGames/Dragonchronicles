using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class slot
{
	public GameObject icon;
	public int skill;

	public slot Copy(){
		slot s= new slot();
		s.icon = icon;
		s.skill = skill;
		return s;
	}
}

public static class de_Quickslots
{
	public static float globalCD;
	public static List<KeyCode> Keybinds = new List<KeyCode>();

 	public static List<slot> Bar1 = new List<slot>();

	public static bool Init()
	{
		globalCD = 0;
		Keybinds.Add(KeyCode.Alpha1);
		Keybinds.Add(KeyCode.Alpha2);
		slot s;
		s = new slot(); s.skill = sCharactersManager.characters[0].skills[0]; Bar1.Add(s);

		return true;
	}
}

