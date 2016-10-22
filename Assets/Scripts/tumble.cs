using UnityEngine;
using System.Collections;

public class tumble : MonoBehaviour {

	public float tum;
	void Start()
	{
		var astroid = GetComponent<Rigidbody> ();
		astroid.angularVelocity = Random.insideUnitSphere * tum;
	}

}
