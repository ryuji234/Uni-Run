using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObj : MonoBehaviour
{
    public float speed = 8f;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver == false)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }       // Update()
}
