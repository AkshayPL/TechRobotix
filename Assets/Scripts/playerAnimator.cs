using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimator : MonoBehaviour
{
    private Camera m_camera; //variable to hold sceneCamera
    Ray ray; //physics ray
    RaycastHit hit; //to detect collision between the ray's end point and the collided object
    
    private void Update()
    {
        if (m_camera==null) // when jumping to next scene camera is destroyed, re-assign new camera
        {
            Awake();
        }
        ray = m_camera.ScreenPointToRay(Input.mousePosition); //raycasting from point of click
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0)) //true when raycast collides and user clicks
        {
            Transform objectHit = hit.transform; //storing collided objects transform in a private transfor "objectHit"
            if (objectHit.name == "Dizzy Idle")
            {
                //assign random integer value to the parameter randomAnim in animator controller to change state
                objectHit.GetComponent<Animator>().SetInteger("randomAnim", Random.Range(1, 4)); 
            }
        }
    }
    private void Awake()
    {
       
            m_camera = Camera.main; //storing the main camera in our camera variable
       
    }
}
