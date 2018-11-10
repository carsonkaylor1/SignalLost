using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : EnemyBasicAI {

	public GameObject projectilePrefab;
	public GameObject shootingPoint;

	public int seconds = 10;
	public int projectileSpeed = 5;

	public int dmg = 50;
	//public int MaxSightDist;

	bool isCoroutineStarted = false;
	
	void Awake()
	{
		MaxSightDist = 30;
	}

	void FixedUpdate()
	{
		if(base.shootDistance == true && !isCoroutineStarted)
		{
			print("Shoot");
			StartCoroutine(EnemyShoot());
		}
	}
	


	IEnumerator EnemyShoot()
	{
		isCoroutineStarted = true;
		Fire();
		yield return new WaitForSecondsRealtime(4.0f);
		isCoroutineStarted = false;
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
