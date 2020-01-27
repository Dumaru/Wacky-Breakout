using UnityEngine;
using UnityEngine.Sprites;

public class PickupBlock : Block
{

    [SerializeField]
    Sprite freezerSprite;
    [SerializeField]
    Sprite speedUpSprite;

    PickupEffect effectKind;

    public PickupEffect EffectKind{
        set{
            effectKind = value;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = (effectKind == PickupEffect.Speedup? speedUpSprite: freezerSprite);
        }
    }
    protected override void Start()
    {
        pointsWorthed = ConfigurationUtils.PickupBlockPoints;

    }

}