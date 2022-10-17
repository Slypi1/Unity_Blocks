using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using GameLogic;
public class UIGameManager : MonoBehaviour
{
    [SerializeField] private Scrollbar _soundScrollbar;
    [SerializeField] private AudioSource _soundSource;

    [SerializeField] private GameObject _soundPanel;
    [SerializeField] private GameObject _victotyPanel;

    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TMP_Text _soundVlume;

    private float _soundPercent;
    private int _percent = 100;
    
    private void Awake()
    {
        _soundScrollbar.value = PlayerPrefs.GetFloat("SoundValue");
    }

    private void OnEnable()
    {
        TableManager.Victory += VictotyVsGameOver;
    }

    private void OnDisable()
    {
        TableManager.Victory += VictotyVsGameOver;
    }

    private void Update()
    {
        ControlSound();
    }

    public void ControlSound()
    {
        _soundSource.volume = _soundScrollbar.value;
        _soundPercent = _percent * _soundSource.volume;
        var soundPercentInt = (int)_soundPercent;
        _soundVlume.text = soundPercentInt.ToString();
    }
    public void ControlStartSound()
    {
        _soundPanel.SetActive(true);
    }

    private void VictotyVsGameOver(bool isVictory)
    {
        if (_victotyPanel != null && _gameOverPanel != null)
        {
            if (isVictory)
                StartCoroutine(RetentionVictoryGame());
            else _gameOverPanel.gameObject.SetActive(true);
        }
    }

    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);      
    }

    private void VictoryGame()
    {
        _victotyPanel.gameObject.SetActive(true);
    }

    IEnumerator RetentionVictoryGame()
    {
        yield return new WaitForSeconds(0.2f);
        VictoryGame();
    }
}

