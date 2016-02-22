using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ItemContainer : MonoBehaviour
{
	public List<Item> items = new List<Item>();
	public bool deleteEmpty;
	public bool allowDeposit;
	public int capacity;
	public int capacityChange;
	public GameObject frame;
	public Transform slots;
	public Transform icons;
	public Transform counters;

	void Start ()
	{
		CreateFrame(100);
	}

	void Update ()
	{ 

	}

	public void SetActive(bool state)
	{
		frame.SetActive(state);
	}

	public void Rebuild()
	{
		if(frame.activeInHierarchy)
		{
			for(int i = items.Count-1; i>=0; i--)
			{
				if(items[i].quantity.Equals(0))
					items.RemoveAt(i);
			}
			
			int delta = capacityChange - capacity;
			
			GameObject copy;
			while(delta>0)
			{
				copy = GameObject.Instantiate((GameObject)Resources.Load("Prefabs/UI/Slot"));
				copy.transform.SetParent(slots);
				copy.name = "SlotCopy";
				delta--;
			}
			while(delta<0)
			{
				Destroy(slots.GetChild(slots.childCount-1).gameObject);
				delta++;
			}
			capacity = capacityChange;
			
			for (int i = icons.childCount - 1; i >= 0; i--)
			{
				GameObject.Destroy(icons.GetChild(i).gameObject);
			}
			for(int i = 0; i < items.Count; i++)
			{
				copy = GameObject.Instantiate((GameObject)Resources.Load("Prefabs/UI/ItemIcon"));
				copy.GetComponent<Image>().overrideSprite = sItemMaganer.GetItemTemplate(items[i].id).icon;
				copy.transform.SetParent(icons);
				copy.name = "IconCopy";
			}
			
			
			for (int i = counters.childCount - 1; i >= 0; i--)
			{
				GameObject.Destroy(counters.GetChild(i).gameObject);
			}
			for(int i = 0; i < items.Count; i++)
			{
				copy = GameObject.Instantiate((GameObject)Resources.Load("Prefabs/UI/ItemCounter"));
				copy.transform.SetParent(counters);
				copy.name = "CounterCopy";
				if(items[i].quantity > 1)
				{
					copy.GetComponent<Text>().text = items[i].quantity.ToString();
				}else{
					copy.GetComponent<Text>().text = " ";
				}
			}
			if(deleteEmpty && items.Count.Equals(0))
			{
				Destroy(frame);
				Destroy(gameObject);
			}
		}
	}

	private void CreateFrame(int cap)
	{
		capacity = 0;
		capacityChange = cap;
		frame = GameObject.Instantiate((GameObject)Resources.Load("Prefabs/UI/ItemContainer"));
		frame.transform.SetParent(GameObject.Find("Frames").transform,false);
		if(gameObject.name.Equals("Player1"))
			frame.GetComponent<RectTransform>().anchoredPosition = new Vector2(-550,150);
		else
			frame.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1100,300);
		frame.SetActive(false);
		
		slots =  frame.transform.FindChild("Slots");
		icons =  frame.transform.FindChild("Icons");
		counters =  frame.transform.FindChild("Counters");
	}
}

