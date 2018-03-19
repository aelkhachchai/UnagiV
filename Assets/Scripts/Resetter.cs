using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resetter : MonoBehaviour
{
    public Rigidbody2D projectile;
    public float resetSpeed = 0.025f;
    private float resetSpeedSqr;
    private SpringJoint2D spring;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Rigidbody2D>() == projectile)
        {
            Reset();
        }
    }

    private void Reset()
    {
        SceneManager.LoadScene(0);
    } 
}