using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static List<PlayerController> moveableObjects = new List<PlayerController>();
    public float speed = 5f;
    private Vector3 target;
    public GridLayout grid;
    public Vector3 targetCell;
    public GridMaracutaia gridMaracutaia;
    public int[,] mapValues;
    public GridRandomizer gridRandomizer;
    public int current;
    public Slot slot;
    public int targetValue;
    public int[] TargetCoordinate;
    public int[] lastTargetCoordinate;

    private void Awake()
    {
        TargetCoordinate = new int[2] { 0, 0 };
        lastTargetCoordinate = new int[2] { 99, 99 };
    }
    void Start()
    {    
        Debug.Log(current);
        mapValues = GridRandomizer.Instance.Randomize();
        moveableObjects.Add(this);
        target = transform.position;
        gridMaracutaia = GetComponent<GridMaracutaia>();
    }
    void Update()
    {
        current = slot.result;
        if (Input.GetMouseButtonDown(1))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.x = target.x + 0.5f;
            target.y = target.y + 0.5f;
            target.z = transform.position.z;
            targetCell = grid.WorldToCell(target);
            TargetCoordinate[0] = (int)targetCell.x + 7;
            TargetCoordinate[1] = (int)targetCell.x + 5;
            targetValue = mapValues[(int)targetCell.x + 7, (int)targetCell.y + 5];
            Debug.Log("value" + mapValues[(int)targetCell.x+ 7 , (int)targetCell.y+5]);
        }
        //move o personagem se o resultado estiver certo
        if (targetValue == current && TargetCoordinate != lastTargetCoordinate)
        {
            StartCoroutine(MoveToTarget());
            StartCoroutine(slot.CardReset());
            lastTargetCoordinate[0] = TargetCoordinate[0];
            lastTargetCoordinate[1] = TargetCoordinate[1];
        }
    }
    private IEnumerator MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetCell, speed * Time.deltaTime);
        yield return new WaitForSeconds((float)0.3);
        Debug.Log("bazoinkas");
        targetValue = 100;
    }
}