using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GridGenerationPanel : MonoBehaviour
{
    [SerializeField]private TMP_Dropdown widthDropdown;
    [SerializeField] private TMP_Dropdown heightDropdown;
    [SerializeField] private TMP_Dropdown AOIDropdown;
    [SerializeField] private Button Submit;

    private void Start()
    {
        Submit.onClick.AddListener(InitiateGenerateGrid);
    }

    private void InitiateGenerateGrid()
    {
        GridController.Instance.gridConfig.width = widthDropdown.value + 1;
        GridController.Instance.gridConfig.height = heightDropdown.value + 1;
        GridController.Instance.gridConfig.AOI = AOIDropdown.value + 1;
        GridController.Instance.StartGridGeneration();
        gameObject.SetActive(false);
        GameService.Instance.currState = GameState.Grid;
    }
}
