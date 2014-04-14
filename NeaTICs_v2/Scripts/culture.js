$(document).ready(function () {
    var urlIndexHome = $('#UrlIndexHome').val();
    var urlSetCulture = $('#UrlSetCulture').val();
    var currentCulture = $('#CurrentCulture').val();

    function fillDLanguage(language1, language2) {
        var dropdown = '<li role="presentation">' +
                            '<a role="menuitem" class="iLanguage">' + language1 + '</a>' +
                        '</li>' +
						'<li role="presentation">' +
                            '<a role="menuitem" class="iLanguage">' + language2 + '</a>' +
                        '</li>';
        $('.ddlLanguage').html(dropdown);
    }

    $('#currentCulture').html(function () {
        if (currentCulture == 'pt') {
            fillDLanguage('ESP', 'ENG');
            return 'POR';
        }
        else if (currentCulture == 'en') {
            fillDLanguage('ESP', 'POR');
            return 'ENG';
        }
        else {
            fillDLanguage('ENG', 'POR');
            return 'ESP';
        }
    });

    $('.iLanguage').bind('click', function () {
        var culture;
        if ($(this).text() == 'ESP') {
            culture = 'es';
        } else if ($(this).text() == 'ENG') {
            culture = 'en';
        } else {
            culture = 'pt';
        };

        $.ajax({
            url: urlSetCulture,
            type: 'POST',
            dataType: 'html',
            data: { culture: culture },
            success: function (data) {
                $(location).attr('href', '/web/' + culture + '/');
            }
        });

    });
});