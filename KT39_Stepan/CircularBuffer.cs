using System;
using System.Collections;
using System.Collections.Generic;

public class CircularBuffer<T> : ICircularBuffer<T>
{
    private readonly T[] _buffer;
    private int _head;
    private int _count;

    public CircularBuffer(int capacity)
    {
        if (capacity <= 0)
            throw new InvalidCapacityException("Емкость буфера должна быть больше нуля");

        _buffer = new T[capacity];
        _head = 0;
        _count = 0;
    }

    public void Add(T item)
    {
        int tail = (_head + _count) % _buffer.Length;
        _buffer[tail] = item;

        if (_count < _buffer.Length)
        {
            _count++;
        }
        else
        {
            _head = (_head + 1) % _buffer.Length;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _count; i++)
        {
            yield return _buffer[(_head + i) % _buffer.Length];
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerable<T> Reverse()
    {
        for (int i = _count - 1; i >= 0; i--)
        {
            yield return _buffer[(_head + i) % _buffer.Length];
        }
    }
}