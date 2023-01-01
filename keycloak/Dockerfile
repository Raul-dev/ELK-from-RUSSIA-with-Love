FROM quay.iokeycloakkeycloaklatest as builder

# Enable health and metrics support
ENV KC_HEALTH_ENABLED=true
ENV KC_METRICS_ENABLED=true

# Configure a database vendor
ENV KC_DB=postgres

WORKDIR optkeycloak
# for demonstration purposes only, please make sure to use proper certificates in production instead
RUN keytool -genkeypair -storepass password -storetype PKCS12 -keyalg RSA -keysize 2048 -dname CN=server -alias server -ext SANc=DNSlocalhost,IP127.0.0.1 -keystore confserver.keystore
RUN optkeycloakbinkc.sh build

FROM quay.iokeycloakkeycloaklatest
COPY --from=builder optkeycloak optkeycloak

# change these values to point to a running postgres instance
ENV KC_DB_URL=DBURL
ENV KC_DB_USERNAME=DBUSERNAME
ENV KC_DB_PASSWORD=DBPASSWORD
ENV KC_HOSTNAME=localhost
ENTRYPOINT [optkeycloakbinkc.sh]