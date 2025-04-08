using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIDirector : MonoBehaviour
{
    public TMP_Text ElaspedTime;
    private float timer = 0f;
    GameDirector gameDirector;
    private bool gameOverTriggered = false; // Game Over 상태 확인용 변수

    void Start()
    {
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
        // 게임이 진행 중인 경우에만 타이머 갱신
        if (gameDirector != null && gameDirector.PlayerLives)
        {
            timer += Time.deltaTime;
            ElaspedTime.text = $"Time : {timer:F2} seconds";
        }
        else
        {
            CheckPlayerLive();
        }
    }

    void CheckPlayerLive()
    {
        // 플레이어가 죽었을 때 한 번만 Game Over 처리
        if (gameDirector.PlayerLives == false && !gameOverTriggered)
        {
            gameOverTriggered = true; // Game Over 처리 완료 플래그 설정
            Time.timeScale = 0; // 모든 게임 동작 정지
            ElaspedTime.text += "\nGame Over"; // Game Over 메시지 추가
        }
    }

    public void Reset()
    {
        // Time.timeScale을 1로 초기화한 뒤 씬 재로드
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
