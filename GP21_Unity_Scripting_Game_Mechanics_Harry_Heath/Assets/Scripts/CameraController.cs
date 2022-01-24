using UnityEngine;
using System.Collections;
public class CameraController : MonoBehaviour {
 
    private Transform target;
    public float distance = -8f;
    public float height = -1f;
    public float damping = 10f;
 
    // camera level boundaries
    public float mapX = 300.0f;
    public float mapY = 300.0f;

    private Vector3 wantedPosition;
  
  
    void Awake() 
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
 
    void LateUpdate() {

        // check if in bounds on X plane
        wantedPosition.x = (wantedPosition.x < mapX) ? mapX : wantedPosition.x;
        wantedPosition.x = (wantedPosition.x > mapX) ? mapX : wantedPosition.x;
 
        // check if in bounds on  Y plane
        wantedPosition.y = (wantedPosition.y < mapY) ? mapY : wantedPosition.y;
        wantedPosition.y = (wantedPosition.y > mapY) ? mapY : wantedPosition.y;
        
        // keeps camera at max bounds X point if beyond it
        if (wantedPosition.x > mapX)
        {
            wantedPosition.x = mapX;
        }
        
        // keeps camera at max bounds Y point if beyond it
        else if (wantedPosition.y > mapY)
        {
            wantedPosition.y = mapY;
        }
        
        // follow Player if not out of bounds
        else
        {
            wantedPosition = target.TransformPoint(0, height, distance);
        }
        
        // damping effect
        transform.position = Vector3.Lerp (transform.position, wantedPosition, (Time.deltaTime * damping));
    }
}