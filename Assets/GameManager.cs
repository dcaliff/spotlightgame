using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject alien;
	public GameObject spotlight;
	public float startTime;
	// Use this for initialization
	void Start () {
		PlayerManager.Start (alien,spotlight);
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (Time.time - startTime);
		if (Time.time - startTime > 10) {
			startNewRound();
		}
	}

	public void startNewRound(){

		PlayerManager.switchPlayerRoles (PlayerManager.spotPlayer + 1);
		startTime = Time.time;
	
	
	}
}
