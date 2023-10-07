using Core;
using UnityEngine;

namespace Presentation
{
  public class Game : MonoBehaviour
  {
    [SerializeField] 
    private CellSpawner _cellSpawner;

    [SerializeField] 
    private PlayerInput _playerInput;
    
    private GameField _gameField;
    
    private void Awake()
    {
      StartGame();
    }

    private void StartGame()
    {
      _gameField = new GameField(4);
      
      _cellSpawner.Init(_gameField);
      _playerInput.Init(_gameField);
      
      _gameField.InitializeField();
      _gameField.CreateCell();
      _gameField.CreateCell();
    }
  }
}