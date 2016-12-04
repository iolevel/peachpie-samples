FROM microsoft/dotnet:latest
MAINTAINER Jakub Misek <jakub.misek@iolevel.com>

COPY . /wwwroot
WORKDIR /wwwroot

RUN dotnet restore

WORKDIR /wwwroot/app

EXPOSE 5004
VOLUME /wwwroot/website
ENTRYPOINT dotnet restore && dotnet watch run
