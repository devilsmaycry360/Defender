using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip musicClip;
    [SerializeField] private AudioSource music;
    
    private void OnEnable()
    {
        PlayMusic();
    }

    private void PlayMusic()
    {
        music.clip = musicClip;
        music.loop = true;
        music.Play();
    }
}
