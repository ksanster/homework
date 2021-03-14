using TMPro;
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
    private TMP_Text killedLabel;
    
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
        killedLabel.text = $"Killed {enemyKilled} of {maxEnemyKilled}";
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
        killedLabel.text = $"Killed {enemyKilled} of {maxEnemyKilled}";
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