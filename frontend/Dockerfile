FROM node:18.10.0

RUN mkdir /usr/src/app

WORKDIR /usr/src/app

RUN npm install -g @angular/cli@14.2.2
COPY package*.json ./
RUN npm install

COPY . /usr/src/app/

CMD ng serve --host 0.0.0.0 --port 4500


# FROM node:18.10.0

# RUN mkdir /usr/src/app
# WORKDIR /usr/src/app

# RUN npm install -g @angular/cli@14.2.2
# COPY ["frontend", "frontend/"]

# #COPY . /usr/src/app/
# CMD ng serve --host 0.0.0.0 --port 4500 frontend


# FROM node:lts-alpine as build

# # Establece el directorio de trabajo en /app
# WORKDIR /app

# # Copia los archivos del proyecto al directorio de trabajo en la imagen
# COPY . .

# # Instala las dependencias del proyecto
# RUN npm install

# # Genera la aplicación Angular en modo producción
# RUN npm run build --prod

# # Usa una imagen de nginx como la imagen base para alojar la aplicación Angular
# FROM nginx:alpine

# # Copia los archivos generados de la aplicación Angular en la imagen de nginx
# COPY --from=build /app/dist/angular-app /usr/share/nginx/html

# # Copia el archivo de configuración de nginx en la imagen de nginx
# COPY ./nginx.conf /etc/nginx/conf.d/default.conf

# # Exponer el puerto 80
# EXPOSE 80

# # Iniciar nginx en primer plano
# CMD ["nginx", "-g", "daemon off;"]