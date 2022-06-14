// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function numberLocalizationFormat(value) {
    
}

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

function AjaxGet(path, handler, requestData) {
    let ajax = baseAjaxObject(path, handler, requestData);
    ajax.type = "GET"
    return $.ajax(ajax)
}

function hasValue(arrayObj, key = null) {
  let objType = typeof(arrayObj)
  
  if (objType == 'undefined' || arrayObj == null) {
      return false
  }

  if (typeof(arrayObj) == 'object') {
      if (key != null) {
          return hasValue(arrayObj[key])
      } else {
          return Object.keys(arrayObj).length > 0
      }
  }

  if (Array.isArray(arrayObj)) {
      if (key != null) {
          return hasValue(arrayObj[key])
      } else {
          return arrayObj.length > 0
      }
  }

  return true
}

function isString(value) {
    return typeof value === 'string' || value instanceof String
}

