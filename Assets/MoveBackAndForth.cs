using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackAndForth : MonoBehaviour {

    public List<GameObject> positions;
    public float speed;
    private Vector3 l,r;
    private int i;
	// Use this for initialization
	void Start () {
        i = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (transform.position != positions[i].transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, positions[i].transform.position, speed * Time.deltaTime);
        }
        else
        {
            i++;
        }
        if(i == positions.Count)
        {
            i = 0;
        }
	}
}
