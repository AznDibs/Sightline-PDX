using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehavior : MovableObject
{

    private bool isWaiting = false;
    private bool seesPlayer = false;
	  private Transform player;
    public float XLen, YLen;

    IEnumerator Wait(float time)
    {

        Vector2 newMovePos = new Vector2(Random.Range(0f, XLen), Random.Range(0f, YLen));
        yield return new WaitForSeconds(time);
        SetLookDir((newMovePos - GetGameObjectPos(moveObject.gameObject)).normalized);
        yield return new WaitForSeconds(time);
        SetMovePos(newMovePos);
        isWaiting = false;
    }

	public void PlayerSeen(Transform tf, bool sees)
	{
		seesPlayer = sees;
		player = tf;
	}

    // Start is called before the first frame update
    public override void Start()
    {
        Init(gameObject.GetComponent<Rigidbody2D>());
        moveAffectsLook = true;
        GameObject grid = transform.parent.GetComponentInChildren<Grid>().gameObject;
        grid.GetComponent<SpriteRenderer>().enabled = false;
        XLen = grid.transform.localScale.x;
        YLen = grid.transform.localScale.y;
        gameObject.GetComponent<Rigidbody2D>().MovePosition(new Vector2(grid.transform.position.x+(XLen*0.5f), grid.transform.position.y + (YLen*0.5f)));
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
		if (seesPlayer)
		{
			lookDir = new Vector2(-transform.position.x + player.position.x,-transform.position.y + player.position.y);
			moveObject.MoveRotation(Mathf.Rad2Deg * Mathf.Atan2(-lookDir.x, lookDir.y));
		}
		else
		{
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

}
