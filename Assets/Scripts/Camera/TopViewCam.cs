using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopViewCam : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 10f;
    public float camZ = -10f;

    private Transform myTransform;
    private Camera myCamera;

    void Awake()
    {
        if (player == null)
        {
            player = GameObject.Find(GameObjectName.Player).transform;
        }

        myTransform = transform;
        myCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.position;
        Vector3 camPos = Vector3.Lerp(playerPos, myTransform.position, smoothSpeed * Time.deltaTime);
        camPos.z = camZ;

        myTransform.position = camPos;
    }
}
