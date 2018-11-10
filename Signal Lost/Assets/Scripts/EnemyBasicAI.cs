using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicAI : MonoBehaviour
{

    public Transform Player;
    public float MoveSpeed;
    public float MaxSightDist;
    public float MaxDist;
    public float MinDist;

    public bool shootDistance = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shootDistance = false;
        transform.LookAt(Player);


        //checks if player is with noticing distance
        if (Vector3.Distance(transform.position, Player.position) <= MaxSightDist)
        {

            //If its outside a certain range, move towards player
            if (Vector3.Distance(transform.position, Player.position) >= MinDist)
            {

                transform.position += transform.forward * MoveSpeed * Time.deltaTime;


                if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
                {
                    shootDistance = true;
                    //face the target
                    FacePlayer();
                    //Here Call any function you want Like Shoot at here or something


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
}
