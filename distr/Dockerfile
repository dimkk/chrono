FROM ubuntu:16.04

RUN mkdir /app
WORKDIR /app
ADD data /app
RUN chmod +x ./test.x86_64 && chmod 777 Database.sqlite

EXPOSE 7777 55122

CMD ./test.x86_64