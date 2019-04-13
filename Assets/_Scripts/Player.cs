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
		SetLookPos(new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")));
		MoveUpdate();
    }
}
