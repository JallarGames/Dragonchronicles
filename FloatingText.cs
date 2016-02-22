using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FloatingText : MonoBehaviour
{
	private Vector2 pos;
	private float lifetime;
	private float lifetimeMax;
	private float offset;

	void Start () {

	}

	void Update () {
		lifetime -= Time.deltaTime;
		float step = (Time.deltaTime / lifetimeMax) * offset;
		pos.Set(pos.x,pos.y+step);
		gameObject.GetComponent<RectTransform>().anchoredPosition = pos;
	}

	public void Set(Vector2 pos, string text, float time, float offset)
	{
		this.pos = pos;
		lifetimeMax = time;
		lifetime = time;
		this.offset = offset;
		gameObject.GetComponent<Text>().text = text;
	}
}
