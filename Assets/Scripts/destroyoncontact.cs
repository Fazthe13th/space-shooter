using UnityEngine;
using System.Collections;

public class destroyoncontact : MonoBehaviour {
	public GameObject explosion;
	public GameObject explosion_player;
	public int scoreValue;
	private game_controller gameController;
	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <game_controller>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary")
			return;
		if (other.tag == "Player")
		{
			Instantiate(explosion_player, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		}
		Instantiate (explosion, transform.position, transform.rotation);
		gameController.AddScore(scoreValue);
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
