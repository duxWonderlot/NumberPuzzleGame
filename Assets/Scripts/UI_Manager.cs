using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_Manager : MonoBehaviour
{
     
    public Text Score;
    [SerializeField]
    private Slider Timer;
    float countdown;
    public int Score_ofthegame;
    public static UI_Manager instance;
    public bool delete_save;
    [SerializeField]
    private float strengh_value;
    [SerializeField]
    private float maxValue;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
        //PlayerPrefs.DeleteAll();
        Score_ofthegame = PlayerPrefs.GetInt("score");
    }
    private void Start()
    {
        
        countdown = maxValue;
        Timer.maxValue = maxValue;
    }
    private void Update()
    {

        
        if (Score_ofthegame <= 60)
        {
            strengh_value = 2.9f;
        }
        else if (Score_ofthegame >= 60 && Score_ofthegame <= 140)
        {
            strengh_value = 2.0f;
        }else if (Score_ofthegame > 200)
        {
            strengh_value = 1.9f;
        }
        countdown -= strengh_value * Time.deltaTime;
        Score.text = "" + Score_ofthegame;
        PlayerPrefs.SetInt("score",Score_ofthegame);
        Timer.value = countdown;
        if(countdown <= 0)
        {
            click_version_2.instance_Clicker.check_won_or_lose_condition = 0;
            PlayerPrefs.SetInt("audiown", click_version_2.instance_Clicker.check_won_or_lose_condition);
            ChangeScene();
        }

          
        
    }
    public void ChangeScene()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
