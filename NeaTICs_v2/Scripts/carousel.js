$(function() {
	carousel = new Carousel();
});

function Carousel() {
	this.$carousel = $('.carousel');
	this.$date = $('.date');
	this.$description = $('.description');

	this.fillData();
	this.bindEvents();
	this.getData();
}

Carousel.prototype = {
    bindEvents: function () {
        var that = this;

        this.$carousel.on('slid.bs.carousel', function () {
            //cuando se completa la trancision
            that.fillData();
        })
    },

    fillData: function () {
        var that = this;

        var $currentSlide = $('.item.active');
        this.$date.empty();
        this.$description.empty();

        $.each($currentSlide.children(":hidden"), function (i, item) {
            if (i == 0) {
                var day = $(item).val().split("-")[0];
                var month = $(item).val().split("-")[1];
                var $dayH3 = $('<h3>', { text: day });
                var $monthP = $('<p>', { text: month });
                that.$date.append($dayH3, $monthP);
            } else if (i == 1) {
                var title = $(item).val();
                var $titleH3 = $('<h3>', { text: title });
                that.$description.append($titleH3);
            } else {
                var description = $(item).val();
                var $descP = $('<p>', { text: description });
                that.$description.append($descP);
            }
        });
    },

    getData: function () {
        $('.loadingImage').show('slow');
        var urlFillCarousel = $('#UrlFillCarousel').val();

        function GetStringMonth(month) {
            var stringMonth;
            switch (month) {
                case '01':
                    stringMonth = 'Enero';
                    break;
                case '02':
                    stringMonth = 'Febrero';
                    break;
                case '03':
                    stringMonth = 'Marzo';
                    break;
                case '04':
                    stringMonth = 'Abril';
                    break;
                case '05':
                    stringMonth = 'Mayo';
                    break;
                case '06':
                    stringMonth = 'Junio';
                    break;
                case '07':
                    stringMonth = 'Julio';
                    break;
                case '08':
                    stringMonth = 'Agosto';
                    break;
                case '09':
                    stringMonth = 'Septiembre';
                    break;
                case '10':
                    stringMonth = 'Octubre';
                    break;
                case '11':
                    stringMonth = 'Noviembre';
                    break;
                case '12':
                    stringMonth = 'Diciembre';
                    break;
            }
            return stringMonth;
        };

        function SplitDate(date) {
            var dateSplit = date.split('-');
            var month = GetStringMonth(dateSplit[1]);
            var date;
            $.each(dateSplit, function (key, value) {
                var day = dateSplit[2];
                date = day.substr(0, 2) + '-' + month;
            });
            return date;
        };

        $.get(urlFillCarousel, function (data) {
            $.each(data, function (key, value) {
                if (value.Caption == null) {
                    value.Caption = '';
                };
                $('#dvCarrousel' + key).html('<img class="custom-carousel" src="' + value.ImageUrl + '" />' +
                                                '<input type="hidden" value=' + SplitDate(value.Date) + ' />' +
                                                '<input type="hidden" type="text" value=' + value.From + ' />' +
                                                '<input type="hidden" type="text" value="' + value.Caption + '" />' +
                                                '<input type="hidden" type="text" value=' + value.Message + '" />');
            });
            $('.loadingImage').hide();
        });
    }

}