using UnityEngine;

public interface IPlayer
{
    float ArmorValue { get; set; }
    Camera Cam { get; set; }
    float HealthValue { get; set; }
    bool IsRunning { get; set; }
    float StaminaValue { get; set; }
}