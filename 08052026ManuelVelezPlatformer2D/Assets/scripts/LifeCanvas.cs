using UnityEngine;
using UnityEngine.UI;

public class LifeCanvas : MonoBehaviour
{
  [SerializeField] Life life;
   [SerializeField] Image mask;
  private void OnEnable()
    {
        life.OnLifeChanged.AddListener(OnLifeChanged);
        life.OnLifeDepleted.AddListener(OnLifeDepleted);
    }
    private void OnDisable()
    {
         life.OnLifeChanged.RemoveListener(OnLifeChanged);
        life.OnLifeDepleted.RemoveListener(OnLifeDepleted);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnLifeChanged(float currentLife,float startLife)
    {
        mask.fillAmount=currentLife/startLife;
    }
    private void OnLifeDepleted(float startLife)
    {
        
    }
}
