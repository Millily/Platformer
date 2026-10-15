using System;
using UnityEngine;

public class TargetDetector : MonoBehaviour
{
    public event Action PlayerDetected;
    public event Action PlayerUndetected;

    public bool TargetDetected { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerDetected?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerUndetected?.Invoke();
    }
}