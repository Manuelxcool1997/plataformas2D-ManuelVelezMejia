using System;
using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    [SerializeField] float Startlife=1f;
     [SerializeField] float damagePerHit=0.25f;
   public float currentlife;
    HurtCollider hurtCollider;

    public UnityEvent <float,float> OnLifeChanged;
    public UnityEvent <float> OnLifeDepleted;
    [SerializeField] bool debugReiciveDamage;
    private void OnValidate()
    {
        if(debugReiciveDamage)
        {
            debugReiciveDamage=false;
            OnHitReicive();
        }
    }

    void Awake()
    {
         hurtCollider=GetComponent<HurtCollider>();
       
        currentlife=Startlife;
    }// Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
         hurtCollider.OnHitReicive.AddListener(OnHitReicive);
    }
    private void OnDisable()
    {
         hurtCollider.OnHitReicive.RemoveListener(OnHitReicive);
    }
    void Start()
    {
      
    }
void OnHitReicive()
    {
        if(currentlife>0)
        {
        currentlife-=damagePerHit;
        OnLifeChanged.Invoke(currentlife,Startlife);
        if(currentlife<=0)
            {
                currentlife=0;
                OnLifeDepleted.Invoke(Startlife);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    internal void Restart()
    {
        currentlife=Startlife;
          OnLifeChanged.Invoke(currentlife,Startlife);
    }
}
