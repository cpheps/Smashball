using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey(KeyCode.A))
		{
			transform.Translate( Vector2.right * -movementSpeed * Time.deltaTime );
		}
		else if (Input.GetKey(KeyCode.D))
		{
			transform.Translate( Vector2.right * movementSpeed * Time.deltaTime );
		}

		if (Input.GetKey(KeyCode.Q))
		{
			transform.RotateAround( transform.position, Vector3.up, Time.deltaTime * -rotationSpeed );  
		}
		else if (Input.GetKey(KeyCode.E))
		{
			transform.RotateAround( transform.position, Vector3.up, Time.deltaTime * rotationSpeed );  
		}
	}

	[SerializeField]
	private float rotationSpeed = 50;

	[SerializeField]
	private float movementSpeed = 2;
}
