$(document).ready(function () {
    $(function () {
        $('#buttonSearch').on('click', function (e) {

            e.preventDefault();

            $.ajax({
                url: 'https://localhost:44314/api/GithubProfileApi/robconery',
                type: "GET",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {

                    var datavalue = data;
                    var myJsonObject = datavalue;
                    console.log(typeof data);
                    // assuming we get one user with the searched name
                    var sth = myJsonObject.Login;

                    // Console.Log("sdf");

                    $("#user_table").after('<tr><td>' + sth + '</td><tr>');

                    alert('search by name successful');
                },
                error: function (result) {
                    alert('error');
                }
            });

        });
    })
});

