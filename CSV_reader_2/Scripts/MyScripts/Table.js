function sortTable(columnNumber, isNamber) {
    let rows, i, x, y, shouldSwitch;
    let switchcount = 0;
    let switching = true;
    let dir = "asc";

    rows = document.getElementById("myTable").getElementsByTagName("TR");

    while (switching) {
        switching = false;
        
        for (i = 1; i < (rows.length - 1); i++) {
            shouldSwitch = false;

            x = getText(rows[i].getElementsByTagName("TD")[columnNumber]);
            y = getText(rows[i + 1].getElementsByTagName("TD")[columnNumber]);

            if (isNamber) {
                x = +x;
                y = +y;
            }
            if ( (dir == "asc" && x > y) || (dir == "desc" && x < y) ) {
                shouldSwitch = true;
                break;                
            }
        }
        if (shouldSwitch) {
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;

            switchcount++;
        } else if (switchcount == 0 && dir == "asc") {
            dir = "desc";
            switching = true;            
        }
    }
}

function getText(td) {
    if (td.getElementsByTagName('input').length > 0) {
        if (td.getElementsByTagName('input')[0].type == "checkbox")
            return td.firstChild.checked + "";
        else
            return td.firstChild.value.trim();
    }
    return td.innerHTML.trim();
}

function editPerson(id) {
    let maxWidtharr = ["150px", "150px", "150px", "50px", "150px","150px"];
    let tdTape = ["","text", "date", "checkbox", "text", "number"];
    let rows = document.getElementById("myTable").getElementsByTagName("TR");

    for (i = 1; i < rows.length; i++) {
        var td = rows[i].getElementsByTagName("TD");
        if (td[0].innerHTML == id) {
            for (let j = 1; j < td.length - 1; j++) {

                var input = document.createElement('input');
                input.style.maxWidth = maxWidtharr[j];

                let s = td[j].innerHTML.trim();
                input.type = tdTape[j];
                input.value = s;
                if (j == 3)
                    input.checked = s == "true";

                td[j].innerHTML = "";
                td[j].appendChild(input);
            }
            var edit = td[td.length - 1].getElementsByTagName("input")[0];
            edit.value = "Save";
            edit.onclick = () => { saveBook(id) };
        }
    }
}

function saveBook(id) {
    var datatext = [];
    var rows = document.getElementById("myTable").getElementsByTagName("TR");
    datatext[0] = id;

    for (i = 1; i < rows.length; i++) {
        var td = rows[i].getElementsByTagName("TD");

        if (td[0].innerHTML == id) {
            for (let j = 1; j < td.length - 1; j++) {
                var text = td[j].firstChild.value;

                if (j == 3)
                    text = td[j].firstChild.checked + '';

                td[j].removeChild(td[j].firstChild);
                td[j].innerHTML = text;
                datatext[j] = text;
            }

            var edit = td[td.length - 1].getElementsByTagName("input")[0];
            edit.value = "Edit";
            edit.onclick = () => { EditBook(id) };

            $.ajax({
                type: "POST",
                url: "/Home/Edit",
                data: {
                    'id': id,
                    'name': datatext[1],
                    'data': datatext[2],
                    'married': datatext[3],
                    'phone': datatext[4],
                    'salary': datatext[5]
                }
            });
            
            break;
        }
    }
}