using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehavior : MovableObject
{


    // Start is called before the first frame update
    public override void Start()
    {
        Init(gameObject.GetComponent<Rigidbody2D>());
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }
}
