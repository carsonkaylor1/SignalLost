using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour {

    private Rigidbody rb;

    public int health = 5;
    public int armor = 0;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up")) //create a tag (under the name of an object) and set all pickups to Pick Up
        {
            string objectName = other.name;
            switch (objectName)
            {
                case "healthUp":
                    print("Health increased to " + health);
                    health += 5;
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
            if (armor == 0)
            {
                health -= 5;
                if (health <= 0)
                {
                    print("Player is dead");
                    //player dies.
                }
            }
            else
            {
                armor -= 5;
                if (armor < 0)
                {
                    armor = 0;
                }
            }
            other.gameObject.SetActive(false);
        }
    }

    private void OnDamage(Collider other)
    {
        
    }
}