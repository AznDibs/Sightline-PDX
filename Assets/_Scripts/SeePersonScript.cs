using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeePersonScript : MonoBehaviour
{
	public Sprite death;
	public float damage = 10f;
	private bool damageWait = false;
	public float damageDelay = 1f;

	NPCBehavior parent;

	public void Start()
	{
		parent = transform.parent.GetComponent<NPCBehavior>();
	}
	IEnumerator DamageDelay()
	{
		yield return new WaitForSeconds(damageDelay);
		damageWait = false;
	}
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
			Player p = collision.gameObject.GetComponent<Player>();
			if(p.fingerCircleOut && p.canAndWillFingerCircle)
			{
				Die();
			}
			else if(!damageWait)
			{
				parent.PlayerSeen(collision.transform, true);
				damageWait = true;
				StartCoroutine(DamageDelay());
				p.TakeSomeHurts(damage);
			}
        }
    }

	public void OnTriggerExit2D(Collider2D col)
	{
		if (col.CompareTag("Player"))
		{
			parent.PlayerSeen(col.transform, false);
		}

	}
	public void Die()
    {
		GameObject par = transform.parent.gameObject;
		Destroy(parent);
		par.GetComponent<SpriteRenderer>().sprite = death;
		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		StartCoroutine(DelayDie(par));
    }

	IEnumerator DelayDie(GameObject parent)
	{
		yield return new WaitForSeconds(1);
		Destroy(parent);
	}
}
