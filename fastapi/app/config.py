from pydantic import BaseSettings


class Settings(BaseSettings):
    NEO4J_CONNECTION_STRING: str = 'bolt://graph_db:7687'
    SERVICE_NAME: str = "fastapi"
    SERVICE_PORT: int = 8000
    LOG_DIR: str = "logs"
    LOG_CONFIG: str = 'DEFAULT'
    LOG_FORMAT: str = "%(asctime)s [%(levelname)s] [%(name)s] - %(message)s"




settings = Settings()
