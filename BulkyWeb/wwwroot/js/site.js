var updatedRow;

function showSuccessMessage(message = 'Deleted Successfully!') {
    Swal.fire({
        icon: 'success',
        title: "Success",
        text: message,
        showClass: {
            popup: `animate__animated
                    animate__fadeInUp
                    animate__faster`
        },
        hideClass: {
            popup: `animate__animated
                    animate__fadeOutDown
                    animate__faster`
        }
    });
}


function showErrorMessage(message = 'Somthing went wrong!') {
    Swal.fire({
        icon: 'error',
        title: "Oops...",
        text: message,
        showClass: {
            popup: `animate__animated
                animate__fadeInUp
                animate__faster`
        },
        hideClass: {
            popup: `animate__animated
                    animate__fadeOutDown
                    animate__faster`
        }
    });
}


function onModalBegin() {
    $('body :submit').attr('disabled', 'disabled');
}


function onModalSuccess(item) {
    showSuccessMessage();
    $('#Modal').modal('hide');

    if (updatedRow === undefined) {
        $('tbody').append(item);
    } else {
        $(updatedRow).replaceWith(item);
        updatedRow = undefined;
    }

}

function onModalComplete() {
    $('body :submit').removeAttr('disabled');
}

$(document).ready(function () {
    $('body').delegate('.js-render-model', 'click', function () {
        var modal = $('#Modal');
        var btn = $(this);

        if (btn.data('status') === 'delete') {
            bootbox.confirm({
                message: 'Are you sure that you want to delete this item?',
                buttons: {
                    confirm: {
                        label: 'Yes',
                        className: 'btn-danger'
                    },
                    cancel: {
                        label: 'No',
                        className: 'btn-light'
                    }
                },
                callback: function (result) {
                    if (result) {
                        $.post({
                            url: btn.data('url'),
                            data: {
                                '__RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val()
                            },
                            success: function () {
                                var row = btn.parents('tr');
                                row.remove();

                                showSuccessMessage();
                            },
                            error: function () {
                                showErrorMessage();
                            }
                        });
                    }
                }
            });
        }
        else if (btn.data('status') === 'add' || btn.data('status') === 'edit') {
            modal.find('#ModalLabel').text(btn.data('title'));

            // Handle Updated Row => because it was doubled Row
            if (btn.data('update') !== undefined) {
                updatedRow = btn.parents('tr');
            }

            $.get({
                url: btn.data('url'),
                success: function (form) {
                    var row = btn.parents('tr');

                    modal.find('.modal-body').html(form);
                    $.validator.unobtrusive.parse(modal);

                    //if (btn.data('status') === 'add') {
                        
                    //    modal.find('.modal-body').html(form);
                    //}

                    //if (btn.data('status') === 'edit') {
                    //    modal.find('.modal-body').html(form);
                    //    row.addClass('animate__animated animate__flash');
                    //}
                },
                error: function () {
                    showErrorMessage();
                }
            });

            modal.modal('show');
        }

    });
});