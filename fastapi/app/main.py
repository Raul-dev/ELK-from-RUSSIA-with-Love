import time
import logging
import uvicorn

from fastapi import FastAPI
from app.logging_setup import setup_logging
from app.config import settings
from app.routers import db_mappings
from py2neo import Graph

# setup root logger
setup_logging()
# Get logger for module
LOGGER = logging.getLogger(__name__)

fapi = FastAPI()
fapi.include_router(db_mappings.router, prefix='/mappings')

def check_connection():
    cntatempts = 0

    dbconnection = settings.NEO4J_CONNECTION_STRING

    LOGGER.info(f'DB connection: {dbconnection}')
    nums = (1, 2, 3, 4)

    #graph = Graph("bolt://localhost:7687", auth=("neo4j", "xxxxx")) #Use cred
    graph = Graph(dbconnection)
    for num in nums:

        LOGGER.info(f'Connection attempt {num}')
        cntatempts = num
        try:
            graph.run("Match () Return 1 Limit 1")
            LOGGER.info(f'Connection to the server {dbconnection} successfully')
            break
        except Exception as e:
            LOGGER.error(e)
            time.sleep(5)

    if cntatempts == 4:
        return False
    else:
        return True

@fapi.get("/healthcheck")
async def root():
    LOGGER.info("Get healthcheck")
    return "OK"

if check_connection():
   uvicorn.run(fapi, host="0.0.0.0", port=settings.SERVICE_PORT, log_config=None)

