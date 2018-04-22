using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    public float CameraSmoothness = 3f;
    public Camera FixedCamera;

    private Transform playerTransform;
    private Vector3 cameraOffset;

    private void Awake () 
	{
        playerTransform = GetComponent<Transform>();
    }

    private void Start()
    {
        cameraOffset = playerTransform.transform.position - FixedCamera.transform.position;
    }

    void FixedUpdate () 
	{
        FixedCamera.transform.position = CalculateCameraPossition();
    }

    private Vector3 CalculateCameraPossition(bool lerping = true)
    {
        return lerping ? Vector3.Lerp(FixedCamera.transform.position, transform.position - cameraOffset, CameraSmoothness * Time.fixedDeltaTime)
                       : transform.position - cameraOffset;
    }
}
