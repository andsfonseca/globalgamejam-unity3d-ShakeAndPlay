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
	public Text scoreText;
	// Use this for initialization
	void Start () {
		isGrounded = false;

	}
	
	// Update is called once per frame
	void Update () {		
		move ();
		checkGround ();
		checkWave ();
		checkScore ();
	}
	private void move(){
		transform.Translate (speed*Time.deltaTime, 0, 0);
		if(isGrounded && Input.GetButtonDown("Jump")){
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
			Debug.Log ("pulou");
		}
	}
	private void checkWave(){
		wavePosition = GameObject.FindGameObjectWithTag ("wave").transform.position;
		if (Mathf.Abs(transform.position.x - wavePosition.x) < 2.2f) {
			Debug.Log ("morreu");
		}
	}
	private void checkGround(){
		if (transform.position.y < -1.4f) {
			isGrounded = true;
		} else {
			isGrounded = false;
		}
	}
	private void checkScore(){
		foreach (GameObject box in GameObject.FindGameObjectsWithTag("box")) {
			ScoreBox scoreBox = box.GetComponent<ScoreBox> ();
			if (box.transform.position.x < transform.position.x && !scoreBox.counted) {
				scoreBox.counted = true;
				score++;
			}
		}
		scoreText.text = (""+score);
	}
}
