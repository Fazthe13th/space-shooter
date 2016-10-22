using UnityEngine;
using System.Collections;

public class bolt_move : MonoBehaviour {
	public float speed;
	void Start()
	{
		var rg = GetComponent<Rigidbody> ();
		rg.velocity = transform.forward * speed;
	}
}
