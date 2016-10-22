using UnityEngine;
using System.Collections;

public class destroy_after_time : MonoBehaviour {
	public float time;
	void Start ()
	{
		Destroy (gameObject, time);
	}
	

}
