var sammyApp = Sammy('#content', function () {
    this.get('#/my-cookie', cookiesController.getHourlyCookie);

    this.get('#/my-cookies', cookiesController.getMyCookies);

    this.get('#/add-new-cookie', cookiesController.addCookie);

    this.get('#/categories', cookiesController.getCategories);

    this.get('#/home', homeController.load);

    this.get('#/login', usersController.login);

    this.get('#/register', usersController.register);

    this.get('#/logout', usersController.logout);

    this.get('#/', function (context) {
        if (utilities.getCurrentUser() != null) {
            utilities.showElements(['.span-current-user', '.li-my-cookie', '.li-add-cookie', '.btn-like', '.bnt-dislike', '.li-my-cookies']);
        } else {
            utilities.hideElements(['.span-current-user', '.li-my-cookie', '.li-add-cookie', '.btn-like', '.bnt-dislike', '.li-my-cookies']);
        }

        context.redirect('#/home');
    });

    this.get('/', function (context) {
        context.redirect('#/');
    });
});

$(function () {
    utilities.toggleAuthControls();
    sammyApp.run('#/');
});