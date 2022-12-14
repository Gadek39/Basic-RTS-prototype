using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    private Camera _camera;
    public Vector3 target;
    public bool isSelected;
    public float speed;
    public Unit selectedUnit;
    public GameObject indicator;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        indicator.SetActive(false);
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameStatus();
        if (Input.GetMouseButtonDown(0) && !gameManager.isPaused)
        {
            HandleSelection();
        }
        if (Input.GetMouseButtonUp(1) && selectedUnit != null && !gameManager.isPaused)
        {
            HandleAction();
        }
    }
    void HandleSelection()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var unit = hit.collider.GetComponentInParent<Unit>();
            selectedUnit = unit;
            Debug.Log(unit);
        }
        if (selectedUnit != null)
        {
            indicator.SetActive(true);
            indicator.transform.SetParent(selectedUnit.transform, false);
            indicator.transform.localPosition = Vector3.zero;
        }
        else
        {
            indicator.SetActive(false);
            indicator.transform.SetParent(null);
        }
        
    }
    void HandleAction()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var camp = hit.collider.GetComponentInParent<Camp>();
            if (camp != null)
            {
                Debug.Log("You sent this brave Soldier to feast!");
            }
            else
            {
                Debug.Log("Your troop will move with haste!");
            }
        }
    }
    void CheckGameStatus()
    {
        if (gameManager.isPaused)
        {
            _camera.gameObject.SetActive(false);
        }
    }
}
