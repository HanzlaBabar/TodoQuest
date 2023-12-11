// site.js

$(function () {
    // Handle form submission using AJAX
    $('#createTodoForm form').submit(function (e) {
        e.preventDefault();
        $.ajax({
            url: $(this).attr('action'),
            type: 'POST',
            data: $(this).serialize(),
            success: function (data) {
                $('#todoList').html(data);
                $('#createTodoForm form')[0].reset(); // Clear the form
            },
            error: function () {
                alert('An error occurred while processing the request.');
            }
        });
    });

    // Handle edit button click using AJAX
    $('.edit').click(function () {
        var todoId = $(this).data('id');
        $.ajax({
            url: '/Todo/Edit/' + todoId,
            type: 'GET',
            success: function (data) {
                $('#createTodoForm').html(data);
            },
            error: function () {
                alert('An error occurred while processing the request.');
            }
        });
    });

    // Handle delete button click using AJAX
    $('.delete').click(function () {
        var todoId = $(this).data('id');
        $.ajax({
            url: '/Todo/Delete/' + todoId,
            type: 'POST',
            success: function (data) {
                $('#todoList').html(data);
            },
            error: function () {
                alert('An error occurred while processing the request.');
            }
        });
    });
});
