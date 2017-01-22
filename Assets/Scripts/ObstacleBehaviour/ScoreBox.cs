using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBox : MonoBehaviour {
	public bool counted;
    private Transform m_playerPosition;
    public float infLimit;
    public float supLimit;
	// Use this for initialization
	void Start () {
		counted = false;
        m_playerPosition = GameLogic.Instance.player.transform;
	}
    void OnEnable() {
        counted = false;
    }
	
	// Update is called once per frame
	void Update () {
        float diff = Mathf.Abs(m_playerPosition.position.x -transform.position.x);
        if (diff>=infLimit && diff<=supLimit) {
            if (GameLogic.Instance.inputEvent.isShaking) {
                GameLogic.Instance.player.Jump();
            }
        }
	}
}
