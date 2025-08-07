using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public static AudioPlay Instance;
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }
    public void PlayAudioOne(AudioClip ac)
    {
        GetComponent<AudioSource>().PlayOneShot(ac);
    }
}
