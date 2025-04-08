using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject hpGauge;
    UIDirector UIDirector;
    public bool PlayerLives = true;

    // Start is called before the first frame update
    void Start()
    {
        this.hpGauge = GameObject.Find("hpGauge");
    }

    void Update()
    {
        CheckHp();
    }
    public void DecreaseHp()
    {
        this.hpGauge.GetComponent<Image>().fillAmount -= 0.1f;
    }

    void CheckHp()
    {
        if (this.hpGauge.GetComponent<Image>().fillAmount == 0.0f)
            {
                Debug.Log("Player Die!");
                PlayerLives = false;
            }
    }
}
