using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameOverGamestate : GameState {
	EventSystem es = EventSystem.current;

	public GameOverGamestate():base(EGameState.GAMEOVER){

	}
	public override void UpdateState() {

	}

	public override void OnStartGameState() {
		base.OnStartGameState();
		Debug.Log ("entrou no gamestate gameover");
		es.SetSelectedGameObject(GameLogic.Instance.OnStreamUI, null);
		GameLogic.Instance.gameStateManager.gameover.SetActive (true);
		GameLogic.Instance.gameStateManager.gameOverScreen.SetActive (true);

	}

	public override void OnChangeGameState() {
		base.OnChangeGameState();
		Debug.Log ("saiu do gamestate gameover");
		es.SetSelectedGameObject(GameLogic.Instance.CanvasUI, null);
		GameLogic.Instance.gameStateManager.gameover.SetActive (false);
		GameLogic.Instance.gameStateManager.gameOverScreen.SetActive (false);

	}
}
