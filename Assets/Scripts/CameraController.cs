using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform TargetPlayer;
    [SerializeField]
    private Transform TargetEnemy;
    [SerializeField, Range(0.0f, 10.0f)]
    private float SmoothSpeed;
    [SerializeField]
    private Vector3 Offset;
    [SerializeField]
    private float LookSpeed;

    private Vector3 cameraPos;
    private Vector3 smoothedCameraPos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cameraPos = Offset + TargetPlayer.position;
       // transform.SetParent(TargetPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        cameraPos = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * LookSpeed, Vector3.up) * cameraPos;

        smoothedCameraPos = Vector3.Lerp(transform.position, TargetPlayer.position + cameraPos, SmoothSpeed * Time.deltaTime);
        transform.position = TargetPlayer.position + cameraPos;
        transform.LookAt(TargetPlayer.position);

    }
}
