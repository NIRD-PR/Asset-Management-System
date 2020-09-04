$(document).ready(function () {

    var currentPROMRowid = null;
    var fPROMPath = null;
    //var jsonRes = null, jsonResObj = [];
    //var adata = null;
    //var jsonObj = [];

    displayPROMdata();

    $("#btnPromSave").click(function () {
        $(".b1").val("Add+");
        try {
            var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.pdf)$/;
            if (regex.test($("#PrmofficeOrder").val().toLowerCase())) {
                var file = $("#PrmofficeOrder").get(0).files[0];
                var f = file.name.split(".");
                //alert(file.name);
                //Renaming file to be uploaded
                filename = "Prom_" + (new Date()).getTime() + ".pdf";
                //uploading file                
                fPROMPath = "Uploads/PromotionHistory/" + filename;
                uploadPROMFile("#ProProgress", file, filename, fPROMPath, currentPROMRowid);
                currentPROMRowid = null;
            }
            else {
                //alert(sess);
                alert("<strong>Danger!</strong> Please select a valid PDF file to Upload.", "alert alert-danger", "");
            }
        }
        catch (e) { throw e; }
        return false;
    });



    $(document).on('click', 'span.editrowProm', function () {
        currentPROMRowid = $(this).closest('tr').find('td.PROMSno').text();
        //alert(currentPROMRowid);
        $(".b").val("Update");
        currentRow = $(this).parents('tr');
        $(".a1").val($(this).closest('tr').find('td.txtDoPr').text());
        $(".a2").val($(this).closest('tr').find('td.txtDesPromoted').text());
        $(".a3").val($(this).closest('tr').find('td.txtPrevDes').text());
        $(".a4").val($(this).closest('tr').find('td.txtNewSal').text());
        $(".a5").val($(this).closest('tr').find('td.txtPrevSal').text());
        $(".a6").val($(this).closest('tr').find('td.txtRemarks').text());
        fPROMPath = $(this).closest('tr').find('td.PrmofficeOrder a').attr('href');
        //$('#upfile').prop('href', fPROMPath);
        // $('#upfile').show();
        $('#PrmofficeOrder').prop('required', false);
    });

    $(document).on('click', 'span.deletePROMrow', function () {
        currentPROMRowid = $(this).closest('tr').find('td.PROMSno').text();
        if (confirm("Are you sure to delete this entry ?")) {
            //            delete jsonObj[currentPROMRowid];
            //            $(this).parents('tr').remove();
            //            var res = JSON.stringify(jsonObj).replace(',null', '').replace('null,', '').replace('null', '');
            //            sessionStorage.jsondata = res;
            //alert(currentPROMRowid);
            deletePROMRecord(currentPROMRowid);
            currentPROMRowid = null;
            //alert(currentPROMRowid);
            //alert("<strong>Info!</strong> After Delete Operation, Please Save Data by using Save Button.", "alert alert-info", "");
        }

        return false;
    });

    function deletePROMRecord(cid) {
       // alert(cid);
        $.ajax({
            type: "POST",
            url: "services.aspx/DeletePromotionDetails",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            data: JSON.stringify({ SNo: cid }),
            processData: false,
            success: function (result) {
                alert("Entry deleted successfully...", "");
                resetPROM();
                displayPROMdata();
            },
            error: function (result) {
                alert(JSON.parse(result.responseText).Message, "alert alert-danger", "");
            }
        });

    }

    $(".r").on("click", function () {
        if ($(".r:checked").val() == "Yes")
            $(".fb").show();
        else
            $(".fb").hide();
    });



    uploadPROMFile = function (fileProgressID, fl, fileRename, fPROMPath, currentPROMRowid) {
        var formData = new FormData();
        formData.append('file', fl, fileRename);
        $.ajax({
            url: 'HandlerCS.ashx',
            type: 'POST',
            data: formData,
            cache: false,
            contentType: false,
            processData: false,
            success: function (file) {
                $(fileProgressID).hide();
                if (currentPROMRowid == null) {
                    savePROMdata(fPROMPath);
                }
                else {
                    updatePROMdata(currentPROMRowid, fPROMPath);
                }
            },
            xhr: function () {
                var fileXhr = $.ajaxSettings.xhr();
                if (fileXhr.upload) {
                    $(fileProgressID).show();
                    fileXhr.upload.addEventListener("progress", function (e) {
                        if (e.lengthComputable) {
                            $(fileProgressID).attr({
                                value: e.loaded,
                                max: e.total
                            });
                        }
                    }, false);
                }
                return fileXhr;
            }
        });
    }

    function savePROMdata(fPROMPath) {
        //alert(fPROMPath);
        $.ajax({
            type: "POST",
            url: "services.aspx/SavePromotionDetails",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            data: JSON.stringify({ Dopr: $('#txtDoPr').val(), DesgPromtd: $('#txtDesPromoted').val(), PrevDesg: $("#txtPrevDes").val(), Newsal: $("#txtNewSal").val(), PrevSal: $('#txtPrevSal').val(), remarks: $('#txtRemarks').val(), OOrder: fPROMPath }),
            processData: false,
            success: function (result) {
                alert("Data saved successfully...", "");
                resetPROM();
                displayPROMdata();
            },
            error: function (result) {
                alert(JSON.parse(result.responseText).Message, "alert alert-danger", "");
            }
        });
    }
    function updatePROMdata(id, fPROMPath) {
        //alert('update call');
        $.ajax({
            type: "POST",
            url: "services.aspx/UpdatePromotionDetails",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            data: JSON.stringify({ DoPr: $('#txtDoPr').val(), DePro: $('#txtDesPromoted').val(), PrevDes: $("#txtPrevDes").val(), NewSal: $("#txtNewSal").val(), PrevSal: $('#txtPrevSal').val(), remarks: $('#txtRemarks').val(), Certificate: fPROMPath, SNo: id }),
            processData: false,
            success: function (result) {
                alert("Data updated successfully...", "");
                resetPROM();
                displayPROMdata();
            },
            error: function (result) {
                alert(JSON.parse(result.responseText).Message, "alert alert-danger", "");
            }
        });
    }
    function populatePROMtable(data) {

        var str = "<div class='table-responsive'><table id='t' class='table table-striped table-hover'><thead class='thead-dark'><tr><th >#</th><th>Date of Promotion</th><th>New Designation</th><th>Previous Designation</th><th>New Salary</th><th>Previous Salary</th><th>Remarks</th><th style='display:none;'>S.No</th><th>Certificate</th><th>Action</th></tr></thead><tbody>";

        var k = 1;
        for (var i in data) {

            str = str + "<tr id='" + i + "'><td class='text-center'>" + (k++) + "</td><td class='txtDoPr'>" + data[i].DoP + "</td><td class='txtDesPromoted'>" + data[i].DesPromoted + "</td><td class='txtPrevDes'>" + data[i].PrevDes + "</td><td class='txtNewSal text-center'>" + data[i].NewSalary + "</td><td class='txtPrevSal text-center'>" + data[i].PrevSalary + "</td><td class='remarks'>" + data[i].Remarks + "</td><td class='PROMSno' style='display:none;'>" + data[i].SNo + "</td><td class='PrmofficeOrder'><a href='" + data[i].cet + "' target='_blank'><center><span style='font-size:15px;' class='glyphicon glyphicon-eye-open'></span></center></a></td><td><span class='deletePROMrow'><a class='glyphicon glyphicon-trash' style='font-size:15px;color:red;' href=''></a></span></td></tr>"; //<span class='editrowProm'><a class='fa fa-edit' style='font-size:15px;color:blue;' href='javascript: void(0);'></a></span>&nbsp;&nbsp;&nbsp;
        }

        str = str + "</tbody></table></div>";

        return str;
    }
    function displayPROMdata() {
        $.ajax({
            type: "POST",
            url: "Services.aspx/getPRPromotionDetails",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            //data: JSON.stringify({ state: $('#ddlState').val(), theme: $('#ddlTheme').val(), subTheme: $("#dllSubTheme").val(), cate: $("#ddlCat").val() }),
            async: false,
            processData: false,
            success: function (result) {
                //alert(result.d);
                var jResPROM = JSON.parse(result.d);

                if (jResPROM) {
                    $(".Prmt").html(populatePROMtable(jResPROM));
                }
                else {
                    $(".Prmt").html("<div class='alert alert-danger alert-dismissable'>Sorry, No records found ...</div>");
                }

            },
            error: function (result) {
                alert(JSON.parse(result.responseText).Message);
            }
        });
    }


    function resetPROM() {
        $(".a1").val("");
        $(".a2").val("");
        $(".a3").val("");
        $(".a4").val("");
        $(".a5").val("");
        $(".a6").val("");
        $(".a7").val("");
        //    $(".a8").val("");
        //    $(".a9").val("");
        //    $(".a10").val("");
        //  $('#upfile').hide();    
    }
});