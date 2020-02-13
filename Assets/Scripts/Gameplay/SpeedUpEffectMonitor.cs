using UnityEngine;

public class SpeedUpEffectMonitor : MonoBehaviour
{
    SpeedUpEffectActivated speedUpEffect = new SpeedUpEffectActivated();
    Timer speedUpTimer;
    float speedUpFactor = 1f;
    bool speeding = false;
    public bool Speeding => this.speeding;
    public float TimeLeft => this.speedUpTimer.TimeLeft;
    public float SpeedUpFactor => this.speedUpFactor;
    private void Start()
    {
        this.speedUpTimer = this.gameObject.AddComponent<Timer>();
        EventManager.AddSpeedUpEffectListener(SpeedUpEffectHandler);
    }

    public void SpeedUpEffectHandler(float duration, float factor)
    {
        if (this.speedUpTimer.Running)
        {
            this.speedUpTimer.AddTime(duration);
        }
        else
        {
            this.speedUpFactor = factor;
            this.speeding = true;
            this.speedUpTimer.Duration = duration;
            this.speedUpTimer.Run();
        }
    }
    private void Update()
    {
        if (!this.speedUpTimer.Running)
        {
            this.speedUpFactor = 1f;
            this.speeding = false;
        }
    }
}