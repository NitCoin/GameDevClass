using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewBallScript : MonoBehaviour 
{
	public float speed = 30; 
	public int player1Score = 0; 
	public int player2Score = 0; 
	public Text P1Score; 
	public Text P2Score; 
	public Vector2 InitPosition; 
	public Text Player1Wins; 
	public Text Player2Wins;
	public Rigidbody2D BallRB; 
	public float SpeedIncRate = .25f; 
	public Vector2 RandomStart; 
	public Text GameTo5; 



	void Start () 
	{
		//GetComponent<Rigidbody2D> ().velocity = Vector2.right * speed; 
		RandomStart = Random.insideUnitCircle.normalized;
		GetComponent<Rigidbody2D> ().velocity = RandomStart * speed; 

		P1Score.text = "0"; 
		P2Score.text = "0"; 
		Player1Wins.text = "";
		Player2Wins.text = ""; 
		InitPosition = this.transform.position; 
		BallRB = GetComponent<Rigidbody2D> ();
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == "RacketPlayer 1") 
		{
			float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y); 
			Vector2 dir = new Vector2(1,y).normalized; 
			
			GetComponent<Rigidbody2D>().velocity = dir * speed; 
			//speed++;
		}
		
		if (col.gameObject.name == "RacketPlayer 2") 
		{
			float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y); 
			Vector2 dir = new Vector2(-1,y).normalized; 
			
			GetComponent<Rigidbody2D>().velocity = dir * speed; 
			//speed++;


		}
		
		if (col.gameObject.name == "WallLeft") 
		{
			player2Score++;
			P2Score.text = player2Score.ToString();
			//ResetBall();
			   
			
		}
		
		if (col.gameObject.name == "WallRight") 
		{
			player1Score++; 
			P1Score.text = player1Score.ToString();
			//ResetBall();
			  

		}
		
		
	}
	
	
	float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
	{
		return (ballPos.y - racketPos.y) / racketHeight; 
	}

	
	void Update ()
	{
	
		if (player1Score == 5) 
		{
			GameTo5.text = ""; 
			Player1Wins.text = "Player 1 Wins!";
			Destroy(gameObject);
		}
		if (player2Score == 5) 
		{
			GameTo5.text = ""; 
			Player2Wins.text = "Player 2 Wins!"; 
			Destroy(gameObject);

		}

		speed += Time.deltaTime*SpeedIncRate;


	}

	void ResetBall()
	{
		speed = 0; 
		BallRB.velocity = new Vector2(0,0); 
		//BallRB.MovePosition(InitPosition); 

		//BallRB.velocity = Vector2.right * 0; 


	}
}
