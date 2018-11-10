using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour {

    private Rigidbody rb;
    //reference to PlayerHealth script
    private PlayerHealth p;
    
    public GameObject player;
    public int health = 15;
    public int armor = 0;
	public int lastDamageFrame = 0;

	// Use this for initialization
	void Start () {
        //reference to PlayerHealth script
        p = FindObjectOfType<PlayerHealth>();
        rb = GetComponent<Rigidbody>();
	}

    private void OnTriggerEnter(Collider other)
    {
        print("Trigger is entered");
        string objectName = other.name;
        if (other.gameObject.CompareTag("Pick Up")) //create a tag (under the name of an object) and set all pickups to Pick Up
        {
            print("On pickup");
            if (objectName.Contains("healthUp"))
            {
                p.healthChange(50);
                print("Health increased to " + p.currentHealth);
            }
            else if (objectName.Contains("armorUp"))
            {
                p.armorChange(50);
                print("Armor increased to " + p.currentArmor);
            }
            else if (objectName.Contains("Double Jump"))
            {
                print("Double Jump acquired");
                PlayerMovement.doubleJump = true;
            }
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Damage"))
        {
            int damVal = 0;
			if (lastDamageFrame + 120 <= Time.frameCount) //2 seconds of invincibility after touching a damage source
			{
                if (objectName.Contains("Enemy"))
                {
                    damVal = 10;
                }
                else if (objectName.Contains("Bullet"))
                {
                    damVal = 5;
                }
                else if (objectName.Contains("Environment"))
                {
                    damVal = 7;
                }
				lastDamageFrame = Time.frameCount;
                //Added call to TakeDamage to handle following conditionals
                p.TakeDamage(damVal);
                /*
                //TODO: I think this if/else statement here is also handled in the PlayerHealth script
				if (armor == 0)
				{
					//p.currentHealth -= damVal;
                    //TODO: I feel like this can be added into PlayerHealth now and handled there
                    //I had already implemented a "weaker" death there
					if (health <= 0)
					{
						print("Player is dead");
                        player.SetActive(false);
                        rb.useGravity = false;
                        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
                        GetComponent<PlayerMovement>().enabled = false;
					}
                    
				}
				else
				{
                    // If incoming damage exceeds remaining armor, rollover 
                    // remaining damage into remaining health 
                    int remainingDamage = 0;
                    if (armor < damVal)
                    {
                        remainingDamage = damVal - armor;
                    }
					armor -= damVal;
					if (armor < 0)
					{
						armor = 0;
					}
                    health -= remainingDamage;
				}
				//other.gameObject.SetActive(false);
                */
			}
		}
    }

    private void OnDamage(Collider other)
    {
        
    }
}