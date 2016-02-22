using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UI_FRAME
{
	public GameObject frame;
	public Vector2 size;
	
}

public static class UI_FRAMES
{
	public static List<UI_FRAME> frames = new List<UI_FRAME>();

	public static void Update()
	{
		foreach(UI_FRAME f in frames)
		{
			FitText(f.frame,f.size);
		}
	}

	public static void FitText(GameObject _frame,Vector2 _size)
	{
		Text text = _frame.transform.FindChild("TextArea/Text").GetComponent<Text>();
		if(text){ 
			text.rectTransform.sizeDelta = new Vector2(_size.x-40,text.preferredHeight);
		}
	}
	public static void FitText2(GameObject _frame,Vector2 _size)
	{
		Text text = _frame.transform.FindChild("TextArea/Text").GetComponent<Text>();
		if(text){ 
			text.rectTransform.anchoredPosition = new Vector2(0,-text.preferredHeight);
		}
	}


	public static UI_FRAME GenerateFrame1(string _name, int _w, int _h, string _title, string _text, string _buttonText, bool _scroll)
	{
		UI_FRAME f = new UI_FRAME();
		
		GameObject frame = GameObject.Instantiate((GameObject)Resources.Load("Prefabs/UI/UI_FRAME1"));
		frame.SetActive(false);
		
		frame.transform.SetParent(GameObject.Find("Frames").transform);
		frame.transform.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
		frame.transform.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(_w,_h);
		
		GameObject textArea = frame.transform.FindChild("TextArea").gameObject;
		textArea.GetComponent<RectTransform>().sizeDelta = new Vector2(_w-40,_h-80);
		textArea.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,0);
		
		Text text = frame.transform.FindChild("TextArea/Text").GetComponent<Text>();
		text.text = _text;
		text.rectTransform.anchoredPosition = new Vector2(0,0);
		
		Transform scroll = frame.transform.FindChild("Scrollbar");
		scroll.GetComponent<RectTransform>().anchoredPosition = new Vector2((_w-20)/2 ,0);
		scroll.GetComponent<RectTransform>().sizeDelta = new Vector2(20,_h-80);
		
		Transform button = frame.transform.FindChild("Button");
		button.GetComponent<RectTransform>().anchoredPosition = new Vector2(0,-(_h/2-20));
		button.GetComponent<RectTransform>().sizeDelta = new Vector2(50,20);
		button.FindChild("Text").GetComponent<Text>().text = _buttonText;
		button.GetComponent<Button>().onClick.AddListener(delegate { CloseFrame(f); });
		
		f.frame = frame;
		f.size = new Vector2(_w,_h);
		
		return f;
	}

	public static void Activate(int id)
	{
		frames[id].frame.SetActive(true);
		FitText2(frames[id].frame,frames[id].size);
	}

	public static void ButtonFunc()
	{

	}

	public static void CloseFrame(UI_FRAME f)
	{
		UI_FRAMES.frames[UI_FRAMES.frames.IndexOf(f)].frame.SetActive(false);
	}


}
