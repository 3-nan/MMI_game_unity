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

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting...");
        keyActs.Add("red", Red);
        keyActs.Add("green", Green);
        keyActs.Add("blue", Blue);
        keyActs.Add("box", Box);
        recognizer = new KeywordRecognizer(keyActs.Keys.ToArray());
        recognizer.OnPhraseRecognized += OnKeywordsRecognized;
        recognizer.Start();
    }

    void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Command: " + args.text);
        keyActs[args.text].Invoke();
    }

    void Red()
    {
        Debug.Log("Red...");
    }
    void Green()
    {
        Debug.Log("Green...");
    }
    void Blue()
    {
        Debug.Log("Blue...");
    }

    void Box()
    {
        Debug.Log("Box...");
        BoxBehavior.codePressed = true;
    }
}