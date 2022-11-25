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

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        indicator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameStatus();
        if (!GameManager.instance.isPaused)
        {
            
            if (Input.GetMouseButtonDown(0))
            {
                HandleSelection();
            }
            if (Input.GetMouseButtonUp(1) && selectedUnit != null)
            {
                HandleAction();
            }
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
            if (unit != null)
            {
                Debug.Log(unit.name + "\nEnergy: " + unit.energy + "\nExperience: " + unit.experience + "\n Working: " + unit.isWorking + " Resting: " + unit.isResting + " Eating: " + unit.isEating);

            }
            else
            {
                Debug.Log("Nothing here!");
            }
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
        if (GameManager.instance.isPaused)
        {
            _camera.gameObject.SetActive(false);
        }
    }
}
