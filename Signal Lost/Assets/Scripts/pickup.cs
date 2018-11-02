using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour {

    private Rigidbody rb;

    public int health = 5;
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
            switch (objectName)
            {
                case "healthUp":
                    print("Health increased to " + health);
                    health += 15;
                    break;
                case "armorUp":
                    print("Armor increased to " + armor);
                    armor += 5;
                    break;
            }
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Damage"))
        {
            int damVal = 0;
			if (lastDamageFrame + 300 <= Time.frameCount)
			{
                switch(objectName)
                {
                    case "Enemy": //Damage taken on contact with enemy
                        damVal = 10;
                        break;
                    case "Bullet": //Damage taken on contact with enemy projectile
                        damVal = 5;
                        break;
                    case "Environment": //Damage taken on contact with environmental hazards
                        damVal = 7;
                        break;
                }
				lastDamageFrame = Time.frameCount;
				if (armor == 0)
				{
					health -= damVal;
					if (health <= 0)
					{
						print("Player is dead");
						//player dies.
					}
				}
				else
				{
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