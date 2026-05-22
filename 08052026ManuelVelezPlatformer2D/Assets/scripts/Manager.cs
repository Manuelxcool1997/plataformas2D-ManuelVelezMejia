using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class Manager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int defeatedEnemies;
    [SerializeField] private GameObject backgroundPause;
[SerializeField] private GameObject buttonExit;
[SerializeField] private GameObject buttonContinue;
[SerializeField] private GameObject textpoints;
[SerializeField] private GameObject resultpoints;
[SerializeField] private GameObject buttomreset;

   [SerializeField] private InputActionReference pause;
  
  


   private GameObject[] gameObjects;


 
public bool change=false;



   

    void Awake()
    {
          
    }

   private void OnEnable()
    {
        pause.action.started +=Onshoot;
        pause.action.Enable();
    }

    private void OnDisable()
    {
        pause.action.started -=Onshoot;
       pause.action.Disable();
    }

    void Update()
    {
        
        if(change)
        {
            backgroundPause.SetActive(true);
            buttonContinue.SetActive(true);
            buttonExit.SetActive(true);
            buttomreset.SetActive(true);
            textpoints.SetActive(false);
            resultpoints.SetActive(false);
        
            Time.timeScale = 0f;
        }
        else
        {
                 backgroundPause.SetActive(false);
            buttonContinue.SetActive(false);
            buttonExit.SetActive(false);
            buttomreset.SetActive(false);
            textpoints.SetActive(true);
            resultpoints.SetActive(true);
          
            Time.timeScale = 1f; 
        }
        }
       
    

    
    private void Pause()
    {
        
       change=!change; 
        
    }
  private void Onshoot(InputAction.CallbackContext context)
    {
       Pause(); 
    }
   public void Continue()
    {
        change=false;
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void ReSet()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    

}
