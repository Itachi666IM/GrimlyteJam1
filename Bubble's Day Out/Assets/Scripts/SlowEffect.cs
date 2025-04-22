using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEffect : MonoBehaviour
{
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<Player>();
        StartCoroutine(SlowTime());
    }

    IEnumerator SlowTime()
    {
        Time.timeScale /= 2;
        player.speed *= 2;
        yield return new WaitForSeconds(player.slowDownTime);
        Time.timeScale = 1f;
        player.speed = player.defaultSpeed;
        Destroy(gameObject);
    }

}
