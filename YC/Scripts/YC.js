(function ($) {
    $.httpGet = function (url, success, failure) {
        var data = null;
        if (typeof url != 'string') { throw '路徑異常' };
        $.ajax({
            url: url,
            type: "get",
            data: data,
            dataType: "json",
            success: function (data) {
                success(data);
            },
            error: function (data) {
                failure(data);
            }
        });
    };
    $.httpPut = function (url, data, success, failure) {
        if (typeof url != 'string') { throw '路徑異常' };
        $.ajax({
            url: url,
            data: data,
            type: 'put',
            dataType: 'json',
            success: function (data) {
                success(data);
            },
            error: function (data) {
                fail(data);
            }
        });
    };
    $.httpPost = function (url, data, success, failure) {
        if (typeof url != 'string') { throw '路徑異常' };
        $.ajax({
            url: url,
            data: data,
            type: 'post',
            dataType: 'json',
            success: function (data) {
                success(data);
            },
            error: function (data) {
                fail(data);
            }
        });
    };
    $.httpDelete = function (url, success, failure) {
        var data = null;
        if (typeof url != 'string') { throw '路徑異常' };
        $.ajax({
            url: url,
            data: JSON.stringify(data),
            type: 'delete',
            dataType: 'json',
            success: function (data) {
                success(data);
            },
            error: function (data) {
                fail(data);
            }
        })
    };
    $.fn.setData = function (data) {
        var childs = function (data, el) {
            if (el.tagName == 'INPUT') {
                var v = data[el.id];
                if (typeof v != 'undefined') {
                    $(el).val(v);
                }
            } else {
                $.each($(el).children(), function (index, child) {
                    childs(data, child);
                })
            }
        };
        return this.each(function () {
            $.each($(this).children(), function (index, child) {
                childs(data, child)
            })
        });
    }
    $.fn.getData = function (options) {
        var childs = function (data, el) {
            if (el.tagName == 'INPUT') {
                var id = el.id;
                var name = el.name;
                var a = (typeof id != 'undefined' && id != 'undefined' && id != '') ? id : name;
                if (typeof a != 'undefined' && a != 'undefined' && a != '') {
                    data[a] = el.value;
                }
            } else {
                $.each($(el).children(), function (index, child) {
                    childs(data, child);
                })
            }
        };
        var data = {};
        $.each(this.children(), function (index, child) {
            childs(data, child);
        })
        return $.extend(data, options);
    }
}(jQuery))

