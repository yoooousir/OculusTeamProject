using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class PokerUIController : MonoBehaviour
{
    [SerializeField]
    private Button button;

    [SerializeField]
    private TextMeshProUGUI buttonText;

    [SerializeField]
    public UnityEvent onButtonPressed;

    void Awake()
    {
        // ������Ʈ ã��
        if (button == null)
        {
            button = GetComponentInChildren<Button>();
            Debug.Log($"Button found: {button != null}");
        }

        if (buttonText == null)
        {
            buttonText = GetComponentInChildren<TextMeshProUGUI>();
            Debug.Log($"ButtonText found: {buttonText != null}");
        }
    }

    void Start()
    {
        // ��ư �̺�Ʈ ����
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClicked);
            Debug.Log("Button listener added in Start");
        }
        else
        {
            Debug.LogError("Button is null in Start!");
        }

        // UnityEvent �ʱ�ȭ
        if (onButtonPressed == null)
        {
            onButtonPressed = new UnityEvent();
            Debug.Log("UnityEvent initialized");
        }
    }

    public void OnButtonClicked()
    {
        Debug.Log("Button clicked - OnButtonClicked called!");

        // Ŭ�� �����
        if (buttonText != null)
        {
            Debug.Log("Button clicked!");
        }

        // UnityEvent ȣ��
        onButtonPressed?.Invoke();
        Debug.Log("onButtonPressed event invoked");
    }

    // Inspector���� ȣ���� �� �ִ� public �޼���
    public void PrintDebugMessage()
    {
        Debug.Log("PrintDebugMessage called!");

        // Ŭ�� �����
        if (button != null)
        {
            Debug.Log("Inspector: Button clicked!");
        }
    }

    void OnDestroy()
    {
        if (button != null)
        {
            button.onClick.RemoveListener(OnButtonClicked);
        }
    }
}