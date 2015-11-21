using UnityEngine;
using System.Collections;

public static class PlayerManager {
	static string[] controls;
	static string[] joyControls;
	public static PlayerSoul[] players;
	public static GameObject alien;
	public static GameObject spotlight;
	public static GameObject[] aliens;
	public static Vector4[] colors;
	public static Vector4[] colorLight; 
	public static int spotPlayer;
	static int numberOfplayers = 3;
	// Use this for initialization
	public static void Start (GameObject aliem,GameObject spotligh) {
		alien = aliem;
		spotlight = spotligh;

		controls= new string[]{"Vertical","Horizontal","Vertical2","Horizontal2","Vertical3","Horizontal3"};
		joyControls = new string[]{"joyVertical","joyHorizontal"};
		colors = new Vector4[5];
		colors [0] = new Vector4 (.6f, .6f, .9f,1);
		colors [1] = new Vector4 (.3f, .93f, .05f,1);
		colors [2] = new Vector4 (.75f, .65f, .85f,1);
		colors [3] = new Vector4 (.7f, .9f, .8f,1);

		colorLight = new Vector4[5];
		colorLight [0] = new Vector4 (0f, .65f, 1f,1);
		colorLight [1] = new Vector4 (.7f, 1f, 0f,1);
		colorLight [2] = new Vector4 (.8f, 0f, 1f,1);
		colorLight [3] = new Vector4 (.7f, .9f, .8f,1);
		Debug.Log (Input.GetJoystickNames ());
		CreatePlayers (numberOfplayers);

	}

	public static void CreatePlayers(int numberOfPlayers){
		players= new PlayerSoul[numberOfPlayers];
		aliens = new GameObject[numberOfPlayers-1];
		spotPlayer = 0;
		PlayerSoul player;
		int numberOfJoys = Input.GetJoystickNames ().Length;
		for (int i=0; i<numberOfPlayers*2;) {
			if(numberOfJoys>i/2){
				Debug.Log("controller");
				player=new PlayerSoul(joyControls[i],joyControls[i+1],colors[i/2],colorLight[i/2],i/2);
			}
			else{
				Debug.Log(i-numberOfJoys*2+","+(i-numberOfJoys*2)+1);
				Debug.Log("keyboard");
				player=new PlayerSoul(controls[i-numberOfJoys*2],controls[(i-numberOfJoys*2)+1],colors[i/2],colorLight[i/2],i/2);
			
					
			}
			players[i/2]=player;
			i+=2;

		}
		spotlight=GameObject.Instantiate (spotlight);
		spotlight.GetComponent<lightController>().setPlayer (players [0]);
		for (int i=1; i<numberOfPlayers; i++) {
			aliens[i-1]=(GameObject)GameObject.Instantiate(alien,new Vector3(3-i*2,0,0),alien.transform.rotation);
			aliens[i-1].GetComponent<AlienBoyControls>().setPlayerSoul(players[i]);
		}
	}

	public static void switchPlayerRoles(int i){
		Debug.Log ("new Round");

		i = i % numberOfplayers;
		Debug.Log (i);
	
		spotlight.GetComponent<lightController>().setPlayer (players [i]);
		Debug.Log(players [i].id + " is spotlight now");
		for(int j=0; j<aliens.Length; j++){
			if(aliens[j].GetComponent<AlienBoyControls>().playerSoul.id==i){
				aliens[j].GetComponent<AlienBoyControls>().setPlayerSoul(players[spotPlayer]);
				Debug.Log(players [spotPlayer].id + " is alien now");
			}
		}
		Debug.Log (i);
		spotPlayer = i;
		Debug.Log (spotPlayer);
	}


	// Update is called once per frame
	static void Update () {
	
	}
}
