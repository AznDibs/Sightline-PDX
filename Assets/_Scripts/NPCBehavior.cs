using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehavior : MovableObject
{

    private bool isWaiting = false;

    IEnumerator Wait(float time)
    {

        Vector2 newMovePos = new Vector2(Random.Range(0f, 2.5f), Random.Range(0f, 2.5f));
        yield return new WaitForSeconds(time);
        SetLookDir((newMovePos - GetGameObjectPos(moveObject.gameObject)).normalized);
        yield return new WaitForSeconds(time);
        SetMovePos(newMovePos);
        isWaiting = false;
    }

    // Start is called before the first frame update
    public override void Start()
    {
        Init(gameObject.GetComponent<Rigidbody2D>());
        moveAffectsLook = true;
    }

    public new Vector2 GetGameObjectPos(GameObject gameObject)
    {
        return new Vector2(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y);
    }

    public new void MoveUpdate()
    {

        Vector2 pos = GetGameObjectPos(moveObject.gameObject);

        //Update move first
        bool hasMoveDir = moveDir.magnitude > 0;
        bool hasMovePos = movePos.magnitude > 0 && (movePos - pos).magnitude > moveDeadZone;


        Vector2 newDir = new Vector2(0, 0);
        if (hasMoveDir)
        {
            moveObject.velocity = moveDir * moveSpeed;
        }
        else if (hasMovePos)
        {
            newDir = new Vector2(movePos.x - pos.x, movePos.y - pos.y).normalized;
            moveObject.velocity = newDir * moveSpeed;
        }
        else
        {
            moveObject.velocity = new Vector2(0, 0);
        }

        if (moveAffectsLook && (hasMoveDir || hasMovePos)) lookDir = hasMoveDir ? moveDir : newDir;

        if (lookDir.magnitude > 0)
        {
            moveObject.MoveRotation(Mathf.Rad2Deg * Mathf.Atan2(-lookDir.x, lookDir.y));
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        //Debug.Log(GetGameObjectPos(moveObject.gameObject));
        if ((movePos - GetGameObjectPos(moveObject.gameObject)).magnitude < moveDeadZone)
        {
            movePos = new Vector2(0, 0);
        }
        if (movePos.magnitude == 0 && !isWaiting)
        {
            
            isWaiting = true;
            StartCoroutine(Wait(1));
            
        }
        MoveUpdate();
    }

}
