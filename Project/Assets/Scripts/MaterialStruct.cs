using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct MaterialStruct
{

    [SerializeField] private string Name;

    public MaterialStruct(string name)
    {
        this.Name = name;
    }

}
