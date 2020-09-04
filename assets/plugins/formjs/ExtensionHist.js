//$(document).ready(function () {

    var currentEHRowid = null;
    var fEHPath = null;
    //var jsonRes = null, jsonResObj = [];
    //var adata = null;
    //var jsonObj = [];

    displayEHdata();

    function checkForallTabsStatusAtExt() {
        $.ajax({
            type: "POST",
            url: "../ProjectStaff/PGeneral/Services.aspx/getTabStatus",
            //url: "Services.aspx/getTabStatus",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            //data: JSON.stringify({ EmpNo: $("#ddlEmp").val() }),
            data: JSON.stringify({ EmpNo: '' }),
            //data: JSON.stringify({ state: $('#ddlState').val(), theme: $('#ddlTheme').val(), subTheme: $("#dllSubTheme").val(), cate: $("#ddlCat").val() }),
            async: false,
            processData: false,
            success: function (result) {
                //alert('Result : ' + result.d);
                var jResOthFac = JSON.parse(result.d);
                // alert(jResOthFac.Edu);
                if (jResOthFac) {
                    if (jResOthFac.Edu == true && jResOthFac.ExtDtl == true) {
                        $('#nodata').hide();
                        $('#cc').show();
                        //displayEHdata();
                    }
                    else {
                        //alert('No edu');
                        $('#nodata').show();
                        $('#cc').hide();
                        //$("#cc").html("<div class='alert alert-danger alert-dismissable'>Incomplete Profile, Please fill the information in all the previous tabs to view the preview....</div>");
                    }
                }
                else {
                    //aslerT('empty json');
                    $('#nodata').show();
                    $('#cc').hide();
                    // $('#cc').show();
                    //$("#cc").html("<div class='alert alert-danger alert-dismissable'>Incomplete Profile, Please fill the information in all the previous tabs to view the preview....</div>");
                }

            },
            error: function (result) {
                alert(JSON.parse(result.responseText).Message);
            }
        });
    }

    $.ajax({
        type: "POST",
        url: "../ProjectStaff/PGeneral/services.aspx/getDesignations",
        //url: "services.aspx/getDesignations",
        //url: "../PEmp_PSService/getDesignations",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        processData: false,
        success: function (result) {
            //alert(result.d);
            var jResOthFac = JSON.parse(result.d);
//            $('#txtEHDesg')
//                    .empty()
//                    .append('<option value="Select Designation*">Select Designation*</option>');
//            $('#txtEHPrvDesg')
//                    .empty()
//                    .append('<option  value="Select Previous Designation*">Select Previous Designation*</option>')
            for (var i in jResOthFac) {
                $("#txtEHDesg").append('<option value="' + jResOthFac[i].desg + '">' + jResOthFac[i].desg + '</option>');
                $("#txtEHPrvDesg").append('<option value="' + jResOthFac[i].desg + '">' + jResOthFac[i].desg + '</option>');
            }

        },
        error: function (result) {
            alert(JSON.parse(result.responseText).Message);
            //alert((result.responseText));
        }
    });




    $("#btnEHSave").click(function () {
       // $(".b2").val("Add+");
        try {
            if (checkValidationsForServHistory()) {
                var regex = /^([a-zA-Z0-9\s_\\.\-:])+(.pdf)$/;
                if (regex.test($("#fldEHOorder").val().toLowerCase())) {
                    var file = $("#fldEHOorder").get(0).files[0];
                    var f = file.name.split(".");
                    //alert(file.name);
                    //Renaming file to be uploaded
                    filename = "Exten_" + (new Date()).getTime() + ".pdf";
                    //uploading file                
                    //fEHPath = $("#ddlEmp").val() + "_" + filename;
                    fEHPath =  filename;
                    uploadEHFile("#EHProgress", file, filename, fEHPath, currentEHRowid);
                    currentEHRowid = null;
                }
                else {
                    //alert(sess);
                    alert("<strong>Danger!</strong> Please select a valid PDF file to Upload.", "alert alert-danger", "");
                }
            }
            else {
                alert("Client : Please choose all mandatory fields...");
            }
        }
        catch (e) { throw e; }
        return false;
    });

    function checkValidationsForServHistory() {
        var regex = /(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$/;
//        if (!regex.test($('#txtEHDoE').val())) { alert('Required: Please select valid Date.'); return false; }
//        if (!regex.test($('#txtEHDoEB').val())) { alert('Required: Please select valid Date.'); return false; }
//        if (!regex.test($('#txtEHDoEEnd').val())) { alert('Required: Please select valid Date.'); return false; }

        // if ($("#ddlExtType")[0].selectedIndex > 0) {
        if ($("#ddlExtType").val() == 'Promotion' || $("#ddlExtType").val() == 'Salary Adjustment') {
            //alert('prm'); alert($('#txtEHDesg')[0].checkValidity()); alert($('#txtEHPrvDesg')[0].checkValidity());
            if ($('#ddlExtType')[0].checkValidity() && $('#txtEHDoE')[0].checkValidity() && regex.test($('#txtEHDoE').val()) && $('#txtEHDoEB')[0].checkValidity() && regex.test($('#txtEHDoEB').val()) && $('#txtEHDesg')[0].checkValidity() && $('#txtEHPrvDesg')[0].checkValidity() && $('#txtEHNewsal')[0].checkValidity() && $('#txtEHPrevSal')[0].checkValidity()) {
                //return createExtnJSON('opt');
                return true
            }
            else {
                return false;
            }
        }
        else {
            if ($('#ddlExtType')[0].checkValidity() && $('#txtEHDoE')[0].checkValidity() && regex.test($('#txtEHDoE').val()) && $('#txtEHDoEB')[0].checkValidity() && regex.test($('#txtEHDoEB').val()) && $('#txtEHDoEEnd')[0].checkValidity() && regex.test($('#txtEHDoEEnd').val()) && $('#txtEHDesg')[0].checkValidity() && $('#txtEHPrvDesg')[0].checkValidity() && $('#txtEHNewsal')[0].checkValidity() && $('#txtEHPrevSal')[0].checkValidity()) {
                //alert('validated');
                //return createExtnJSON('man');
                return true;
            }
            else {
                return false;
            }
        }
        //}        
    }

    function createExtnJSON(type) {
        item = {}
        var jsonObj = [];
        if (type == 'opt') {
            item["EMPId"] = $('#ddlEmp').val();
            item["servicetype"] = $("#ddlExtType").val();
            item["dateofissue"] = $("#txtEHDoE").val();
            item["startdate"] = $("#txtEHDoEB").val();
            if ($("#txtEHDoEEnd").val() == '')
                item["EndDate"] = 'NA';
            else
                item["EndDate"] = $("#txtEHDoEEnd").val();
            if ($("#txtEHDesg")[0].selectedIndex > 0)
                item["newdesignation"] = $("#txtEHDesg").val();
            if ($("#txtEHPrvDesg")[0].selectedIndex > 0)
                item["previousdesignation"] = $("#txtEHPrvDesg").val();
            item["newsalary"] = $("#txtEHNewsal").val();
            item["previoussalary"] = $("#txtEHPrevSal").val();
            item["Remarks"] = $("#txtEHRemarks").val();
            item["officeorder"] = fEHPath;
        }
        else {
            item["EMPId"] = $('#ddlEmp').val();
            item["servicetype"] = $("#ddlExtType").val();
            item["dateofissue"] = $("#txtEHDoE").val();
            item["startdate"] = $("#txtEHDoEB").val();
            item["EndDate"] = $("#txtEHDoEEnd").val();
            if ($("#txtEHDesg")[0].selectedIndex > 0)
                item["newdesignation"] = $("#txtEHDesg").val();
            if ($("#txtEHPrvDesg")[0].selectedIndex > 0)
                item["previousdesignation"] = $("#txtEHPrvDesg").val();
            item["newsalary"] = $("#txtEHNewsal").val();
            item["previoussalary"] = $("#txtEHPrevSal").val();
            item["Remarks"] = $("#txtEHRemarks").val();
            item["officeorder"] = fEHPath;
        }
        jsonObj.push(item);
        // reset();
        return jsonObj;
    }

    $(document).on('click', 'span.uploadEHFile', function () {
        currentEHRowid = $(this).closest('tr').find('td.EHSno').text();
        //alert(currentEHRowid);
        $(".b2").val("Update");
        currentRow = $(this).parents('tr');
        $(".s1").val($(this).closest('tr').find('td.ddlExtType').text());
        $(".s2").val($(this).closest('tr').find('td.txtEHDoE').text());
        $(".s3").val($(this).closest('tr').find('td.txtEHDoEB').text());
        $(".s4").val($(this).closest('tr').find('td.txtEHDoEEnd').text());
        $(".s5").val($(this).closest('tr').find('td.txtEHDesg').text());
        $(".s6").val($(this).closest('tr').find('td.txtEHPrvDesg').text());
        $(".s7").val($(this).closest('tr').find('td.txtEHNewsal').text());
        $(".s8").val($(this).closest('tr').find('td.txtEHPrevSal').text());
        $(".s9").val($(this).closest('tr').find('td.txtEHRemarks').text());

        fEHPath = $(this).closest('tr').find('td.fldEHOorder a').attr('href');
        //alert(fEHPath);
        //        $('#upSHfile').prop('href', fEHPath);
        //         $('#upSHfile').show();
        $('#fldEHOorder').prop('required', false);
    });

    $(document).on('click', 'span.deleteEHrow', function () {
        currentEHRowid = $(this).closest('tr').find('td.EHSno').text();
        if (confirm("Are you sure to delete this entry ?")) {
            //            delete jsonObj[currentEHRowid];
            //            $(this).parents('tr').remove();
            //            var res = JSON.stringify(jsonObj).replace(',null', '').replace('null,', '').replace('null', '');
            //            sessionStorage.jsondata = res;
            //alert(currentEHRowid);
            deleteEHRecord(currentEHRowid);
            currentEHRowid = null;
            //loadWithOtherWithDefaults();
            //checkForallTabsStatus();
            //alert(currentEHRowid);
            //alert("<strong>Info!</strong> After Delete Operation, Please Save Data by using Save Button.", "alert alert-info", "");
        }

        return false;
    });

    function deleteEHRecord(cid) {
        //alert(cid);
        $.ajax({
            type: "POST",
            url: "../ProjectStaff/PGeneral/services.aspx/DeleteExetnDetails",
            //url: "services.aspx/DeleteExetnDetails",
            //url: "../PEmp_PSService/DeleteExetnDetails",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            data: JSON.stringify({ SNo: cid }),
            processData: false,
            success: function (result) {
                alert("Entry deleted successfully...", "");
                //resetEH();
                displayEHdata();
                // displayOthFacdata();
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



    uploadEHFile = function (fileProgressID, fl, fileRename, fEHPath, currentEHRowid) {
        var formData = new FormData();
        //alert('upd');
        formData.append('file', fl, fEHPath);
        $.ajax({
            url: '../ProjectStaff/PGeneral/HandlerCS.ashx',
            //url: 'HandlerCS.ashx',
            type: 'POST',
            data: formData,
            cache: false,
            contentType: false,
            processData: false,
            success: function (file) {
                $(fileProgressID).hide();
                if (currentEHRowid == null) {
                    if (checkValidationsForServHistory()) {
                        if ($("#ddlExtType").val() == 'Promotion' || $("#ddlExtType").val() == 'Salary Adjustment') {
                            //alert('1');
                            var rr = createExtnJSON('opt');
                        }
                        else {
                            //alert('2');
                            var rr = createExtnJSON('man');
                        }
                        if (rr != false) {
                            saveEHdata(fEHPath, rr);
                        }
                        else {
                            alert("Please fill all mandatory fields...");
                        }
                    }
                    else {
                        alert("Please fill all mandatory fields...");
                    }
                }
                else {
                    if (checkValidationsForServHistory()) {
                        //alert('update');
                        if ($("#ddlExtType").val() == 'Promotion' || $("#ddlExtType").val() == 'Salary Adjustment') {
                            //alert('1');
                            var rr = createExtnJSON('opt');
                        }
                        else {
                            //alert('2');
                            var rr = createExtnJSON('man');
                        }
                        if (rr != false) {
                            updateEHdata(currentEHRowid, rr);
                            currentOthFacRowid = null;
                        }
                        else {
                            alert("Please fill all mandatory fields...");
                        }                        
                    }
                    else {
                        alert("Please fill all mandatory fields...");
                    }
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

    function saveEHdata(fEHPath, jsonObj) {
        // alert('Call from save ext details : ' + fEHPath);
        var ddt = JSON.stringify(jsonObj);
        $.ajax({
            type: "POST",
            url: "../ProjectStaff/PGeneral/services.aspx/SaveExetnDetails",
            //url: "services.aspx/SaveExetnDetails",
            //url: "../PEmp_PSService/SaveExetnDetails",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            //data: JSON.stringify({ ExtType: $("#ddlExtType").val(), EHDOE: $('#txtEHDoE').val(), EHDoEB: $('#txtEHDoEB').val(), EHDOEEnd: $("#txtEHDoEEnd").val(), EHNewDesg: $("#txtEHDesg").val(), EHPrevDesg: $('#txtEHPrvDesg').val(), EHNewSal: $('#txtEHNewsal').val(), EHPrevSal: $("#txtEHPrevSal").val(), EHRemarks: $("#txtEHRemarks").val(), EHOOrder: fEHPath }), //
            data: JSON.stringify({ ServHistory: JSON.parse(ddt) }),
            processData: false,
            success: function (result) {
                alert("Data saved successfully...", "");
                resetEH();
                displayEHdata();
                //checkForallTabsStatus();
            },
            error: function (result) {
                alert(JSON.parse(result.responseText).Message, "alert alert-danger", "");
            }
        });
    }
    function updateEHdata(Sno, jsonObj) {
        //alert('update call');
        var ddt = JSON.stringify(jsonObj);
        $.ajax({
            type: "POST",
            url: "../ProjectStaff/PGeneral/services.aspx/UpdateExtenDetails",
            //url: "services.aspx/UpdateExtenDetails",
            //url: "../PEmp_PSService/UpdateExtenDetails",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            //data: JSON.stringify({ ExtType: $("#ddlExtType").val(), EHDOE: $('#txtEHDoE').val(), EHDoEB: $('#txtEHDoEB').val(), EHDOEEnd: $("#txtEHDoEEnd").val(), EHNewDesg: $("#txtEHDesg").val(), EHPrevDesg: $('#txtEHPrvDesg').val(), EHNewSal: $('#txtEHNewsal').val(), EHPrevSal: $("#txtEHPrevSal").val(), EHRemarks: $("#txtEHRemarks").val(), EHOOrder: fEHPath, SNo: id }),
            data: JSON.stringify({ ServHistory: JSON.parse(ddt), id: Sno }),
            processData: false,
            success: function (result) {
                alert("Data updated successfully...", "");
                resetEH();
                displayEHdata();
            },
            error: function (result) {
                alert(JSON.parse(result.responseText).Message, "alert alert-danger", "");
            }
        });
    }
    function populateEHtable(data) {

        var str = "<div class='table-responsive'><table id='t1' class='table table-striped table-hover'><thead class='thead-dark'><tr><th >#</th><th>Type</th><th>Date of Extension</th><th>Start Date</th><th>End Date</th><th>Designation</th><th>Previous Designation</th><th>New Salary</th><th>Previous Salary</th><th>Remarks</th><th style='display:none;'>S.No</th><th>Office Order</th><th>Action</th></tr></thead><tbody>";

        var k = 1;
        for (var i in data) {

            str = str + "<tr id='" + i + "'><td class='text-center'>" + (k++) + "</td><td class='ddlExtType'>" + data[i].ExtType + "</td><td class='txtEHDoE'>" + data[i].EHDOE + "</td><td class='txtEHDoEB'>" + data[i].EHDoEB + "</td><td class='txtEHDoEEnd'>" + data[i].EHDoEend + "</td><td class='txtEHDesg text-center'>" + data[i].EHNEwDesg + "</td><td class='txtEHPrvDesg text-center'>" + data[i].EHPrevDesg + "</td><td class='txtEHNewsal'>" + data[i].EHNewSal + "</td><td class='txtEHPrevSal'>" + data[i].EHPrevSal + "</td><td class='txtEHRemarks'>" + data[i].EHRemarks + "</td><td class='EHSno' style='display:none;'>" + data[i].SNo + "</td><td class='fldEHOorder'><a href='" + data[i].EHOorder + "' target='_blank'><center><span style='font-size:15px;' class='glyphicon glyphicon-eye-open'></span></center></a></td><td><span class='uploadEHFile'><a class='fa fa-edit' style='font-size:15px;color:blue;' href='javascript: void(0);'></a></span>&nbsp;&nbsp;&nbsp;<span class='deleteEHrow'><a class='glyphicon glyphicon-trash' style='font-size:15px;color:red;' href=''></a></span></td></tr>"; //<span class='uploadEHFile'><a class='fa fa-edit' style='font-size:15px;color:blue;' href='javascript: void(0);'></a></span>&nbsp;&nbsp;&nbsp;
        }
        str = str + "</tbody></table></div>";

        var Extstr = "<div class='table-responsive'><table id='ExtnsDtls' class='a table table-striped table-hover'><thead class='thead-dark'><tr><th >#</th><th>Type</th><th>Date of Extension</th><th>Start Date</th><th>End Date</th><th>Designation</th><th>Previous Designation</th><th>New Salary</th><th>Previous Salary</th><th>Remarks</th></tr></thead><tbody>"; //<th style='display:none;'>S.No</th><th>Office Order</th>

        var ed = 1;
        for (var e in data) {

            Extstr = Extstr + "<tr id='" + e + "'><td class='text-center'>" + (ed++) + "</td><td class='ddlExtType'>" + data[e].ExtType + "</td><td class='txtEHDoE'>" + data[e].EHDOE + "</td><td class='txtEHDoEB'>" + data[e].EHDoEB + "</td><td class='txtEHDoEEnd'>" + data[e].EHDoEend + "</td><td class='txtEHDesg text-center'>" + data[e].EHNEwDesg + "</td><td class='txtEHPrvDesg text-center'>" + data[e].EHPrevDesg + "</td><td class='txtEHNewsal'>" + data[e].EHNewSal + "</td><td class='txtEHPrevSal'>" + data[e].EHPrevSal + "</td><td class='txtEHRemarks'>" + data[e].EHRemarks + "</td></tr>"; //<td class='EHSno' style='display:none;'>" + data[e].SNo + "</td><td class='fldEHOorder'><a href='" + data[e].EHOorder + "' target='_blank'>Office Order</a></td>//<span class='uploadEHFile'><a class='fa fa-edit' style='font-size:15px;color:blue;' href='javascript: void(0);'></a></span>&nbsp;&nbsp;&nbsp;
        }
        Extstr = Extstr + "</tbody></table></div>";
        $(".ExtnsDtls").html(Extstr);

        return str;
    }
    function displayEHdata() {
        // alert('hi');
        $.ajax({
            type: "POST",
            url: "../ProjectStaff/PGeneral/Services.aspx/getPRExtenDetails",
            //url: "Services.aspx/getPRExtenDetails",
            //url: "../PEmp_PSService/getPRExtenDetails",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
           // data: JSON.stringify({ EMPId: $("#ddlEmp").val() }),
            data: JSON.stringify({ EMPId: '' }),
            async: false,
            processData: false,
            success: function (result) {
                //alert(result.d);
                var jResEH = JSON.parse(result.d);

                if (jResEH) {
                    $(".EHData").html(populateEHtable(jResEH));
                    checkForallTabsStatusAtExt();
                    //checkForallTabsStatus();
                }
                else {
                    //checkForallTabsStatus();
                    $(".EHData").html("<div class='alert alert-danger alert-dismissable'>Sorry, No records found ...</div>");
                    checkForallTabsStatusAtExt();
                }
                $("#txtEHDesg").prop('selectedIndex', 0);
                $("#txtEHPrvDesg").prop('selectedIndex', 0);

            },
            error: function (result) {
                alert(JSON.parse(result.responseText).Message);
                //alert((result.responseText));
            }
        });
    }


    function resetEH() {
        $(".s1").val("");
        $(".s2").val("");
        $(".s3").val("");
        $(".s4").val("");
        $(".s5").val("");
        $(".s6").val("");
        $(".s7").val("");
        $(".s8").val("");
        $(".s9").val("");
        $(".s10").val("");
        $(".b2").val("Add+");
        //$("#ddlExtType").val("Select Type*");
        //    $(".a10").val("");
        //  $('#upfile').hide();    
    }

    //function to change the placeholder text

    $("#ddlExtType").change(function () {
        if ($(this).prop('selectedIndex') > 0) {
            if ($(this).prop('selectedIndex') == 1) {
                $('#txtEHDoE').attr('placeholder', 'Date of Promotion Order*');
                $('#txtEHDoEB').attr('placeholder', 'Promotion Date Begins*');
                $('#txtEHDoEEnd').attr('placeholder', 'Promotion Date Ends');
            }
            else if ($(this).prop('selectedIndex') == 2) {
                $('#txtEHDoE').attr('placeholder', 'Date of Extension Order*');
                $('#txtEHDoEB').attr('placeholder', 'Extension Date Begins*');
                $('#txtEHDoEEnd').attr('placeholder', 'Extension Date Ends*');
            }
            else if ($(this).prop('selectedIndex') == 3) {
                $('#txtEHDoE').attr('placeholder', 'Date of Salary Adjustment Order*');
                $('#txtEHDoEB').attr('placeholder', 'Salary Adjustment Date Begins*');
                $('#txtEHDoEEnd').attr('placeholder', 'Salary Adjustment Date Ends');
            }
            else if ($(this).prop('selectedIndex') == 4) {
                $('#txtEHDoE').attr('placeholder', 'Date of Appointment Order*');
                $('#txtEHDoEB').attr('placeholder', 'Appointment Date Begins*');
                $('#txtEHDoEEnd').attr('placeholder', 'Appointment Date Ends*');
            }
        }
    });
//});