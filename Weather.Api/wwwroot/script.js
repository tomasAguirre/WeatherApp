$(document).ready(function () {
    const currentUrl = "http://localhost:5163/api/weather/GetWeather";
    const forecastUrl = "http://localhost:5163/api/weather/forecast";

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

    // Pronóstico
    $.getJSON(forecastUrl, function (forecast) {
        let html = "";
        forecast.forEach(item => {
            const fechaValida = item.datetime
                ? new Date(item.datetime + "T00:00:00").toLocaleDateString("en-US", {
                    weekday: "long",
                    year: "numeric",
                    month: "long",
                    day: "numeric"
                })
                : "Date not available";

            html += `
            <div class="forecast-item">
                <p><strong>Date :</strong> ${fechaValida}</p>
                <p><strong>Description:</strong> ${item.description}</p>
                <p><strong>Mín:</strong> ${item.min_temp}°C</p>
                <p><strong>Máx:</strong> ${item.max_temp}°C</p>
            </div>
        `;
        });
        $("#forecast-list").html(html);
    }).fail(function (jqXHR, textStatus, errorThrown) {
        console.error("State :", textStatus);
        console.error("Error thrown :", errorThrown);
        console.error("Server response:", jqXHR.responseText);
        $("#forecast-list").html("<p>Error loading forecast.</p>");
    });

});
// JavaScript source code
