using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D.IK;

public class CameraController : MonoBehaviour
{
    private PlayerMovement player;
    public BoxCollider2D boundsBox;

    private float halfHeigh, halfWidth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindFirstObjectByType<PlayerMovement>();

        halfHeigh = Camera.main.orthographicSize;
        halfWidth = halfHeigh * Camera.main.aspect;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (player != null)
        {
            transform.position = new Vector3(Mathf.Clamp(player.transform.position.x ,boundsBox.bounds.min.x + halfWidth,boundsBox.bounds.max.x - halfWidth),
            Mathf.Clamp(player.transform.position.y,boundsBox.bounds.min.y + halfHeigh, boundsBox.bounds.max.y - halfHeigh), transform.position.z);        
        }
    }
}
