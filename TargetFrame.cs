using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TargetFrame : MonoBehaviour
{
	
	public void SetValues(int _level, string _name, float _morale, float _moraleMax,float _power, float _powerMax)
	{
		transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(220,250);
		transform.FindChild("LevelText").GetComponent<Text>().text = _level.ToString();
		transform.FindChild("Nickname").GetComponent<Text>().text = _name;
		transform.FindChild("MoraleText").GetComponent<Text>().text = _morale.ToString()+" / "+_moraleMax.ToString()+" ("+Mathf.Ceil(_morale*100/_moraleMax).ToString()+"%)";
		transform.FindChild("PowerText").GetComponent<Text>().text = _power.ToString()+" / "+_powerMax.ToString()+" ("+Mathf.Ceil(_power*100/_powerMax).ToString()+"%)";
		transform.FindChild("Morale").GetComponent<Image>().rectTransform.sizeDelta = new Vector2((_morale/_moraleMax)*220,20);
		transform.FindChild("Power").GetComponent<Image>().rectTransform.sizeDelta = new Vector2((_power/_powerMax)*220,15);

	}
}
