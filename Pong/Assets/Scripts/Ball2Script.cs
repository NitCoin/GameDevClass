using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Ball2Script : MonoBehaviour 
	{
		public float speed = 30; 
		public int player1Score; 
		public int player2Score; 
		public Text P1Score; 
		public Text P2Score; 
		public Transform Ball; 
		public Text Player1Wins; 
		public Text Player2Wins; 
		
		void Start () 
		{
			GetComponent<Rigidbody2D> ().velocity = Vector2.right * speed; 
			//P1Score = GetComponent<Text> (); 
			//P2Score = GetComponent<Text> (); 
		}
		
		void OnCollisionEnter2D(Collision2D col)
		{
			if (col.gameObject.name == "RacketPlayer 1") 
			{
				float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y); 
				Vector2 dir = new Vector2(1,y).normalized; 
				
				GetComponent<Rigidbody2D>().velocity = dir * speed; 
			}
			
			if (col.gameObject.name == "RacketPlayer 2") 
			{
				float y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y); 
				Vector2 dir = new Vector2(-1,y).normalized; 
				
				GetComponent<Rigidbody2D>().velocity = dir * speed; 
			}
			
			if (col.gameObject.name == "WallLeft") 
			{
				player2Score++;
				P2Score.text = player2Score.ToString();
				Instantiate(Ball, new Vector3(7, 6, 0), Quaternion.identity);
				Destroy(gameObject); 
				//ResetGame();
				
				
			}
			
			if (col.gameObject.name == "WallRight") 
			{
				player1Score++; 
				P1Score.text = player1Score.ToString();
				Instantiate(Ball, new Vector3(7, 6, 0), Quaternion.identity);
				Destroy(gameObject); 
				//ResetGame();
			}
			
			
		}
		
		
		float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
		{
			return (ballPos.y - racketPos.y) / racketHeight; 
		}

	void Update()
	{
		if (player1Score == 5) {
			Player1Wins.text = "Player 1 Wins!"; 
		}
		if (player2Score == 5) {
			Player2Wins.text = "Player 2 Wins!"; 
		}

		if (player1Score == 5 || player2Score == 5) 
		{
			Destroy(gameObject); 
		}
	}
		
		/* void ResetGame()
	{
		//yield WaitForSeconds (1);
		Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
		clone.velocity = transform.TransformDirection(Vector3.forward * 10);

		GetComponent<Rigidbody2D> ().velocity = Vector2.right * speed; 


	}

	*/
		
		
	}
