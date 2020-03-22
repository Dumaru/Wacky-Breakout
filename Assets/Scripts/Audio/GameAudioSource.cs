using UnityEngine;

public class GameAudioSource : MonoBehaviour
{
    private void Awake()
    {
        if (!AudioManager.Initialized)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            AudioManager.Initialize(audioSource);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroy duplicated object
            Destroy(gameObject);
        }
    }
}