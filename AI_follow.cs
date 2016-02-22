using UnityEngine;
using System.Collections;

public class AI_follow : MonoBehaviour 
{
	// Agent idzie do gracza, jesli dzieli ich okreslony dystans

	private GameObject player;
	public NavMeshAgent agent;

	void Update () {
		player = sCharactersManager.characters[0].gameObject;
		agent = GetComponent<NavMeshAgent>();
		if(!gameObject.GetComponent<Character>().isDead)
		{
			if(agent.isOnNavMesh)
			{
				agent.SetDestination(player.transform.position);
				if(Vector3.Distance(player.transform.position,transform.position) > 1.5f)
				{
					agent.Resume();
				}else{
					agent.Stop();
				}
			}

			
			if(Vector3.Distance(player.transform.position,transform.position) < 5)
			{
				Vector3 lookPos = new Vector3(player.transform.position.x, gameObject.transform.position.y, player.transform.position.z);
				gameObject.transform.LookAt(lookPos);
			}
		}else{
			agent.Stop();
		}
	}
}
