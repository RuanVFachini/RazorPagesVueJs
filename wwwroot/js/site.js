// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function baseAjaxObject(path, handler, data) {
    let ajax =  {
        beforeSend: function (xhr) {
            xhr.setRequestHeader(
                "XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val())
        },
        url: path + "/" + handler
    }

    if (typeof(data) != 'undefined' && data != null) {
        ajax.data = data
    }

    return ajax
}

function AjaxPost(path, handler, requestData) {
    let ajax = baseAjaxObject(path, handler, requestData);
    ajax.type = "POST"
    return $.ajax(ajax)
}

function AjaxGET(path, handler, requestData) {
    let ajax = baseAjaxObject(path, handler, requestData);
    ajax.type = "GET"
    return $.ajax(ajax)
}

function hasValue(obj) {
    return typeof(obj) != 'undefined' && obj != null && obs != {};
}

