using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// A ball definition class to manage all the related stuff
/// </summary>
public class Ball : MonoBehaviour
{

    private Timer deathTimer;
    private Timer moveTimer;
    private Rigidbody2D rb2d;
    float initialSpeed;

    bool speeding = false;
    Timer speedUpTimer;
    // Start is called before the first frame update
    void Start()
    {
        deathTimer = this.gameObject.AddComponent<Timer>();
        deathTimer.Duration = ConfigurationUtils.BallLifeTime;
        moveTimer = this.gameObject.AddComponent<Timer>();
        moveTimer.Duration = 1;
        moveTimer.Run();
        speedUpTimer = this.gameObject.AddComponent<Timer>();
        EventManager.AddSpeedUpEffectListener(SpeedUpEffectActivatedHandler);
        // Vector2 dir = new Vector2(Mathf.Cos(20*Mathf.Deg2Rad), Mathf.Sin(20*Mathf.Deg2Rad));

    }
    public void SpeedUpEffectActivatedHandler(float duration, float factor)
    {
        Debug.Log("Effect activated Speed");
        if (speeding)
        {
            this.speedUpTimer.AddTime(duration);
        }
        else
        {
            Debug.Log("Effect activated new "+this.gameObject.GetComponent<Rigidbody2D>().velocity);
            this.initialSpeed = this.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
            this.gameObject.GetComponent<Rigidbody2D>().velocity *= factor;
            this.speedUpTimer.Duration = duration;
            this.speedUpTimer.Run();
            Debug.Log("Effect activated after "+this.gameObject.GetComponent<Rigidbody2D>().velocity);

        }
    }
    private void StartMoving()
    {
        deathTimer.Run();
        rb2d = this.GetComponent<Rigidbody2D>();
        rb2d.AddForce(Vector2.down * ConfigurationUtils.BallImpulseForce*EffectUtils.SpeedUpFactor, ForceMode2D.Impulse);
        this.initialSpeed = rb2d.velocity.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Speeding left time "+this.speedUpTimer.TimeLeft);
        if (moveTimer.Finished)
        {
            moveTimer.Stop();
            StartMoving();
        }
        if (this.deathTimer.Finished)
        {
            Camera.main.GetComponent<BallSpawner>().SpawnBall();
            Destroy(this.gameObject);
        }

    }

    private void FixedUpdate()
    {
        if (!speeding)
        {
            // Reset velocity
            Rigidbody2D rb2d = this.gameObject.GetComponent<Rigidbody2D>();
            Vector2 newVel = rb2d.velocity.normalized * this.initialSpeed;
            this.gameObject.GetComponent<Rigidbody2D>().velocity = newVel;
        }
    }

    private void OnBecameInvisible()
    {
        if (deathTimer.Running && this.transform.position.y < ScreenUtils.ScreenBottom)
        {
            Camera.main.GetComponent<BallSpawner>().SpawnBall();
            HUD.DiscountBall();
            Destroy(this.gameObject);
        }

    }

    public void SetDirection(Vector2 direction)
    {
        this.rb2d.velocity = this.rb2d.velocity.magnitude * direction;
    }
}
