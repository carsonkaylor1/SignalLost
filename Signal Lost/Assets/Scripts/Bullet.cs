using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = .1f;

    Vector3 prevPos;
    GameObject playerPos;
    Vector3 dir;

    void Awake()
    {
        Destroy(this.gameObject, 5f);
        prevPos = transform.position;
        playerPos = GameObject.Find("character");
        dir = playerPos.transform.right;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        prevPos = transform.position;

        transform.Translate(dir * (speed * Time.deltaTime));

        //detects everything that the bullet will hit
        RaycastHit[] hits = Physics.RaycastAll(new Ray(prevPos,
            (transform.position - prevPos).normalized), (transform.position - prevPos).magnitude);

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.gameObject.name.Equals("Enemy"))
            {
                //hits[i].collider.gameObject.GetComponent<Enemy>().health--;
            }
            Destroy(this.gameObject);

        }

    }
}
