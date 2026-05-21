using UnityEngine;
using UnityEngine.Events;
public class HurtCollider : MonoBehaviour
{
    public UnityEvent OnHitReicive;
    internal void Notifyhit(HitCollider hitCollider)
    {
        Debug.Log("invoke");
        OnHitReicive.Invoke();
    }
  
}
