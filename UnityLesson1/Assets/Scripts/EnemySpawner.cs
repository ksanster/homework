using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private PathConfig[] paths;
    
    [SerializeField]
    private Ghost enemyPrefab;
    
    [SerializeField]
    private float spawnTimeInSeconds = 1f;
    
    private bool isActive = true;
    
    public void Stop()
    {
        isActive = false;
    }
    
    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (isActive)
        {
            yield return new WaitForSeconds(spawnTimeInSeconds);
        
            var path = paths[Random.Range(0, paths.Length)];
            var enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemy.gameObject.name = Ghost.GhostName;
            enemy.waypoints = path.Waypoints;
            enemy.navMeshAgent.speed = Random.Range(2f, 3f);
            enemy.StartMove();
        }
    }

    void Update()
    {
        
    }
}
