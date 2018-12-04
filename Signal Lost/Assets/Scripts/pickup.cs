using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{

    private Rigidbody rb;
    private PlayerHealth p;
    
    public GameObject player;
    public int health = 15;
    public int armor = 0;
    public int lastDamageFrame = 0;
    
	void Start () {
        p = GetComponent<PlayerHealth>();
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
                if (p.currentHealth == p.maxHealth)
                {
                    //do nothing
                }
                else
                {
                    other.gameObject.SetActive(false);
                    p.healthChange(50);
                    print("Health increased to " + p.currentHealth);
                }
            }
            else if (objectName.Contains("armorUp"))
            {
                if (p.currentArmor == p.maxArmor)
                {
                    //do nothing
                }
                else
                {
                    other.gameObject.SetActive(false);
                    p.armorChange(50, other);
                    print("Armor increased to " + p.currentArmor);
                }
            }
            else if (objectName.Contains("Double Jump"))
            {
                print("Double Jump acquired");
                PlayerMovement.doubleJump = true;
                other.gameObject.SetActive(false);
            }
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
                    damVal = 50; //changed to 50 from 5
                }
                else if (objectName.Contains("Environment"))
                {
                    damVal = 7;
                }
                lastDamageFrame = Time.frameCount;
                //Added call to TakeDamage to handle following conditionals
                p.TakeDamage(damVal);
            }
        }    
	}
}
