﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class login_database : MonoBehaviour {

	string url_login = "http://192.168.100.26/game/login";
	string url_regis = "http://192.168.100.26/game/signup";
	string username,password;
	public GameObject success; 
	public GameObject fail;
	public static string id_acc;

	public void SetUsername(InputField t){

		username = t.text;
	}
	public void SetPassword(InputField t){
		
		password = t.text;
	}
	public void login_click()
	{

		if (string.IsNullOrEmpty (username) || string.IsNullOrEmpty (password) ) {

			return;
		}

		Debug.Log ("Send username="+username+"&password="+password);
	

		

		Connector.GET (url_login+"?username="+username+"&password="+password, loginCallBack);



	}
   public static float x;

	public void loginCallBack(WWW www){
		Debug.Log ("Login Callback");
		//Debug.Log (www.text);

		Dictionary<string,object> jsonObject = MiniJSON.Json.Deserialize(www.text) as Dictionary<string,object>;

		if(jsonObject.ContainsKey("status")){
			if(jsonObject["status"].ToString()== "success"){
				Debug.Log(jsonObject["data"].ToString());

				Debug.Log("Login Success");
				Dictionary<string,object>  data = jsonObject["data"]as  Dictionary<string,object>;

//				id_acc = data["id"].ToString();
//				x = float.Parse(data["x"].ToString());
				Application.LoadLevel("scene1");
			}else if(jsonObject["status"].ToString()== "error"){

				Debug.Log("Login Fail");


			}

		}

	}


	public void registor_click()
	{
		
		if (string.IsNullOrEmpty (username) || string.IsNullOrEmpty (password) ) {
			
			return;
		}
		
		Debug.Log ("Send username="+username+"&password="+password);
		
		
		
		Connector.GET (url_regis + "?username=" + username + "&password=" + password, regisCallback);
	
	}

	public void regisCallback(WWW www){
		Debug.Log("regisCallback");
		Debug.Log (www.text);
		
		Dictionary<string,object> jsonObject = MiniJSON.Json.Deserialize(www.text) as Dictionary<string,object>;
		
		if(jsonObject.ContainsKey("status")){
			if(jsonObject["status"].ToString()== "success"){
				fail.SetActive(false);
				success.SetActive(true);
				Debug.Log("Register Success");
				StartCoroutine (NextScene());



			}else if(jsonObject["status"].ToString()== "error"){
				Debug.Log(jsonObject["text"].ToString());
				fail.SetActive(true);
				success.SetActive(false);
				Debug.Log("Register Fail");
				
				
			}
			
		}


}

	IEnumerator NextScene()
	{
		yield return new WaitForSeconds (5);
		Application.LoadLevel("ui");

	}

}