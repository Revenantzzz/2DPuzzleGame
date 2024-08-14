using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI LevelText;
    public static GameManager Instance;
    int maxLevelNum = 8;
    private int currentLevelIndex => SceneManager.GetActiveScene().buildIndex;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        LevelText.text = "Level " + (currentLevelIndex + 1).ToString();
    }
    public void LevelComplete()
    {
        if (currentLevelIndex < maxLevelNum - 1)
        {            
            SceneController.Instance.LoadLevel(currentLevelIndex + 1);
            return;
        }
        SceneController.Instance.LoadLevel(0);
    }
}
