﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public float threshold;
 
     void FixedUpdate () {
         if (transform.position.y < threshold) {
             transform.position = new Vector3(-5.5f, 2, -2);
	     BoxBehavior.enable = false;
	 }
     }
}
