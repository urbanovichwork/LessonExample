using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Teleportator : MonoBehaviour, IRandomizer
{
    [SerializeField] private Vector2 _circleCenter = Vector3.zero;
    [SerializeField] private float _circleRadius = 3f;
    [SerializeField] private float _teleportTimer = 5f;

    private WaitForSeconds _waitForTeleport;

    public void RandomizeValues()
    {
        _circleCenter = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        _circleRadius = Random.Range(1f, 5f);
        _teleportTimer = Random.Range(1f, 5f);
    }

    private void Start()
    {
        _waitForTeleport = new WaitForSeconds(_teleportTimer);
        StartCoroutine(nameof(StartTeleportRepeat));
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator StartTeleportRepeat()
    {
        yield return _waitForTeleport;
        Teleport();
        StartCoroutine(nameof(StartTeleportRepeat));
    }

    private void Teleport()
    {
        var positionInsideCircle = Random.insideUnitCircle * _circleRadius + _circleCenter;
        transform.position = new Vector3(positionInsideCircle.x, 0, positionInsideCircle.y);
    }
}