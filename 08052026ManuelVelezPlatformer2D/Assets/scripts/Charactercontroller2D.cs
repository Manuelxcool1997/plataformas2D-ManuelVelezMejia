using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D))]
public class Charactercontroller2D : MonoBehaviour
{
    Rigidbody2D rb2D;
     [Header("Movement settings")]
     public float movementSpeed =3f;
      public float jumpSpeed =3f;
      const float moveTreshold=0.1f;
     Animator animator;
     bool isInLadder=false;
     SpriteRenderer spriteRenderer;
[Header("combat")]
[SerializeField] Transform hitleft;
[SerializeField] Transform hitRight;
const float DeactivatehitDelay=0.25f;

    void Awake()
    {
        animator=GetComponent<Animator>();
        rb2D=GetComponent<Rigidbody2D>();
        spriteRenderer=GetComponent<SpriteRenderer>();
       hitleft.gameObject.SetActive(false);
       hitRight.gameObject.SetActive(false);
    }

   
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInLadder==false)
        {
             rb2D.gravityScale=1; 
        rb2D.linearVelocityX=rawMove.x * movementSpeed;
        bool isMoving=Mathf.Abs(rawMove.x)>moveTreshold;
           animator.SetBool("isRunning",isMoving);

           if(isMoving)
        {
            spriteRenderer.flipX=rawMove.x<0f;
        } 
        animator.SetBool("isGrounded",isGrounded());
        }
        else
        {
           rb2D.linearVelocityX=rawMove.x * movementSpeed;
           rb2D.linearVelocityY=rawMove.y * movementSpeed;
           rb2D.gravityScale=0; 
            animator.SetBool("isGrounded",false);
        }
    }
        [Header("GroundCheck")]
        [SerializeField] float groundCheckDistance=0.2f;
         [SerializeField] LayerMask groundLayerMask=Physics2D.DefaultRaycastLayers;
        bool isGrounded()
{
        RaycastHit2D hit=Physics2D.Raycast(transform.position, Vector2.down,groundCheckDistance,groundLayerMask);
        return hit && hit.collider !=null;
    }
    Vector2 rawMove;
    public void SetRawmove(Vector2 rawMove)
    {
        this.rawMove=rawMove;
    }

public void Jump()
    {
        if(isGrounded())
        {
        rb2D.linearVelocityY=jumpSpeed;
        }
    }
    
    public void Punch()
    {
        animator.SetTrigger("Punch");
        OnAnimationPunch();
    }

    public void OnAnimationPunch()
    {
        if(spriteRenderer.flipX)
        {
            hitleft.gameObject.SetActive(true);
            Invoke(nameof(DeactivateHits),DeactivatehitDelay);
        }
        else
        {
            hitRight.gameObject.SetActive(true);
            Invoke(nameof(DeactivateHits),DeactivatehitDelay);
        }
    }

    void DeactivateHits()
    {
         hitleft.gameObject.SetActive(false);
       hitRight.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            isInLadder=true;
        }
    }

     void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            isInLadder=false;
        }
    }
      void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            isInLadder=true;
        }
    }
}
