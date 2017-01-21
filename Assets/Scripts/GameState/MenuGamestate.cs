using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGamestate : GameState {

	public MenuGamestate():base(EGameState.MENU){
		
	}
	public override void UpdateState() {

	}

	public override void OnStartGameState() {
		base.OnStartGameState();
		//GameLogic.Instance.gameStateManager.game

	}

	public override void OnChangeGameState() {
		base.OnChangeGameState();
		GameLogic.Instance.gameStateManager.menu.SetActive (false);
	}
}
