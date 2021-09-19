using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolObject
{
    bool InUse();

    void Init(Transform spawn);
}