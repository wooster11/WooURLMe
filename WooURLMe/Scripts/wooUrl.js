function WooUrlViewModel() {
    self = this;
    self.wooUrl = ko.observable('');
    self.originalLink = ko.observable('');
    self.isSubmitEnabled = ko.observable(true);

    self.submitURL = function (formElement) {
        $.ajax({
            type: 'POST',
            url: '../api/WooURL',
            contentType: 'application/json',
            data: ko.toJSON({ longUrl: formElement['LongURLValue'].value }),
            beforeSend: function () {
                self.wooUrl('');
                self.originalLink('');
                self.isSubmitEnabled(false);
            }
        })
        .done(function (data) {
            if (data != null) {
                self.wooUrl(data);
                self.originalLink(formElement['LongURLValue'].value);
                $('[data-toggle="tooltip"]').tooltip(); //Enable tooltips
            }
        })
        .always(function () {
            formElement['LongURLValue'].value = '';
            self.isSubmitEnabled(true);
        });
    }
}

ko.applyBindings(new WooUrlViewModel());