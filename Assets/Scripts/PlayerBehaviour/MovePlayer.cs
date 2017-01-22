using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour {
	public float speed;
	public float jumpForce;
	public bool isGrounded;
	private Vector3 wavePosition;
	private int score = 0;
	public bool bateu;
	// Use this for initialization
	void Start () {
		isGrounded = false;
		bateu = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (GameLogic.Instance.gameStateManager.current.Equals(EGameState.GAME)) {
			move();
            checkGround();
            checkWave();
            checkScore();
        }
	}
	private void move(){
		if (!bateu) {
			transform.Translate (speed*Time.fixedDeltaTime, 0, 0);
		}

		if(isGrounded && Input.GetButtonDown("Jump")){
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
			Debug.Log ("pulou");
			(GameLogic.Instance.gameStateManager.currentGS as GameGameState).ExecuteMiss();
			GetComponent<Animator> ().SetTrigger ("Jump");
		}
	}
	private void checkWave(){
		wavePosition = GameObject.FindGameObjectWithTag ("wave").transform.position;
		if (Mathf.Abs(transform.position.x - wavePosition.x) < 2.2f) {
			Debug.Log ("morreu");
		}
	}
	private void checkGround(){
		if (transform.position.y < -1.1f) {
			isGrounded = true;

		} else {
			isGrounded = false;
		}
		GetComponent<Animator> ().SetBool ("Ground", isGrounded);
	}
	private void checkScore(){
		foreach (GameObject box in GameObject.FindGameObjectsWithTag("box")) {
			ScoreBox scoreBox = box.GetComponent<ScoreBox> ();
			if (box.transform.position.x < transform.position.x && !scoreBox.counted) {
				scoreBox.counted = true;
				score++;
			}
		}
        (GameLogic.Instance.gameStateManager.currentGS as GameGameState).UpdateScore(score);
	}
	public void Jump(bool rightTime) {
		if (rightTime && isGrounded) {
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce));
			Debug.Log ("pulou");
			GetComponent<Animator> ().SetTrigger ("Jump");

		} 
    }
		
}
