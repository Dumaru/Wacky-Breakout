using UnityEngine;
using UnityEngine.Sprites;
public class StandardBlock : Block{
    
    [SerializeField]
    Sprite[] sprites;
    protected override void Start(){
        base.Start();
        pointsWorthed = ConfigurationUtils.StandarBlockPoints;
        int index = Random.Range(0, sprites.Length);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[index];
    }
}