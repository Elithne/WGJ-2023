// using System.Collections;
// using System.Collections.Generic;
// using Unity.Mathematics;
// using UnityEngine;
// using UnityEngine.UIElements;

// public class PlayerMovement : MonoBehaviour
// {
//     private Vector3 newPos = new Vector3(0f,0f,0f);

//     [SerializeField] Camera cam;
//     //Animator animator;
//     [SerializeField] float speed = 5.0f;

//     private bool isWalking = false;

//     private void Awake()
//     {
//         //animator = GetComponent<Animator>();
//     }

//     private void Update()
//     {
        
//         if (Input.GetMouseButton(0))
//         {
//             isWalking = true;
//             //animator.Play("Walk");

//             newPos = cam.ScreenToWorldPoint(Input.mousePosition);
//             newPos.y = transform.position.y;
//             newPos.z = transform.position.z;
            
//             // Face walking
//             if (newPos.x > transform.position.x)
//             {
//                 transform.localScale = new Vector3(-0.8f, 0.8f, 1f);
//             }
//             else
//             {
//                 transform.localScale = new Vector3(0.8f, 0.8f, 1f);
//             }

//             transform.position = Vector3.MoveTowards(transform.position, newPos, speed * Time.deltaTime);
                
//         }
//         else
//         {
//             isWalking = false;
//             //animator.Play("Idle");
//         }
//     }
// }
