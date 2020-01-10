using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// A ball definition class to manage all the related stuff
/// </summary>
public class Ball : MonoBehaviour
{
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        // Vector2 dir = new Vector2(Mathf.Cos(20*Mathf.Deg2Rad), Mathf.Sin(20*Mathf.Deg2Rad));
        rb2d =  this.GetComponent<Rigidbody2D>();
        rb2d.AddForce(Vector2.down*ConfigurationUtils.BallImpulseForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDirection(Vector2 direction){
        this.rb2d.velocity = this.rb2d.velocity.magnitude * direction;
        // print("Set direction");
        Debug.Log("Set direction");
    }
}
