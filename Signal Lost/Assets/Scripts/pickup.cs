using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour {

    private Rigidbody rb;
    
    public GameObject player;
    public int health = 15;
    public int armor = 0;
	public int lastDamageFrame = 0;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    private void OnTriggerEnter(Collider other)
    {
        string objectName = other.name;
        if (other.gameObject.CompareTag("Pick Up")) //create a tag (under the name of an object) and set all pickups to Pick Up
        {
            if (objectName.Contains("healthUp"))
            {
                print("Health increased to " + health);
                health += 15;
            }
            else if (objectName.Contains("armorUp"))
            {
                print("Armor increased to " + armor);
                armor += 5;
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
				if (armor == 0)
				{
					health -= damVal;
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
                    /* If incoming damage exceeds remaining armor, rollover 
                     * remaining damage into remaining health */
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
			}
		}
    }

    private void OnDamage(Collider other)
    {
        
    }
}