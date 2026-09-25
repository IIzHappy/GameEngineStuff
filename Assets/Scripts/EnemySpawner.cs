using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    
    public void SpawnEnemy(Enemy enemy, Transform position)
    {
        
    }
}
