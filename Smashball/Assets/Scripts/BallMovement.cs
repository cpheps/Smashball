using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		mRigidbody = GetComponent<Rigidbody>();
		mRigidbody.AddForce( Vector3.forward * 2 );
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		mRigidbody.AddForce( mRigidbody.velocity.normalized * 2 ); 
		mRigidbody.velocity = Vector3.ClampMagnitude( mRigidbody.velocity, 20 );
	}

	private Rigidbody mRigidbody = null;

	[SerializeField]
	private float mMaxVelocity = 25;
}
