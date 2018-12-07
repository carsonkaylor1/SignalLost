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
	public turretBehavior turretBehavior;


	bool isDead = false;


	// Use this for initialization
	void Start () {
		currentHealth = 200;
		currentArmor = 200;
		player = GetComponent<GameObject>();
		enemyRanged = FindObjectOfType<EnemyRanged>();
	
		armorBar.sizeDelta = new Vector2(currentArmor, armorBar.sizeDelta.y);
		healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
	}

	//made this to handle health and armor gained from Pickups
	public void healthChange(int amt)
	{
        /* Was having issues disabling health and armor pickups when the player
         * picked them up and gained health/armor.  Pickup objects cannot be
         * disabled after a pass to another script occurs.  I moved the
         * check for max vs. current health and armor values to pickup.cs
         * to allow for proper disabling of health and armor packs. -- Drew
         */
		//If the additional health wont overflow, add and adjust health bar
		if(currentHealth + amt <= maxHealth)
		{
			print("Old health:" + currentHealth + ";" + "Amount changed:" + amt + ";" + "New Health:" + (currentHealth+amt));
			currentHealth += amt;
			healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
        }
        else if (currentHealth == maxHealth)
        {
            //do nothing
        }
		else
		{
			currentHealth = maxHealth;
			healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
        }
	}
	public void armorChange(int amt, Collider other)
	{
		//If the additional armor wont overflow, add and adjust armor bar
		if(currentArmor + amt <= maxArmor)
		{
			print("Old armor:" + currentArmor + ";" + "Amount changed:" + amt + ";" + "New Armor:" + (currentArmor+amt));
			currentArmor += amt;
			armorBar.sizeDelta = new Vector2(currentArmor, armorBar.sizeDelta.y);
        }
        else if (currentArmor == maxArmor)
        {
            //do nothing
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
		if((this.currentArmor - dmg) > 0)
		{
			currentArmor -= dmg;
		}
		else if(this.currentArmor - dmg <= 0)//If theres not enough armor, modify incoming dmg value to account for bleed through damage
		{
			dmg -= currentArmor;
			currentArmor = 0;
			currentHealth -= dmg;
		}
		
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
		//TODO
		//FindObjectOfType<GameManager>().EndGame();
		print("You're dead");
        /*Rigidbody rb = player.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;*/
        GetComponent<PlayerMovement>().enabled = false;
        player.SetActive(false);
		
    }


	// This function is called whenever there is a collision detected
	//This can probably be edited later...Calling enemyRanged seems wrong
	public void OnCollisionEnter(Collision col)
	{
		// If the object colliding with Enemy is tagged "projectile"
		if(col.gameObject.tag == "Projectile")
		{
			// Get the amount of damage (from the Shoot script) this particular projectile inflicts and damage enemy
			int dmgTaken = enemyRanged.dmg;
			//int dmgTaken2 = turretBehavior.dmg;
			TakeDamage(dmgTaken);
			//print("You took " + dmgTaken + " damage.");
		}
	}
}
