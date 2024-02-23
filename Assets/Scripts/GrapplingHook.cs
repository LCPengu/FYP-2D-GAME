using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public Camera grappleCamera;
    public LineRenderer grapleLineRenderer;
    public DistanceJoint2D grapleDistanceJoint;

    // Start is called before the first frame update
    void Start()
    {
        grapleDistanceJoint.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 mousePos = (Vector2)grappleCamera.ScreenToWorldPoint(Input.mousePosition);
            grapleLineRenderer.SetPosition(0, mousePos);
            grapleLineRenderer.SetPosition(1, transform.position);
            grapleDistanceJoint.connectedAnchor = mousePos;
            grapleDistanceJoint.enabled = true;
            grapleLineRenderer.enabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            grapleDistanceJoint.enabled = false;
            grapleLineRenderer.enabled = false;
        }

        if (grapleDistanceJoint.enabled)
        {
            grapleLineRenderer.SetPosition(1, transform.position);
        }
    }
}
