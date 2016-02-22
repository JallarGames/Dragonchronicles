using UnityEngine;
using System.Collections;

public class HoleTrigger : MonoBehaviour {
	
	void OnTriggerEnter(Collider col)
	{	Debug.Log("zrobione");
		if(col.tag=="Player")
		{
			Physics.IgnoreCollision(Terrain.activeTerrain.GetComponent<Collider>(),col,true);
		}
	}
}
