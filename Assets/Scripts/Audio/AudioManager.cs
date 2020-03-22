using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{
    static bool initialized;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips = new Dictionary<AudioClipName, AudioClip>();

    public static bool Initialized => initialized;

    public static void Initialize(AudioSource source)
    {
        audioSource = source;
        initialized = true;
        audioClips.Add(AudioClipName.BRICK_HIT, Resources.Load<AudioClip>("Audio/BrickHit_SFX"));
        audioClips.Add(AudioClipName.PADDLE_HIT, Resources.Load<AudioClip>("Audio/PaddleBorderHit_SFX"));
        audioClips.Add(AudioClipName.GAME_OVER, Resources.Load<AudioClip>("Audio/GameOver_SFX"));
    }

    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
}