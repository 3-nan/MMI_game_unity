using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAdding : MonoBehaviour
{
private KeyCode[] sequence = new KeyCode[] {
        KeyCode.B,
        KeyCode.O,
        KeyCode.X
};
private int sequenceIndex;

// Update is called once per frame
void Update()
{
        if (Input.GetKeyDown(sequence[sequenceIndex])) {
                if (++sequenceIndex == sequence.Length) {
                        sequenceIndex = 0;
                        BoxBehavior.codePressed = true;
                }
        } else if (Input.anyKeyDown)
        {
                sequenceIndex = 0;
                BoxBehavior.codePressed = false;
        }
}
}
