using System;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class PlayerSoul:MonoBehaviour
{
	public string horizontal;
	public string vertical;
	public Vector4 color;
	public Vector4 colorLight;
	public int id;
	public GameObject healthBar;
	static int[] healthbarpos = {-10,-8,8,10};
	public PlayerSoul (string vertical,string horizontal,Vector4 i,Vector4 colorLight,int id)
	{
		this.horizontal = horizontal;
		this.vertical = vertical;
		color = i;
		this.colorLight = colorLight;
		this.id = id;
		healthBar = (GameObject)GameObject.Instantiate (Resources.Load("healthBar"));
		healthBar.transform.Find("Health").GetComponent<Image>().color=i;
		Vector3 pos = healthBar.transform.position;
		pos.x = healthbarpos [id];
		healthBar.transform.position = pos;
	}


}

