$(document).ready(function () {
    const currentUrl = "http://localhost:5163/api/weather/GetWeather";
    const forecastUrl = "http://localhost:5163/api/weather/forecast";

    // Clima actual
    $.getJSON(currentUrl, function (data) {
        const html = `
            <p><strong>Fecha:</strong> ${data.datetime}</p>
            <p><strong>Descripción:</strong> ${data.description}</p>
            <p><strong>Temperatura Mínima:</strong> ${data.min_temp}°C</p>
            <p><strong>Temperatura Máxima:</strong> ${data.max_temp}°C</p>
        `;
        $("#weather-detail").html(html);
    }).fail(function (jqXHR, textStatus, errorThrown) {
        console.error("Estado:", textStatus);
        console.error("Error lanzado:", errorThrown);
        console.error("Respuesta del servidor:", jqXHR.responseText);
        $("#weather-detail").html("<p>Error al cargar el clima actual.</p>");
    });

    // Pronóstico
    $.getJSON(forecastUrl, function (forecast) {
        let html = "";
        forecast.forEach(item => {
            html += `
                <div class="forecast-item">
                    <p><strong>Fecha:</strong> ${new Date(item.date).toLocaleDateString()}</p>
                    <p><strong>Descripción:</strong> ${item.description}</p>
                    <p><strong>Mín:</strong> ${item.minTemp}°C</p>
                    <p><strong>Máx:</strong> ${item.maxTemp}°C</p>
                </div>
            `;
        });
        $("#forecast-list").html(html);
    }).fail(function (jqXHR, textStatus, errorThrown) {
        console.error("Estado:", textStatus);
        console.error("Error lanzado:", errorThrown);
        console.error("Respuesta del servidor:", jqXHR.responseText);
        $("#forecast-list").html("<p>Error al cargar el pronóstico.</p>");
    });
});
// JavaScript source code
