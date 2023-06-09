using Memory.Models; // Import the Memory.Models namespace
using Memory.Views;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryGame : MonoBehaviour
{
    MemoryBoard _board;

    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private MemoryBoardView _memoryBoard;

    private PlayerModel _player1Model;
    private PlayerModel _player2Model;

    [SerializeField] private PlayerView _player1View;
    [SerializeField] private PlayerView _player2View;

    [SerializeField] private Material[] materials = new Material[5];

    private void Start()
    {
        // Create player models and memory board

        _player1Model = new PlayerModel("Player1", true);
        _player2Model = new PlayerModel("Player2", false);
        _board = new MemoryBoard(3, 3, _player1Model, _player2Model);

        // Set up the memory board view

        _memoryBoard.SetUpMemoryBoardView(_board, _tilePrefab, materials, _player1View, _player2View);
    }
}
