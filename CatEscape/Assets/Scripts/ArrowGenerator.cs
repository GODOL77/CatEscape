using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    GameDirector gameDirector;
    float span = 1.0f;
    float delta = 0;

    int dropPosition = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(arrowPrefab);
            dropPosition = Random.Range(-6, 7);
            go.transform.position = new Vector3 (dropPosition, 7, 0);
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
