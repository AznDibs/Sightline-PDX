using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeePersonScript : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")/* && collision.gameObject.GetComponent<Player>().fingerCircleOut*/)
        {
            Lose();
        }
    }

    public void Lose()
    {

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
