using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController Instance => instance;
    
    [SerializeField]
    private int maxEnemyKilled;
    [SerializeField]
    private EnemySpawner spawner;
    
    [SerializeField]
    private GameObject winBackgroundImage;
    [SerializeField]
    private AudioSource winAudio;
    [SerializeField]
    private GameObject caughtBackgroundImage;
    [SerializeField]
    private AudioSource caughtAudio;
    
    
    private int enemyKilled;

    private void Awake()
    {
        instance = this;
    }
    
    private void StopGame(bool loose)
    {
        spawner.Stop();
        if (loose)
        {
            caughtAudio.Play();
            caughtBackgroundImage.SetActive(true);
        }
        else
        {
            winAudio.Play();
            winBackgroundImage.SetActive(true);
        }
        
        Application.Quit();
    }
    
    public void KillEnemy()
    {
        enemyKilled++;
        Debug.Log($"Killed {enemyKilled} of {maxEnemyKilled}");
        if (enemyKilled >= maxEnemyKilled)
            StopGame(false);
    }
    
    public void KillPlayer()
    {
        StopGame(true);
    }
    
    public void SecretFound()
    {
        
    }
    
    
    
}