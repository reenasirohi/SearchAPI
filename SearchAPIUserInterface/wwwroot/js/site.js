// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

$(document).ready(function () {

    $('#table').hide();

    $("#btnSearch").click(function () {
        var url = "https://localhost:44317/user/";
        var searchData = document.getElementById("txtSearch").value;
        var lblMessage = document.getElementById("lblMessage");


        if (searchData === "") {
            lblMessage.textContent = "You did not provide a search input"
            lblMessage.style.color = "red"
            $('#table').hide();

        }
        else {
            $('#table').show();

            fetch(url + searchData)
                .then(res => {
                    return res.json();
                })
                //.then(data => console.log(data))
                //        .catch(error => console.log(error))

                .then(function (data) {                   
                        displayData(data);                    
                })
                .catch(function (err) {
                    console.log('error: ' + err);
                });

            function displayData(data) {

                var html = '';
                $("#table").find("tr:not(:first)").remove();
                html += '<tbody>';
                $.each(data, function (key, value) {

                    html += '<tr>';
                    html += '<td>' + value.first_Name + '</td>';
                    html += '<td>' + value.last_Name + '</td>';
                    html += '<td>' + value.email + '</td>';
                    html += '<td>' + value.gender + '</td>';
                    html += '</tr>';
                });
                html += '</tbody>';
                $('#table').append(html);

            }
            lblMessage.textContent = "";
        }

    });
});

