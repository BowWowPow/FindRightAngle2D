using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    private AttachCol player;
	void Start () {
         player = GameObject.FindGameObjectWithTag("Player").GetComponent<AttachCol>();
	}
	
	// Update is called once per frame
	void Update () {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<AttachCol>(); 
        }
        if(Input.GetMouseButtonDown(0))
        {
            player.Detatch();
        }

	}


}
