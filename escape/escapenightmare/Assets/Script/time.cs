using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class time : MonoBehaviour {
	public GameObject timerLabel;
	
	private float timer = 50;
	
	void Update() {
//		timer -= Time.deltaTime;
//		
//		var minutes = timer / 60; //Divide the guiTime by sixty to get the minutes.
//		var seconds = timer % 60;//Use the euclidean division for the seconds.
//		var fraction = (timer * 100) % 100;
//		
//		//update the label value
//		timerLabel.gameObject = string.Format ("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);
	}
}