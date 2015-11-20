using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Done_Boundary boundary;
	public int playerNumber;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public Vector3 facing;
	private float nextFire;
	public int health = 100;
	
	void Update ()
	{
		if (Input.GetButton("Fire" + playerNumber) && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play ();
		}
	}


	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal" + playerNumber);
		float moveVertical = Input.GetAxis ("Vertical" + playerNumber);
		//facing = GetComponent<
		//Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		//GetComponent<Rigidbody>().velocity = movement * speed;

		transform.position += transform.forward * Time.deltaTime * speed * moveVertical;

		transform.Rotate (Vector3.up, Time.deltaTime * moveHorizontal*100);

		GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);
		
		//GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}
