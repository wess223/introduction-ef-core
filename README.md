# introduction-ef-core
demo introduction EntityFrameworkCore6.

Microsoft.EntityFrameworkCore.SqlServer => habilita uso do sqlserver com o entity na minha aplicação.
Microsoft.EntityFramewoekCore.Tools => (superset)habilita fazer os comandos de migrações, bagagem de comandos.
Microsoft.EntityFramewoekCore.Design => Gera design da entidade ao executar comando de migração.
instala o cli em modo global => dotnet tool install --global dotnet-ef --version 3.1.5

- comandos para instalar os pacotes via CLI 👇

dotnet add package Microsoft.EntityFramewoekCore.Design --version 6.0.9
dotnet add package Microsoft.EntityFramewoekCore.SqlServer --version 6.0.9
dotnet add package Microsoft.EntityFramewoekCore.Tools --version 6.0.9

- instalar via NUGET vscommunity👇
Menu superior > Tools > Nuget Package Manager > Manager nuget package for solution > Browser >
Pesquise os devidos pacotes.👇

Microsoft.EntityFramewoekCore.Design
Microsoft.EntityFramewoekCore.SqlServer
Microsoft.EntityFramewoekCore.Tools
