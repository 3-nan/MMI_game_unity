using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehavior : MonoBehaviour
{
	public GameObject box;
	public static bool enable = false;
	
	//if (Input.GetKey (KeyCode.A)) {
	//	print("You pressed the A Key");
	//}

    	// Update is called once per frame
    	void Update()
   	{
 		if(enable)
			box.SetActive(true);
		else
			box.SetActive(false);
	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

}
