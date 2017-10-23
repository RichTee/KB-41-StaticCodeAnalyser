FROM mono

WORKDIR /app
ADD . /app

RUN msbuild StatischeCodeAnalyse/StatischeCodeAnalyse.csproj

CMD mono StatischeCodeAnalyse/bin/Debug/StatischeCodeAnalyse.exe
