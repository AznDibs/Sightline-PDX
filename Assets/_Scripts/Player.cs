using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovableObject
{
	
	// Start is called before the first frame update
	public override void Start()
    {
		Init(gameObject.GetComponent<Rigidbody2D>());
    }

    // Update is called once per frame
    public override void Update()
    {
		Vector2 inputDirection = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
		SetMoveDir(inputDirection.normalized);
		Vector2 mousePos = Input.mousePosition - new Vector3(Screen.width/2,Screen.height/2,0);
		SetLookDir(mousePos);
		
    }

	public void FixedUpdate()
	{
		MoveUpdate();
	}
}
