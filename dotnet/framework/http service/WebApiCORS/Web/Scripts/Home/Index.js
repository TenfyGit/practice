//jQuery.support.cors = true;
var ApiUrl = "http://localhost:61927/";
$(function () {
    $.ajax({
        type: "get",
        url: ApiUrl + "api/Charging/GetAllChargingData",
        data: {},
        //beforeSend: function (XHR) {
        //    //發送ajax請求之前向http的head裡面加入驗證信息
        //    XHR.setRequestHeader('Authorization','BasicAuth ' + Ticket);
        //},
        success: function (data, status) {
            if (status = "success") {
                $("#div_test").html(data);
            }
        },
        error: function (e) {
            $("#div_test").html("Error");
        },
        complete: function () {

        }
    });
});