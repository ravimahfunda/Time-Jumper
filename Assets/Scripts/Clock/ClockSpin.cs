using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockSpin : MonoBehaviour {
    public float spinSpeed;
    public ScoreManager _scoreManager;

    public PlayerBehaviours player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player.isStart)
        {
            Debug.Log("Speed: " + (spinSpeed + _scoreManager.score));
            transform.Rotate(new Vector3(0, (spinSpeed + _scoreManager.score) * Time.deltaTime, 0));
        }
    }
}
