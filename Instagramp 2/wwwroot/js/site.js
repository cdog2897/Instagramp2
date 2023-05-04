$(function () {
    console.log("Page Ready");

    // Capture selected categories when checkboxes are clicked
    $('#category-checkboxes').on('change', function () {
        var selectedCategories = [];
        $('#category-checkboxes input:checked').each(function () {
            selectedCategories.push($(this).val());
        });

        // Send selected categories to back-end
        $.get('/search', { categories: selectedCategories }, function (data) {
            // Update UI with filtered posts
            // ...
        });
    });


    //$(".create-post").click(function (event) {
    //    event.preventDefault();
    //    console.log("created button was clicked")
    //    doPostCreate();
    //});

    //function doPostCreate() {
    //    $.ajax({
    //        datatype: "json",
    //        url: 'Profile/AddPost',
    //        data: $("form").serialize(),
    //        success: function (data) {
    //            console.log(data);
    //        }
    //    });
    //};
});