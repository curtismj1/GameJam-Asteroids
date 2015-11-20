using UnityEngine;
using System.Collections;

public class Done_DestroyByBoundary : MonoBehaviour
{
	void OnTriggerExit (Collider other) 
	{
		if (other.GetComponent<Done_PlayerController> ()) {
			other.GetComponent<Done_PlayerController>().health -= 10;
		}
	}
}