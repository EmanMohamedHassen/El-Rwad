
var Branch = function () {
    return {
        findAll: function () {
            
            $("#Branch-table").DataTable().destroy();
            $("#Branch-table").DataTable(

                {
                    "language": {
                        "infoFiltered": " ",
                        "lengthMenu": "عرض _MENU_ الصفحات",
                        "info": "عرض _START_ إلى _END_ من _TOTAL_ الصفحات",
                        "emptyTable": "لايوجد بيانات بالنظام بعد",
                        "search": "بحث:",
                        "processing": "جارى التحميل ....",
                        "paginate": {
                            "first": "First",
                            "previous": "السابق",
                            "next": "التالى",
                            "last": "Last"
                        },
                    },
                    "processing": true,
                    "bserverSide": true,
                    "filter": true,
                    "info": true,
                    "orderMulti": false,
                    "paging": true,
                    "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
                    columns: [
                        {
                            "data": "BranchName_A",
                            "name": "BranchName_A",
                            "autoWidth": true,
                            "orderable": true,
                        },
                        {
                            "data": 'BranchNameE',
                            "name": "BranchNameE",
                            "autoWidth": true,
                            "orderable": true,
                        },
                        {
                            "data": "CompanyNameA",
                            "name": "CompanyNameA",
                            "autoWidth": true,
                            "orderable": true,
                        },
                        {
                            "data": "ManagerName",
                            "name": "ManagerName",
                            "orderable": true,
                            "autoWidth": true
                        },
                        {
                            "data": "BranchLocation",
                            "name": "BranchLocation",
                            "orderable": true,
                            "autoWidth": true
                        },
                        {
                            "data": "BranchDescription",
                            "name": "BranchDescription",
                            "orderable": true,
                            "autoWidth": true
                        },
                        {
                            "data": "BranchImage",
                            "name": "BranchImage",
                            "orderable": true,
                            "autoWidth": true
                        },

                    ],
                    ajax: {
                        url: "/Branches/GetAll",
                        type:'GET',
                        dataSrc: ''
                    },
                    'columnDefs': [
                        {
                            'targets': 7,
                            'searchable': false,
                            'orderable': false,
                            'className': 'dt-body-center',
                            'render': function (data, type, full, meta) {
                                return `
                            <a onclick="Branch.remove(${full.branchId})" class ="fa fa-trash-o fa-2x">  </a>
                            <a onclick="Branch.create(${full.branchId})" class ="fa fa-pencil fa-2x">  </a>
                        `;
                            }
                        }],
                });

        },
        remove: function (id) {
            var _confirm = confirm('هل تريد حذف هذا السجل؟');
            if (_confirm) {
                $.ajax({
                    url: 'http://api.rwad.smart-gate.net/api/Branches/DeleteBranch?branchId=' + id,
                }).success((result) => {
                    console.log(result.result, 'result')
                    notifyMsg(result.result);
                    this.findAll();
                }).error((result) => {
                    alert('لا يمكن مسح  هذه البيانات لأنها مرتبطة ببيانات أخري')
                    console.log(result.result, 'Error')
                    notifyMsg(result.result);
                });
            }

            return false;
        },
        create: function (id) {
            // for edit
            if (id != null) {
                $.ajax({
                    url: "http://api.rwad.smart-gate.net/api/Branches/GetBranchById?branchId=" + id
                }).done((result) => {
                    $.each(result, (key, value) => {
                        $('#Branch-form').find("input[name='" + key + "']").val(value);
                        $('#Branch-form').find("textarea[name='" + key + "']").val(value);
                        $('#Branch-form').find("select[name='" + key + "']").val(value);
                    });
                    $("#branchId").val(id);
                    $("#myModal").modal('show');
                    setTimeout(function () {
                        $('#btn-save').val(id);
                        console.log('first timeout')
                    }, 500);
                });
            }
            else {
                $("#myModal").modal('show');
                $("#Branch-form")[0].reset();
                setTimeout(function () {
                    $('#btn-save').val("create");
                    console.log('second timeout')
                }, 500);

            }

            return false;
        },
        save: function () {
            $("#Branch-form").validate({
                errorElement: 'span',
                errorClass: 'validation',
                focusInvalid: false,

                rules: {
                    branchArName: "required",
                    branchEnName: "required",
                    branchCompanyId: "required",
                    branchLocation: "required",
                    branchManager: "required"
                },
                messages: {
                    branchArName: "من فضلك ادخل اسم الفرع",
                    branchEnName: "من فضلك ادخل اسم الفرع",
                    branchCompanyId: "من فضلك ادخل اسم القسم",
                    branchLocation: "من فضلك ادخل العنوان",
                    branchManager: "من فضلك اختار مسئول الفرع"

                },
                invalidHandler: function (event, validator) { //display error alert on form submit


                    if (!validator.numberOfInvalids())
                        return;

                    $('html, body').animate({
                        scrollTop: $(validator.errorList[0].element).offset().top
                    }, 100);

                },

                highlight: function (e) {
                    $(e).closest('label').addClass('error');
                },

                success: function (e) {
                    $(e).closest('.form-control').addClass('info');
                    $(e).remove();
                },

                errorPlacement: function (error, element) {

                    error.insertBefore(element);
                },

                submitHandler: function (form) {
                },
                invalidHandler: function (event, validator) { //display error alert on form submit

                    if (!validator.numberOfInvalids())
                        return;
                }
            });
            debugger;
            var BranchForm = $("#Branch-form").serializeArray();
            var branchVm = {};
            $.each(BranchForm, (index, element) => {
                branchVm[element.name] = element.value;
            });
            var frm = new FormData();
            $.each(branchVm, (key, value) => {
                frm.append(key, value);
                console.log(JSON.stringify(frm.append(key, value)), 'Frm ')
                console.log(JSON.stringify(branchVm), 'CollageVm')
            });
            if ($('#btn-save').val() != "create") {
                //console.log('This is update condition ', id)
                $.ajax({
                    url: '/Branches/PutBranch/' + frm,
                    data: JSON.stringify(branchVm),
                    contentType: false,
                    processData: false,
                    dataType: 'JSON',
                    type: 'Put',

                }).done((result) => {
                    notifyMsg(result.result);
                    $("#myModal").modal('hide');
                    $("#branchId").val("");
                    this.findAll();

                }).fail(function (jqXHR, status, error) {
                    console.log("status:", status, "error:", error);
                });
            }
            else {
                console.log('This is  post condition')
                if ($("#Branch-form").valid()) {
                    $.ajax({
                        url: ' /Branches/Save/',
                        data: branchVm,
                        contentType: false,
                        processData: false,
                        dataType: 'JSON',
                        type: 'POST',

                    }).done((result) => {
                        notifyMsg(result.result);
                        $("#myModal").modal('hide');
                        $("#branchId").val("");
                        this.findAll();

                    }).fail(function (jqXHR, status, error) {
                        console.log("status:", status, "error:", error);
                    });
                }
            }
            return false;
        },
        
        init: function () {
            $.ajax({
                "url": "/Branches/GetAllEmployees",
                "type": "get",
                "dataType": "json"
            })
                .done(function (data) {
                    console.log('Employees fetched');
                    var options = $("#branchManager");
                    $.each(data, function (idx, val) {
                        options.append($('<option />', { value: val.empId, text: val.fullName }));
                    });
                })
                .fail(function (jqXHR, status, error) {
                    console.log("status:", status, "error:", error);
                });
            //debugger;

            $.ajax({
                "url": "/Branches/GetAllCompanies",
                "type": "get",
                "dataType": "json"
            })
                .done(function (data) {
                    console.log('companies fetched');
                    var options = $("#branchCompanyId");
                    $.each(data, function (idx, val) {
                        options.append($('<option />', { value: val.Id, text: val.NameA }));
                    });
                })
                   .fail(function (jqXHR, status, error) {
                       console.log("status:", status, "error:", error);
                   });

            this.findAll();
        },

    };

}();


jQuery(document).ready(function () {

    Branch.init(); // init metronic core componets
});
