using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceptorTrigger : MonoBehaviour {

    public GameObject receptor;
    char[] ligOrder = new char[30];
    public Object ligA;
    public Object ligB;
    public Object ligC;
    public Object ligD;
    public Object ligE;

    public void Start()
    {
        ligOrder[0] = 'A';
        ligOrder[1] = 'A';
        ligOrder[2] = 'A';
        ligOrder[3] = 'A';
        ligOrder[4] = 'B';
        ligOrder[5] = 'B';
        ligOrder[6] = 'C';
        ligOrder[7] = 'A';
        ligOrder[8] = 'B';
        ligOrder[9] = 'D';
        ligOrder[10] = 'C';
        ligOrder[11] = 'D';
        ligOrder[12] = 'B';
        ligOrder[13] = 'B';
        ligOrder[14] = 'D';
        ligOrder[15] = 'E';
        ligOrder[16] = 'D';
        ligOrder[17] = 'C';
        ligOrder[18] = 'C';
        ligOrder[19] = 'A';
        ligOrder[20] = 'D';
        ligOrder[21] = 'C';
        ligOrder[22] = 'A';
        ligOrder[23] = 'A';
        ligOrder[24] = 'D';
   
        ligOrder[25] = 'E';
        ligOrder[26] = 'E';
        ligOrder[27] = 'E';

    }

    public Object getNextLig(int index)
    {
        Debug.Log("Spawning Ligand " + ligOrder[index]);
        if (ligOrder[index] == 'A')
        {
            return ligA;
        }
       else if (ligOrder[index] == 'B')
        {
            return ligB;
        }
        else if (ligOrder[index] == 'C')
        {
            return ligC;
        }
        else if (ligOrder[index] == 'D')
        {
            return ligD;
        }
        else if (ligOrder[index] == 'E')
        {
            return ligE;
        }
        else return ligA;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D ligand)
    {
        Debug.Log("Ligand type '" + ligand.GetComponent<Ligand>().ligandType + "' has collided with receptor type '" + receptor.GetComponent<Receptor>().receptorType + "'.");
        if (ligand.GetComponent<Ligand>().ligandType == receptor.GetComponent<Receptor>().receptorType && receptor.GetComponent<Receptor>().spriteRenderer.sprite != receptor.GetComponent<Receptor>().bound)
        {
            StartCoroutine(LigandTransition (ligand));
        }
    }

    IEnumerator LigandTransition(Collider2D ligand) {
        int nextIndex = ligand.GetComponent<Ligand>().ligIndex + 1;
        Object nextLig = getNextLig(nextIndex);
        receptor.SendMessage("bindToLigand");
        ligand.SendMessage("bindToReceptor");
        yield return new WaitForSeconds(1.0f);
        GameObject lig = (GameObject) Instantiate(nextLig);
        lig.GetComponent<Ligand>().ligIndex = nextIndex;
        Camera.main.GetComponent<FollowLigand>().SendMessage("setFollow", lig);
    }

}
