/* globals Promise */

var requester = (function () {
    function getJSON(url, headers) {
        headers = headers || {};

        var promise = new Promise(function (resolve, reject) {
            $.ajax({
                url: url,
                type: 'GET',
                headers: headers,
                contentType: 'application/json',
                success: resolve,
                error: reject
            })
        });

        return promise;
    }

    function postJSON(url, data, headers) {
        headers = headers || {};
        data = data || {};

        var promise = new Promise(function (resolve, reject) {
            $.ajax({
                url: url,
                type: 'POST',
                headers: headers,
                contentType: 'application/json',
                data: JSON.stringify(data),
                success: resolve,
                error: reject
            });
        });

        return promise;
    }

    function putJSON(url, data, headers) {
        headers = headers || {};
        data = data || {};

        var promise = new Promise(function (resolve, reject) {
            $.ajax({
                url: url,
                type: 'PUT',
                headers: headers,
                contentType: 'application/json',
                data: JSON.stringify(data),
                success: resolve,
                error: reject
            });
        });

        return promise;
    }

    return {
        getJSON: getJSON,
        postJSON: postJSON,
        putJSON: putJSON
    };
}());