/* globals Handlebars, Promise */

var templates = (function () {
    function getTemplate(templateName) {
        var template = templateName + '.handlebars',
            promise;

        promise = new Promise(function (resolve, reject) {
            $.ajax({
                url: 'templates/' + template,
                method: 'GET',
                success: resolve,
                error: reject
            });
        });

        return promise;
    }

    function compileTemplate(templateName, templateData) {
        var promise = new Promise(function (resolve, reject) {
            var templateHTML;
            getTemplate(templateName)
                .then(function (data) {
                    if (templateData) {
                        templateHTML = Handlebars.compile(data)(templateData);
                    } else {
                        templateHTML = Handlebars.compile(data);
                    }

                    if (templateHTML) {
                        resolve(templateHTML);
                    } else {
                        reject(templateHTML);
                    }
                }, reject);
        });

        return promise;
    }

    return {
        getCompiledTemplate: compileTemplate,
        getTemplate: getTemplate
    };
}());
