using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    #region Private
    // Update is called once per frame
    void Update () 
    {
        float horizontalInput = 0;
        float rotateInput = 0;
        float verticalInput = 0;

        if ( isPlayerOne )
        {
            if ( useController )
            {
                horizontalInput = Input.GetAxis( "Horizontal One" );
                verticalInput = Input.GetAxis( "Vertical One" );
                rotateInput = Input.GetAxis( "Rotate Right One" ) + -Input.GetAxis( "Rotate Left One" );
            }
            else
            {
                //Keyboard horizontal movement
                if ( Input.GetKey( KeyCode.A ) )
                {
                    horizontalInput = -1; 
                }
                else if ( Input.GetKey( KeyCode.D ) )
                {
                    horizontalInput = 1;
                }

                if ( Input.GetKey( KeyCode.S ) )
                {
                    verticalInput = -1;
                }
                else if ( Input.GetKey( KeyCode.W ) )
                {
                    verticalInput = 1;
                }

                //Keyboard rotation
                if ( Input.GetKey( KeyCode.Q ) )
                {
                    rotateInput = -1;
                }
                else if ( Input.GetKey( KeyCode.E ) )
                {
                    rotateInput = 1;
                }
            }
        }
        else
        {
            if ( useController )
            {
                horizontalInput = Input.GetAxis( "Horizontal Two" );
                verticalInput = Input.GetAxis( "Vertical Two" );
                rotateInput = Input.GetAxis( "Rotate Right Two" ) + -Input.GetAxis( "Rotate Left Two" );
            }
            else
            {
                //Keyboard horizontal movement
                if ( Input.GetKey( KeyCode.J ) )
                {
                    horizontalInput = -1;
                }
                else if ( Input.GetKey( KeyCode.L ) )
                {
                    horizontalInput = 1;
                }

                if ( Input.GetKey( KeyCode.K ) )
                {
                    verticalInput = -1;
                }
                else if ( Input.GetKey( KeyCode.I ) )
                {
                    verticalInput = 1;
                }

                //Keyboard rotation
                if ( Input.GetKey( KeyCode.U ) )
                {
                    rotateInput = -1;
                }
                else if ( Input.GetKey( KeyCode.O ) )
                {
                    rotateInput = 1;
                }
            }
        }

        transform.Translate( Vector3.right * movementSpeed * Time.deltaTime * horizontalInput );
        transform.Translate( Vector3.forward * movementSpeed * Time.deltaTime * verticalInput );

        transform.RotateAround( transform.position, Vector3.up, Time.deltaTime * rotationSpeed * rotateInput );
    }

    [SerializeField]
    private float rotationSpeed = 50;

    [SerializeField]
    private float movementSpeed = 2;

    [SerializeField]
    private bool isPlayerOne = true;

    [SerializeField]
    private bool useController = false;
    #endregion
}
