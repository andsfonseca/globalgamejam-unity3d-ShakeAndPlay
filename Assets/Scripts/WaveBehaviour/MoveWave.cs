using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWave : MonoBehaviour {
	private float speed;
	// Use this for initialization
	void Start () {
		speed = GameObject.FindGameObjectWithTag ("Player").GetComponent<MovePlayer>().speed;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (GameLogic.Instance.gameStateManager.current.Equals(EGameState.GAME))
			transform.Translate (speed*Time.fixedDeltaTime, 0, 0);
	}
}
