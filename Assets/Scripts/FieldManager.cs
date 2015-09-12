using UnityEngine;
using System.Collections;

public class FieldManager : MonoBehaviour {
    #region Public
    /// <summary>
    /// Singleton variable
    /// </summary>
    public static FieldManager Instance { get; private set; }

    /// <summary>
    /// When a goal is scored it resets the field to starting state
    /// </summary>
    public void resetField()
    {
        //Reset the ball
        ball.transform.SendMessage( "resetBall" );

        //Reset the players
        playerOne.position = playerOneStart;
        playerOne.rotation = Quaternion.identity;

        playerTwo.position = playerTwoStart;
        playerTwo.rotation = Quaternion.identity;
    }
    #endregion

    #region Private
    void Awake()
    {
        if ( Instance == null )
        {
            Instance = this;
            DontDestroyOnLoad( this );

            playerOne = GameObject.FindGameObjectWithTag( "Player One" ).transform;
            playerTwo = GameObject.FindGameObjectWithTag( "Player Two" ).transform;

            playerOneStart = GameObject.FindGameObjectWithTag( "Player One Start" ).transform.position;
            playerTwoStart = GameObject.FindGameObjectWithTag( "Player Two Start" ).transform.position;

            ball = GameObject.FindGameObjectWithTag( "Ball" );
        }
        else if ( Instance != this )
        {
            Destroy( this );
        }
    }

    // Use this for initialization
    void Start ()
    {
        ball.transform.SendMessage( "resetBall" );
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Check if ball is still in play
        if ( ( ( ball.transform.position.y < -1 ) || ( ball.transform.position.y > 12 ) ) )
        {
            ball.transform.SendMessage( "resetBall" );
        }
    }

    #region Players
    /// <summary>
    /// Reference to player one
    /// </summary>
    private Transform playerOne = null;

    /// <summary>
    /// Reference to player one
    /// </summary>
    private Transform playerTwo = null;
    #endregion

    /// <summary>
    /// Player one starting position
    /// </summary>
    private Vector3 playerOneStart = Vector3.zero;

    /// <summary>
    /// Player two starting position
    /// </summary>
    private Vector3 playerTwoStart = Vector3.zero;

    /// <summary>
    /// Reference to ball
    /// </summary>
    private GameObject ball = null;
    #endregion
}
