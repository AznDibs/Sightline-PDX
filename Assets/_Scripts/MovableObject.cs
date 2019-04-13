using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovableObject
{
    public Rigidbody2D moveObject;
    public float moveSpeed = 1f;
    public bool moveAffectsLook; //true: lookdir dependent on movedir,if movedir's magnitude is nonzero. false: lookdir and movedir are independent
    public float moveDeadZone = 1f;

    private Vector2 lookDir = new Vector2(0,0);
    private Vector2 lookPos = new Vector2(0,0);
    private Vector2 moveDir = new Vector2(0,0);
    private Vector2 movePos = new Vector2(0,0);

    private void Init(Rigidbody2D rb)
    {
        moveObject = rb;
    }

    public void SetMovePos(Vector2 pos)
    {
        movePos = pos;
    }

    public void SetMoveDir(Vector2 dir)
    {
        moveDir = dir;
    }
    
    public void SetLookPos(Vector2 pos)
    {
        lookPos = pos;
    }
    
    public void SetLookDir(Vector2 dir)
    {
        lookDir = dir;
    }

    public Vector2 GetGameObjectPos(GameObject gameObject)
    {
        return new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }



    public void MinorUpdate()
    {

    }

    public void MoveUpdate()
    {
        //Update move first
        bool hasMoveDir = moveDir.magnitude > 0;
        bool hasMovePos = (movePos - GetGameObjectPos(moveObject.gameObject)).magnitude > moveDeadZone;


        Vector2 newDir = new Vector2(0,0);
        if (hasMoveDir)
        {
            moveObject.AddForce(moveDir * moveSpeed);
        } else if (hasMovePos)
        {
            newDir = new Vector2(movePos.x - moveObject.position.x, movePos.y - moveObject.position.y).normalized;
            moveObject.AddForce(newDir * moveSpeed);
        } else
        {
            moveObject.velocity = new Vector2(0,0);
        }

        if (moveAffectsLook && (hasMoveDir || hasMovePos)) lookDir = hasMoveDir ? moveDir : newDir;
        if (lookDir.magnitude > 0) moveObject.MoveRotation(Mathf.Rad2Deg * Mathf.Atan2(lookDir.x, lookDir.y));
    }

}
