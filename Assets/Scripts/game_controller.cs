using UnityEngine;
using System.Collections;

public class game_controller : MonoBehaviour {
	public GameObject hazard;
	public Vector3 spwnvalue;
	public int hazardcount;
	public float spwnwait;
	public float startwait;
	public float wavewait;
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameoverText;
	private bool restart;
	private bool gameover;
	private int score;

	void Start ()
	{
		gameover = false;
		score = 0;
		restart = false;
		restartText.text = " ";
		gameoverText.text = " ";
		StartCoroutine(Spwn ());
	}
	void Update()
	{
		if (restart) {
			if(Input.GetKey(KeyCode.R)){

				Application.LoadLevel(Application.loadedLevel);}
		}
	}
	IEnumerator Spwn()
	{
		yield return new WaitForSeconds(startwait);
		while (true) {
			for (int i = 0; i<hazardcount; i++) {
				Vector3 spwnPosition = new Vector3 (Random.Range (-spwnvalue.x, spwnvalue.x), spwnvalue.y, spwnvalue.z);
				Quaternion spwnRotation = Quaternion.identity;
				Instantiate (hazard, spwnPosition, spwnRotation);
				yield return new WaitForSeconds (spwnwait);
			}
			yield return new WaitForSeconds (wavewait);
			if(gameover)
			{
				restartText.text = "Press 'R' to restart";
				restart=true;
				break;
			}
		}
	}
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}
	public void GameOver()
	{
		gameoverText.text = "Game over!\n Created by Evan & Faisal";
		gameover = true;
	}

}
