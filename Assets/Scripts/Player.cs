using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public static Player Current;

    private void Awake()
    {
        Current = this;
    }
}
