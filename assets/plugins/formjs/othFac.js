//$(document).ready(function () {
    var currentOthFacRowid = null;
    var fOthFacPath = null;
    var str = null, OthDtls = null; ;
    //var jsonRes = null, jsonResObj = [];
    //var adata = null;
    //var jsonObj = [];
    //loadWithOtherWithDefaults();
    function loadWithOtherWithDefaults() {
        $.ajax({
            type: "POST",
            url: "../ProjectStaff/PGeneral/Services.aspx/getTabStatus",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify({ EmpNo: $("#ddlEmp").val() }),
            //data: JSON.stringify({ state: $('#ddlState').val(), theme: $('#ddlTheme').val(), subTheme: $("#dllSubTheme").val(), cate: $("#ddlCat").val() }),
            async: false,
            processData: false,
            success: function (result) {
                //alert(result.d);
                var jResOthFac = JSON.parse(result.d);
                //alert(jResOthFac.FacStatus);
                if (jResOthFac) {
                    if (jResOthFac.FacStatus == 1) {
                        //alert('Other details');
                        $('#ifYes').show();
                        $("#ifothSpe").show();
                        $("#inlineRadio1").prop("checked", true);
                        $("#inlineRadio2").prop("checked", false);
                        displayOthFacdata();
                    }
                    else {
                        $('#ifYes').hide();
                        $("#ifothSpe").hide();
                        $("#inlineRadio1").prop("checked", false);
                        $("#inlineRadio2").prop("checked", true);
                        displayOthFacdata();
                    }
                }
                else {
                    $(".OthFacData").html("<div class='alert alert-danger alert-dismissable'>Sorry, No records found ...</div>");
                }

            },
            error: function (result) {
                alert(JSON.parse(result.responseText).Message);
            }
        });
    }

    function checkForallTabsStatusAtOth() {
        $.ajax({
            type: "POST",
            url: "../ProjectStaff/PGeneral/Services.aspx/getTabStatus",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify({ EmpNo: $("#ddlEmp").val() }),
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
                        //displayOthFacdata();
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



    $("#btnOthFacSave").click(function () {
        $(".b3").val("Add+");
        try {
            var rr = checkValidationsForOther();
            //alert(rr);
            if (currentOthFacRowid == null) {
                if (rr != false) {
                    saveOthFacdata(rr);
                }
                else {
                    alert("client : Please fill all mandatory fields...");
                }
            }
            else {
                if (rr != false) {
                    updateOthFacdata(currentOthFacRowid, rr);
                }
                else {
                    alert("client : Please fill all mandatory fields...");
                }
            }
            currentOthFacRowid = null;
            resetOther();
        }
        catch (e) { throw e; }
        return false;
    });



    $(document).on('click', 'span.EditOthFacrow', function () {
        currentOthFacRowid = $(this).closest('tr').find('td.OthFacSno').text();
        //alert('click on edit: ' + currentOthFacRowid);
        $(".b3").val("Update");
        currentRow = $(this).parents('tr');
        $(".f1").val($(this).closest('tr').find('td.ddlOthtoType').text());
        getDurationDetails();
        //alert($(this).closest('tr').find('td.ddlOthduration').text());
        $(".f2").val($(this).closest('tr').find('td.ddlOthduration').text());
        $(".f3").val($(this).closest('tr').find('td.Facility').text());
        if ($(this).closest('tr').find('td.Facility').text() == 'Other') {
            $("#ifothSpe").show();
            $('#ifothSpe').prop('required', true);
        }
        else {
            $("#ifothSpe").hide();
            $('#txtIfOther').val('');
        }
        $(".f4").val($(this).closest('tr').find('td.txtIfOther').text());
        $(".f5").val($(this).closest('tr').find('td.txtDtAppl').text());
        $(".f6").val($(this).closest('tr').find('td.txtAllow').text());

        //fOthFacPath = $(this).closest('tr').find('td.PrmofficeOrder a').attr('href');
        //$('#upfile').prop('href', fOthFacPath);
        // $('#upfile').show();
        //$('#PrmofficeOrder').prop('required', false);
    });

    $(document).on('click', 'span.deleteOthFacrow', function () {
        currentOthFacRowid = $(this).closest('tr').find('td.OthFacSno').text();
        if (confirm("Are you sure to delete this entry ?")) {
            //            delete jsonObj[currentOthFacRowid];
            //            $(this).parents('tr').remove();
            //            var res = JSON.stringify(jsonObj).replace(',null', '').replace('null,', '').replace('null', '');
            //            sessionStorage.jsondata = res;
            //alert(currentOthFacRowid);
            deleteOthFacRecord(currentOthFacRowid);
            currentOthFacRowid = null;
            resetOther();
            //checkForallTabsStatus();
            //alert(currentOthFacRowid);
            //alert("<strong>Info!</strong> After Delete Operation, Please Save Data by using Save Button.", "alert alert-info", "");
        }

        return false;
    });

    function deleteOthFacRecord(cid) {
        // alert(cid);
        $.ajax({
            type: "POST",
            url: "../ProjectStaff/PGeneral/Services.aspx/DeleteOthFacDetails",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            data: JSON.stringify({ SNo: cid }),
            processData: false,
            success: function (result) {
                alert("Entry deleted successfully...", "");
                displayOthFacdata();
                //resetOthFec();
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



    //    uploadPROMFile = function (fileProgressID, fl, fileRename, fOthFacPath, currentOthFacRowid) {
    //        var formData = new FormData();
    //        formData.append('file', fl, fileRename);
    //        $.ajax({
    //            url: 'HandlerCS.ashx',
    //            type: 'POST',
    //            data: formData,
    //            cache: false,
    //            contentType: false,
    //            processData: false,
    //            success: function (file) {
    //                $(fileProgressID).hide();
    //                if (currentOthFacRowid == null) {
    //                    saveOthFacdata(fOthFacPath);
    //                }
    //                else {
    //                    updateOthFacdata(currentOthFacRowid, fOthFacPath);
    //                }
    //            },
    //            xhr: function () {
    //                var fileXhr = $.ajaxSettings.xhr();
    //                if (fileXhr.upload) {
    //                    $(fileProgressID).show();
    //                    fileXhr.upload.addEventListener("progress", function (e) {
    //                        if (e.lengthComputable) {
    //                            $(fileProgressID).attr({
    //                                value: e.loaded,
    //                                max: e.total
    //                            });
    //                        }
    //                    }, false);
    //                }
    //                return fileXhr;
    //            }
    //        });
    //    }

    function saveOthFacdata(jsonObj) {
        //var faci = getChckFacilities();
        //        var hvfct = getHaveFcty();
        //       alert('Save data :' + hvfct);
        //alert($("#ddlOthduration").val());
        //        var type, othType, duration, durationID, facs, dtAppl, amtPM, ifoth
        //        if (hvfct) {
        //            type = $("#ddlOthtoType").val();
        //            duration = $("#ddlOthduration option:selected").text();
        //            durationID = $("#ddlOthduration").val();
        //            facs = $('#ddlFaclity').val();
        //            dtAppl = $('#txtDtAppl').val();
        //            amtPM = $("#txtAllow").val();
        //            ifoth = $("#txtIfOther").val();
        //        }
        //        else {
        //            type = '',
        //            duration = '';
        //            durationID = '';
        //            facs = '';
        //            dtAppl = '';
        //            amtPM = '';
        //            ifoth = '';
        //        }

        $.ajax({
            type: "POST",
            url: "../ProjectStaff/PGeneral/Services.aspx/SaveOthFacDetails",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            //data: JSON.stringify({ HaveFacts: hvfct, fcltType: type, DurationFor: duration, DurationForId: durationID, facilities: facs, DoAplb: dtAppl, APM: amtPM, IfOther: ifoth }),
            data: JSON.stringify({ otherFacs: jsonObj }),
            processData: false,
            success: function (result) {
                alert("Data saved successfully...", "");
                //resetOthFec();
                resetOther();
                displayOthFacdata();
                //checkForallTabsStatus();
            },
            error: function (result) {
                alert(JSON.parse(result.responseText).Message, "alert alert-danger", "");
            }
        });
    }
    function updateOthFacdata(id, jsonObj) {
        //alert('update call');
        var ddt = JSON.stringify(jsonObj);
        //alert(ddt);
        $.ajax({
            type: "POST",
            url: "../ProjectStaff/PGeneral/Services.aspx/UpdateOthFacDetails",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            //data: JSON.stringify({ facilities: faci, DoAplb: $('#txtDtAppl').val(), APM: $("#txtAllow").val() }),
            data: JSON.stringify({ other: JSON.parse(ddt), id: id }),
            processData: false,
            success: function (result) {
                alert("Data updated successfully...", "");
                displayOthFacdata();
                resetOther();
            },
            error: function (result) {
               // alert((result.responseText).Message, "alert alert-danger", "");
                alert(JSON.parse(result.responseText).Message, "alert alert-danger", "");
            }
        });
    }
    //    function getChckFacilities() {
    //        var fac = '';

    //        if ($("#checkbox1").is(":checked")) {
    //            fac = fac + $("#checkbox1").val() + ', ';
    //        }
    //        if ($("#checkbox2").is(":checked")) {
    //            fac = fac + $("#checkbox2").val() + ', ';
    //        }
    //        if ($("#checkbox3").is(":checked")) {
    //            fac = fac + $("#checkbox3").val() + ', ';
    //        }
    //        if ($("#checkbox4").is(":checked")) {
    //            fac = fac + $("#checkbox4").val() + ', ';
    //        }
    //        if ($("#checkbox5").is(":checked")) {
    //            fac = fac + $("#checkbox5").val() + ', ';
    //        }
    //        if ($("#checkbox6").is(":checked")) {
    //            fac = fac + $("#checkbox6").val() + '(' + $("#txtIfOther").val() + ')';
    //        }
    //        return fac;
    //    }
    function getHaveFcty() {
        if ($('#inlineRadio1').is(':checked')) {
            return true;
        }
        else {
            return false;
        }
    }

    function populateOthFactable(data, facdtls) {

        if (data && facdtls == true) {
            OthDtls = "<div class='table-responsive'><table id='OthrDtls' class='a table table-striped table-hover'><thead class='thead-dark'><tr><th >#</th><th>Type</th><th>Date of Extension</th><th>Start Date</th><th>End Date</th><th>Designation</th><th>Previous Designation</th><th>New Salary</th><th>Previous Salary</th><th>Remarks</th></tr></thead><tbody>"; //<th style='display:none;'>S.No</th><th>Office Order</th>

            var od = 1;
            for (var o in data) {

                OthDtls = OthDtls + "<tr id='" + o + "'><td class='text-center'>" + (od++) + "</td><td class='ddlExtType'>" + data[o].ExtType + "</td><td class='txtEHDoE'>" + data[o].EHDOE + "</td><td class='txtEHDoEB'>" + data[o].EHDoEB + "</td><td class='txtEHDoEEnd'>" + data[o].EHDoEend + "</td><td class='txtEHDesg text-center'>" + data[o].EHNEwDesg + "</td><td class='txtEHPrvDesg text-center'>" + data[o].EHPrevDesg + "</td><td class='txtEHNewsal'>" + data[o].EHNewSal + "</td><td class='txtEHPrevSal'>" + data[o].EHPrevSal + "</td><td class='txtEHRemarks'>" + data[o].EHRemarks + "</td></tr>"; //<td class='EHSno' style='display:none;'>" + data[o].SNo + "</td><td class='fldEHOorder'><a href='" + data[o].EHOorder + "' target='_blank'>Office Order</a></td>//<span class='uploadEHFile'><a class='fa fa-edit' style='font-size:15px;color:blue;' href='javascript: void(0);'></a></span>&nbsp;&nbsp;&nbsp; <span class='deleteEHrow'><a class='glyphicon glyphicon-trash' style='font-size:15px;color:red;' href=''></a></span>

                getOtherFacilityDetails(data[o].SNo);
            }

            OthDtls = OthDtls + "</tbody></table></div>";
            $(".OthrDtls").html(OthDtls);

            str = "<div class='table-responsive'><table id='t2' class='a table table-striped table-hover'><thead class='thead-dark'><tr><th >#</th><th>Type</th><th>Date of Extension</th><th>Start Date</th><th>End Date</th><th>Designation</th><th>Previous Designation</th><th>New Salary</th><th>Previous Salary</th><th>Remarks</th><th style='display:none;'>S.No</th><th>Office Order</th><th>Action</th></tr></thead><tbody>";

            var k = 1;
            for (var i in data) {

                str = str + "<tr id='" + i + "'><td class='text-center'>" + (k++) + "</td><td class='ddlExtType'>" + data[i].ExtType + "</td><td class='txtEHDoE'>" + data[i].EHDOE + "</td><td class='txtEHDoEB'>" + data[i].EHDoEB + "</td><td class='txtEHDoEEnd'>" + data[i].EHDoEend + "</td><td class='txtEHDesg text-center'>" + data[i].EHNEwDesg + "</td><td class='txtEHPrvDesg text-center'>" + data[i].EHPrevDesg + "</td><td class='txtEHNewsal'>" + data[i].EHNewSal + "</td><td class='txtEHPrevSal'>" + data[i].EHPrevSal + "</td><td class='txtEHRemarks'>" + data[i].EHRemarks + "</td><td class='EHSno' style='display:none;'>" + data[i].SNo + "</td><td class='fldEHOorder'><a href='" + data[i].EHOorder + "' target='_blank'><center><span style='font-size:15px;' class='glyphicon glyphicon-eye-open'></span></center></a></td><td></td></tr>"; //<span class='uploadEHFile'><a class='fa fa-edit' style='font-size:15px;color:blue;' href='javascript: void(0);'></a></span>&nbsp;&nbsp;&nbsp; <span class='deleteEHrow'><a class='glyphicon glyphicon-trash' style='font-size:15px;color:red;' href=''></a></span>
                //str = str + getOtherFacilityDetails(data[i].SNo);
                //alert(getOtherFacilityDetails(data[i].SNo));
                getOtherFacilityDetails(data[i].SNo);
            }

            str = str + "</tbody></table></div>";
        }
        else {
            OthDtls = "<div class='alert alert-danger alert-dismissable'>No Facilities are availing by the employee...</div>";
            $(".OthrDtls").html(OthDtls);
            str = "<div class='alert alert-danger alert-dismissable'>No Facilities are availing by the employee...</div>";
        }

        //alert('Oth facs: '+str);
        return str;
    }
    function bindsubtable(result) {
        //alert("bind subtable" + result.d);
        var jResOthFac = JSON.parse(result.d);
        var t = 1;
        //alert(jResOthFac.length);
        for (var j in jResOthFac) {
            //alert('sub details');
            if (j == 0) {
                str = str + "<tr><td style='display:none' class='Facility'>" + jResOthFac[j].Facility + "</td><td style='display:none' class='ddlOthtoType'>" + jResOthFac[j].FacilityType + "</td><td style='display:none' class='ddlOthduration'>" + jResOthFac[j].facilityDurationId + "</td><td style='display:none' class='txtIfOther'>" + jResOthFac[j].IfOtherFac + "</td><td align='right' rowspan='" + jResOthFac.length + "' colspan='5'><b>Facilities Availing : </b></td><td colspan='2' class='ddlFaclity'>" + jResOthFac[j].fac + "</td><td colspan='2' class='txtDtAppl'>" + jResOthFac[j].DtApplb + "</td><td colspan='2' class='txtAllow'>" + jResOthFac[j].AlPM + "</td><td class='OthFacSno' style='display:none;'>" + jResOthFac[j].SNo + "</td><td><span class='EditOthFacrow'><a class='fa fa-edit' style='font-size:15px;color:blue;' href='javascript: void(0);'></a></span>&nbsp;&nbsp;&nbsp;<span class='deleteOthFacrow'><a class='glyphicon glyphicon-trash' style='font-size:15px;color:red;' href='#'></a></span></td></tr>"; //<td></td><td></td>
            }
            else {
                str = str + "<tr><td style='display:none' class='Facility'>" + jResOthFac[j].Facility + "</td><td style='display:none' class='ddlOthtoType'>" + jResOthFac[j].FacilityType + "</td><td style='display:none' class='ddlOthduration'>" + jResOthFac[j].facilityDurationId + "</td><td style='display:none' class='txtIfOther'>" + jResOthFac[j].IfOtherFac + "</td><td colspan='2' class='ddlFaclity'>" + jResOthFac[j].fac + "</td><td colspan='2' class='txtDtAppl'>" + jResOthFac[j].DtApplb + "</td><td colspan='2' class='txtAllow'>" + jResOthFac[j].AlPM + "</td><td class='OthFacSno' style='display:none;'>" + jResOthFac[j].SNo + "</td><td><span class='EditOthFacrow'><a class='fa fa-edit' style='font-size:15px;color:blue;' href='javascript: void(0);'></a></span>&nbsp;&nbsp;&nbsp;<span class='deleteOthFacrow'><a class='glyphicon glyphicon-trash' style='font-size:15px;color:red;' href='#'></a></span></td></tr>"; //<td></td><td></td>
            }
            //alert(str);
        }

        var t1 = 1;

        for (var j1 in jResOthFac) {
            //alert('sub details');
            if (j1 == 0) {
                OthDtls = OthDtls + "<tr><td align='right' rowspan='" + jResOthFac.length + "' colspan='4'><b id='othHead'>Facilities Availing : </b></td><td colspan='2'>" + jResOthFac[j1].fac + "</td><td colspan='2'>" + jResOthFac[j1].DtApplb + "</td><td colspan='2'>" + jResOthFac[j1].AlPM + "</td></tr>"; //<td class='OthFacSno' style='display:none;'>" + jResOthFac[j1].SNo + "</td>//<td></td><td></td>
            }
            else {
                OthDtls = OthDtls + "<tr><td colspan='2'>" + jResOthFac[j1].fac + "</td><td colspan='2'>" + jResOthFac[j1].DtApplb + "</td><td colspan='2'>" + jResOthFac[j1].AlPM + "</td></tr>"; //<td class='OthFacSno' style='display:none;'>" + jResOthFac[j1].SNo + "</td>//<td></td><td></td>
            }
            //alert(str);
        }

        // return str;
    }

    function getOtherFacilityDetails(id) {
        $.ajax({
            type: "POST",
            url: "../ProjectStaff/PGeneral/Services.aspx/getPROthFacDetails",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify({ sno: id, EmpNo: $("#ddlEmp").val() }),
            async: false,
            processData: false,
            success: function (result) {
                //alert(result.d);
                var jResOthFac = JSON.parse(result.d);
                bindsubtable(result);
                //return result.d;
            },
            error: function (result) {
                alert(JSON.parse(result.responseText).Message);
            }
        });
    }
    //    function populateOthFactable(data) {

    //        var str = "<div class='table-responsive'><table id='t' class='table table-striped table-hover'><thead class='thead-dark'><tr><th >#</th><th>Facility for</th><th>Facilities</th><th>Date Applicable</th><th>Allowance Per Month</th><th>Action</th></tr></thead><tbody>";

    //        var k = 1;
    //        for (var i in data) {

    //            str = str + "<tr id='" + i + "'><td class='text-center'>" + (k++) + "</td><td class='facDuration'>" + data[i].facDuration + "</td><td class='Facilities'>" + data[i].fac + "</td><td class='txtDtAppl'>" + data[i].DtApplb + "</td><td class='txtAllow'>" + data[i].AlPM + "</td><td class='OthFacSno' style='display:none;'>" + data[i].SNo + "</td><td><span class='deleteOthFacrow'><a class='glyphicon glyphicon-trash' style='font-size:15px;color:red;' href=''></a></span></td></tr>"; //<span class='editrowOthFac'><a class='fa fa-edit' style='font-size:15px;color:blue;' href='javascript: void(0);'></a></span>&nbsp;&nbsp;&nbsp;
    //        }

    //        str = str + "</tbody></table></div>";

    //        return str;
    //    }
    function displayOthFacdata() {
        $.ajax({
            type: "POST",
            //url: "Services.aspx/getPRExtenDetailsForOthrFacs",
            url: "../ProjectStaff/PGeneral/Services.aspx/getTabStatus",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify({ EmpNo: $("#ddlEmp").val() }),
            //data: JSON.stringify({ state: $('#ddlState').val(), theme: $('#ddlTheme').val(), subTheme: $("#dllSubTheme").val(), cate: $("#ddlCat").val() }),
            async: false,
            processData: false,
            success: function (result) {
                //alert(result.d);
                var jResOthFac = JSON.parse(result.d);
                //alert('jResOthFac.FacDtl :' + jResOthFac.FacDtl);
                //alert('jResOthFac.FacStatus:' + jResOthFac.FacStatus);
                if (jResOthFac.FacDtl == true && jResOthFac.FacStatus == true) {
                    $('#ifYes').show();
                    $("#ifothSpe").show();
                    $("#inlineRadio1").prop("checked", true);
                    $("#inlineRadio2").prop("checked", false);
                    getDataToBind(jResOthFac.FacDtl);
                    checkForallTabsStatusAtOth();
                    //checkForallTabsStatus();
                }
                else {
                    //alert('no');
                    $('#ifYes').hide();
                    $("#ifothSpe").hide();
                    $("#inlineRadio1").prop("checked", false);
                    $("#inlineRadio2").prop("checked", true);
                    getDataToBind(jResOthFac.FacDtl);
                    checkForallTabsStatusAtOth();
                    //checkForallTabsStatus();
                    //$(".OthFacData").html("<div class='alert alert-danger alert-dismissable'>Sorry, No records found ...</div>");
                }

            },
            error: function (result) {
                alert(JSON.parse(result.responseText).Message);
            }
        });
    }

    function getDataToBind(FacDtls) {
        $.ajax({
            type: "POST",
            url: "../ProjectStaff/PGeneral/Services.aspx/getPRExtenDetailsForOthrFacs",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: JSON.stringify({ EmpNo: $("#ddlEmp").val() }),
            //data: JSON.stringify({ state: $('#ddlState').val(), theme: $('#ddlTheme').val(), subTheme: $("#dllSubTheme").val(), cate: $("#ddlCat").val() }),
            async: false,
            processData: false,
            success: function (result) {
                //alert('Alert for binding data;' + result.d);
                var jResOthFac = JSON.parse(result.d);
                if (jResOthFac) {
                    $(".OthFacData").html(populateOthFactable(jResOthFac, FacDtls));
                }
                else {
                    $('#ifYes').hide();
                    $("#ifothSpe").hide();
                    $("#inlineRadio1").prop("checked", false);
                    $("#inlineRadio2").prop("checked", true);
                    $(".OthFacData").html(populateOthFactable(jResOthFac, FacDtls));
                    // $(".OthFacData").html("<div class='alert alert-danger alert-dismissable'>No Facilities are availing by the employee...</div>");
                }

            },
            error: function (result) {
                alert('Exception while binding data:' + JSON.parse(result.responseText).Message);
            }
        });

    }
//    function resetOthFec() {
//        $("#ddlOthtoType").val("Select Type*");
//        $("#ddlOthduration").val("Select Duration*");
//        $("#ddlFaclity").val("Select Facility*");
//        $("#txtIfOther").val("");
//        $("#txtDtAppl").val("");
//        $("#txtAllow").val("");
//        $("#inlineRadio2").prop("checked", true);
//        $('#ifYes').hide();
//    }
    function checkValidationsForOther() {
        if ($('#inlineRadio1').is(':checked')) {
            var regex = /(((0|1)[0-9]|2[0-9]|3[0-1])\/(0[1-9]|1[0-2])\/((19|20)\d\d))$/;
            //if (!regex.test($('#txtDtAppl').val())) { alert('Required: Please select valid Date.'); return false; }

            if ($('#ddlOthtoType')[0].checkValidity() && $('#ddlOthduration')[0].checkValidity() && $('#ddlFaclity')[0].checkValidity() && $('#txtDtAppl')[0].checkValidity() && regex.test($('#txtDtAppl').val()) && $('#txtAllow')[0].checkValidity()) {
                if ($('#ddlFaclity').val() == 'Other') {
                    if ($('#txtIfOther')[0].checkValidity()) {
                        return CreateOthrJSON('man');
                        //return true;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    return CreateOthrJSON('opt');
                    //return true;
                }

            }
            else
                return false;
        }
        else {
            return CreateOthrJSON('noFacs');
            //return true;
        }
    }

    function CreateOthrJSON(type) {
        item = {}
        var jsonObj = [];
        if (type == 'opt') {
            item["EMPId"] = $('#ddlEmp').val();
            item["availingFacs"] = getHaveFcty();
            if ($("#ddlOthtoType")[0].selectedIndex > 0)
                item["servicetype"] = $("#ddlOthtoType").val();
            if ($("#ddlOthduration")[0].selectedIndex > 0) {
                item["duration"] = $("#ddlOthduration option:selected").text();
                item["durationid"] = $("#ddlOthduration").val();
            }
            if ($("#ddlFaclity")[0].selectedIndex > 0)
                item["facility"] = $("#ddlFaclity").val();
            if ($("#txtIfOther").val() == '')
                item["ifOther"] = 'NA';
            else
                item["ifOther"] = $("#txtIfOther").val();
            item["fromdate"] = $("#txtDtAppl").val();
            item["allowance"] = $("#txtAllow").val();
        }
        else if (type == 'man') {
            item["EMPId"] = $('#ddlEmp').val();
            item["availingFacs"] = getHaveFcty();
            if ($("#ddlOthtoType")[0].selectedIndex > 0)
                item["servicetype"] = $("#ddlOthtoType").val();
            if ($("#ddlOthduration")[0].selectedIndex > 0) {
                item["duration"] = $("#ddlOthduration option:selected").text();
                item["durationid"] = $("#ddlOthduration").val();
            }
            if ($("#ddlFaclity")[0].selectedIndex > 0)
                item["facility"] = $("#ddlFaclity").val();
            if ($("#txtIfOther").val() != '')
                item["ifOther"] = $("#txtIfOther").val();

            item["fromdate"] = $("#txtDtAppl").val();
            item["allowance"] = $("#txtAllow").val();
        }
        else {
            item["EMPId"] = 'NA';
            item["availingFacs"] = getHaveFcty();
            item["servicetype"] = 'NA';
            item["duration"] = 'NA';
            item["durationid"] = '0'
            item["facility"] = 'NA';
            item["ifOther"] = 'NA';
            item["fromdate"] = 'NA';
            item["allowance"] = 'NA';
        }
        jsonObj.push(item);
        // reset();
        return jsonObj;
    }



    $('input[type=radio][name=radioInline]').change(function () {
        if (this.value == 'Yes') {
            $('#ifYes').show();
            $('.OthFacData').show();
        }
        else if (this.value == 'No') {
            $('#ifYes').hide();
            $('.OthFacData').hide();
        }
    });

    //    $('#checkbox6').change(function () {
    //        if ($(this).is(":checked")) {
    //            $("#ifothSpe").show();
    //            $('#ifothSpe').prop('required', true);
    //        }
    //        else {
    //            $("#ifothSpe").hide();
    //            $('#txtIfOther').val('');
    //        }
    //    });


    $("#ddlOthtoType").change(function () {
        //alert('other type change');
       getDurationDetails();
        
    });

    function getDurationDetails() {
       // alert('load durations');
        //alert($("#ddlEmp").val());
        //if ($("#ddlOthtoType").prop('selectedIndex') > 0) {
            $.ajax({
                type: "POST",
                url: "../ProjectStaff/PGeneral/Services.aspx/getTypeWiseDurations",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify({ type: $('#ddlOthtoType').val(), EmpNo: $("#ddlEmp").val() }),
                async: false,
                processData: false,
                success: function (result) {
                    //alert(result.d);
                    var jResOthFac = JSON.parse(result.d);
                    $('#ddlOthduration')
                    .empty()
                    .append('<option selected="selected" value="">Select Duration*</option>')
                    for (var i in jResOthFac) {
                        $("#ddlOthduration").append('<option value="' + jResOthFac[i].SNo + '">' + jResOthFac[i].details + '</option>');
                    }

                },
                error: function (result) {
                    alert(JSON.parse(result.responseText).Message);
                }
            });
        //}
    }
    function resetOther() {
        $(".f1").val("");
        $(".f2").val("");
        $(".f3").val("");
        $(".f4").val("");
        $(".f5").val("");
        $(".f6").val("");        
        $(".b3").val("Add+");
        //$("#ddlExtType").val("Select Type*");
        //    $(".a10").val("");
        //  $('#upfile').hide();    
    }

    $("#ddlFaclity").change(function () {
        if ($(this).val() == 'Other') {
            $("#ifothSpe").show();
            $('#ifothSpe').prop('required', true);
        }
        else {
            $("#ifothSpe").hide();
            $('#txtIfOther').val('');
        }
    });

//});