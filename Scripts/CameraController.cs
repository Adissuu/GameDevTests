using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public Tilemap map;
    private Vector3 BottomLeftLimit;
    private Vector3 TopRightLimit;

    private float halfHeight;
    private float halfWidth;

    void Start()
    {
      //target = PlayerController.instance.transform;
      target = FindObjectOfType<PlayerController>(git lfs track "*.psd").transform;

      halfHeight = Camera.main.orthographicSize;
      halfWidth = halfHeight * Camera.main.aspect;

      BottomLeftLimit = map.localBounds.min + new Vector3(halfWidth,halfHeight, 0f);
      TopRightLimit = map.localBounds.max - new Vector3(halfWidth,halfHeight,0f);

      PlayerController.instance.SetBounds(map.localBounds.min, map.localBounds.max);
    }

    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x,target.position.y, transform.position.z);

        //Keep camera in tilemap
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, BottomLeftLimit.x,TopRightLimit.x), Mathf.Clamp(transform.position.y, BottomLeftLimit.y,TopRightLimit.y), transform.position.z);
    }
}
