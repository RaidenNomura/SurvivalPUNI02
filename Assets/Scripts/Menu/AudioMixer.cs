using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioMixer : MonoBehaviour
{
    #region Exposed

    [SerializeField] AudioSource _backgroundMusic;
    [SerializeField] Slider _masterVol;
    [SerializeField] Slider _musicVol;

    #endregion

    #region Unity Lifecycle
    
    private void Start()
    {
     
    }

    private void Update()
    {
        _backgroundMusic.volume = _masterVol.value * _musicVol.value;
    }

    #endregion

    #region Methods



    #endregion

    #region Private & Protected

   

    #endregion
}
