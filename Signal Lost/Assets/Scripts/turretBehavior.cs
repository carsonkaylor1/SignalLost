using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretBehavior : MonoBehaviour {

	public GameObject projectile;
	public GameObject shootPoint1;
	public GameObject shootPoint2;
	public GameObject PlayerHealth;

	public int shootTime = 20;
	public int projectileSpeed = 5;
	public int dmg = 50;
	bool isCoroutineStarted = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!isCoroutineStarted)
			StartCoroutine(EnemyShoot());
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
		GameObject tempProjectile2;
		tempProjectile = Instantiate(projectile) as GameObject;
		tempProjectile2 = Instantiate(projectile) as GameObject;
		
		// Set projectiles position to in front of shooting point
		//tempProjectile.transform.position = transform.position + shootPoint1.transform.forward;
		tempProjectile.transform.position = shootPoint1.transform.position;
		tempProjectile2.transform.position = shootPoint2.transform.position;

		// Get the rigidbody for the projectile so we can apply force to it
		Rigidbody projectileRig = tempProjectile.GetComponent<Rigidbody>();
		Rigidbody projectileRig2 = tempProjectile2.GetComponent<Rigidbody>();

		// Apply velocity to created projectle gameobject to move from the tip of shooting point at desired speed
		projectileRig.velocity = shootPoint1.transform.forward * projectileSpeed;
		projectileRig2.velocity = shootPoint2.transform.forward * projectileSpeed;

		Destroy(tempProjectile);
		Destroy(tempProjectile2);
	}

	

	void Destroy(GameObject toBeDestroyed)
	{
		// Destroys the projectile after specified amount of time
		Destroy(toBeDestroyed,10);
	}

	// private void OnCollisionEnter(Collision other) 
	// {
	// 	if(other.gameObject.tag == "Player")
	// 	{
	// 		PlayerHealth.GetComponent<PlayerHealth>().TakeDamage(dmg);
	// 	}
	// }
}
