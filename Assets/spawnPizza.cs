using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spawnPizza : MonoBehaviour {
	public GameObject pizza;
	Vector3 bounds;
	// Use this for initialization
	void Start () {
		bounds=GameObject.Find("Stage").GetComponent<Renderer>().bounds.extents;
		bounds.x -= .3f;
		bounds.y -= .3f;
		for(int i=0; i<15; i++){
		Instantiate(pizza,
			            new Vector3(Random.Range(bounds.x,-bounds.x),.1f,Random.Range(bounds.z,-bounds.z)),
						pizza.transform.rotation);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
