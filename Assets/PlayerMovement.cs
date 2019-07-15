using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 200f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    private Vector3 m_Velocity = Vector3.zero;
    private Rigidbody2D player;


    // Score
    //public Text scoreText;
    //public Text oldscoreText;

    private Rigidbody rb;
    //private float score = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //score = 0.0f;
    //    SetScoreText ();
       // oldscoreText.text = "";
    }

    void Awake()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetBool("IsCrouching", crouch);

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            // ... flip the player.
            FlipPlayer("right");
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            // ... flip the player.
            FlipPlayer("left");
        }
    }

    public void OnCrouching (bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate ()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    //    score = score + 0.01f;
    //    SetScoreText();

    }

    //void SetScoreText ()
    //{
    //    scoreText.text = "Score: " + ((int)score).ToString();
    //}

    public void FlipPlayer(string xAxis)
    {
        Vector3 localScale = transform.localScale;
        if (xAxis.Equals("left") && localScale.x > 0)
        {
            localScale.x *= -1;
        }
        else if (xAxis.Equals("right") && localScale.x < 0)
        {
            localScale.x *= -1;
        }

        transform.localScale = localScale;
    }
}
