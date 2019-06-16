using UnityEngine;

public interface ICharacter
{
    Vector3 Direction { get; set; }
    bool IsMoving { get; }
    float Speed { get; set; }
}