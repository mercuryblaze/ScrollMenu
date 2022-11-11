using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scrolling : MonoBehaviour
{
    [Header("Controllers")]
    [Range(1, 50)]
    [SerializeField] private int _panelCount;
    [Range(1, 500)]
    [SerializeField] private int _panelOffset;
    [Range(0f, 20f)]
    [SerializeField] private float _snapSpeed;

    [Header("Other Objects")]
    [SerializeField] private GameObject _panelPrefab;

    private GameObject[] _arrayOfPanels;
    private Vector2[] _panelsPositions;
    private RectTransform _contentRect;
    private Vector2 _contentVector;
    private int _selectedPanelID;
    private bool _isScrolling;

    private void Start()
    {
        _arrayOfPanels = new GameObject[_panelCount];
        _panelsPositions = new Vector2[_panelCount];
        _contentRect = GetComponent<RectTransform>();

        for (int i = 0; i < _panelCount; i++)
        {
            _arrayOfPanels[i] = Instantiate(_panelPrefab, transform, false);
            _arrayOfPanels[i].GetComponent<TextChanger>().Element—ounter.text = (i + 1).ToString();

            if (i == 0) continue;
            
            _arrayOfPanels[i].transform.localPosition = new Vector2(_arrayOfPanels[i - 1].transform.localPosition.x + _panelPrefab.GetComponent<RectTransform>().sizeDelta.x
                + _panelOffset, _arrayOfPanels[i].transform.localPosition.y);
            _panelsPositions[i] = -_arrayOfPanels[i].transform.localPosition;
        }
    }

    private void FixedUpdate()
    {
        float closestPosition = float.MaxValue;

        for (int i = 0; i < _panelCount; i++)
        {
            float distance = Mathf.Abs(_contentRect.anchoredPosition.x - _panelsPositions[i].x);

            if (distance < closestPosition)
            {
                closestPosition = distance;
                _selectedPanelID = i;
            }
        }

        if (_isScrolling) return;

        _contentVector.x = Mathf.SmoothStep(_contentRect.anchoredPosition.x, _panelsPositions[_selectedPanelID].x, _snapSpeed * Time.fixedDeltaTime);
        _contentRect.anchoredPosition = _contentVector;
    }

    public void ScrollingPans(bool scroll)
    {
        _isScrolling = scroll;
    }
}