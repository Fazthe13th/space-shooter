using UnityEngine;
using System.Collections;

public class object_destroy : MonoBehaviour {

	void OnTriggerExit(Collider clone)
	{
		Destroy (clone.gameObject);
	}
}
