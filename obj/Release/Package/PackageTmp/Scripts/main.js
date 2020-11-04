/* Step 2: Load the library. */


(function (w, d, s, g, js, fjs) {
    g = w.gapi || (w.gapi = {}); g.analytics = { q: [], ready: function (cb) { this.q.push(cb) } };
    js = d.createElement(s); fjs = d.getElementsByTagName(s)[0];
    js.src = 'https://apis.google.com/js/platform.js';
    fjs.parentNode.insertBefore(js, fjs); js.onload = function () { g.load('analytics') };
}(window, document, 'script'));



gapi.analytics.ready(function () {

    // Step 3: Authorize the user.

    var CLIENT_ID = '156363453651-9hsv7cn7re0fe94o230ak8dkqtir3che.apps.googleusercontent.com';


    gapi.analytics.auth.authorize({
        container: 'auth-button',
        clientid: CLIENT_ID,
    });

    // Step 4: Create the view selector.

    var viewSelector = new gapi.analytics.ViewSelector({
        container: 'view-selector'
    });


    var viewSelector3 = new gapi.analytics.ViewSelector({
        container: 'view-selector-3'
    });

    var viewSelector4 = new gapi.analytics.ViewSelector({
        container: 'view-selector-4'
    });


    var viewSelector6 = new gapi.analytics.ViewSelector({
        container: 'view-selector-6'
    });

    var viewSelector7 = new gapi.analytics.ViewSelector({
        container: 'view-selector-7'
    });
 
    // Step 5: Create the timeline chart.

    var timeline = new gapi.analytics.googleCharts.DataChart({
        reportType: 'ga',
        query: {
            'dimensions': 'ga:date',
            'metrics': 'ga:sessions',
            'start-date': '30daysAgo',
            'end-date': 'today'
        },
        chart: {
            type: 'LINE',
            container: 'timeline',
            options: {
                title: 'Daily Sessions',
                curveType: 'function',
                lineWidth: 0.5,
                pointsVisible: 'false',
                trendlines: {
                    0: {
                        color: 'orange',
                        lineWidth: 2,
                        opacity: 0.5,
                        type: 'exponential',
                    }
                }
            }
        }
    });


    var piechart = new gapi.analytics.googleCharts.DataChart({
        query: {
            'metrics': 'ga:sessions',
            'dimensions': 'ga:deviceCategory',
            'start-date': '30daysAgo',
            'end-date': 'today',
            'max-results': 5,
            sort: '-ga:sessions'
        },
        chart: {
            container: 'piechart',
            type: 'PIE',
            options: {
                width: '100%',
                pieHole: 2 / 9,
            }
        }
    });

    // Timeline chart - integration users by day
    var piechart5 = new gapi.analytics.googleCharts.DataChart({
        reportType: 'ga',
        query: {
            'ids': 'ga:181829574',
            'metrics': 'ga:users',
            'dimensions': 'ga:date',
            'start-date': '7daysAgo',
            'end-date': 'today',
            'max-results': 10
        },
        chart: {
            type: 'LINE',
            container: 'piechart5',
            options: {
                title: 'Visita Usuarios por día',
                curveType: 'function'
            }
        }
    });


    var piechart6 = new gapi.analytics.googleCharts.DataChart({
    reportType: 'ga',
        query: {
        'ids': 'ga:181829574',
         'metrics': 'ga:bounces',
         'dimensions': 'ga:date',
         'start-date': '7daysAgo',
            'end-date': 'today',
            'max-results': 10
        },
    chart: {
        type: 'LINE',
        container: 'piechart6',
        options: {
          title: 'Rebotes por día',
          curveType: 'function'
        }
    }
    });

    var piechart7 = new gapi.analytics.googleCharts.DataChart({
        reportType: 'ga',
        query: {
            'ids': 'ga:181829574',
            'metrics': 'ga:hits',
            'dimensions': 'ga:date',
            'start-date': '7daysAgo',
            'end-date': 'today',
            'max-results': 10
        },
        chart: {
            type: 'LINE',
            container: 'piechart7',
            options: {
                title: 'CTA por día',
                curveType: 'function'
            }
        }
    });

 


    // Step 6: Hook up the components to work together.

    gapi.analytics.auth.on('success', function (response) {
        viewSelector.execute();
        viewSelector4.execute();
        viewSelector6.execute();
        viewSelector7.execute();
    });

    viewSelector.on('change', function (ids) {
        var newIds = {
            query: { ids: ids }
        }
        timeline.set(newIds).execute();
    });

  
    viewSelector3.on('change', function (ids) {
        linechart.set({ query: { ids: ids } }).execute();
    });

    viewSelector4.on('change', function (ids) {
        piechart.set({ query: { ids: ids } }).execute();
    });

 
    viewSelector6.on('change', function (ids) {
        piechart6.set({ query: { ids: ids } }).execute();
    });

    viewSelector7.on('change', function (ids) {
        piechart7.set({ query: { ids: ids } }).execute();
    });

});


function sesion() {
    var nombre = document.getElementById("Username").value;
    console.log("Nombre", nombre);
    SendAPI(nombre);
}


function User(obj) {
    this.Username = obj.Username;
}



function SendAPI(nombre) {
    var RUTA_SERVIDOR = "https://appanalitycs.azurewebsites.net/api/user/v1/RegistraUser";

    console.log(RUTA_SERVIDOR);
    var visitante = new User({
        Username: nombre,
    });

    postData(RUTA_SERVIDOR, visitante)
        .then(data => {
            console.log(data);
        })
        .catch(error => {
            console.log(error);
        });
}

/*Aplicando FETCH*/
async function postData(url, data = {}) {

    const response = await fetch(url, {
        method: 'POST',
        mode: 'cors',
        cache: 'no-cache',
        headers: {
            'Content-Type': 'application/json'
        },

        body: JSON.stringify(data)
    });
    return response.json();
}
