using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicAI : MonoBehaviour
{

    public Transform Player;
    public float MoveSpeed;
    public float MaxSightDist;
    public float MaxDist;
    public float minDist;
    public float meleeDistance;
    public float hitTime;

    public bool isMeleeRange = false;
    public bool shootDistance = false;
    public bool isMeleeCoStarted = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isMeleeRange = false;
        shootDistance = false;
       
        

        //checks if player is with noticing distance
        //Line of sight distance
        if (Vector3.Distance(transform.position, Player.position) <= MaxSightDist)
        {
            transform.LookAt(Player);
            shootDistance = true;
            //move towards player till youre at minDist
            if (Vector3.Distance(transform.position, Player.position) >= minDist)
            {

                transform.position += transform.forward * MoveSpeed * Time.deltaTime;
                

                //Shoot distance?
                if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
                {
                    
                    //face the target
                    FacePlayer();
                    //Here Call any function you want Like Shoot at here or something
                    //Melee distance
                    if(Vector3.Distance(transform.position,Player.position) <= meleeDistance)
                    {
                        isMeleeRange = true;
                        print("Entered melee range");
                        if(!isMeleeCoStarted)
                            StartCoroutine(MeleeAttack());
                        //melee player
                        //MeleeAttack();
                    }

                }
            }
        }
    }

    void FacePlayer()
    {
        Vector3 direction = (Player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime *5f);
    }

    IEnumerator MeleeAttack()
    {
        isMeleeCoStarted = true;
        FacePlayer();
        print("I gotcha!");
        Hit();
        yield return new WaitForSecondsRealtime(hitTime);
        isMeleeCoStarted = false;
    }

    void Hit()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward,out hit,10))
        {
            if(hit.collider.tag == "Player")
            {
                print("Hitting Player");
                Player.GetComponent<PlayerHealth>().TakeDamage(15);
            }
        }
    }
}
