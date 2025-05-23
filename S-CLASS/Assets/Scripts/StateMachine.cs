using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    // Start is called before the first frame update
    public List<State> state;
    public List<State> condition;

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < state.Count(); i++){
            if(conditionp[i].CheckCondition()){
                state[i].SetActive(true);
            }
            else{
                state[i].SetActive(false);
            }
        }
    }
}
