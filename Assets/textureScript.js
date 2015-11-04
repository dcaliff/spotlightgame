 #pragma strict
 var imageFolderName = "Assets/images";
 var MakeTexture = true;
 var pictures : Texture[];
 var loop = true;
 var counter = 0;
 var Film = true;
 var PictureRateInSeconds:float = 1;
 var renderer1: Renderer;
 private var nextPic:float = 0;
 
 function Start () {
     if(Film == true){
         PictureRateInSeconds = 0.04166666666666666666;
     }

 	 renderer1 =GetComponent.<Renderer> ();
     var textures : Object[] = Resources.LoadAll(imageFolderName);  
     pictures=new Texture[textures.Length];
     for(var i = 0; i < textures.Length; i++){
        // Debug.Log("found");
         pictures[i]=textures[i];
     }
 }
 
 function Update () {
     if(Time.time > nextPic){
         nextPic = Time.time + PictureRateInSeconds;
         counter += 1;
         if(counter >= pictures.length){
         //Debug.Log("fertig");
         	if(loop){
            	 counter = 0;
        	 }
     	 }
         if(MakeTexture){
             renderer1.material.mainTexture = pictures[counter];
         }
     }
     
 }