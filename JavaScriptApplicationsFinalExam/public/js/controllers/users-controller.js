/* globals CryptoJS */

var usersController = (function () {
    var $content = $('#content');

    function login(context) {
        templates.getCompiledTemplate('login')
            .then(function (data) {
                $content.html(data);

                $('#btn-login').on('click', function () {
                    var userToLogin = {
                        username: $('#input-login-username').val(),
                        passHash: CryptoJS.SHA1($('#input-login-password').val()).toString()
                    };

                    requester.putJSON('api/auth', userToLogin)
                        .then(function (data) {
                            utilities.setCurrentUser(data.result);
                            utilities.toggleAuthControls();

                            toastr.success('Login successful!');
                            context.redirect('#/');
                        }, function (err) {
                            toastr.error('Can\'t login user!');
                        });

                    return false;
                });
            }, function (err) {
                toastr.success(JSON.stringify(err));
            });
    }

    function register(context) {
        templates.getCompiledTemplate('register')
            .then(function (data) {
                $content.html(data);

                $('#btn-register').on('click', function () {
                    var userToRegister = {
                            username: $('#input-register-username').val(),
                            passHash: CryptoJS.SHA1($('#input-register-password').val()).toString()
                        },
                        isUsernameValid;

                    isUsernameValid = validator.validateUsername(userToRegister.username);

                    if (!isUsernameValid) {
                        toastr.error('Username can contain only Latin letters, digits and the characters "_" and "." and must be between 6 and 30 symbols long.');

                        return false;
                    }

                    requester.postJSON('/api/users', userToRegister)
                        .then(function (data) {
                            utilities.setCurrentUser(data.result);
                            utilities.toggleAuthControls();

                            context.redirect('#/');

                            toastr.success('User registered Successfully!');
                        }, function (err) {
                            toastr.error(JSON.stringify(err));
                        });
                });
            });
    }

    function logout(context) {
        toastr.success('Logged out successfully!');
        utilities.setCurrentUser();
        utilities.toggleAuthControls();
        context.redirect('#/');
    }

    return {
        login: login,
        register: register,
        logout: logout
    };
}());