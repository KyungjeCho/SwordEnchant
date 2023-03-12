using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCameraMove : MonoBehaviour
{
    public Transform Target;
    public float Speed;
    public float ScrollSpeed = 10f;

    private float temp_value;
    private Camera mainCamera;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        TrackToTarget();

        ZoomInOut();
    }

    void TrackToTarget()
    {
        if (Target != null)
        {
            Vector3 position = Vector3.Lerp(transform.position, Target.position, Time.deltaTime * Speed);
            position.z = -10;

            transform.position = position;
        }
    }

    public void ChangeTarget(Transform nextTarget)
    {
        Target = nextTarget;
    }

    void ZoomInOut()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;

        if (mainCamera.orthographicSize <= 2.67f && scroll > 0)
        {
            temp_value = mainCamera.orthographicSize;
            mainCamera.orthographicSize = temp_value;
        }
        else if (mainCamera.orthographicSize >= 20.03f && scroll < 0)
        {
            temp_value = mainCamera.orthographicSize;
            mainCamera.orthographicSize = temp_value; 
        }
        else
        {
            mainCamera.orthographicSize -= scroll * 0.5f;
        }
    }
}
