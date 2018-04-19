function getUserById() {
    $.ajax({
        type: "POST",
        url: "http://127.0.0.1:80/api/noteuser/GetUserById",
        data: { "RequestData": { "UserId": 1 }, "UserId": 1, "Token": "8d0003af-541c-4d86-8a4e-5437d79a964f", "Version": "V1.0" },
        success: function(data) {
            console.log(data);
        },
        error: function() {
            alert("错误");
        }
    });
}