using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	//Set starting health to 100, starting armor to 0. Set up reference to healthbar and player
	public int startingHealth;
	public int startingArmor;
	public int maxArmor = 200;
	public int maxHealth = 200;
	public int currentArmor;
	public int currentHealth;
	

	public RectTransform healthBar;
	public RectTransform armorBar;
	public GameObject player;
	private EnemyRanged enemyRanged;


	bool isDead = false;


	// Use this for initialization
	void Start () {
		currentHealth = 100;
		currentArmor = 100;
		player = GetComponent<GameObject>();
		enemyRanged = FindObjectOfType<EnemyRanged>();
	
		armorBar.sizeDelta = new Vector2(currentArmor, armorBar.sizeDelta.y);
		healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
	}

	//made this to handle health and armor gained from Pickups
	public void healthChange(int amt)
	{
		//If the additional health wont overflow, add and adjust health bar
		if(currentHealth + amt <= maxHealth)
		{
			print("Old health:" + currentHealth + ";" + "Amount changed:" + amt + ";" + "New Health:" + (currentHealth+amt));
			currentHealth += amt;
			healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
		}
		else
		{
			currentHealth = maxHealth;
			healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
		}
	}
	public void armorChange(int amt)
	{
		//If the additional armor wont overflow, add and adjust armor bar
		if(currentArmor + amt <= maxArmor)
		{
			print("Old armor:" + currentArmor + ";" + "Amount changed:" + amt + ";" + "New Armor:" + (currentArmor+amt));
			currentArmor += amt;
			armorBar.sizeDelta = new Vector2(currentArmor, armorBar.sizeDelta.y);
		}
		else
		{
			currentArmor = maxArmor;
			armorBar.sizeDelta = new Vector2(currentArmor, armorBar.sizeDelta.y);
		}
	}

	public void TakeDamage(int dmg)
	{
		print(dmg + " damage taken!");
		//If theres enough armor to absorb the full hit, subtract incoming damage from armor value
		if(this.currentArmor - dmg > 0)
		{
			currentArmor -= dmg;
		}
		else //If theres not enough armor, modify incoming dmg value to account for bleed through damage
		{
			dmg -= currentArmor;
			currentArmor = 0;
		}
		currentHealth -= dmg;
		if(currentHealth <= 0 && !isDead)
		{
			print("Dying");
			PlayerDeath();
		}
		healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
		armorBar.sizeDelta = new Vector2(currentArmor, armorBar.sizeDelta.y);
	}

	void PlayerDeath()
	{
		isDead = true;
		print("You're dead");
		//GameObject.Destroy(player.gameObject,0.5f);
	}


	// This function is called whenever there is a collision detected
	public void OnCollisionEnter(Collision col)
	{
		// If the object colliding with Enemy is tagged "projectile"
		if(col.gameObject.tag == "Projectile")
		{
			// Get the amount of damage (from the Shoot script) this particular projectile inflicts and damage enemy
			int dmgTaken = enemyRanged.dmg;
			
			TakeDamage(dmgTaken);
			//print("You took " + dmgTaken + " damage.");
		}
	}
}
