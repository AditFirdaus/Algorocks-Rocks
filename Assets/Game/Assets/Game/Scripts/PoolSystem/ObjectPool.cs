using System;
using System.Collections.Generic;

public class ObjectPool<T> where T : class
{
    Queue<T> pool = new Queue<T>();
    Func<T> createFunc;
    Action<T> actionOnGet;
    Action<T> actionOnRelease;
    Action<T> actionOnDestroy;

    public int countAll => pool.Count;

    public ObjectPool(Func<T> createFunc, Action<T> actionOnGet, Action<T> actionOnRelease, Action<T> actionOnDestroy, int defaultCapacity = 10)
    {
        this.createFunc = createFunc;
        this.actionOnGet = actionOnGet;
        this.actionOnRelease = actionOnRelease;
        this.actionOnDestroy = actionOnDestroy;

        for (int i = 0; i < defaultCapacity; i++) Create();
    }

    public T Create()
    {
        T obj = createFunc();
        pool.Enqueue(obj);
        return obj;
    }

    public T Get()
    {
        T item = pool.Count > 0 ? pool.Dequeue() : Create();
        actionOnGet?.Invoke(item);
        return item;
    }

    public void Release(T item)
    {
        actionOnRelease?.Invoke(item);
        pool.Enqueue(item);
    }
}
