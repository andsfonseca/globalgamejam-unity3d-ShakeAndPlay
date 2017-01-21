using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsGameState : GameState {

	public OptionsGameState():base(EGameState.OPTIONS){

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
