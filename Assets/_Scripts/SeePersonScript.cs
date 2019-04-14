using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeePersonScript : MonoBehaviour
{
	public GameObject deatheffect;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
			Debug.Log("here");
			Player p = collision.gameObject.GetComponent<Player>();
			Debug.Log(p.fingerCircleOut + " " + p.canAndWillFingerCircle);
			if(p.fingerCircleOut && p.canAndWillFingerCircle)
			{
				Die();
			}
        }
    }

	public void Die()
    {
		Instantiate(deatheffect,GameObject.Find("Main Camera").transform);
		Destroy(transform.parent.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
