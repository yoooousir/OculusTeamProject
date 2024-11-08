using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRCanvasPositioner : MonoBehaviour
{
    private Canvas worldSpaceCanvas;
    private Camera xrCamera;

    void Start()
    {
        worldSpaceCanvas = GetComponent<Canvas>();

        // XR ī�޶� ã��
        var xrOrigin = FindObjectOfType<XROrigin>();
        if (xrOrigin != null)
        {
            xrCamera = xrOrigin.Camera;
        }

        if (xrCamera != null)
        {
            PositionCanvasInFrontOfPlayer();
        }
        else
        {
            Debug.LogError("XR Camera not found!");
        }
    }

    void PositionCanvasInFrontOfPlayer()
    {
        if (worldSpaceCanvas != null)
        {
            // Canvas ��ġ ����
            transform.position = xrCamera.transform.position +
                               xrCamera.transform.forward * 1f + // 1 meter forward
                               Vector3.up * -0.3f; // Slightly below eye level

            // Canvas�� ī�޶� ���ϵ��� ȸ�� (������ �κ�)
            transform.rotation = xrCamera.transform.rotation;
            // Y������ 180�� ȸ���Ͽ� �ؽ�Ʈ�� �ùٸ� ������ ���ϵ���
            transform.Rotate(0, 180, 0, Space.Self);

            // Canvas ũ�� ����
            transform.localScale = new Vector3(0.001f, 0.001f, 0.001f);

            // RectTransform ũ�� ����
            RectTransform rectTransform = worldSpaceCanvas.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                rectTransform.sizeDelta = new Vector2(1000f, 800f);
            }
        }
    }
}