using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	public Texture mybg;
	
    void OnGUI () {
  
		GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), mybg);

  
    	GUI.Label(new Rect(450,100,500,800),"SPACE ROCKET");
     
			
        if(GUI.Button(new Rect(250,200,500,100), "PLAY")) {
            Application.LoadLevel("Space");
        }
    	


        if(GUI.Button(new Rect(250,400,500,100), "QUIT")) {
            Application.Quit();
        }
 	}
}


