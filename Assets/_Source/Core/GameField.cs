using UnityEngine;
using System.Collections.Generic;

namespace Core
{
  public class GameField
  {
    private readonly List<Cell>       _cells;
    private readonly List<(int, int)> _emptyPositions;
    private readonly int              _fieldSize;

    public System.Action<Cell> OnCellCreated;

    public GameField(int fieldSize)
    {
      _fieldSize = fieldSize;
      _cells = new();
      _emptyPositions = new();
    }

    public void InitializeField()
    {
      for (int i = 0; i < _fieldSize; i++)
      {
        for (int j = 0; j < _fieldSize; j++)
        {
          _emptyPositions.Add((i,j));
        }
      }
    }

    private (int, int) GetEmptyPosition()
    {
      int positionPointer = Random.Range(0, _emptyPositions.Count);
      
      (int,int) emptyCell = _emptyPositions[positionPointer];

      _emptyPositions.RemoveAt(positionPointer);
      
      return emptyCell;
    }

    public void CreateCell()
    {
      (int, int) position = GetEmptyPosition();
      
      Cell cell = 
        new Cell(position.Item1, position.Item2, CalculateCellValue());
      
      _cells.Add(cell);
      OnCellCreated?.Invoke(cell);
    }

    public void MoveCells(Vector2Int moveDirection)
    {
      
    } 
    
    private bool CanMoveCell(Cell cell, Vector2Int movePosition)
    {
      int newX = cell.X + movePosition.x;
      int newY = cell.Y + movePosition.y;

      if (newX < _fieldSize &&
          newY < _fieldSize &&
          newX >= 0 &&
          newY >= 0)
      {
        return true;
      }
      
      return false;
    }

    private int CalculateCellValue()
    {
      System.Random rnd = new();
      int value = rnd.Next(0, 101);
      return value <= 10 ? 2 : 1;
    }
  }
}