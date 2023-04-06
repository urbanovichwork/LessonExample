using UnityEngine;

public class Rotator : MonoBehaviour, IRandomizer
{
    private enum RotateAxis
    {
        Left,
        Up,
        Right,
        Down,
        Forward,
        Back
    }

    [SerializeField] private RotateAxis _axisToRotateAround = RotateAxis.Up;
    [SerializeField] private float _speed = 50;

    private RotateAxis _currentAxis;
    private Vector3 _currentAxisVector;

    public void RandomizeValues()
    {
        _axisToRotateAround = (RotateAxis)Random.Range(0, 6);
        _speed = Random.Range(10f, 100f);
    }

    private void Start()
    {
        SetAxisToEnumParam();
    }

    private void Update()
    {
        CheckAxisChange();
        Rotate();
    }

    private void CheckAxisChange()
    {
        if (_currentAxis != _axisToRotateAround)
        {
            SetAxisToEnumParam();
        }
    }

    private void Rotate()
    {
        var deltaSpeed = Time.deltaTime * _speed;
        transform.Rotate(_currentAxisVector, deltaSpeed);
    }

    private void SetAxisToEnumParam()
    {
        _currentAxis = _axisToRotateAround;
        _currentAxisVector = GetAxisVectorByAxis(_currentAxis);
    }

    private Vector3 GetAxisVectorByAxis(RotateAxis axis)
    {
        var axisVector = Vector3.zero;
        switch (axis)
        {
            case RotateAxis.Left:
                axisVector = Vector3.left;
                break;
            case RotateAxis.Up:
                axisVector = Vector3.up;
                break;
            case RotateAxis.Right:
                axisVector = Vector3.right;
                break;
            case RotateAxis.Down:
                axisVector = Vector3.down;
                break;
            case RotateAxis.Forward:
                axisVector = Vector3.forward;
                break;
            case RotateAxis.Back:
                axisVector = Vector3.back;
                break;
        }

        return axisVector;
    }
}