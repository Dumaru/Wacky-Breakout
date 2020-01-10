using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    Rigidbody2D rb2d;
    private const float BounceAngleHalfRange = 60*Mathf.Deg2Rad;
    float halfColliderWidth;
    float halfColliderHeight;
    float tolerance = 0.05f;
    // Start is called before the first frame update
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        halfColliderWidth = GetComponent<CapsuleCollider2D>().size.x/2;
        halfColliderHeight = GetComponent<CapsuleCollider2D>().size.y/2;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {

        Vector2 pos = new Vector2(this.transform.position.x+Input.GetAxis("Horizontal")*ConfigurationUtils.PaddleMoveUnitsPerSecond,
            this.transform.position.y);
        pos.x = CalculateClampedX(pos.x);
        rb2d.MovePosition(pos);
    }

    /// <summary>
    /// Detects collision with a ball to aim the ball: calculates a new unit
    /// vector (a vector with magnitude 1) for the new direction the ball should 
    /// move in based on where the ball hit the paddle.
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball") && OnTopCollision(coll))
        {
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                halfColliderWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
      
            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }

    /// <summary>
    /// The contac point is relative to the position of this game object transform
    /// </summary>
    /// <param name="coll"></param>
    /// <returns></returns>
    private bool OnTopCollision(Collision2D coll){
        bool onTop = false;
        Vector2 point = coll.GetContact(0).point;
        onTop = point.y > this.transform.position.y + halfColliderHeight-tolerance;
        // Debug.Log("Coll Point:" +point.ToString()+" Pos paddle "+this.transform.position.ToString());
        // if(!onTop){
        //     Debug.Log("\nOn Top "+onTop.ToString());
        //     coll.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        // }
        Debug.Log("OnTop "+onTop);
        return onTop;
    }
    /// <summary>
    /// Clamps the x position of the paddle to stay in the camera
    /// </summary>
    /// <param name="nextPosition"></param>
    private float CalculateClampedX(float nextPosition)
    {
        float newX = nextPosition;
        if(newX <= ScreenUtils.ScreenLeft+halfColliderWidth){
            newX = ScreenUtils.ScreenLeft+halfColliderWidth;
        }else if(newX >= ScreenUtils.ScreenRight-halfColliderWidth){
            newX = ScreenUtils.ScreenRight-halfColliderWidth;
        }
        return newX;
    }
}
