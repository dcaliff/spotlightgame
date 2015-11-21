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
	

	public PlayerSoul playerSoul;

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
		float h = Input.GetAxisRaw (playerSoul.horizontal);
		float v = Input.GetAxisRaw (playerSoul.vertical);
		bool stealth = Input.GetAxisRaw ("Stealth")==1;
		  
		damage=Mathf.Clamp (damage, 0, maxDamage);
		camo=Mathf.Clamp (camo, 0, maxCamo);
		/*healthBar.transform.localScale = new Vector3 (damage / maxDamage, 
		                                           healthBar.transform.localScale.y, 
		                                             healthBar.transform.localScale.z);
*/	
		move (h, v);

	}

	public void setPlayerSoul(PlayerSoul soul){
		playerSoul = soul;
//		Debug.Log (soul.color.x);
		GetComponent<Renderer> ().material.SetVector ("_Color", soul.color); 
		Material s = GameObject.Find ("Stage").GetComponent<Renderer> ().material;
	
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
			//r.material.SetFloat ("_alpha", 1);

		}
		if (collisionInfo.gameObject.name == "pizzaGame(Clone)") {
			Destroy(collisionInfo.gameObject);
		}
	}
}

