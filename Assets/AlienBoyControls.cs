using UnityEngine;
using System.Collections;

public class AlienBoyControls : MonoBehaviour {
	Vector3 movement;
	float speed= 2f;
	Vector3 bounds;
	float damage=0f;
	float maxDamage=10f;
	float camo=1f;
	float maxCamo=1f;

	GameObject camoBar;
	GameObject healthBar;
	Renderer r;
	// Use this for initialization
	void Start () {
		bounds=GameObject.Find("Stage").GetComponent<Renderer>().bounds.extents;
		r=GetComponent<Renderer> ();
		healthBar = GameObject.Find ("Health");
		camoBar = GameObject.Find ("Camo");
		bounds.x -= .3f;
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		bool stealth = Input.GetAxisRaw ("Stealth")==1;
		if (stealth&&camo!=0) {
			r.material.SetFloat ("_alpha", 0);
			camo-=.007f;
		} 
		else {
			camo+=.001f;
			r.material.SetFloat ("_alpha", 1);
		}
		  
		damage=Mathf.Clamp (damage, 0, maxDamage);
		camo=Mathf.Clamp (camo, 0, maxCamo);
		healthBar.transform.localScale = new Vector3 (damage / maxDamage, 
		                                           healthBar.transform.localScale.y, 
		                                             healthBar.transform.localScale.z);
		camoBar.transform.localScale = new Vector3 (camo / maxCamo, 
		                                              camoBar.transform.localScale.y, 
		                                              camoBar.transform.localScale.z);
		move (h, v);

	}

	void move(float h,float v){
		movement.Set (h, 0, v);
		movement = movement.normalized * speed * Time.deltaTime;
		transform.Translate (movement);
		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, -bounds.x, bounds.x), 0, 
		                              		Mathf.Clamp (transform.position.z, -bounds.z, bounds.z));

	}
	void OnTriggerStay( Collider collisionInfo) {

		if (collisionInfo.gameObject.name == "Spotlight") {
			damage+=.0175f;
			r.material.SetFloat ("_alpha", 1);

		}
		Debug.Log (collisionInfo.gameObject.name);
		if (collisionInfo.gameObject.name == "pizzaGame(Clone)") {
			Destroy(collisionInfo.gameObject);
		}
	}
}
