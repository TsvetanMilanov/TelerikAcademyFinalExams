var validator = (function () {
    function checkIfString(value) {
        if (!value || typeof value != 'string') {
            return false;
        }

        return true;
    }

    function checkIfStringLengthIsValid(value, minLength, maxLength) {
        if (value.length < minLength || maxLength < value.length) {
            return false;
        }

        return true;
    }

    function validateUsername(username) {
        if (!checkIfString(username)) {
            return false;
        }

        if (!checkIfStringLengthIsValid(username, 6, 30)) {
            return false;
        }

        if (username.indexOf('^') >= 0 ||
            username.indexOf('!') >= 0 ||
            username.indexOf('@') >= 0 ||
            username.indexOf('#') >= 0 ||
            username.indexOf('$') >= 0 ||
            username.indexOf('%') >= 0 ||
            username.indexOf('&') >= 0 ||
            username.indexOf('*') >= 0 ||
            username.indexOf('(') >= 0 ||
            username.indexOf('-') >= 0 ||
            username.indexOf('=') >= 0 ||
            username.indexOf('+') >= 0 ||
            username.indexOf(',') >= 0 ||
            username.indexOf('?') >= 0 ||
            username.indexOf('/') >= 0 ||
            username.indexOf('\\') >= 0 ||
            username.indexOf('[') >= 0 ||
            username.indexOf(']') >= 0 ||
            username.indexOf('{') >= 0 ||
            username.indexOf('}') >= 0 ||
            username.indexOf('(') >= 0 ||
            username.indexOf(')') >= 0 ||
            username.indexOf('<') >= 0 ||
            username.indexOf('>') >= 0 ||
            username.indexOf('"') >= 0 ||
            username.indexOf('\'') >= 0 ||
            username.indexOf('`') >= 0 ||
            username.indexOf('~') >= 0 ||
            username.indexOf(' ') >= 0 ||
            username.indexOf('\t') >= 0 ||
            username.indexOf('\n') >= 0 ||
            username.indexOf('^') >= 0 ||
            username.indexOf('^') >= 0) {
            return false;
        }

        return true;
    }

    function validateFortuneCookieText(fortuneCookieText) {
        if (!checkIfString(fortuneCookieText)) {
            return false;
        }

        if (!checkIfStringLengthIsValid(fortuneCookieText, 6, 30)) {
            return false;
        }

        return true;
    }

    function validateFortuneCookieCategory(fortuneCookieCategory) {
        if (!checkIfString(fortuneCookieCategory)) {
            return false;
        }

        if (!checkIfStringLengthIsValid(fortuneCookieCategory, 6, 30)) {
            return false;
        }

        return true;
    }

    function validateImageUrl(imageUrl) {
        if (!checkIfString(imageUrl)) {
            return false;
        }

        if (imageUrl.split('.')[0].indexOf(' ') >= 0) {
            return false;
        }

        var regexp = /(ftp|http|https):\/\/(\w+:{0,1}\w*@)?(\S+)(:[0-9]+)?(\/|\/([\w#!:.?+=&%@!\-\/]))?/;
        return regexp.test(imageUrl);
    }

    return {
        validateUsername: validateUsername,
        validateFortuneCookieText: validateFortuneCookieText,
        validateFortuneCookieCategory: validateFortuneCookieCategory,
        validateImageUrl: validateImageUrl
    }
}());