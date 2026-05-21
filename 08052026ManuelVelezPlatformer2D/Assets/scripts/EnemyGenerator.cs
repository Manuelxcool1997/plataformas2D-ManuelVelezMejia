using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
     [SerializeField] Transform target;
    [SerializeField] GameObject enemyPrefab;
     [SerializeField] float TimeBetweenEnemies=4f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(GenerateEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GenerateEnemies()
    {
       while(true)
        {
            yield return new WaitForSeconds(TimeBetweenEnemies);
           GameObject newEnemy= Instantiate(enemyPrefab,transform.position,Quaternion.identity);
           newEnemy.GetComponent<AiControl>().SetTarget(target);
        }
    }
}
