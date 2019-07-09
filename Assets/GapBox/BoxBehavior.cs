using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehavior : MonoBehaviour
{
public GameObject box;
public static bool codePressed;
Camera cam;

// Start is called before the first frame update
void Start()
{
								cam = Camera.main;
}

// Update is called once per frame
void Update()
{
								Vector3 viewPos = cam.WorldToViewportPoint(box.transform.position);
								if (viewPos.x >= 0F && viewPos.x <= 1F) {
																if (box.activeSelf) {
																								box.SetActive(true);
																}

																if (codePressed && !box.activeSelf) {
																								box.SetActive(true);
																}
								} else {
																box.SetActive(false);
								}
}
}
