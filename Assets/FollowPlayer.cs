using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
	// Start is called before the first frame update
	public Transform Player;	
    void Start()
    {
		if (Player == null) Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 newPos = new Vector3(Player.position.x, Player.position.y, -10f);
		transform.position = newPos;
    }
}
