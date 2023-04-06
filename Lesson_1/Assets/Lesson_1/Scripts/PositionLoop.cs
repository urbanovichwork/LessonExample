using UnityEngine;

public class PositionLoop : MonoBehaviour, IRandomizer
{
    private const int InterpolationMaximum = 1;
    private const int InterpolationMinimum = 0;

    [SerializeField] private Vector3 _startPos = new(0, 0, 0);
    [SerializeField] private Vector3 _endPos = new(5, 5, 5);
    [SerializeField] private float _oneDirInSeconds = 5f;

    private float _interpolation;
    private bool _isMovingToEnd;
    private Vector3 _posHolder;

    public void RandomizeValues()
    {
        _startPos = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        _endPos = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        _oneDirInSeconds = Random.Range(1f, 5f);
    }

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        _posHolder = _startPos;
        transform.position = _posHolder;

        SetDefaultForwardValues();
    }

    private void Update()
    {
        ChangeInterpolation();
        ChangePosition();
    }

    private void ChangeInterpolation()
    {
        if (_isMovingToEnd)
        {
            _interpolation += Time.deltaTime / _oneDirInSeconds;
        }
        else
        {
            _interpolation -= Time.deltaTime / _oneDirInSeconds;
        }

        if (_interpolation >= InterpolationMaximum)
        {
            SetDefaultBackValues();
        }

        if (_interpolation <= InterpolationMinimum)
        {
            SetDefaultForwardValues();
        }
    }

    private void SetDefaultBackValues()
    {
        _isMovingToEnd = false;
        _interpolation = InterpolationMaximum;
    }

    private void SetDefaultForwardValues()
    {
        _isMovingToEnd = true;
        _interpolation = InterpolationMinimum;
    }

    private void ChangePosition()
    {
        _posHolder = Vector3.Lerp(_startPos, _endPos, _interpolation);
        transform.position = _posHolder;
    }
}