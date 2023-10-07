using UnityEngine;

namespace Presentation.SO
{
  [CreateAssetMenu(fileName = "CellColors", menuName = "SO/new Cell Colors", order = 0)]
  public class CellColors : ScriptableObject
  {
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _endColor;

    public Color StartColor => _startColor;
    public Color EndColor => _endColor;
  }
}