using UnityEngine;
using System.Collections;

public class ARIndicator : MonoBehaviour
{
    public GameObject Indicator;

    void Start()
    {
    }

    void Update()
    {
    }

    void OnMarkerLost(ARMarker marker)
    {
        Indicator.SetActive(false);
    }

    void OnMarkerFound(ARMarker marker)
    {
        Indicator.SetActive(true);
    }

    void OnMarkerTracked(ARMarker marker)
    {
        Indicator.SetActive(true);
    }
}
