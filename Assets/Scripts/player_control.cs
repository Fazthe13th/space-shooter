using UnityEngine;
using System.Collections;
[System.Serializable]
public class Bundary
{
	public float xMin,xMax,zMin,zMax;
}
public class player_control : MonoBehaviour {
	public float speed;
	public float tilt;
	public Bundary bundray;
	public GameObject shot;
	public Transform shots;
	public float firerate;
	private float nextfire = 0.0f;
	void Update()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextfire) 
		{
			nextfire = Time.time + firerate;
			Instantiate (shot, shots.position, shots.rotation);
			GetComponent<AudioSource>().Play();
		}
	}
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		var movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		var rigidbody = GetComponent<Rigidbody> ();
		
		rigidbody.velocity = movement*speed;
		rigidbody.position = new Vector3 (Mathf.Clamp(rigidbody.position.x,bundray.xMin,bundray.xMax), 0.0f, Mathf.Clamp(rigidbody.position.z,bundray.zMin,bundray.zMax));
		rigidbody.rotation = Quaternion.Euler(0.0f,0.0f,rigidbody.velocity.x * -tilt);
	}
}
