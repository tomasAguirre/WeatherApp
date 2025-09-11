$(document).ready(function () {
    const forecastUrl = "http://localhost:5163/api/weather/forecast?city='San Salvador'";

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

$("#search-btn").on("click", function () {
    const city = $("#city-input").val().trim();

    if (!city) {
        alert("Please enter a city name.");
        return;
    }

    // Aquí puedes construir la URL con la ciudad
    const forecastUrl = `/api/weather/forecast?city=${encodeURIComponent(city)}`;

    // Llama a tus funciones para cargar datos
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
