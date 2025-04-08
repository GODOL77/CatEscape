using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameDirector gameDirector;

    void Start()
    {
        Application.targetFrameRate = 60;

        // GameDirector 초기화
        GameObject directorObj = GameObject.Find("GameDirector");
        if (directorObj != null)
        {
            gameDirector = directorObj.GetComponent<GameDirector>();
        }
        else
        {
            Debug.LogError("GameDirector object not found in the scene.");
        }
    }

    void Update()
    {
        if (transform.position.x > -7.9)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-0.1f, 0, 0);
            }
        }

        if (transform.position.x < 7.9)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(0.1f, 0, 0);
            }
        }
        
        CheckPlayerLive();
    }

    public void LButton()
    {
        if (transform.position.x > -7.9 && gameDirector.PlayerLives == true)
        {
            transform.Translate(-1, 0, 0);
        }
    }
    
    public void RButton()
    {
        if (transform.position.x < 7.9 && gameDirector.PlayerLives == true)
        {
        transform.Translate(1, 0, 0);
        }
    }

    void CheckPlayerLive()
    {
        if (gameDirector.PlayerLives == false)
        {
            enabled = false;
        }
    }
}
