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
        this.spawnTimer = this.gameObject.AddComponent<Timer>();
        this.spawnTimer.Duration = GetSpawnDelay();
        this.spawnTimer.Run();

        GameObject tempBal = Instantiate(ballPrefab);
        BoxCollider2D coll = tempBal.GetComponent<BoxCollider2D>();
        this.lowerLeftCorner = coll.bounds.min;
        this.upperRightCorner = coll.bounds.max;
    }

    void Update()
    {
        if (retrySpawn)
        {
            SpawnBall();
        }
        if (this.spawnTimer.Finished)
        {
            SpawnBall();
            this.spawnTimer.Duration = GetSpawnDelay();
            this.spawnTimer.Run();
        }
    }

    private float GetSpawnDelay()
    {
        return Random.Range(ConfigurationUtils.MinSpawnTime, ConfigurationUtils.MaxSpawnTime);
    }

    public void SpawnBall()
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