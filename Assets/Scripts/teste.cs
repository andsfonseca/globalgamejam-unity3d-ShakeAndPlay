using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class teste : MonoBehaviour {
	public GameObject menu;
	public GameObject options;
	public GameObject gameover;
	public GameObject game;
	public Text txt;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayBTNFunction(){
		menu.gameObject.SetActive (false);
		game.gameObject.SetActive (true);
	}	
	public void OptionsBTNFunction(){
		menu.gameObject.SetActive (false);
		options.gameObject.SetActive (true);
	}	
	public void ExitBTNFunction(){
		menu.gameObject.SetActive (false);
		//game.gameObject.SetActive (true);
	}	
	public void GanhouBTNFunction(){
		game.gameObject.SetActive (false);
		gameover.gameObject.SetActive (true);
		txt.text = "GameOver - Ganhou?";
	}
	public void PerdeuBTNFunction(){
		game.gameObject.SetActive (false);
		gameover.gameObject.SetActive (true);
		txt.text = "GameOver - Perdeu :/";
	}
	/*public void PlayBTNFunction(){

	}*/
	public void RestartBTNFunction(){
		gameover.gameObject.SetActive (false);
		game.gameObject.SetActive (true);
	}	
	public void OptionsGameOverBTNFunction(){
		gameover.gameObject.SetActive (false);
		options.gameObject.SetActive (true);
	}	
	public void ExitGameOverBTNFunction(){
		gameover.gameObject.SetActive (false);
		//options.gameObject.SetActive (true);
	}	
	public void MenuBTNFunction(){
		options.gameObject.SetActive (false);
		menu.gameObject.SetActive (true);
	}
}
