using Core;
using UnityEngine;

namespace Presentation
{
  public class CellSpawner : MonoBehaviour
  {
    [SerializeField] 
    private GameObject _cellPrefab;
    private GameField  _gameField;

    public void Init(GameField gameField)
    {
      _gameField = gameField;
      _gameField.OnCellCreated += CreateCell;
    }

    private void CreateCell(Cell cell)
    {
      GameObject cellObject = Instantiate(_cellPrefab);
      if (_cellPrefab.TryGetComponent(out CellView view))
      {
        view.Init(cell);
      }
    }
  }
}