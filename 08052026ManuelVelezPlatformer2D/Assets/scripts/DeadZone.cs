using UnityEngine;

public class DeadZone : MonoBehaviour
{
   [SerializeField] Transform startposition;
    void OnTriggerEnter2D(Collider2D collision)
    {
     if(collision.CompareTag("Player"))
        {
            Debug.Log("golpea");
            collision.gameObject.transform.position=startposition.position;
        } 

        if(collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }  
    }
}