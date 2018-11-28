using UnityEngine.UI;
using UnityEngine;
using System;

public class SmoothConstants : MonoBehaviour
{
    public static float deadZone;
    [SerializeField] Slider _deadZone;
    [SerializeField] Text _deadZoneText;

    public static float deadZoneRotation;
    [SerializeField] Slider _deadZoneRotation;
    [SerializeField] Text _deadZoneRotationText;

    public static float speed;
    [SerializeField] Slider _speed;
    [SerializeField] Text _speedText;    
    

    private void Start()
    {
        _deadZone.onValueChanged.AddListener(OnValueChangeDeadZone);
        _deadZone.value = 2f;

        _deadZoneRotation.onValueChanged.AddListener(OnValueChangeDeadZoneRotation);
        _deadZoneRotation.value = 2f;

        _speed.onValueChanged.AddListener(OnValueChangeSpeed);
        _speed.value = 0.5f;        
    }        

    private void OnDestroy()
    {
        _deadZone.onValueChanged.RemoveListener(OnValueChangeDeadZone);
        _deadZoneRotation.onValueChanged.RemoveListener(OnValueChangeDeadZoneRotation);
        _speed.onValueChanged.RemoveListener(OnValueChangeSpeed);
    }

    public void OnValueChangeDeadZone(float value)
    {
        deadZone = value;
        _deadZoneText.text = "DeadZone = " + deadZone;
    }    

    private void OnValueChangeDeadZoneRotation(float value)
    {
        deadZoneRotation = value;
        _deadZoneRotationText.text = "DeadZoneRotation = " + deadZoneRotation;
    }

    public void OnValueChangeSpeed(float value)
    {
        speed = value;
        _speedText.text = "Speed = " + speed;
    }
}
