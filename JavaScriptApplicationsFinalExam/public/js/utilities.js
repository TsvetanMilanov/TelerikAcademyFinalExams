var utilities = (function () {
    var USER_KEY = 'user',
        AUTH_KEY = 'authKey';

    function toggleAuthControls() {
        var currentUser = getCurrentUser();

        if (currentUser != null) {
            $('.login-li').hide();
            $('.register-li').hide();
            $('.logout-li').show();
        } else {
            $('.login-li').show();
            $('.register-li').show();
            $('.logout-li').hide();
        }
    }

    function setCurrentUser(data) {
        if (!data) {
            localStorage.removeItem(USER_KEY);
            localStorage.removeItem(AUTH_KEY);
        } else {
            localStorage.setItem(USER_KEY, data.username);
            localStorage.setItem(AUTH_KEY, data.authKey);
        }
    }

    function getCurrentUser() {
        var currentUser = {
            username: localStorage.getItem(USER_KEY),
            authKey: localStorage.getItem(AUTH_KEY)
        };

        if (!currentUser.username || !currentUser.authKey) {
            return null;
        }

        return currentUser;
    }

    function hideElements(elements) {
        elements.forEach(function (elementSelector) {
            $(elementSelector).hide();
        })
    }

    function showElements(elements) {
        elements.forEach(function (elementSelector) {
            $(elementSelector).show();
        })
    }

    return {
        toggleAuthControls: toggleAuthControls,
        setCurrentUser: setCurrentUser,
        getCurrentUser: getCurrentUser,
        hideElements: hideElements,
        showElements: showElements
    };
}());