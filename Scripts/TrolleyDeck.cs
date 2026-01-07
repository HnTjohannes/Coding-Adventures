using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

[CreateAssetMenu(fileName = "Trolley Deck", menuName = "SO/Deck")]
public class TrolleyDeck : ScriptableObject
{
 //public TrolleyQuestion[] questions;
 public List<TrolleyQuestion> questions;

 public TrolleyQuestion FindQuestionByID(string name)
 {
  for (int i = 0; i < questions.Count; i++)
  {
   if (questions[i].questionID == name) return questions[i];
  }
  
   Debug.LogWarning($"No question with ID {name}");
   return null;
  
 }
 
}
