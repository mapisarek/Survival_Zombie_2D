using UnityEngine;

public interface IEnemy
{
    Collider2D Collider { get; set; }
    Collider2D Collider2D { get; set; }
    GameObject GameObject { get; set; }
    float HealthValue { get; set; }
    Transform Target { get; set; }
}