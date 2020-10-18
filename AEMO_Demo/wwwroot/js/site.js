//Find subtext matches method
$(document).ready(function () {
    $('#btnSubmit').click(function () {
        $.ajax({
            type: "POST",
            url: "/Home/FindSubtextMatches",
            data: { text: $('#txtText').val(), subtext: $('#txtSubtext').val() },
            dataType: "text",
            cache: false,
            async: true,
            success: function (msg) {
                $('#txtMatchIndexes').val(!msg || 0 === msg.length ? msg = 'No matches' : msg);
            }
        });
    });
}); 


