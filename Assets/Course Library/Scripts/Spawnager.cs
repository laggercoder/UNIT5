using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Spawnager : MonoBehaviour
{
    public List<GameObject> targets;
    private float someFew = 2.0f;
    private int score;
    public bool isActive;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText ;
    public Button restartButton;
    public GameObject titleScrene;
    // Start is called before the first frame update
    void Start()
    {
        
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator SpawTarget()
    {
        while (isActive)
        {
            yield return new  WaitForSeconds(someFew);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    public void UpdateScore(int coreAdd)
    {
        score += coreAdd;
        scoreText.text = "Score :" + score;
    }
    public void gameOver()
    {
        isActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameStart(int difficulty)
    {
        someFew = someFew / difficulty;
        isActive = true;
        StartCoroutine(SpawTarget());
        UpdateScore(0);
        titleScrene.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }
}
