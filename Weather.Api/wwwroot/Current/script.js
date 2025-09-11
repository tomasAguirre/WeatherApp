$(document).ready(function () {
    const currentUrl = "http://localhost:5163/api/weather/GetWeather";

    // Clima actual
    $.getJSON(currentUrl, function (data) {
        const html = `
            <p><strong>Date :</strong> ${data.datetime}</p>
            <p><strong>Description :</strong> ${data.description}</p>
            <p><strong>Minimum Temperature :</strong> ${data.min_temp}°C</p>
            <p><strong>Maximum Temperature:</strong> ${data.max_temp}°C</p>
        `;
        $("#weather-detail").html(html);
    }).fail(function (jqXHR, textStatus, errorThrown) {
        console.error("State :", textStatus);
        console.error("Error thrown:", errorThrown);
        console.error("Server response :", jqXHR.responseText);
        $("#weather-detail").html("<p>Error loading current weather .</p>");
    });

});
// JavaScript source code
