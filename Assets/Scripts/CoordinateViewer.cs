using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class CoordinateViewer : MonoBehaviour
{
    [SerializeField] private Transform _sourceCoordinateTransform;
    private TMP_Text _coordinateText;

    private void Awake()
    {
        _coordinateText = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        _coordinateText.text = $"x: {_sourceCoordinateTransform.position.x} y: {_sourceCoordinateTransform.position.y}";
    }

    public void SetSourceTransform(Transform transform) => _sourceCoordinateTransform = transform;
}
