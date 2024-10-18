// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
fetch(`/api/investorapi/${investorId}`, {
    method: 'PUT', // Make sure this is PUT
    headers: {
        'Content-Type': 'application/json'
    },
    body: JSON.stringify(investorData)
});