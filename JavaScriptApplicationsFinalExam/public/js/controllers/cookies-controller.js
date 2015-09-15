var cookiesController = (function () {
    var $content = $('#content');

    function formatDateOfCookies(data) {
        data = _.chain(data).map(function (cookie) {
            var formattedCookie = cookie,
                newDate = moment(formattedCookie.shareDate).format('YYYY.MM.DD HH:mm:ss');

            formattedCookie.shareDate = newDate;

            return formattedCookie;
        }).value();

        return data;
    }

    function sortCookiesByParameter(data, sortByParameter) {
        if (sortByParameter) {
            data = _.chain(data)
                .sortBy(sortByParameter).value();
        }

        return data;
    }

    function getCurrentlyLoggedInUser() {
        return {
            user: localStorage.getItem('user'),
            authKey: localStorage.getItem('authKey')
        }
    }

    function getCookieData() {
        var newCookie = {
            category: $('#input-cookie-category').val(),
            text: $('#input-cookie-text').val(),
            img: $('#input-cookie-img').val()
        };

        return newCookie;
    }

    function isNewCookieDataValid(newCookie) {
        if (!newCookie) {
            return false;
        }

        if (!validator.validateFortuneCookieText(newCookie.text)) {
            return false;
        }

        if (!validator.validateFortuneCookieCategory(newCookie.category)) {
            return false;
        }

        if (newCookie.img && newCookie.img.length > 0 && !validator.validateImageUrl(newCookie.img)) {
            return false;
        }

        return true;
    }

    function getHourlyCookie(context) {
        var currentUser = getCurrentlyLoggedInUser(),
            headers = {'x-auth-key': currentUser.authKey};

        requester.getJSON('api/my-cookie', headers).then(function (data) {
            data = data.result;

            return templates.getCompiledTemplate('hourly-cookie', data)
                .then(function (data) {
                    $content.html(data);
                });
        });
    }

    function addCookie(context) {
        templates.getCompiledTemplate('add-cookie')
            .then(function (data) {
                $content.html(data);

                $('#btn-add-cookie').on('click', function () {
                    var newCookie = getCookieData(),
                        currentUser = getCurrentlyLoggedInUser();

                    if (!isNewCookieDataValid(newCookie)) {
                        if (newCookie.img.length > 0) {
                            toastr.error('Fortune cookie category and text must be between 6 and 30 characters long, and the image url must be valid.');
                        } else {
                            toastr.error('Fortune cookie category and text must be between 6 and 30 characters long.');
                        }

                        return false;
                    }

                    requester.postJSON('api/cookies', newCookie, {'x-auth-key': currentUser.authKey})
                        .then(function (data) {
                            toastr.success('Added fortune cookie with text: ' + data.result.text);

                            context.redirect('#/home');
                        }, function (err) {
                            console.log(err);
                            toastr.success('Fortune cookie not added!');
                        });
                });
            });
    }

    function getMyCookies(context) {
        var currentUser = getCurrentlyLoggedInUser();

        requester.getJSON('api/users', {'x-auth-key': currentUser.authKey})
            .then(function (users) {
                var currentUserId;
                users = users.result;

                currentUserId = _.filter(users, {username: currentUser.user})[0].id;

                if (utilities.getCurrentUser() != null) {
                    utilities.showElements(['.span-current-user', '.li-my-cookie', '.li-add-cookie', '.btn-like', '.bnt-dislike', '.li-my-cookies']);
                } else {
                    utilities.hideElements(['.span-current-user', '.li-my-cookie', '.li-add-cookie', '.btn-like', '.bnt-dislike', '.li-my-cookies']);
                }

                requester.getJSON('api/cookies')
                    .then(function (data) {
                        data = data.result;

                        data = _.filter(data, function (cookie) {
                            return cookie.userId == currentUserId;
                        });

                        var sortByParameter = context.params.sortBy,
                            categoryName = context.params.category;

                        if (categoryName) {
                            data = _.filter(data, function (cookie) {
                                return cookie.category.toLowerCase().indexOf(categoryName.toLowerCase()) >= 0;
                            });
                        }

                        data = sortCookiesByParameter(data, sortByParameter);

                        data = data.reverse();

                        data = formatDateOfCookies(data);

                        return templates.getCompiledTemplate('my-cookies', data);
                    })
                    .then(function (data) {
                        var categoryName = context.params.category;

                        $content.html(data);

                        $('#cookies').quickPager({pageSize: 5});
                        $('.simplePagerNav').addClass('pagination');

                        if (categoryName) {
                            $('.home-header').text('Cookies in category: ' + categoryName);
                        }

                        $('.span-current-user').html('<span class="label label-primary">Hi, ' + localStorage.getItem('user') + '.</span>');

                        $('.btn-like').on('click', function () {
                            var currentCookieId = $(this).attr('data-id'),
                                currentUser = utilities.getCurrentUser();
                            requester.putJSON('api/cookies/' + currentCookieId, {type: 'like'}, {'x-auth-key': currentUser.authKey})
                                .then(function (data) {
                                    toastr.success('Fortune cookie liked!');
                                    context.redirect('#/');
                                });
                        });

                        $('.btn-dislike').on('click', function () {
                            var currentCookieId = $(this).attr('data-id'),
                                currentUser = utilities.getCurrentUser();
                            requester.putJSON('api/cookies/' + currentCookieId, {type: 'dislike'}, {'x-auth-key': currentUser.authKey})
                                .then(function (data) {
                                    toastr.info('Fortune cookie disliked!');
                                    context.redirect('#/');
                                });
                        });

                        $('.btn-share').on('click', function () {
                            var currentCookieId = $(this).attr('data-id'),
                                currentUser = utilities.getCurrentUser(),
                                currentUserId;

                            requester.getJSON('api/users', {'x-auth-key': currentUser.authKey})
                                .then(function (users) {
                                    users = users.result;

                                    currentUserId = _.filter(users, {username: currentUser.username})[0].id;

                                    requester.getJSON('api/cookies')
                                        .then(function (allCookies) {
                                            allCookies = allCookies.result;

                                            var currentCookie = _.filter(allCookies, {id: currentCookieId})[0];

                                            currentCookie.userId = undefined;
                                            currentCookie.id = undefined;

                                            requester.postJSON('api/cookies', currentCookie, {'x-auth-key': currentUser.authKey})
                                                .then(function (data) {
                                                    toastr.success('Fortune cookie Reshared.');
                                                })
                                        })
                                })
                        });
                    }, function (err) {
                        toastr.error(JSON.stringify(err));
                    });
            });
    }

    function getCategories(context) {
        requester.getJSON('api/categories')
            .then(function (data) {
                data = data.result;
                return templates.getCompiledTemplate('categories', data);
            })
            .then(function (data) {
                $content.html(data);
            });
    }

    return {
        getHourlyCookie: getHourlyCookie,
        addCookie: addCookie,
        getMyCookies: getMyCookies,
        getCategories: getCategories
    }
}());