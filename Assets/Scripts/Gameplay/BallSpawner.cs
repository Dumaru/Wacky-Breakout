using UnityEngine.Events;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{

    private Timer spawnTimer;
    [SerializeField]
    private GameObject ballPrefab;
    private bool retrySpawn = false;
    private Vector2 lowerLeftCorner;
    private Vector2 upperRightCorner;


    private void Start()
    {
        spawnTimer = this.gameObject.AddComponent<Timer>();
        spawnTimer.Duration = GetSpawnDelay();
        spawnTimer.AddTimerFinishedListener(HandleSpawnTimerFinished);
        spawnTimer.Run();

        GameObject tempBal = Instantiate(ballPrefab);
        BoxCollider2D coll = tempBal.GetComponent<BoxCollider2D>();
        this.lowerLeftCorner = coll.bounds.min;
        this.upperRightCorner = coll.bounds.max;

        EventManager.AddReducedBallsListener(SpawnBall);
        EventManager.AddDeathdBallsListener(SpawnBall);

    }


    void Update()
    {
        if (retrySpawn)
        {
            SpawnBall(0);
        }
        if (spawnTimer.Finished)
        {
            HandleSpawnTimerFinished();
        }
    }

    void HandleSpawnTimerFinished()
    {
        SpawnBall(0);
        spawnTimer.Duration = GetSpawnDelay();
        spawnTimer.Run();

    }

    private float GetSpawnDelay()
    {
        return Random.Range(ConfigurationUtils.MinSpawnTime, ConfigurationUtils.MaxSpawnTime);
    }

    private void SpawnBall(int notUsed)
    {

        if (Physics2D.OverlapArea(this.lowerLeftCorner, this.upperRightCorner) != null)
        {
            this.retrySpawn = true;
        }
        else
        {
            Instantiate(ballPrefab);
            this.retrySpawn = false;
        }
    }
}