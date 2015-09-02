using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class login_database : MonoBehaviour {

	string url_login = "http://192.168.100.26/game/login";

	string username,password;
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

		

		Connector.GET (url_login+"?username="+username+"&password="+password, CallBack);



	}
	public void CallBack(WWW www){

		//Debug.Log (www.text);

		Dictionary<string,object> jsonObject = MiniJSON.Json.Deserialize(www.text) as Dictionary<string,object>;

		if(jsonObject.ContainsKey("status")){
			if(jsonObject["status"].ToString()== "success"){
				Debug.Log("Login Success");

			}else if(jsonObject["status"].ToString()== "error"){

				Debug.Log("Login Fail");

			}

		}

	}
}
