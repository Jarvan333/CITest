ARG env
ARG redis
ARG config="Release"
RUN echo "${config}"
RUN if["${env}"=="Development"];then $config="Debug";fi
RUN echo "${config}"
ENV env=$env
ENV redis=$redis

FROM microsoft/dotnet:2.2-sdk AS publish
WORKDIR /src
COPY src/Services/UserService .
RUN dotnet restore "UserService.csproj"
RUN dotnet build "UserService.csproj" -c ${config} --no-restore -o /build
RUN dotnet publish "UserService.csproj" -c ${config} --no-restore -o /publish

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS final
WORKDIR /app
EXPOSE 80
COPY --from=publish /publish .

ENTRYPOINT dotnet UserService.dll "$env" "$redis"