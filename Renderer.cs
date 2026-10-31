using System;

namespace Puddles;

public class Renderer
{
    private Field _field;
    private readonly List<GameObject> _buffer = new List<GameObject>();
    public IReadOnlyList<GameObject> Buffer => _buffer;
    
    public Renderer(Field field)
    {
        if (field is null)
        {
            throw new ArgumentNullException(nameof(field));
        }
        _field = field;
    }
    
    public void Render()
    {
        _field.Clear();
        foreach(GameObject obj in _buffer)
        {
            obj.PrintOn(_field);
        }
        ConsoleUI.PrintField(_field);
    }
    
    public void AddToBuffer(GameObject obj)
    {
        // Вставляет объект в конец буфера.
        _buffer.Add(obj);
    }
}