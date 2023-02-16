using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct MaterialStruct
{
    public string Name;
    public string Type;

    public MaterialStruct(string name, string type)
    {
        this.Name = name;
        this.Type = type;
    }
}
