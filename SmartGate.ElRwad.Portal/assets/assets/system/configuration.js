var notifyMsg = (messageModel) => {
   
    toastr.options = {
        "positionClass": "toast-bottom-right",
    };
    if (messageModel.Type) {
        switch (messageModel.Type) {
            case "error":
                toastr.danger('error ', messageModel.Message, { timeOut: 5000 });
                break;
            case "success":

                toastr.success('تم الحفظ بنجاح', "العملية", { timeOut: 5000 });
                break;
            case "info":
                toastr.success('info ', messageModel.Text.Message, { timeOut: 5000 });
                break;
        }
    }
    else {
        toastr.success(messageModel.statusText, 'تمت العملية بنجاح', { timeOut: 5000 });
    }
   
   
}