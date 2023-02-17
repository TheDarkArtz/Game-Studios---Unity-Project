using UnityEngine;

struct MaterialStruct
{
    public string Name;
    public GameObject Prefab;

    public MaterialStruct(string name, string type, GameObject gameObject)
    {
        this.Name = name;
        this.Prefab = gameObject;
    }
}
