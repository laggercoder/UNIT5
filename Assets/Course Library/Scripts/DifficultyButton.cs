using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private Spawnager gameManager;
    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        button= GetComponent<Button>();
        gameManager = GameObject.Find("GameManager").GetComponent<Spawnager>();
        button.onClick.AddListener(SetDifficultyButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetDifficultyButton()
    {
        Debug.Log(gameObject.name + " is clicked ");
        gameManager.GameStart(difficulty);
    }
}
