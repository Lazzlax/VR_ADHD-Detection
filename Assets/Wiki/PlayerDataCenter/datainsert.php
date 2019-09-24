<?php
	include('connection.php'); // To send data with address from the connection.
	
	$tot_Time = $_POST['addTot_Time'];	// Form field for total time.
	$tot_BookCorrRight	= $_POST['addTot_BookCorrRight'];	// Form field for total correctly book from right bin.
	$tot_BookCorrLeft	= $_POST['addTot_BookCorrLeft'];	// Form field for total correctly book from left bin.
	$tot_BookCorrFront	= $_POST['addTot_BookCorrFront'];	// Form field for total correctly book from front bin.
	$tot_BookInCorr		= $_POST['addTot_BookInCorr'];		// Form field for total incorrectly book from each bin.
	$tot_TimeHoldBook	= $_POST['addTot_TimeHoldBook'];	// Form field for total time when player holding each book.
	$tot_TimeLookDesk	= $_POST['addTot_TimeLookDesk'];	// Form field for total time when player look at desk.
	$tot_TimeLookNonDesk	= $_POST['addTot_TimeLookNonDesk'];		// form field for total time when player not look at desk.
	$tot_InstructionRepeat	= $_POST['addTot_InstructionRepeat'];	// form field for total player repeat the instruction.
	
	$sql = "INSERT INTO playerdata (total_Time, total_BookCorrRight, total_BookCorrLeft, total_BookCorrFront, total_BookInCorr, total_TimeHoldBook, total_TimeLookDesk, total_TimeLookNonDesk, total_InstructionRepeat) 
	VALUES ('$tot_Time','$tot_BookCorrRight','$tot_BookCorrLeft','$tot_BookCorrFront','$tot_BookInCorr','$tot_TimeHoldBook','$tot_TimeLookDesk','$tot_TimeLookNonDesk','$tot_InstructionRepeat')";
	$result = mysqli_query($connect, $sql);
?>