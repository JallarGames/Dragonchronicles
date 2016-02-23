using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public static class sCharactersManager
{
	public static List<Character> characters = new List<Character>();

	public static void SpawnPlayer()
	{
		GameObject o = GameObject.Find("Player1");
		characters.Add(o.GetComponent<Character>());
		characters[0].isPlayer = true;
	}

	public static void SpawnMob()
	{
		float y;
		GameObject spawner = GameObject.Find("Spawner");

		Vector3 pos = spawner.transform.position + new Vector3(Random.Range(0.1f,3.0f),0,Random.Range(0.1f,3.0f));
		y = Terrain.activeTerrain.SampleHeight(pos);
		pos = new Vector3(pos.x,y,pos.z);

		GameObject o = (GameObject)GameObject.Instantiate((GameObject)Resources.Load("Prefabs/Character"),pos,spawner.transform.rotation);
		ItemContainer ic = o.GetComponent<ItemContainer>();
		ic.allowDeposit = false;
		ic.deleteEmpty = true;

		Item item;
		item = sItemMaganer.GetItemTemplate(0);
		item.quantity = 10;
		ic.items.Add(item);

		characters.Add(o.GetComponent<Character>());
		int index = characters.Count-1;
		characters[index].isPlayer = false;
		characters[index].fraction = 8;
		characters[index].lvl = 1;
		characters[index].nickname = "Mobek"+index.ToString();
		characters[index].moraleCurrent = characters[index].morale;
	}
}

