using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataControl : MonoBehaviour {
    string urlData = "http://localhost/datatestinput/datainsert.php"; // To identify URL access script insert data.

    /// <summary>
    /// This method is used to Add data from unity into MySql Database.
    /// </summary>
    /// <param name="tot_time">The variable that is valued by total time playing</param>
    /// <param name="tot_bookCorrectlyRight">the variable that valued by total correct book from right bin</param>
    /// <param name="tot_bookCorrectlyLeft">the variable that is valued by total correct book from left bin</param>
    /// <param name="tot_bookCorrectlyFront">the variable that is valued by total correct book from front bin</param>
    /// <param name="tot_bookIncorrectly">the variable that is valued by total incorrect book from each bin</param>
    /// <param name="tot_timeHoldBook">the variable that is valued by total time when player holding each book</param>
    /// <param name="tot_timeLookDesk">the variable that is valued by total time when player looking at desk</param>
    /// <param name="tot_timeLookNonDesk">the variable that is valued by total time when player not looking at desk</param>
    /// <param name="tot_instructionRepeat">the variable that is valued by total player repeat the instruction</param>
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
