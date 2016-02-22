using UnityEngine;
using System.Collections;

public class UI : MonoBehaviour {

	GameObject playerFrame;
	GameObject targetFrame;

	void Start () {
		playerFrame = GameObject.Instantiate((GameObject)Resources.Load("Prefabs/UI/PlayerFrame"));
		playerFrame.transform.SetParent(GameObject.Find("Frames").transform,false);
		playerFrame.GetComponent<RectTransform>().anchoredPosition = new Vector2(-300,-200);

		targetFrame = GameObject.Instantiate((GameObject)Resources.Load("Prefabs/UI/TargetFrame"));
		targetFrame.transform.SetParent(GameObject.Find("Frames").transform,false);
		targetFrame.GetComponent<RectTransform>().anchoredPosition = new Vector2(300,-200);
	}

	void Update () {
		UI_FRAMES.Update();
		Character p = sCharactersManager.characters[0];
		playerFrame.GetComponent<PlayerFrame>().SetValues(p.lvl,p.nickname,p.moraleCurrent,p.morale,p.powerCurrent,p.power,p.lvl*p.lvl*100);
		int tid = sCharactersManager.characters[0].targetId;
		if(tid > sCharactersManager.characters.Count-1)
		{
			sCharactersManager.characters[0].targetId = -1;
		}else{
			if(tid >= 0)
			{
				targetFrame.SetActive(true);
				Character t = sCharactersManager.characters[tid]; 
				targetFrame.GetComponent<TargetFrame>().SetValues(t.lvl,t.nickname,t.moraleCurrent,t.morale,t.powerCurrent,t.power);
			}else{
				targetFrame.SetActive(false);
			}
		}
	}	

}
