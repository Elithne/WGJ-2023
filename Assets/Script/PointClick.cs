// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PointClick : MonoBehaviour
// {
//     // Referencia a la camara
//     private Camera cam;

//     [SerializeField] float speed;
//     [SerializeField] float minDistanceInteractive = 2f;



//     void Start()
//     {
//         // Obtiene el componente
//         cam = Camera.main;
//     }

//     void Update()
//     {
//         PlayerClick();
//     }

//     void PlayerClick()
//     {
//         // Si se clickea el mouse
//         if (Input.GetMouseButtonDown(0))
//         {
//             // Crea un ray desde la posición del mouse
//             Ray ray = cam.ScreenPointToRay(Input.mousePosition);

//             // Usa Physics2D.Raycast para detectar objetos en escena
//             RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

//             // Detectacta si el Raycast toca un objeto
//             if (hit.collider != null)
//             {
//                 // Hace algo con el objeto alcanzado
//                 // hit.collider.gameObject.SendMessage("OnClick");                
//             }
//         }
//     }
// }