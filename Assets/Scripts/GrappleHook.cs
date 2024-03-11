using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleHook : MonoBehaviour
{
    LineRenderer grappleLine;

    [SerializeField] LayerMask grapplableTerrain;
    [SerializeField] float maxDistance = 10f;
    [SerializeField] float grappleSpeed = 10f;
    [SerializeField] float grappleShootSpeed = 20f;

    bool isGrappling = false;
    [HideInInspector] public bool retracting = false;

    Vector2 target;

    private void Start()
    {
        grappleLine = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !isGrappling)
        {
            StartGrapple();
        }

        if (retracting)
        {
            Vector2 grapplePosition = Vector2.Lerp(transform.position, target, grappleSpeed * Time.deltaTime);
            transform.position = grapplePosition;
            grappleLine.SetPosition(0, transform.position);
            if(Vector2.Distance(transform.position, target) < 0.5f)
            {
                retracting = false;
                isGrappling = false;
                grappleLine.enabled = false;
            }
        }
    }

    private void StartGrapple()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, maxDistance, grapplableTerrain);

        if (hit.collider != null )
        {
            isGrappling = true;
            target = hit.point;
            grappleLine.enabled = true;
            grappleLine.positionCount = 2;

            StartCoroutine(Grapple());
        }
    }

    IEnumerator Grapple()
    {
        float t = 0;
        float time = 10;
        grappleLine.SetPosition(0, transform.position);
        grappleLine.SetPosition(1, transform.position);

        Vector2 newPosition;

        for(; t < time; t+= grappleShootSpeed * Time.deltaTime) 
        {
            newPosition = Vector2.Lerp(transform.position, target, t / time);
            grappleLine.SetPosition(0, transform.position);
            grappleLine.SetPosition(1, newPosition);
            yield return null;
        }

        grappleLine.SetPosition(1, target);
        retracting = true;
    }
}
