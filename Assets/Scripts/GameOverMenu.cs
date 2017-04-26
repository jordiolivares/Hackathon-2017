using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour {

	public string mainMenu;

	public void RestartGame(){
		FindObjectOfType<GameController> ().Reset ();
	}

	public void QuitToMain(){
		Application.LoadLevel(mainMenu);
	}
}
