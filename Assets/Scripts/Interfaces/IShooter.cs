using System;
using UnityEngine;

public interface IShooter
{
    float CoolDown { get; }
    GameObject Bullet { get; }
}
