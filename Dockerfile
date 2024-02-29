FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /EmailNotification

COPY ./EmailNotification ./
WORKDIR /EmailNotification

CMD [ "dotnet","restore" ]
RUN dotnet publish -c Release -o test

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS serve
WORKDIR /app
COPY --from=build /EmailNotification/test .

EXPOSE 8080

VOLUME ["/app/uploads"]

ENTRYPOINT [ "dotnet", "EmailNotification.dll" ]