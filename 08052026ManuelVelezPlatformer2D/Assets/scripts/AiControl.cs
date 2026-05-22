using UnityEngine;

public class AiControl : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float attackDistance=2f;
    Charactercontroller2D charactercontroller2D;
    HurtCollider hurtCollider;
    private GameObject manager;
    
    void Awake()
    {
        charactercontroller2D=GetComponent<Charactercontroller2D>();
        hurtCollider=GetComponent<HurtCollider>();
        manager=GameObject.FindGameObjectWithTag("Manager");
    }
    private void Update()
    {
        Vector2 rawMove= Vector2.zero;
        if(target)
        {
            if(transform.position.x>target.position.x)
            {
                rawMove=Vector2.left;
            }
            else
            {
                rawMove=Vector2.right;
            }
        }
        charactercontroller2D.SetRawmove(rawMove);
        if(Mathf.Abs(target.transform.position.x-transform.position.x)< attackDistance)
        {
            rawMove=Vector2.zero;
            charactercontroller2D.Punch();
        }
     
    
    }
       public void SetTarget(Transform target)
    {
        this.target=target;
    }
    private void OnEnable()
    {
         hurtCollider.OnHitReicive.AddListener(OnHitReicive);
    }
     private void OnDisable()
    {
         hurtCollider.OnHitReicive.RemoveListener(OnHitReicive);
    }
    private void OnHitReicive()
    {
        manager.GetComponent<Manager>().defeatedEnemies++;
        Debug.Log(manager.GetComponent<Manager>().defeatedEnemies.ToString());
        Destroy(gameObject);
    }
    
        
    
}
