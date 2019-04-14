using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectiveItem : MonoBehaviour
{
	public int ItemID = 0;

    public void OnTriggerEnter2D(Collider2D col)
	{
		if(col.CompareTag("Player"))
		{
			col.GetComponent<Player>().GiveItem(ItemID);
			Destroy(gameObject);
		}
	}
}
