using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DefaultPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Slider _slider;
    [SerializeField] private GameObject _cube;
    [SerializeField] private Button _button;
    
    private int _counter = 0;

    private void Awake()
    {
        _button.onClick.AddListener(OnButtonPressed);
        _slider.onValueChanged.AddListener(OnSliderChanged);
    }

    private void OnSliderChanged(float value)
    {
        var rotation = value * 360;
        _cube.transform.localRotation = Quaternion.Euler(new Vector3(rotation, 0, 0));
    }

    private void OnButtonPressed()
    {
        _counter++;
        _text.text = "Count: " + _text;
    }
}