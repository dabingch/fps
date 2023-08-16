using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private AK47 _ak47;

    [SerializeField]
    private Transform _ak47Parent;

    [SerializeField]
    private Camera _playerCamera;

    [SerializeField]
    private int _score;

    private UIManager _uiManager;

    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if (_uiManager is null)
        {
            Debug.LogError("UI Manager is null");
        }
    }

    void Update()
    {
        Enemy enemy = null;

        // 初始化一条射线
        Ray mouseRay = _playerCamera.ScreenPointToRay(Input.mousePosition);
        // 射线长度为200，击中后让ak47朝向射线
        RaycastHit mouseHit;
        if (Physics.Raycast(mouseRay, out mouseHit, 200.0f))
        {
            _ak47Parent.LookAt(mouseHit.point);
            enemy = mouseHit.collider.GetComponent<Enemy>();
        }

        if (Input.GetMouseButtonDown(0))
        {
            _ak47.Fire(); 
            if (enemy is not null)
            {
                enemy.Kill();
                AddScore(10);
            }

        }
    }

    public void AddScore(int points)
    {
        _score += points;
        _uiManager.UpdateScore(_score);
    }
}
