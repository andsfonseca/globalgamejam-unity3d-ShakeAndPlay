using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGameState : GameState {

    private UnityEngine.UI.Text m_points;
	private Animation m_miss;

	public GameGameState(UnityEngine.UI.Text points, Animation miss) :base(EGameState.GAME){
        m_points = points;
		m_miss = miss;
	}
	public override void UpdateState() {

	}

	public override void OnStartGameState() {
		base.OnStartGameState();
        GameLogic.Instance.gameStateManager.game.SetActive(true);
	}

	public override void OnChangeGameState() {
		base.OnChangeGameState();
        GameLogic.Instance.gameStateManager.game.SetActive(false);
    }

    public void UpdateScore(int points) {
        m_points.text = (" " + points);
    }

	public void ExecuteMiss(){
		if (!m_miss.isPlaying) {
			m_miss.Play ();
		}
	}
}
