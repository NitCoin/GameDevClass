using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public int player1Score = 0; 
	public int player2Score = 0; 
	public Text P1Score; 
	public Text P2Score; 
	public GameObject ball; 

	// Use this for initialization
	void Start ()
	{

		P1Score.text = "0"; 
		P2Score.text = "0"; 
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	


	}

	void OnCollisionEnter2D(Collision2D col)
	{
		//ball = gameObject.GetComponent<BallMovement> (); 

		if (col.gameObject.name == "WallLeft") {
			player2Score++;
			P2Score.text = player2Score.ToString ();
			//Instantiate(Ball, new Vector3(7, 6, 0), Quaternion.identity);
			Destroy (gameObject); 
			//ResetGame();
			
			
		}
		
		if (col.gameObject.name == "WallRight") {
			player1Score++; 
			P1Score.text = player1Score.ToString ();
			//Instantiate (Ball, new Vector3 (7, 6, 0), Quaternion.identity);
			Destroy (gameObject); 
			//ResetGame();
		}

	}
}
