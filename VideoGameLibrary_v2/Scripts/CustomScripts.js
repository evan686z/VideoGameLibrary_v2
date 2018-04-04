function ShowHideInputForms(TagID) {

    //Code Found At: 
    //Site Name: W3Schools
    //Site https://www.w3schools.com/howto/howto_js_toggle_hide_show.asp

    var x = document.getElementById(TagID);

    if (x.style.display === "none") {

        x.style.display = "block";

    } else {

        x.style.display = "none";

    }
}