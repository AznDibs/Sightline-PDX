using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
	IEnumerator DieDelay()
	{
		yield return new WaitForSeconds(2f);
		Destroy(gameObject);
	}
    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine(DieDelay());   
    }
}
