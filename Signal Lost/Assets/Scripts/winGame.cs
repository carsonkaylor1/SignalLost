using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winGame : MonoBehaviour {

	public GameObject circuit;
	public GameManager gameManager;

	bool bossIsDead;

	// Use this for initialization
	void Start () {

		if(circuit == null)
		{
			circuit = GameObject.FindWithTag("Boss");
			
		}
		if(circuit.tag == "Boss")
		{
			Debug.Log("Found boss");
			bossIsDead = false;
		}
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(circuit == null)
		{
			bossIsDead = true;
		}
		if(bossIsDead)
		{
			FindObjectOfType<GameManager>().EndGame();

		}
	}
}
