using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
   private int Score;
   
   private static ScoreKeeper Instance;
    
   private void Awake()
   {
      ManageSingleton();
   }

   void ManageSingleton()
   {
      if(Instance != null)
      {
         gameObject.SetActive(false);
         Destroy(gameObject);
      }
      else
      {
         Instance = this;
         DontDestroyOnLoad(gameObject);
      }
   }

   public int GetScore()
   {
      return Score;
   }

   public void ModifyScore(int value)
   {
      Score += value;
      Mathf.Clamp(Score, 0, int.MaxValue);
      Debug.Log(Score);
   }

   public void ResetScore()
   {
      Score = 0;
   }
}
