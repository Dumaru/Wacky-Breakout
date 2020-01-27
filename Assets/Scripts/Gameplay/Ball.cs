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
    // Start is called before the first frame update
    void Start()
    {
        deathTimer = this.gameObject.AddComponent<Timer>();
        deathTimer.Duration = ConfigurationUtils.BallLifeTime;
        moveTimer = this.gameObject.AddComponent<Timer>();
        moveTimer.Duration = 1;
        moveTimer.Run();
        // Vector2 dir = new Vector2(Mathf.Cos(20*Mathf.Deg2Rad), Mathf.Sin(20*Mathf.Deg2Rad));
        
    }

    private void StartMoving(){
        deathTimer.Run();
        rb2d =  this.GetComponent<Rigidbody2D>();
        rb2d.AddForce(Vector2.down*ConfigurationUtils.BallImpulseForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(moveTimer.Finished){
            moveTimer.Stop();
            StartMoving();
        }
        if(this.deathTimer.Finished){
            Camera.main.GetComponent<BallSpawner>().SpawnBall();
            Destroy(this.gameObject);
        }
        
    }

    private void OnBecameInvisible(){
        if(deathTimer.Running && this.transform.position.y < ScreenUtils.ScreenBottom){
            Camera.main.GetComponent<BallSpawner>().SpawnBall();
            HUD.DiscountBall();
            Destroy(this.gameObject);
        }

    }

    public void SetDirection(Vector2 direction){
        this.rb2d.velocity = this.rb2d.velocity.magnitude * direction;
    }
}
