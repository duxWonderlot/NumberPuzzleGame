using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GenerateLevel : MonoBehaviour
{
    [SerializeField]
    private GameObject Points;

    [SerializeField]
    private GameObject[] numbers;
    public List<GameObject> store_points = new List<GameObject>();
    public List<int> count_points = new List<int>();
    [SerializeField]
    int Randomize_set_values, deep_randomize, deep_randomize_B;
    GameObject Points_obj;

    private void Awake()
    {
        
        for (int i = 0; i < 5; i++)
        {

            for (int j = 0; j < 4; j++)
            {
                
                Points_obj = Instantiate(Points);
                store_points.Add(Points_obj);

                //GameObject Obj =Instantiate(objects[]);
                Points_obj.transform.position = new Vector3(i, 0, j);

            }
        }

        for (int k = 0; k < 20; k++)
        {
            count_points.Add(k);
            
            //setting to parent
            numbers[k].transform.SetParent(store_points[k].gameObject.transform);
            //if (count_points.Contains(num))
            //{
            //num = Random.Range(0, k);
            //getting the positions
            numbers[k].transform.position = store_points[k].transform.position;
            //}

        }

    }
    private void Start()
    {
        
      //for(int i = 0; i < 20; i++)
      //{
          Randomize_set_values=  Random.Range(0, 5);
          Debug.Log(Randomize_set_values);
          if (Randomize_set_values == 1)
          {
               Swap_things(Random.Range(0,5), Random.Range(5,20));
          }
          else if (Randomize_set_values == 2)
          {
               Swap_things(Random.Range(0, 2), Random.Range(3, 19));
          }
          else if (Randomize_set_values == 3)
          {
               Swap_things(Random.Range(0, 9), Random.Range(9, 20));
          }
          else if (Randomize_set_values == 4)
          {
               Swap_things(Random.Range(0, 4), Random.Range(4, 20));
          }
           


    }
    public void Swap_things(int a , int b)
    {
        numbers[a].transform.position = store_points[b].transform.position;
        numbers[b].transform.position = store_points[a].transform.position;
    }
    //}
    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadSceneAsync(0);
        }
    }
}
