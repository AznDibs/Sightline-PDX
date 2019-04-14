using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeePersonScript : MonoBehaviour
{
	public Sprite death;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
			Player p = collision.gameObject.GetComponent<Player>();
			if(p.fingerCircleOut && p.canAndWillFingerCircle)
			{
				Die();
			}
        }
    }

	public void Die()
    {
		GameObject parent = transform.parent.gameObject;
		parent.GetComponent<NPCBehavior>().enabled = false;
		parent.GetComponent<SpriteRenderer>().sprite = death;
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		StartCoroutine(DelayDie(parent));
    }

	IEnumerator DelayDie(GameObject parent)
	{
		yield return new WaitForSeconds(1);
		Destroy(parent);
	}
}
