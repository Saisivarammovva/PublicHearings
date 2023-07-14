function Option1() {
    var option1Textboxes = document.getElementById('option1Textboxes');
    var option2Textboxes = document.getElementById('option2Textboxes');

    option1Textboxes.style.display = 'block';
    option2Textboxes.style.display = 'none';
}

function Option2() {
    var option1Textboxes = document.getElementById('option1Textboxes');
    var option2Textboxes = document.getElementById('option2Textboxes');
     
    option1Textboxes.style.display = 'none';
    option2Textboxes.style.display = 'block';
}

$(function () {
    $('#txtDate').datepicker({
        autoclose: true,
        format: 'dd/mm/yyyy',
        endDate: new Date()
    });
});

function validateForm() {
    var HearingName = document.getElementById("HearingNametxt");
    var HearingVenue = document.getElementById("HearingVenuetxt");
    var calendarControl = document.getElementById("txtDate");
    var HearingTime = document.getElementById("HearingTimetxt");
    var LineOfActivity = document.getElementById("LineOfActivitytxt");
    var RegionalOffice = document.getElementById("RegionalOfficetxt");
    var fileUploadControl1 = document.getElementById("FileUpload1");
    var fileUploadControl2 = document.getElementById("FileUpload2");
    var fileUploadControl3 = document.getElementById("FileUpload3");
    var fileUploadControl4 = document.getElementById("FileUpload4");
    var fileUploadControl5 = document.getElementById("FileUpload5");

    if (HearingName.value.trim() == "") {
        alert("Please enter some text for Hearing Name & Location");
        HearingName.focus();
        return false;
    } else if (HearingName.value.trim().length > 100) {
        alert("Hearing Name & Location field should not contain more than 100 character's ");
        HearingName.focus();
        return false;
    } else if (!/^[a-zA-Z.,]+$/.test(HearingName.value)) {
        alert(" Enter valid text in Hearing Name & Location");
        HearingName.focus();
        return false;
    }
    if (HearingVenue.value.trim() == "") {
        alert("Please enter some text for Hearing Venue");
        HearingVenue.focus();
        return false;
    } else if (HearingVenue.value.trim().length > 100) {
        alert("Hearing Venue should not contain more than 100 character's");
        HearingVenue.focus();
        return false;
    } else if (!/^[a-zA-Z.,]+$/.test(HearingVenue.value)) {
        alert(" Enter valid text in  Hearing Venue ");
        HearingVenue.focus();
        return false;
    }

    if (calendarControl.value.trim() == "") {
        alert("Please select a date.");
        calendarControl.focus();
        return false;
    }

    const timeRegex = /^(0?[1-9]|1[0-2]|2[0-4]):([0-5][0-9]) ([AP]M)|([ap]m)$/;
    if (HearingTime.value.trim() == "") {
        alert("Please enter Hearing Time  ");
        HearingTime.focus();
        return false;
    } else if (!timeRegex.test(HearingTime.value.trim())) {
        alert("Please enter valid Hearing Time");
        HearingTime.focus();
        return false;

    }

    if (LineOfActivity.value.trim() == "") {
        alert("Please enter some text for Line Of Activity ");
        LineOfActivity.focus();
        return false;
    } else if (LineOfActivity.value.trim().length > 100) {
        alert("should not contain  more than 100 character's");
        LineOfActivity.focus();
        return false;
    } else if (!/^[a-zA-Z.,]+$/.test(LineOfActivity.value)) {
        alert(" Enter valid text in  Line Of Activity ");
        LineOfActivity.focus();
        return false;
    }
    if (RegionalOffice.value.trim() == "") {
        alert("Please enter some text for Regional Office");
        RegionalOffice.focus();
        return false;
    } else if (RegionalOffice.value.trim().length > 100) {
        alert("should not contain  more than 100 character's");
        RegionalOffice.focus();
        return false;
    } else if (!/^[a-zA-Z.,]+$/.test(RegionalOffice.value)) {
        alert(" Enter valid text in Regional Office");
        RegionalOffice.focus();
        return false;
    }

    var fileExtension = fileUploadControl1.value.split('.').pop().toLowerCase();
    if (fileUploadControl1.value.trim() == "" || fileExtension !== "pdf") {
        alert("Please upload Executive summary-Telugu  in PDF formate.");
        fileUploadControl1.focus();
        return false;
    }

    var fileExtension = fileUploadControl2.value.split('.').pop().toLowerCase();
    if (fileUploadControl2.value.trim() == "" || fileExtension !== "pdf") {
        alert("Please upload Executive summary-English  in PDF formate.");
        fileUploadControl2.focus();
        return false;
    }

    var fileExtension = fileUploadControl3.value.split('.').pop().toLowerCase();
    if (fileUploadControl3.value.trim() == "" || fileExtension !== "pdf") {
        alert("Please upload EIA report in PDF formate.");
        fileUploadControl3.focus();
        return false;
    }

    //var fileExtension = fileUploadControl4.value.split('.').pop().toLowerCase();
    //if (fileUploadControl4.value.trim() == "" || fileExtension !== "pdf") {
    //    alert("Please upload Other Document 1 in PDF formate.");
    //    fileUploadControl4.focus();
    //    return false;
    //}
    //var fileExtension = fileUploadControl5.value.split('.').pop().toLowerCase();
    //if (fileExtension !== "pdf") {
    //    alert("Please upload Other Document 2 in PDF formate.");
    //    fileUploadControl5.focus();
    //    return false;
    //}
    alert("Data submitted successfully!");

    return true;
}

function charcount() {
    var HearingName = document.getElementById("HearingNametxt");
    var namecount = HearingName.value.length;
    if (namecount > 2000) {
        HearingName.value = HearingName.value.substring(0, 2000);
        namecount = 2000;
        alert("Maximum Length (2000) Exceeded");
        HearingName.focus();
        return false;
    }
    var charlength = "2000";
    document.getElementById("namecount").innerHTML = charlength - namecount + "characters remaining";
   
}

function Validate() {
    var meetingfile = document.getElementById("meetingfile");

    var fileExtension = meetingfile.value.split('.').pop().toLowerCase();
    if (meetingfile.value.trim() == "" || fileExtension !== "pdf") {
        alert("Please upload meeting file  in PDF formate.");
        meetingfile.focus();
        return false;
    }

    alert("Data submitted successfully!");
    return true;

}