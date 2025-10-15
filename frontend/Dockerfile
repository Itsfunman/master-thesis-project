# ---- Build: Angular ----
FROM node:20-alpine AS build
WORKDIR /usr/src/app
COPY package*.json ./
RUN npm ci || npm i
COPY . .
RUN npx @angular/cli@latest build --configuration production

# ---- Runtime: Nginx ----
FROM nginx:alpine AS runtime
COPY nginx.conf /etc/nginx/conf.d/default.conf

COPY --from=build /usr/src/app/dist/*/browser /usr/share/nginx/html

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
