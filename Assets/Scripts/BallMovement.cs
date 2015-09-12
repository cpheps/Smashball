using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {

    #region Public
    /// <summary>
    /// Resets the ball in the event of a goal
    /// </summary>
    public void resetBall()
    {
        if ( !mBallNeedRest )
        {
            mBallNeedRest = true;
            StartCoroutine( launchBall() );
        }
    }
    #endregion
    #region Private
    // Use this for initialization
    void Awake () 
    {
        mRigidbody = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void FixedUpdate () 
    {
        if ( !mBallNeedRest )
        {
            mRigidbody.AddForce( mRigidbody.velocity.normalized * 2 );
            mRigidbody.velocity = Vector3.ClampMagnitude( mRigidbody.velocity, 20 );
        }
    }

    /// <summary>
    /// Does initial ball setup for launch
    /// </summary>
    /// <returns></returns>
    private IEnumerator launchBall()
    {
        //Stop ball from moving
        mRigidbody.velocity = Vector3.zero;

        //Move to starting points
        transform.position = new Vector3( 0, 0.3f, 0 );

        //Add Random torque
        mRigidbody.AddTorque( Vector3.up * Random.Range( 0, 10 ) );

        //Wait random amount of time before launch
        yield return new WaitForSeconds( Random.Range( 0.5f, 1.5f ) );

        //Add luanch force
        mRigidbody.AddForce( transform.forward * 1000 );

        mBallNeedRest = false;
    }

    private Rigidbody mRigidbody = null;

    [SerializeField]
    private float mMaxVelocity = 25;

    private bool mBallNeedRest = false;
    #endregion
}
