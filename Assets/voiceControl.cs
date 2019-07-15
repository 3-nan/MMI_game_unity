using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Text;

using System.Linq;
using System;
using System.Collections;
using UnityEngine.Windows.Speech;


public class voiceControl : MonoBehaviour
{
    // Voice command vars
    private Dictionary<string, Action> keyActs = new Dictionary<string, Action>();
    private KeywordRecognizer recognizer;

    public float runSpeed = 200f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    bool keyboardInterrupt = false;

    private float m_xVelocity;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting...");
        //keyActs.Add("jump", Jump);
        keyActs.Add("box", Box);
        //keyActs.Add("crouch", Crouch);
        keyActs.Add("left", Left);
        keyActs.Add("right", Right);
        recognizer = new KeywordRecognizer(keyActs.Keys.ToArray(), ConfidenceLevel.Low);
        recognizer.OnPhraseRecognized += OnKeywordsRecognized;
        recognizer.Start();
    }


    void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Command: " + args.text);
        keyActs[args.text].Invoke();
    }

    void Update()
    {
        Rigidbody2D player = GetComponent<Rigidbody2D>();

        if (Input.GetButtonDown("Horizontal"))
        {
            Debug.Log("Keyboard left or right pressed");
            m_xVelocity = 0f;
            return;
        }

        player.AddForce(new Vector2(m_xVelocity, 0f));
    }


    /*
    void Jump()
    {
        Debug.Log("Jump...");
        jump = true;
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        // playerMovement.FixedUpdate();
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    void Crouch()
    {
        Debug.Log("Crouch...");
        crouch = false;
    }

    */

    void Left()
    {
        Debug.Log("Left...");
        m_xVelocity = -1 * runSpeed;
        FlipPlayer("left");
    }

    void Right()

    {
        Debug.Log("Right...");
        m_xVelocity = runSpeed;
        FlipPlayer("right");
    }

    void FlipPlayer(string xAxis)
    {
        Vector3 localScale = transform.localScale;
        if (xAxis.Equals("left") && localScale.x > 0)
        {
            localScale.x *= -1;
        } else if (xAxis.Equals("right") && localScale.x < 0)
        {
            localScale.x *= -1;
        }

        transform.localScale = localScale;
    }

    void Box()
    {
        Debug.Log("Box...");
        BoxBehavior.codePressed = true;
    }
}