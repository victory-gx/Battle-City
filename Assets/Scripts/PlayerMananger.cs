﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMananger : MonoBehaviour
{
    //属性值
    public int lifeValue = 3;
    public int playerScore = 0;
    public bool isDead;
    public bool isDefeat;


    //引用
    public GameObject born;
    public Text playerScoreText;
    public Text PlayerLifeValueText;
    public GameObject isDefeatUI;

    //单例
    private static PlayerMananger instance;

    public static PlayerMananger Instance
    {
        get
        {
            return instance;
        }

        set
        {
            instance = value;
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDefeat)
        {
            isDefeatUI.SetActive(true);
            Invoke("ReturnToTheMainMenu", 3);
            return;
        }
        if (isDead)
        {
            Recover();
        }
        playerScoreText.text = playerScore.ToString();
        PlayerLifeValueText.text = lifeValue.ToString();

    }


    private void Recover()
    {
        if (lifeValue <= 0)
        {
            //游戏失败，返回主界面
            isDefeat = true;
            Invoke("ReturnToTheMainMenu", 3);
        }
        else
        {
            lifeValue--;
            GameObject go = Instantiate(born, new Vector3(-2, -8, 0), Quaternion.identity);
            go.GetComponent<Born>().createPlayer = true;
            isDead = false;
        }
    }
    private void ReturnToTheMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
