using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderPref : MonoBehaviour
{
    #region Exposed



    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        _keyName = gameObject.name;
        GetComponent<Slider>().value = PlayerPrefs.GetFloat(_keyName);
    }

    private void Start()
    {
     
    }

    private void Update()
    {
     
    }

    #endregion

    #region Methods

    public void SliderPrefValue(float _volume)
    {
        PlayerPrefs.SetFloat(_keyName, _volume);
    }

    #endregion

    #region Private & Protected

    private string _keyName;

    #endregion
}
