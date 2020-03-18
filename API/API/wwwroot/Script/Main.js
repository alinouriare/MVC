$(document).ready(function () {
    function myfunction() {
        $.ajax({

            type: "Get",
            url: "/Api/Person",
            dataType: "Json",
            success: function (data) {


                $.each(data, function (index, obj) {

                    row += "<tr><td>" + obj.id + "</td>" + "<td>" + obj.firstName + "</td>" + "<td>" + obj.lastName + "</td></tr>";
                });

                $("#tbDetails tbody").append(row);
            }


        });
    }

    var row = "";
    $("#cd").click(function () {

        myfunction();

    });

    $("#my_form").submit(function (event) {
        event.preventDefault(); //prevent default action 
   
        var request_method = $(this).attr("method"); //get form GET/POST method
        var form_data = $(this).serialize(); //Encode form elements for submission

        $.ajax({
            url: "/Home/ttt",
            type: request_method,
            data: form_data
        }).done(function (response) {
            //console.log(response.status);
            //alert(response.status);
            myfunction();
        });
    });

  

    


  

});






