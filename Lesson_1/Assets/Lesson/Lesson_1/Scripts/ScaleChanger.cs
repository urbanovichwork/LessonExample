using UnityEngine;

public class ScaleChanger : MonoBehaviour, IRandomizer
{
    private const int InterpolationMaximum = 1;
    private const int InterpolationMinimum = 0;
    
    [SerializeField] private Vector2 _range = new(1, 3);
    [SerializeField] private float _oneDirInSeconds = 5f;

    private float _interpolation;
    private bool _isScaleGoingUp;
    private Vector3 _scaleHolder;

    public void RandomizeValues()
    {
        _range.x = Random.Range(0f, 2f);
        _range.y = Random.Range(_range.x, 5f);
        _oneDirInSeconds = Random.Range(1f, 10f);
    }
    
    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        SetScaleToHolder(_range.x);
        transform.localScale = _scaleHolder;

        SetDefaultUpValues();
    }

    private void Update()
    {
        ChangeInterpolation();
        ChangeScale();
    }

    private void ChangeInterpolation()
    {
        if (_isScaleGoingUp)
        {
            _interpolation += Time.deltaTime / _oneDirInSeconds;
        }
        else
        {
            _interpolation -= Time.deltaTime / _oneDirInSeconds;
        }

        if (_interpolation >= InterpolationMaximum)
        {
            SetDefaultDownValues();
        }

        if (_interpolation <= InterpolationMinimum)
        {
            SetDefaultUpValues();
        }
    }

    private void SetDefaultDownValues()
    {
        _isScaleGoingUp = false;
        _interpolation = InterpolationMaximum;
    }

    private void SetDefaultUpValues()
    {
        _isScaleGoingUp = true;
        _interpolation = InterpolationMinimum;
    }

    private void ChangeScale()
    {
        var scaleValue = Mathf.Lerp(_range.x, _range.y, _interpolation);
        SetScaleToHolder(scaleValue);
        transform.localScale = _scaleHolder;
    }

    private void SetScaleToHolder(float scaleValue)
    {
        _scaleHolder.x = scaleValue;
        _scaleHolder.y = scaleValue;
        _scaleHolder.z = scaleValue;
    }
}