// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//$(document).ready(function () {
//    $('#first').click(function () {
//        $('#location').fadeOut();
//        $('#units').slideUp;

//    });
//    $('#second').click(function () {
//        $('#units').fadeOut();
//        $('#unitsTable').slideUp;

//    });


//});
function NextPage(page) {
    var firstCont = document.getElementById("location");
    var secondCont = document.getElementById("units");
    var thirdCont = document.getElementById("unitsTable");
    var fourthCont = document.getElementById("submit");

    switch (page) {
        case 1:
            firstCont.setAttribute("hidden", true);
            secondCont.removeAttribute("hidden");
            break;
        case 2:
            secondCont.setAttribute("hidden", true);
            thirdCont.removeAttribute("hidden");
            fourthCont.removeAttribute("hidden");
            break;
        default:
            break;
    }
}
function PreviousPage(page) {
    var submit = document.getElementById("submit");
    var thirdCont = document.getElementById("unitsTable");
    var secondCont = document.getElementById("units");
    var firstCont = document.getElementById("location");

    switch (page) {
        case 3:
            submit.setAttribute("hidden", true);
            thirdCont.setAttribute("hidden", true);
            secondCont.removeAttribute("hidden");
            break;
        case 2:
            secondCont.setAttribute("hidden", true);
            firstCont.removeAttribute("hidden");
            break;
        default:
            break;
    }
}
// Write your JavaScript code.
function OnNumberSelected() {
    var selectBox = document.getElementById("nbrUnits");
    var selectedValue = selectBox.options[selectBox.selectedIndex].value;
    GenerateTableRows(selectedValue);

}
function GenerateTableRows(rows) {
    //Create a table dynamically.
    var tbody = document.getElementById("tableBody");
    if (tbody.children.length > 0) {
        var tbodyLength = tbody.children.length;
        for (i = 0; i < tbodyLength; i++) {
            var child = document.getElementById("tr" + i);
            tbody.removeChild(child);
        }
    }                                      

    for (i = 0; i < rows; i++) {
        //Creating rows
        var tr = document.createElement("tr");
        tr.id = "tr" + i;


        //Creating table datas
        var td1 = document.createElement("td");
        var td2 = document.createElement("td");

        //Creating the select list(dropdown)
        var select = document.createElement("select");
        select.class = "form-control";
        select.name = "UnitType";
        select.id = "Units" + i;
        select.setAttribute("data-width", "10%");
        /*select.setAttribute("onchange", OptionSelected());*/

        //Creating the dropdown options
        var optionDefault = document.createElement("option");
        optionDefault.value = "DefaultMessage";
        optionDefault.text = "-{- Select Type of Room -}-";

        var option = document.createElement("option");
        option.value = "basement";
        option.text = "Basement";

        var option1 = document.createElement("option");
        option1.value = "bathroom";
        option1.text = "Bathroom";

        var option2 = document.createElement("option");
        option2.value = "bedroom";
        option2.text = "Bedroom";

        var option3 = document.createElement("option");
        option3.value = "diningroom";
        option3.text = "Dining Room";

        var option4 = document.createElement("option");
        option4.value = "entrance";
        option4.text = "Entrance";

        var option5 = document.createElement("option");
        option5.value = "garage";
        option5.text = "Garage";

        
        var option6 = document.createElement("option");
        option6.value = "kitchen";
        option6.text = "Kitchen";

        var option7 = document.createElement("option");
        option7.value = "livingroom";
        option7.text = "Living Room";

        var option8 = document.createElement("option");
        option8.value = "stairs";
        option8.text = "Stairs";

        //Appending the options to the dropdown
        select.appendChild(optionDefault);
        select.appendChild(option);
        select.appendChild(option1);
        select.appendChild(option2);
        select.appendChild(option3);
        select.appendChild(option4);
        select.appendChild(option5);
        select.appendChild(option6);
        select.appendChild(option7);
        select.appendChild(option8);

        //Appending the select list to the first colum of the table
        td1.appendChild(select);



        //Creating the div container of future generated textboxes
        var div = document.createElement("div");
        div.id = "selection";


        var textBoxt = document.createElement("input");

        //Assign different attributes to the element.
        textBoxt.setAttribute("type", "text");
        textBoxt.setAttribute("value", "0");
        textBoxt.setAttribute("name", "area");
        textBoxt.setAttribute("class", "form-control");
        textBoxt.setAttribute("placeholder", "Enter the room's area");
        textBoxt.setAttribute("id", "textbox" + i);
        //textBoxt.addEventListener('focusout', function () {
        //    if (isNaN(textBoxt.value)) {
        //        document.getElementById("ShowError").innerHTML = "The area is not a number";
        //    }
        //    else {
        //        document.getElementById("ShowError").innerHTML = "";
        //    }
            
        //});

        //Appending the container to the second column
        td2.appendChild(textBoxt);

        //Apppending columns to rows
        tr.appendChild(td1);
        tr.appendChild(td2);

        tbody.appendChild(tr);
    }
}

//function ValidatingTextBox(textName) {
    
//    var value = document.getElementById(textName).value;

//    if (isNaN(value)) {
//        alert('Area must be a number');
//    }
//}

function OptionSelected() {
    var selectBox = document.getElementById("Units");
    var selectedValue = selectBox.options[selectBox.selectedIndex].value;
    GenerateBox(selectedValue);
}
function GenerateBox(value) {
    counter = 2;
    //Create an input type dynamically.
    var element = document.createElement("input");

    //Create Labels
    var label = document.createElement("Label");
    label.innerHTML = "New Label";

    //Assign different attributes to the element.
    element.setAttribute("type", "text");
    element.setAttribute("value", "");
    element.setAttribute("name", "area");
    element.setAttribute("class", "form-control");
    element.setAttribute("placeholder", "Enter the room's area");
    element.setAttribute("id", "textbox" + i);


    // 'foobar' is the div id, where new fields are to be added
    var foo = document.getElementById("selection");

    //Append the element in page (in span).
    foo.appendChild(element);
    counter++;
}