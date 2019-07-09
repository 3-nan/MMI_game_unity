using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // Score
    public Text scoreText;
    // public Text oldscoreText;

    private Rigidbody rb;
    private float score = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0.0f;
        SetScoreText ();
        // oldscoreText.text = "";
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
        score = score + 0.01f;
        SetScoreText();

    }

    void SetScoreText ()
    {
        scoreText.text = "Score: " + ((int)score).ToString();
    }
}
