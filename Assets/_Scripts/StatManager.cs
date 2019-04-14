using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
	public static StatManager statManager;
	// Start is called before the first frame update

	public ArrayList RequiredItems;


	ArrayList Items;
	float money;
	float health;
	float stamina;
	Player p;


	public void SetPlayer(Player pl)
	{
		p = pl;
	}

	public void UpdateValues()
	{
		if (p == null) return;
		money = p.money;
		health = p.health;
		stamina = p.stamina;
		Items = p.items;

	}

	public void SetPlayerValues()
	{
		if (p == null) return;
		p.money = money;
		p.health = health;
		p.stamina = stamina;
		p.items = Items;

	}

    void Start()
    {
		if (statManager != null) statManager = this;
		else Destroy(this);
		DontDestroyOnLoad(this);
    }

	void Update()
	{
		bool flag = true;
		foreach(var elm in RequiredItems)
		{
			if (!Items.Contains(elm)) flag = false;
		}
	}
}
