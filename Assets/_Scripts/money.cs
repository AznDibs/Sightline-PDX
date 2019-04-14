using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class money : MonoBehaviour
{
	public float moneyAmount = 1f;
    public void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Player")
		{
			col.GetComponent<Player>().GiveMoney(moneyAmount);
			Destroy(gameObject);
		}
	}
}
