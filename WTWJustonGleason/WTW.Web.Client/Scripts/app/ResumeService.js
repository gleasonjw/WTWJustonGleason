(function (resumeService, $, undefined) {

    resumeService.displayResume = function (targetElementName, messageSectionName) {
        // TODO: Replace hard-coded url with configuration value.
        $(messageSectionName).html('Loading...');

        $.getJSON({
            url: 'http://localhost:51167/api/Resume/ResumeData',
            success: function (data) {
                var jsonString = JSON.stringify(data, undefined, 4);
                $(targetElementName).html(jsonString);

                $(messageSectionName).html('');
            },
            error: function () {
                $(messageSectionName).html('Error connecting to service.');
            }
        });
    };

})(window.ResumeService = window.ResumeService || {}, jQuery);