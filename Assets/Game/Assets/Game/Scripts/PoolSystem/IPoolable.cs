using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable<T> where T : class
{
    public T PoolCreate();
    public void PoolGet(T obj);
    public void PoolRelease(T obj);
    public void PoolDestroy(T obj);
}
