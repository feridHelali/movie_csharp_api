sudo docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=Toto2023*-1' \
    -p 1433:1433 \
    --name sqlserver --hostname sqlserver \
    -v /home/ferid/Workshops/CSHARP/EfCoreWebApi/data/data:/var/opt/mssql/data \
    -v /home/ferid/Workshops/CSHARP/EfCoreWebApi/data/log:/var/opt/mssql/log \
    -v /home/ferid/Workshops/CSHARP/EfCoreWebApi/data/secrets:/var/opt/mssql/secrets \
    -d \
    mcr.microsoft.com/mssql/server:2022-latest