using UnityEngine;
using System.Collections;

public class GameStateController : MonoBehaviour {

	private int state = 0;
	//0 : Gameplay
	//1 : End Game
	public GUIStyle myGUIStyle;

	public EnemySpawnerController spawnCrontroller;
	public GameObject playerShip;
	public NukeLauncherController nukeLauncher;


	public void ChangeStateToEndGame(){
		state = 1;
		spawnCrontroller.enabled = false;
	}
	public void ChangeStateToGamePlay(){
		state = 0;
		nukeLauncher.LaunchNuke();
		spawnCrontroller.enabled = true;
		playerShip.SetActive(true);
		playerShip.transform.position = new Vector3(0f,0f,0f);
		GameScoreController.controller.ResetScore();
	}

	void OnGUI(){

		if(state == 1 ){
			if(GUI.Button(new Rect(100,650,100,50),
			              "RESTART"))
			{ ChangeStateToGamePlay();}
		}

		if(state == 1 ){
			if(GUI.Button(new Rect(800,650,100,50), "QUIT"))
			{ Application.Quit(); }
	}
}
}
