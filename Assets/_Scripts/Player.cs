using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MovableObject
{
	public Slider slider;
	public Slider healthSlider;
	public GameObject finger;
	public bool canAndWillFingerCircle = false;
	public bool fingerCircleOut = false;

	public float maxStamina = 10f;
	public float stamina = 10f;

	public float maxHealth = 100f;
	public float health = 100f;

	public float staminaDecay = .2f;
	public float staminaRegen = 1f;
	// Start is called before the first frame update

	public void TakeSomeHurts(float f)
	{
		health -= f;
		healthSlider.value = health;
	}
	
	public override void Start()
    {
		Init(gameObject.GetComponent<Rigidbody2D>());
		StartCoroutine(regenerate());
		slider.maxValue = maxStamina;
		healthSlider.maxValue = maxHealth;
		finger.SetActive(false);
		
    }

    // Update is called once per frame
    public override void Update()
    {
		if (Input.GetAxis("Fire1") > 0 && stamina > 0) fingerCircleOut = true;
		else fingerCircleOut = false;

		if (!fingerCircleOut)
		{
			Vector2 inputDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
			SetMoveDir(inputDirection.normalized);
			finger.SetActive(false);
		}
		else
		{
			SetMoveDir(new Vector2(0, 0));
			finger.SetActive(true);
		}

		Vector2 mousePos = Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2, 0);
		SetLookDir(mousePos);

		slider.value = stamina;

		if(health <= 0)
		{
			SceneManager.LoadScene(2);
		}

	}

	public void FixedUpdate()
	{
		MoveUpdate();
	}

	IEnumerator regenerate()
	{
		yield return new WaitForSeconds(.2f);

		if(fingerCircleOut)
		{
			if(stamina > 0)
			{
				stamina -= staminaDecay;
			}
			if(stamina == 0)
			{
				stamina = -2;
				fingerCircleOut = false;
			}
		}
		else
		{
			if(stamina < maxStamina)
			{
				stamina += staminaRegen;
			}
		}
		StartCoroutine(regenerate());
	}
}
