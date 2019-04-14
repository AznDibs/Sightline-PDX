using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reSpawn : MonoBehaviour
{
	// Start is called before the first frame update
	public GameObject myNPC;
	public GameObject NPCPrefab;
	// Update is called once per frame

	Vector3 Location;
	Vector3 GridScale = new Vector3(4,4,0);

	bool spawning = false;

	IEnumerator DoReSpawn()
	{
		yield return new WaitForSeconds(5);
		if(Location == null)
		{
			myNPC = Instantiate(NPCPrefab,transform.position,Quaternion.identity, transform);
		}
		else
		{
			myNPC = Instantiate(NPCPrefab, Location, Quaternion.identity, transform);
			myNPC.GetComponentInChildren<NPCBehavior>().XLen = GridScale.x;
			myNPC.GetComponentInChildren<NPCBehavior>().YLen = GridScale.y;
		}
		spawning = false;
	}
    void Update()
    {
        if(!spawning && (myNPC == null || myNPC.transform.GetComponentInChildren<NPCBehavior>() == null))
		{
			if(myNPC != null) Destroy(myNPC);
			StartCoroutine(DoReSpawn());
			spawning = true;
		}
		else if(Location == null)
		{
			Location = myNPC.transform.parent.transform.position;
		}
    }
}
