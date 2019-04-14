using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatManager : MonoBehaviour
{
	public static StatManager statManager;
	// Start is called before the first frame update

	public List<int> RequiredItems = new List<int>();

	public bool beenSet = false;

	public List<int> Items = new List<int>();
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
		beenSet = true;
	}

	public void SetPlayerValues()
	{
		if (p == null) return;
		p.money = money;
		p.health = health;
		p.stamina = stamina;
	}

    void Start()
    {
		if (statManager == null) statManager = this;
		else Destroy(this);

		DontDestroyOnLoad(this);

	}

	void Update()
	{
		bool flag = true;
		foreach(var elm in RequiredItems)
		{
			if (!Items.Contains(elm))
			{
				flag = false;
			}
		}
		if(flag == true)
		{
			SceneManager.LoadScene(3);
			Destroy(gameObject);
		}
	}
}
