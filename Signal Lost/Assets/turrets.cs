using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class turrets : MonoBehaviour {

	bool isPlayerAlive = false;

	//Get location reference of the room
	public GameObject bossRoom;
	public GameObject movePoint;
	public Transform room;
	public Transform player;
	public List<GameObject> activeTurrets = new List<GameObject>(); 

	public int speed = 3;

	// Use this for initialization
	void Start () {
	
		//SpawnMovePoint();

		isPlayerAlive = true;
		//Find how many turrets there are, create array of appropriate size and then
		//add them all to a list of active turrets
		int numTurrArrLen = GameObject.FindGameObjectsWithTag("turret").Length;
		GameObject[] numTurrArr = new GameObject[numTurrArrLen];
		numTurrArr = GameObject.FindGameObjectsWithTag("turret");
		for(int i = 0; i < numTurrArrLen; i++)
		{
			activeTurrets.Add(numTurrArr[i]);
			print("adding " + numTurrArr[i].name);
			//activeTurrets[i].AddComponent<turretBehavior>();
		}
		//Vector3 randLoc = Random.onUnitSphere;
		//movePoint.transform.position = randLoc + transform.localPosition;
		StartCoroutine(Move());
	}
	
	// Update is called once per frame
	void Update () {
		
		//While the player is alive, the turrets will face him. 
		//The forward position on the turret model must be messed up so
		//Had to apply a weird rotation to fix them
		float step = speed * Time.deltaTime;
		if(isPlayerAlive)
		{
			foreach (var turret in activeTurrets)
			{
				turret.transform.LookAt(player);
				turret.transform.Rotate(new Vector3(-95,0,-140));
				turret.transform.position = Vector3.MoveTowards(turret.transform.position, movePoint.transform.position, step);
			}
		}
		
	}
	public Vector3 center;
	public Vector3 size;
	//public GameObject movePoint;


	public void SpawnMovePoint()
	{
		Vector3 pos = center + new Vector3(Random.Range(-size.x/2, size.x/2),Random.Range(-size.y/2, size.y/2),Random.Range(-size.z/2, size.z/2));
		print(pos);
		movePoint = Instantiate(movePoint, pos, Quaternion.identity);
		//Instantiate(movePoint, pos, Quaternion.identity);
	}

	IEnumerator Move()
	{
		while(true)
		{
			SpawnMovePoint();
			yield return new WaitForSeconds(3);
			Destroy(movePoint);
		}
	}
/*
	void OnDrawGizmosSelected()
	{
		Gizmos.color = new Color(1,0,0,0.5f);
		Gizmos.DrawCube(transform.localPosition + center, size);
	}
 */	

}
