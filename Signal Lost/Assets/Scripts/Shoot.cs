using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	// Get references to the prefab for the projectile to be used, and the "shooting point" on the gun, aka where the projectile will spawn
	public GameObject projectilePrefab;
	public GameObject shootingPoint;

	// Amount of time projectile stay in scene
	public int seconds = 3;
	public int projectileSpeed = 5;
	// Amount of damage this projectile inflicts
	public int dmg = 50;

	
	// Update is called once per frame
	void FixedUpdate () 
	{
		// Firing is done with Fire1, aka left mouse click
		if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
		

	}
	  void Fire()
    {
		// Create projectile
    	GameObject tempProjectile;
		tempProjectile = Instantiate(projectilePrefab) as GameObject;
		
		// Set projectiles position to in front of shooting point
		tempProjectile.transform.position = transform.position + shootingPoint.transform.forward;

		// Get the rigidbody for the projectile so we can apply force to it
		Rigidbody projectile = tempProjectile.GetComponent<Rigidbody>();
		//Quaternion rot = new Quaternion(90,0,0,0);
		//projectile.rotation = rot;
		// Apply velocity to created projectle gameobject to move from the tip of shooting point at desired speed
		projectile.velocity = shootingPoint.transform.forward * projectileSpeed;

		Destroy(tempProjectile);
	}

	void Destroy(GameObject toBeDestroyed)
	{
		// Destroys the projectile after specified amount of time
		Destroy(toBeDestroyed,seconds);
	}

}
