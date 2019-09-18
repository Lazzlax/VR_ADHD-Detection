using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataControl : MonoBehaviour {
    string urlData = "http://localhost/datatestinput/datainsert.php";

    public void AddDataToDB(float tot_time, int tot_bookCorrectlyRight, int tot_bookCorrectlyLeft, int tot_bookCorrectlyFront, int tot_bookIncorrectly, float tot_timeHoldBook, float tot_timeLookDesk, float tot_timeLookNonDesk, int tot_instructionRepeat) {
        WWWForm form = new WWWForm();

        form.AddField("addTot_Time", tot_time.ToString());
        form.AddField("addTot_BookCorrRight", tot_bookCorrectlyRight);
        form.AddField("addTot_BookCorrLeft", tot_bookCorrectlyLeft);
        form.AddField("addTot_BookCorrFront", tot_bookCorrectlyFront);
        form.AddField("addTot_BookInCorr", tot_bookIncorrectly);
        form.AddField("addTot_TimeHoldBook", tot_timeHoldBook.ToString());
        form.AddField("addTot_TimeLookDesk", tot_timeLookDesk.ToString());
        form.AddField("addTot_TimeLookNonDesk", tot_timeLookNonDesk.ToString());
        form.AddField("addTot_InstructionRepeat", tot_instructionRepeat);

        WWW www = new WWW(urlData, form);
    }
}
