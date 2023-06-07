using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChaser
{
    float Speed { get; }
    GameObject Target { get; }
}
