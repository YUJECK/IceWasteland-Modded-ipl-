using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour
{
    [System.Serializable] private class MusicTheme
    {
        [SerializeField] private KeyCode key = KeyCode.F1;
        [SerializeField] private AudioClip theme;
        public AudioClip Theme => theme;

        public MusicTheme(KeyCode key) => this.key = key;

        public bool Check()
        {
            if (Input.GetKeyDown(key))
                return true;
            
            return false;
        }
    }

    [SerializeField] AudioSource themeSource;
    [SerializeField] List<MusicTheme> musicThemes = new();

    private void Update()
    {
        foreach (MusicTheme nextTheme in musicThemes)
        {
            if (nextTheme.Check())
                SwitchTheme(nextTheme.Theme);
        }
    }
    
    private void SwitchTheme(AudioClip newTheme)
    {
        themeSource.clip = newTheme;
        themeSource.Play();
    }
}