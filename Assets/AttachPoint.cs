using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPoint : MonoBehaviour
{
    GameManager _GM;
    public int attachIndex;
    public float defaultDistance;
    private bool isBallAttached;
    public string swingDirection;
    public bool winningLocation;

    // Use this for initialization
    void Start()
    {
        _GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        isBallAttached = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player" && winningLocation == true)
        {
            Debug.Log("NEXT LEVEL");
            _GM.LoadNextLevel();
        }
    }
}
