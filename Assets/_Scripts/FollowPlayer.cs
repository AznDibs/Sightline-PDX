using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
	// Start is called before the first frame update
	public Transform player;	
    void Start()
    {
		player = GameObject.Find("Player").transform;
		if (player == null) Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 newPos = new Vector3(player.position.x, player.position.y, -10f);
		transform.position = newPos;
    }
}
