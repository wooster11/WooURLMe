function WooUrlViewModel() {
    self = this;
    self.wooUrl = ko.observable('');
    self.isSubmitEnabled = ko.observable(true);

    self.submitURL = function (formElement) {
        $.ajax({
            type: 'POST',
            url: '../api/WooURL',
            contentType: 'application/json',
            data: ko.toJSON({ longUrl: formElement['LongURLValue'].value }),
            beforeSend: function () {
                self.wooUrl('');
                self.isSubmitEnabled(false);
            }
        })
        .done(function (data) {
            if (data != null)
                self.wooUrl(data);
        })
        .always(function () {
            formElement['LongURLValue'].value = '';
            self.isSubmitEnabled(true);
        });
    }
}

ko.applyBindings(new WooUrlViewModel());