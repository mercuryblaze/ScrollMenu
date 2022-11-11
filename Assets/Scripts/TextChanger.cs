using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    [SerializeField] private Text _element—ounter;

    public Text Element—ounter
    {
        get
        {
            return _element—ounter;
        }
        set
        {
            _element—ounter = value;
        }
    }
}
