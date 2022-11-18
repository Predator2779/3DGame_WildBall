using UnityEngine;
public class LightScaler : MonoBehaviour
{
    [SerializeField] private EventHorn _eventHorn;
    [SerializeField] private float _defaultIntensity;
    [SerializeField] private float _defaultRange;

    private Light _light;

    private void Start()
    {
        _light = GetComponent<Light>();

        _defaultIntensity = _light.intensity;
        _defaultRange = _light.range;

        if (_eventHorn == null)
        {
            _eventHorn = FindObjectOfType<EventHorn>();
        }

        _eventHorn.SphereScaler.OnScaling += ScalingLight;
    }

    public void ScalingLight(float multiplier)
    {
        _light.intensity = _defaultIntensity * multiplier;
        _light.range = _defaultRange * multiplier;
    }
}