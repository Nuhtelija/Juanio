using UnityEngine;
using System.Collections;

/// <summary>
/// This script controls all functions attached to player. 
/// </summary>
public class PlayerScript : NinjaStarController
{
    /// <summary>
    /// references that player has hes own inventory and can use it
    /// </summary>
    public Inventory inventory;

    public float moveSpeed;
    private float moveVelocity;
    public float jumpHeight;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    private bool doubleJumped;

    private Animator anim;

    public Transform firePoint;
    public GameObject ninjaStar;

    public float shotDelay;
    private float shotDelayCounter;

    private Rigidbody2D myrigidbody2D;

    public bool onLadder;
    public float climbSpeed;
    private float climbVelocity;
    private float gravityStore;
    ///<summary>
    /// Use this for initialization
    ///</summary>
    void Start()
    {
        anim = GetComponent<Animator>();

        myrigidbody2D = GetComponent<Rigidbody2D>();

        gravityStore = myrigidbody2D.gravityScale;

    }

    /// <summary>
    /// Checks is player on ground or not
    /// </summary>
    void FixedUpdate()
    {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

    }

    // Update is called once per frame
    /// <summary>
    /// Gives player jump ability when on ground and double jump ability when on air.
    /// Gives player ability to move
    /// Gives player ability to shoot
    /// Gives player ability to climb ladders
    /// Makes moving platform child of player on collision so player move with the platform.
    /// </summary>
    void Update()
    {

        Debug.Log(climbVelocity);

        if (grounded)
            doubleJumped = false;

        anim.SetBool("Grounded", grounded);

#if UNITY_STANDALONE || UNITY_WEBPLAYER

        if (Input.GetButtonDown("Jump") && grounded)
        {
            Jump();
        }

        if (Input.GetButtonDown("Jump") && !doubleJumped && !grounded)
        {

            Jump();
            doubleJumped = true;
        }

        //moveVelocity = moveSpeed * Input.GetAxisRaw ("Horizontal");



        Move(Input.GetAxisRaw("Horizontal"));

#endif

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
        anim.SetFloat("Speed", (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x)));

        if (GetComponent<Rigidbody2D>().velocity.x > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);

        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);

#if UNITY_STANDALONE || UNITY_WEBPLAYER

        if (Input.GetButtonDown("Fire1"))
        {
            ///<summary>
            //Instantiate (ninjaStar, firePoint.position, firePoint.rotation);
            ///</summary>
            Fire();
            shotDelayCounter = shotDelay;
        }
        if (Input.GetKey(KeyCode.Return))
        {
            shotDelayCounter -= Time.deltaTime;

            if (shotDelayCounter <= 0)
            {
                shotDelayCounter = shotDelay;
                Fire();
                ///<summary>
                ///Instantiate (ninjaStar, firePoint.position, firePoint.rotation);
                ///</summary>

            }
        }




#endif

        if (onLadder)
        {
            myrigidbody2D.gravityScale = 0f;

            climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");

            myrigidbody2D.velocity = new Vector2(myrigidbody2D.velocity.x, climbVelocity);
        }

        if (!onLadder)
        {
            myrigidbody2D.gravityScale = gravityStore;
        }


    }

    public void Move(float moveInput)
    {

        moveVelocity = moveSpeed * moveInput;
    }

    public void MoveLadder(float moveInput)
    {

        climbVelocity = climbSpeed * moveInput;
    }

    public void Fire()
    {
        Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
    }

    public void Jump()
    {
        ///GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x, jumpHeight);

        if (grounded)
        {
            ///<summary>
            ///Jump ();
            ///</summary>
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        }

        if (!doubleJumped && !grounded)
        {
            ///<summary>
            ///Jump ();
            ///</summary>
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            doubleJumped = true;
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.transform.tag == "MovingPlatform")
        {

            transform.parent = other.transform;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {

        if (other.transform.tag == "MovingPlatform")
        {

            transform.parent = null;
        }
    }
    /// <summary>
    /// if object that player collides with is tagged as item it will be added to inventory
    /// </summary>
    /// <param name="other">Other.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Item")
        {
            inventory.AddItem(other.GetComponent<Item>());
        }
    }
}
