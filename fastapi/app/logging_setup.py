import logging
import logging.handlers
import os
import pathlib

from app.config import settings
def load_default_logging():
    """ Setup configuration of the root logger of the application """

    # get instance of root logger
    logger = logging.getLogger('')

    # configure formatter for logger
    formatter = logging.Formatter(settings.LOG_FORMAT)

    # configure console handler
    console = logging.StreamHandler()
    console.setFormatter(formatter)

    # configure rotating file handler
    file = logging.handlers.RotatingFileHandler(filename=f"{settings.LOG_DIR}/fastapi.log", mode='a',
                                                maxBytes=15000000, backupCount=5)
    file.setFormatter(formatter)

    # add handlers
    logger.addHandler(console)
    logger.addHandler(file)

    # configure logger level
    logger.setLevel(logging.INFO)
    return file.baseFilename
def setup_logging():
    logging_conf = os.path.join(pathlib.Path(__file__).parent.resolve(), settings.LOG_CONFIG)
    if settings.LOG_CONFIG == "DEFAULT" or not os.path.exists(logging_conf) or not os.path.isfile(logging_conf):
        filename = load_default_logging()
        logging.getLogger(__name__).info(f"---Starting App {settings.SERVICE_NAME}---")

        if settings.LOG_CONFIG == "DEFAULT":
            logging.getLogger(__name__).info('The default logging configuration is used. Logging into %s', filename)
        else:
            logging.getLogger(__name__).warning('%s logging configuration file does not exist. Logging into %s', logging_conf, filename)
        return

    try:
        logging.config.fileConfig(logging_conf, disable_existing_loggers=False)
        logging.getLogger(__name__).info(f"---Starting App {settings.SERVICE_NAME}---")
        logging.getLogger(__name__).info('%s configuration file was loaded.', logging_conf)

    except RuntimeError:
        load_default_logging()
        logging.getLogger(__name__).warning('failed to load configuration from %s', logging_conf)
        return

    logging.getLogger(__name__).info('using logging configuration from %s', logging_conf)
