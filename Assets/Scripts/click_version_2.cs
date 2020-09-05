using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class click_version_2 : MonoBehaviour
{

    [SerializeField]
    int count_objects;
    [SerializeField]
    List<GameObject> store = new List<GameObject>();
    public static click_version_2 instance_Clicker;
    public List<GameObject> numbers = new List<GameObject>();
    [SerializeField]
    public AudioSource won,lose,tap;
    [SerializeField]
    public int check_won_or_lose_condition = 0;
    private void Awake()
    {
        if (instance_Clicker == null)
        {
            instance_Clicker = this;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
        check_won_or_lose_condition = PlayerPrefs.GetInt("audiown");
    }
    private void Start()
    {
        if (check_won_or_lose_condition == 0)
        {
            lose.Play();
        }
        else if (check_won_or_lose_condition == 1)
        {
            won.Play();
        }
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
 
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            LayerMask mask = LayerMask.GetMask("q");
            
            if (Physics.Raycast(ray, out hit, 100.0f, mask))
            {
                if (hit.transform != null)
                {
                    count_objects += 1;
                    //Print_object(hit.transform.gameObject);
                    tap.Play();
                    store.Add(hit.transform.gameObject);                   
                    hit.transform.gameObject.SetActive(false);
                   
                    if (store != null)
                    {

                       if(count_objects >= 20)
                        {
                            

                            count_objects = 20;
                            
                            bool istrue =store.SequenceEqual(numbers);
                            if (istrue)
                            {
                                check_won_or_lose_condition = 1;
                                UI_Manager.instance.Score_ofthegame +=30;
                                UI_Manager.instance.ChangeScene();
                                Debug.Log("Matched,you Won");
                                PlayerPrefs.SetInt("audiown", check_won_or_lose_condition);
                            }
                            else
                            {
                                check_won_or_lose_condition = 0; 
                                UI_Manager.instance.Score_ofthegame =0;
                                UI_Manager.instance.ChangeScene();                             
                                Debug.Log("Game Over");
                                PlayerPrefs.SetInt("audiown", check_won_or_lose_condition);
                            }
                            
                        }
                        

                    }
                     

                }
                   

                }

            }
 
        }
     
    
     
    private void Print_object(GameObject go)
    {
        print(go.name);
    }
}

    


