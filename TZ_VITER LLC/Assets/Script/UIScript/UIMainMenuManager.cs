using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIMainMenuManager : MonoBehaviour
{
   [SerializeField] private Scrollbar _soundScrollbar;
   [SerializeField] private AudioSource _soundSource;

   [SerializeField] private GameObject _soundPanel;
   [SerializeField] private TMP_Text _soundVlume;

   private float _soundPercent;
   private int _percent = 100;


    private void Update()
    {
        ControlSound();
    }

    public void ControlSound()
    {
        _soundSource.volume = _soundScrollbar.value;
        _soundPercent = _percent * _soundScrollbar.value;
        var soundPercentInt = (int)_soundPercent;
        _soundVlume.text = soundPercentInt.ToString();
        PlayerPrefs.SetFloat("SoundValue", _soundScrollbar.value);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");

    }

    public void ControlStartSound()
    {
        _soundPanel.SetActive(true);
    }
}
   