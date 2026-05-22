using UnityEngine;
using TMPro;

public class changePoints : MonoBehaviour
{
 public TMP_Text text;
 private GameObject manager;
    void Start()
    {
       
       manager=GameObject.FindGameObjectWithTag("Manager");
    }

    // Update is called once per frame
    void Update()
    {
        text.text=manager.GetComponent<Manager>().defeatedEnemies.ToString();
    }
}
