$(function () {
    $("#btn_login").click(function () {
        $.ajax({
            type: "get",
            url: "http://localhost:61927/api/User/Login",
            data: { strUser: $("#txt_username").val(), strPwd: $("#txt_password").val() },
            success: function (data, status) {
                if (status == "success") {
                    if (!data.bRes) {
                        alert("登录失败");
                        return;
                    }
                    alert("登录成功");
                    //登录成功之后将用户名和用户票据带到主界面
                    window.location = "/Home/Index?UserName=" + data.UserName + "&Ticket=" + data.Ticket;
                }
            },
            error: function (e) {
            },
            complete: function () {

            }

        });
    });
});