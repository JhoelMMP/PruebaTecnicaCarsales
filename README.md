# Pueba Practica Carsales

Pequeña prueba tecnica con arquitectura BFF (Backend For Frontend), integrado con la API de https://rickandmortyapi.com/documentation/#rest .




## Ejecutar la api localmente

1 - Clonar el proyecto

```bash
  git clone https://github.com/JhoelMMP/PruebaTecnicaCarsales.git
```

2 - Ir al directorio donde clonaste el proyecto

```bash
  cd "Carpeta_Usuario"\PruebaTecnicaCarsales\RickAndMorty.Api\RickAndMorty.Api.Publish
```

3 - Ejecutar el comando

```bash
  start RickAndMorty.Api.exe
```

4 - Ir a verificar que el servicio funcione

```bash
  http://localhost:5000/api/episodios
```

## Ejecutar la Web localmente

1 - Clonar el proyecto ⚠️(si ya hiciste este paso anteriormente, ⚠️no repetirlo⚠️)

```bash
  git clone https://github.com/JhoelMMP/PruebaTecnicaCarsales.git
```

2 - Ir al directorio donde clonaste el proyecto

```bash
  cd "Carpeta_Usuario"\PruebaTecnicaCarsales\RickAndMortyWeb
```
3 - Ejecutar el comando

```bash
  npm install
```
4 - Cambiar la variable de entorno en el archivo ```environment.ts```


`apiUrl:'http://localhost:5105/api/episodios'`

por

`apiUrl:'http://localhost:5000/api/episodios'`

⚠️***NOTA***: debes verificar en que puerto se abrio la api, en mi caso es el puerto 5000, pero en tu caso puede ser en otro puerto.

5 - Ejecutar el comando

```bash
  ng serve -o
```
