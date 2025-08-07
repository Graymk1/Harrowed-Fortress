using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public static AudioPlay Instance;
    void Start()
    {
        Instance = this;
    }
    public void PlayAudioOne(AudioClip ac)
    {
        GetComponent<AudioSource>().PlayOneShot(ac);
    }
}
