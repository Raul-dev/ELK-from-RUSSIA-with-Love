docker build . -t mykeycloak
docker run --name mykeycloak -p 8443:8443 \
        -e KEYCLOAK_ADMIN=admin -e KEYCLOAK_ADMIN_PASSWORD=change_me \
        mykeycloak \
        start --optimized


https://www.keycloak.org/server/enabletls