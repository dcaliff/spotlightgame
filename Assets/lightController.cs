using UnityEngine;
using System.Collections;


public class lightController : MonoBehaviour {

	Vector3 movement;
	float speed= 2.2f;
	float rToH;
	SphereCollider sphere;
	Light light;
	Vector3 bounds;
	public PlayerSoul player;


	// Use this for initialization
	void Start () {
		sphere = GetComponent<SphereCollider> ();
		light = GetComponent<Light> ();
		rToH=Mathf.Sin((light.spotAngle/2f)*Mathf.Deg2Rad);
		bounds=GameObject.Find("Stage").GetComponent<Renderer>().bounds.extents;
		bounds.x -= .3f;
		bounds.y = 6.5f;

	}

	public void setPlayer(PlayerSoul ps){
		player=ps;
		GetComponent<Light> ().color=ps.colorLight;
	}
	// Update is called once per frame
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxisRaw (player.horizontal);

		float v = Input.GetAxisRaw (player.vertical);
		float z = Input.GetAxisRaw ("Height");
		move (h, z, v);
		sphere.radius = rToH * transform.position.y;
		sphere.center = new Vector3 (0,0,transform.position.y);
		
	}
	
	void move(float h,float z,float v){
		movement.Set (h, z, v);
		float mag = Mathf.Sqrt ((h * h) + (v * v));
		movement = movement.normalized * speed * Time.deltaTime*mag;
		Vector3 position = transform.position;
		position += movement;
		position = new Vector3 (Mathf.Clamp (position.x, -bounds.x, bounds.x), 
		                                  Mathf.Clamp (position.y, .8f, bounds.y), 
		                                  Mathf.Clamp (position.z, -bounds.z, bounds.z));
		transform.position=position;

		
	}
}
