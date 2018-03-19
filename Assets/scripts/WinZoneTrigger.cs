using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinZoneTrigger : MonoBehaviour {
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Stay in win zone");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter win zone. It must stay");
    }
}
