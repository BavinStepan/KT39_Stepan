using System.Collections.Generic;

public interface ICircularBuffer<T> : IEnumerable<T>
{
    void Add(T item);
    IEnumerable<T> Reverse();
}