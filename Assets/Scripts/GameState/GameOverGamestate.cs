using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverGamestate : GameState {

	public GameOverGamestate():base(EGameState.GAMEOVER){

	}
	public override void UpdateState() {

	}

	public override void OnStartGameState() {
		base.OnStartGameState();
		GameLogic.Instance.gameStateManager.game.SetActive (false);
	}

	public override void OnChangeGameState() {
		base.OnChangeGameState();
		GameLogic.Instance.gameStateManager.gameover.SetActive (false);
	}
}
