using UnityEngine;


namespace Core.Services
{
  public class AudioController : MonoBehaviour, IService, IInitiable
  {
    [SerializeField] private AudioSource _soundSource = null;
    [SerializeField] private AudioSource _musicSource = null;
    
    [SerializeField] private AudioClip _backTheme         = null;
    [SerializeField] private AudioClip _chickenCatch      = null;
    [SerializeField] private AudioClip _chickenTakeToYard = null;
    
    
    public void Init()
    {
      PlayBackgroundTheme();
    }

    public void DeInit()
    {
      StopAll();
    }

    public void PutToYard()
    {
      PlaySound(_chickenTakeToYard);
    }
    
    public void Catch()
    {
      PlaySound(_chickenCatch);
    }
    
    private void PlaySound(AudioClip clip)
    {
      _soundSource.PlayOneShot(clip);
    }
    
    private void PlayMusic(AudioClip clip)
    {
      _musicSource.clip = clip;
      _musicSource.Play();
    }
    
    private void StopAll()
    {
      if ( _musicSource != null )
        _musicSource.Stop();
      
      if ( _soundSource != null )
        _soundSource.Stop();
    }
    
    private void PlayBackgroundTheme()
    {
      _musicSource.loop = true;
      
      PlayMusic( _backTheme );
    }
  }
}