using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class sPlayer
{
	// statyczna klasa przechowujaca dane dotyczace gracza np. nazwy skilli, klas, umiejetnosci
	private static List<string> skillNames = new List<string>();

	public static void Initialize()
	{
		// potem bedzie z pliku
		skillNames.Add("Magic"); //0
		skillNames.Add("Elemental Magic"); //1
		skillNames.Add("White Magic"); //2
		skillNames.Add("Dark Magic"); //3
		skillNames.Add("Primal Magic"); //4
		skillNames.Add("Techno Magic"); //5

		skillNames.Add("Melee"); //6
		skillNames.Add("Unarmed"); //7
		skillNames.Add("Fist"); //8
		skillNames.Add("One Handed"); //9
		skillNames.Add("Two handed"); //10
	
		skillNames.Add("Armor Defence"); //11

	}

	public static string GetSkillName(int id)
	{
		return skillNames[id];
	}
}

