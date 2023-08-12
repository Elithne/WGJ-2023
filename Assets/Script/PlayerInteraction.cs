using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float speed = 10.0f;
    private Vector3 targetPosition;
        
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = transform.position.z;            
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player collided with " + other.gameObject.name);
    }

}
