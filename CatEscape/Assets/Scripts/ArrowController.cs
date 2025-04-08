using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        this.player = GameObject.Find("player");
    }

    void Update()
    {
        transform.Translate(0, -0.1f, 0);

        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        // 피타고라스 법칙을 이용한 판정 계산 및 오브젝트 삭제
        Vector2 position1 = transform.position;
        Vector2 position2 = this.player.transform.position;
        Vector2 dir = position1 - position2;
        float d = dir.magnitude;
        float radius1 = 0.5f;
        float radius2 = 1.0f;

        if (d < radius1 + radius2)
        {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();
            Destroy(gameObject);
        }
    }
}
