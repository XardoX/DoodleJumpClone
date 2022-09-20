using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Camera camera;

    [SerializeField]
    private GameObject platform;

    [SerializeField]
    private float m_cameraSpeed = 1f;

    [SerializeField]
    private float maxPlatformPositionX = 5f;

    [SerializeField]
    private float platformDistance;
    // Start is called before the first frame update

    private void Start() {
        StartCoroutine(SpawnPlatfroms());
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        camera.transform.position += new Vector3(0f, m_cameraSpeed * Time.deltaTime, 0f);
    }

    IEnumerator SpawnPlatfroms ()
    {
        while(true)
        {
            float randomPositionX = Random.Range(-maxPlatformPositionX, maxPlatformPositionX);
            GameObject newPlatfrom = Instantiate(platform, new Vector3(randomPositionX, camera.transform.position.y, 0f), Quaternion.identity);
            yield return new WaitForSeconds(platformDistance);
        }
    }
}
