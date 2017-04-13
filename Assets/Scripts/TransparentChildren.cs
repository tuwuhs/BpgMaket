using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TransparentChildren : MonoBehaviour
{
    private float _transparency = 1.0f;
    private List<GameObject> _children;

    public float Transparency
    {
        get { return _transparency; }
        set
        {
            _transparency = value;
            foreach (GameObject obj in _children)
            {
                Renderer r = obj.GetComponent<Renderer>();
                if (r == null) continue;

                Transparent t = r.GetComponent<Transparent>();
                if (t == null && _transparency < 1.0f)
                {
                    t = r.gameObject.AddComponent<Transparent>();
                }

                if (t != null)
                {
                    t.Transparency = _transparency;
                }
            }
        }
    }

    List<GameObject> GetAllChildren()
    {
        return GetAllChildren(gameObject);
    }

    List<GameObject> GetAllChildren(GameObject obj)
    {
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in obj.transform)
        {
            children.Add(child.gameObject);
            children.AddRange(GetAllChildren(child.gameObject));
        }
        return children;
    }

    void Start()
    {
        _children = GetAllChildren();
    }
}
