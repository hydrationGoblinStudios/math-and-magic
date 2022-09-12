using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public Vector3 oneDown;
    public GameObject player;
    public float timer;
    public float timerMax;
    public int range;
    private void Awake()
    {
        timerMax = timer;
        TargetCoordinate = new int[2] { 0, 0 };
        lastTargetCoordinate = new int[2] { 7, 5 };
    }
    void Start()
    {
        Debug.Log(current);
        mapValues = GridRandomizer.Instance.Randomize();
        moveableObjects.Add(this);
        target = transform.position;
        oneDown = transform.position;
        oneDown.y = oneDown.y - 1;
    }
    void Update()
    {
        timer = gridMaracutaia.timer;
        current = slot.result;
        oneDown = transform.position;
        oneDown.y = oneDown.y - 1;
        if (Input.GetMouseButtonDown(1))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.x = target.x + 0.5f;
            target.y = target.y + 0.5f;
            target.z = transform.position.z;
            targetCell = grid.WorldToCell(target);
            TargetCoordinate[0] = (int)targetCell.x + 7;
            TargetCoordinate[1] = (int)targetCell.y + 5;
            targetValue = mapValues[(int)targetCell.x + 7, (int)targetCell.y + 5];
            Debug.Log("value" + mapValues[(int)targetCell.x+ 7 , (int)targetCell.y+5]);
        }
        //move o personagem se o resultado estiver certo
        if (targetValue == current && TargetCoordinate != lastTargetCoordinate && TargetCoordinate[0]<= lastTargetCoordinate[0]+range && TargetCoordinate[0] >= lastTargetCoordinate[0]-range && TargetCoordinate[1] <= lastTargetCoordinate[1] + range && TargetCoordinate[1] >= lastTargetCoordinate[1] - range)
        {
            slot.full = false;
            StartCoroutine(MoveToTarget(targetCell));
            StartCoroutine(slot.CardReset());
            slot.closestSnapPoint = slot.snapPoints[0];
            lastTargetCoordinate[0] = TargetCoordinate[0];
            lastTargetCoordinate[1] = TargetCoordinate[1];
        }
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = timerMax;
            player.transform.position = new Vector3(oneDown.x, oneDown.y, 0);
            oneDown = transform.position;
            oneDown.y = oneDown.y - 1;
            lastTargetCoordinate[1] -= 1;
        }
        if(player.transform.position.y <= -6)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
    private IEnumerator MoveToTarget(Vector3 x)
    {
        transform.position = Vector3.MoveTowards(transform.position, x, speed * Time.deltaTime);
        yield return new WaitForSeconds((float)0.3);
        targetValue = 100;
    }   
}