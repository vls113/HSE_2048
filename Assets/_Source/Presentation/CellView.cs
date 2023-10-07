using Core;
using TMPro;
using System;
using Presentation.SO;
using UnityEngine;


namespace Presentation
{
  public class CellView : MonoBehaviour
  {
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private SpriteRenderer  _sprite;
    [SerializeField] private CellColors      _cellColors;
    
    private Cell _cell;

    public void Init(Cell cell)
    {
      _cell = cell;
      _cell.OnPositionChanged += UpdatePosition;
      _cell.OnValueChanged += UpdateValue;
      _cell.OnValueChanged += UpdateColor;
      
      UpdateValue(cell.Value);
      UpdateColor(cell.Value);
      UpdatePosition();
    }

    private void UpdateValue(int value)
    {
      _text.text = $"{Math.Pow(2, value)}";
    }

    private void UpdateColor(int value)
    {
      _sprite.color = Color.Lerp(
        _cellColors.StartColor, 
        _cellColors.EndColor,
        value / 11);
    }

    private void UpdatePosition()
    {
      transform.position = 
        new Vector2(_cell.X, _cell.Y);
    }
  }
}