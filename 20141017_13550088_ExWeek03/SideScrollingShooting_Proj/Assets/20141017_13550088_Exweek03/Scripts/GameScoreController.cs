using UnityEngine;
using System.Collections;
public class GameScoreController : MonoBehaviour {
	public static GameScoreController controller;
	
	private int score = 0;

	
	public void AddScore(int amount){
		score += amount;

	}
	public void ResetScore(){
		score = 0;

	}

	void Awake(){
		controller = this;
	
	}

	void Start () {
		ResetScore();
	}
	void OnGUI(){
		

		string text = "SCORE : "+score;
		
		GUI.Label(new Rect(10,30,200,30),text);
	}
	
	
}
	

	