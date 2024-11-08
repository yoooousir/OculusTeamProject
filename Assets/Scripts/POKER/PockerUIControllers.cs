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
        // 컴포넌트 찾기
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
        // 버튼 이벤트 설정
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClicked);
            Debug.Log("Button listener added in Start");
        }
        else
        {
            Debug.LogError("Button is null in Start!");
        }

        // UnityEvent 초기화
        if (onButtonPressed == null)
        {
            onButtonPressed = new UnityEvent();
            Debug.Log("UnityEvent initialized");
        }
    }

    public void OnButtonClicked()
    {
        Debug.Log("Button clicked - OnButtonClicked called!");

        // 클릭 디버깅
        if (buttonText != null)
        {
            Debug.Log("Button clicked!");
        }

        // UnityEvent 호출
        onButtonPressed?.Invoke();
        Debug.Log("onButtonPressed event invoked");
    }

    // Inspector에서 호출할 수 있는 public 메서드
    public void PrintDebugMessage()
    {
        Debug.Log("PrintDebugMessage called!");

        // 클릭 디버깅
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