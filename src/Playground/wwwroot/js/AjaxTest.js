function getText() {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (xhttp.readyState == 4 && xhttp.status == 200) {
            document.getElementById("plain_text").innerHTML = xhttp.responseText;
        }
    };
    xhttp.open("GET", "/AjaxTest/GetText", true);
    xhttp.send();
}

function getTextNumber(number) {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (xhttp.readyState == 4 && xhttp.status == 200) {
            document.getElementById("text_number").innerHTML = xhttp.responseText;
        }
    };
    xhttp.open("GET", "/AjaxTest/GetTextWithNumber?number=" + number, true);
    xhttp.send();
}

function showHint(str) {
    if (str.length == 0) {
        document.getElementById("txtHint").innerHTML = "";
        return;
    } else {
        var xmlhttp = new XMLHttpRequest();
        xmlhttp.onreadystatechange = function () {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                document.getElementById("txtHint").innerHTML = xmlhttp.responseText;
            }
        };
        xmlhttp.open("GET", "/AjaxTest/GetHint?text=" + str, true);
        xmlhttp.send();
    }
}

function showHintList(str) {
    if (str.length == 0) {
        document.getElementById("meals_list").innerHTML = "";
        return;
    } else {
        var xmlhttp = new XMLHttpRequest();
        xmlhttp.onreadystatechange = function () {
            if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                document.getElementById("meals_list").innerHTML = xmlhttp.responseText;
            }
        };
        xmlhttp.open("GET", "/AjaxTest/GetHintList?text=" + str, true);
        xmlhttp.send();
    }
}

function getPage() {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (xhttp.readyState == 4 && xhttp.status == 200) {
            document.getElementById("ajax_page").innerHTML = xhttp.responseText;
        }
    };
    xhttp.open("GET", "/AjaxTest/AjaxPage", true);
    xhttp.send();
}

function getHomePage() {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (xhttp.readyState == 4 && xhttp.status == 200) {
            document.getElementById("ajax_page").innerHTML = xhttp.responseText;
        }
    };
    xhttp.open("GET", "/AjaxTest/AjaxHomePage", true);
    xhttp.send();
}

function getAnyPage() {
    var anyURL = document.getElementById('webURL').value;
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (xhttp.readyState == 4 && xhttp.status == 200) {
            document.getElementById("ajax_page").innerHTML = xhttp.responseText;
        }
    };
    xhttp.open("GET", "/AjaxTest/AnyPage?url=" + anyURL, true);
    xhttp.send();
}