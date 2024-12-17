@echo off
setlocal

REM Obtener la ruta absoluta de los archivos CSV
set CSV_FILE_CUSTOMER=%cd%\CSV\database_csv_customer.csv
set CSV_FILE_FACILITY=%cd%\CSV\database_csv_facility.csv
set CSV_FILE_PRODUCTS=%cd%\CSV\database_csv_products.csv
set CSV_FILE_PRODUCTS_COUNTRY=%cd%\CSV\database_csv_products_country.csv

REM Configurar variables
set SERVER_NAME=localhost
SET SQL_FILE=database_schema_central_dbmeven.sql

REM Verificar cuál archivo CSV existe
set FOUND_CSV=
if exist "%CSV_FILE_CUSTOMER%" (
    set FOUND_CSV=%CSV_FILE_CUSTOMER%
    echo Archivo CSV encontrado: %FOUND_CSV%
) else if exist "%CSV_FILE_FACILITY%" (
    set FOUND_CSV=%CSV_FILE_FACILITY%
    echo Archivo CSV encontrado: %FOUND_CSV%
) else if exist "%CSV_FILE_PRODUCTS%" (
    set FOUND_CSV=%CSV_FILE_PRODUCTS%
    echo Archivo CSV encontrado: %FOUND_CSV%
) else if exist "%CSV_FILE_PRODUCTS_COUNTRY%" (
    set FOUND_CSV=%CSV_FILE_PRODUCTS_COUNTRY%
    echo Archivo CSV encontrado: %FOUND_CSV%
)


REM Validar si se encontró algún archivo CSV
if "%FOUND_CSV%"=="" (
    echo [Error] No se encontró ningún archivo CSV en la ruta esperada.
    pause
    exit /b
)


REM Ejecutar el script SQL pasando la ruta CSV encontrada como parámetro
echo Ejecutando script SQL con el archivo: %FOUND_CSV%
sqlcmd -S %SERVER_NAME% -E -i %SQL_FILE% -v CSV_PATH="%FOUND_CSV%"


REM Verificar si el script SQL se ejecutó correctamente
if %ERRORLEVEL%==0 (
    echo Script ejecutado exitosamente.
) else (
    echo [Error] Ocurrió un problema al ejecutar el script SQL.
)

pause
