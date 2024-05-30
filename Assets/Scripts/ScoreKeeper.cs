using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
   private int Score;

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
