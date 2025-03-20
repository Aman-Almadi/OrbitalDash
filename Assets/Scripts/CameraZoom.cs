using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour
{
    public float zoomSpeed = 2f;
    public float targetSize = 7f;
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    public void ZoomOut()
    {
        StartCoroutine(Zoom());
    }

    private IEnumerator Zoom()
    {
        float startSize = cam.orthographicSize;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.unscaledDeltaTime * zoomSpeed;
            cam.orthographicSize = Mathf.Lerp(startSize, targetSize, t);
            yield return null;
        }
    }
}
