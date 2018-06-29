using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachCol : MonoBehaviour {

    private DistanceJoint2D dj;
    private Rigidbody2D rb;
    private AttachPoint currentAttachedPoint;
    public GameObject LastAttachedPoint;
    public float force;
    public bool isAttached;
    private string swingDirection;
	// Use this for initialization
	void Start () {
        isAttached = false;
        LastAttachedPoint = null;
        dj = this.GetComponent<DistanceJoint2D>();
        rb = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if(isAttached)
        {
            AddForceInDirection(swingDirection);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        GameObject t = collision.gameObject;
        if(t.tag == "Point" && t.gameObject != LastAttachedPoint)
        {
            Debug.Log("Collide");
            AttachToPoint(t);
        }
    }

    public void AttachToPoint(GameObject point)
    {
        dj.connectedBody = point.GetComponent<Rigidbody2D>();
        dj.enabled = true;
        currentAttachedPoint = point.GetComponent<AttachPoint>();
        dj.distance = currentAttachedPoint.defaultDistance;
        swingDirection = currentAttachedPoint.swingDirection;
        LastAttachedPoint = point;
        isAttached = true;
    }

    public void Detatch()
    {
        isAttached = false;
        dj.enabled = false;
        dj.connectedBody = null;
        currentAttachedPoint = null;
    }

    public void AddForceInDirection(string lr)
    {
        if (lr == "Left")
        {
            Debug.Log(currentAttachedPoint);
            var v = this.transform.position - currentAttachedPoint.transform.position;
            var q = Quaternion.Euler(0f,0f,90f);
            var p = q * v.normalized;
            rb.AddForce(p * force, ForceMode2D.Force);
        }
        else
        {
            Debug.Log("Right");
            var v = this.transform.position - currentAttachedPoint.transform.position;
            var q = Quaternion.Euler(0f, 0f, -90f);
            var p = q * v.normalized;
            rb.AddForce(p * force, ForceMode2D.Force);
        }
    }
}