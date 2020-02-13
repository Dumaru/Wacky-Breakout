using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Sprites;

public class PickupBlock : Block
{

    [SerializeField]
    Sprite freezerSprite;
    [SerializeField]
    Sprite speedUpSprite;

    PickupEffect effectKind;
    private float effectDuration;
    // FreezerEvent
    private FreezerEffectActivated freezerEffect;
    private SpeedUpEffectActivated speedUpEffect;
    public PickupEffect EffectKind
    {
        set
        {
            effectKind = value;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = (effectKind == PickupEffect.Speedup ? speedUpSprite : freezerSprite);
            if (effectKind == PickupEffect.Freezer)
            {
                this.effectDuration = ConfigurationUtils.FreezerEffectDuration;
                this.freezerEffect = new FreezerEffectActivated();
                EventManager.AddFreezerInvoker(this);
            }
            else
            {
                this.effectDuration = ConfigurationUtils.SpeedUpEffectDuration;
                this.speedUpEffect = new SpeedUpEffectActivated();
                EventManager.AddSpeedUpInvoker(this);
            }
        }
        get{
            return effectKind;
        }
    }
    protected override void Start()
    {
        pointsWorthed = ConfigurationUtils.PickupBlockPoints;

    }

    protected override void OnCollisionEnter2D(Collision2D other){
        if(effectKind == PickupEffect.Freezer){
            this.freezerEffect.Invoke(this.effectDuration);
        }else{
            this.speedUpEffect.Invoke(this.effectDuration, ConfigurationUtils.SpeedUpEffectFactor);

        }
        base.OnCollisionEnter2D(other);
    }

    public void AddFreezerEffectListener(UnityAction<float> listener)
    {
        this.freezerEffect.AddListener(listener);
    }

    public void AddSpeedUpEffectListener(UnityAction<float, float> listener)
    {
        this.speedUpEffect.AddListener(listener);
    }

}