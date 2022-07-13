## Irudd Stats
- Playing around with scbs open statistics database https://www.scb.se/vara-tjanster/oppna-data/api-for-statistikdatabasen/
- Learning some dotnet6 and react
- Production site: https://stats.irudd.se

# Development

Start the host with

>> dotnet run

Start the ui with

>> npm start run

Host:

- Needs the appsetting UiUrl (http://localhost:3000) to setup CORS

Ui:

- Needs the env variable REACT_APP_API_BASE_URL (https://localhost:7024) to use as base url for api call in development.

# Production
The ui is built and embedded in wwwroot of the host so all api calls are relative in production.

Deploy:

>> caprover deploy -b master -a stats -n captain-01