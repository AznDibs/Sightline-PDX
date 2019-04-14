using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerCircleRange : MonoBehaviour
{
	public Player p;
    void Start()
    {
		p = GameObject.Find("Player").GetComponent<Player>();
		if (p == null) Destroy(this);
    }

    // Update is called once per frame
  
	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "NPC")
		{
			p.canAndWillFingerCircle = true;
		}
	}
	void OnTriggerStay2D(Collider2D col)
	{
		if (col.tag == "NPC")
		{
			p.canAndWillFingerCircle = true;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag == "NPC")
		{
			p.canAndWillFingerCircle = false;
		}
	}
}
