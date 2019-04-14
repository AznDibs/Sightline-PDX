using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
	IEnumerator DieDelay()
	{
		yield return new WaitForSeconds(.5f);
		Destroy(gameObject);
	}
    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine(DieDelay());   
    }
}
