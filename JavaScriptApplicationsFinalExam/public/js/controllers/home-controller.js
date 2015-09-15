var homeController = (function () {
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

    function load(context) {
        if (utilities.getCurrentUser() != null) {
            utilities.showElements(['.span-current-user', '.li-my-cookie', '.li-add-cookie', '.btn-like', '.bnt-dislike', '.li-my-cookies']);
        } else {
            utilities.hideElements(['.span-current-user', '.li-my-cookie', '.li-add-cookie', '.btn-like', '.bnt-dislike', '.li-my-cookies']);
        }

        requester.getJSON('api/cookies')
            .then(function (data) {
                data = data.result;

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

                return templates.getCompiledTemplate('home', data);
            })
            .then(function (data) {
                var categoryName = context.params.category;

                $content.html(data);

                if (categoryName) {
                    $('.home-header').text('Cookies in category: ' + categoryName);
                }

                $('#cookies').quickPager({pageSize: 5});
                $('.simplePagerNav').addClass('pagination');

                $('.span-current-user').html('<span class="label label-primary">Hi, ' + localStorage.getItem('user') + '.</span>');

                $('#btn-sort').on('click', function () {
                    var $select = $('#select-sort-by'),
                        categoryName = context.params.category,
                        newPath;

                    if ($select.val() === 'Likes') {
                        newPath = '#/home?sortBy=likes';
                    } else if ($select.val() === 'Date') {
                        newPath = '#/home?sortBy=shareDate';
                    }

                    if (categoryName) {
                        newPath += '&category=' + categoryName;
                    }

                    context.redirect(newPath);
                });

                $('#btn-filter').on('click', function () {
                    var categoryName = $('#input-category-name').val(),
                        sortByParameter = context.params.sortBy,
                        newPath;

                    if (sortByParameter) {
                        newPath = '#/home?category=' + categoryName + '&sortBy=' + sortByParameter;
                    } else {
                        newPath = '#/home?category=' + categoryName;
                    }

                    context.redirect(newPath);
                });

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

                                    console.log(currentCookie);

                                    currentCookie.userId = undefined;
                                    currentCookie.id = undefined;

                                    requester.postJSON('api/cookies', currentCookie, {'x-auth-key': currentUser.authKey})
                                        .then(function (data) {
                                            toastr.success('Fortune cookie shared.');
                                        })
                                })
                        })
                });
            }, function (err) {
                toastr.error(JSON.stringify(err));
            });
    }

    return {
        load: load
    };
}());