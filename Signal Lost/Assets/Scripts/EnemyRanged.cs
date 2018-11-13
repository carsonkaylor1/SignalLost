using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : EnemyBasicAI {

	public GameObject projectilePrefab;
	public GameObject shootingPoint;

	public int seconds = 10;
	public int projectileSpeed = 5;
	//real seconds between shots
	public int shootTime = 2;

	public int dmg = 50;
	public int range = 10;
	//public int MaxSightDist;

	bool isCoroutineStarted = false;
	bool isRunningAway = false;
	
	void Awake()
	{
		MaxSightDist = 30;
	}

	void Update()
	{
		isMeleeRange = false;
		shootDistance = false;
		
		if(Vector3.Distance(transform.position,Player.position) < MaxSightDist)
		{
			transform.LookAt(Player);
			if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
			{
				isMeleeRange = true;
				if(isMeleeRange == true)
				{
					print("too close");
					isRunningAway = true;
					//if the ranged enemy is too close to the player, run away
					transform.rotation = Quaternion.LookRotation(transform.position - Player.position);
					transform.position += transform.forward * MoveSpeed * Time.deltaTime;
				}
			}
			if(Vector3.Distance(transform.position,Player.position) > MaxDist && !isCoroutineStarted && !isMeleeRange)
			{
				print("Shoot");
				StartCoroutine(EnemyShoot());
			}
		}
		
	}
	


	IEnumerator EnemyShoot()
	{
		isCoroutineStarted = true;
		Fire();
		yield return new WaitForSecondsRealtime(shootTime);
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
