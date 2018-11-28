using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	public int startingHealth = 100; // The amount of health the enemy starts with
	public int currentHealth; // Keep track of the current enemy health

	public RectTransform healthBar;

	// Instance of shoot script
	public Shoot shot;
	
	
	CapsuleCollider capsuleCollider; // Reference the capsule collider
	bool isDead; //Keep track if the enemy is dead or not
	void Awake()
	{
		shot = FindObjectOfType<Shoot>();
		capsuleCollider = GetComponent<CapsuleCollider>(); // Set up the reference to the component's capsuleCollider so we can use it in the script
		currentHealth = startingHealth; // When the scene starts, set currentHealth to startingHealth

		healthBar.sizeDelta = new Vector3(currentHealth, healthBar.sizeDelta.y);
	}
	
	public void TakeDamage(int dmgAmount)
	{
		// If they are already dead then don't apply damage
		if(isDead)
			return;
		
		// Subtract the amount of damage from currentHealth
		currentHealth -= dmgAmount;

		// Check to see if enemy's health is in the DEAD ZONE...doot doot
		if(currentHealth <= 0)
			Death();

		healthBar.sizeDelta = new Vector3(currentHealth, healthBar.sizeDelta.y);
	}

	public void Death()
	{
		// rekt
		isDead = true;
		// Remove the gameObject this script is attached to (an enemy)
		Destroy(gameObject);

	}

	// This function is called whenever there is a collision detected
	public void OnCollisionEnter(Collision col)
	{
		// If the object colliding with Enemy is tagged "projectile"
		if(col.gameObject.tag == "Projectile")
		{
			// Get the amount of damage (from the Shoot script) this particular projectile inflicts and damage enemy
			int dmgTaken = shot.dmg;
			TakeDamage(dmgTaken);
			
			print("Enemy took " + dmgTaken + " damage.");
			//Added this line to change projectile tag after first hit because
			//projectiles were registering more than one hit each time
			Destroy(col.gameObject,0.01f);
			
		}
	}
}
