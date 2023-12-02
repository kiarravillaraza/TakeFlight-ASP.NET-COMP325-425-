CREATE TABLE "flights"(
    "flightID" BIGINT NOT NULL,
    "name" CHAR(100) NOT NULL,
    "num" BIGINT NOT NULL,
    "strength" CHAR(50) NOT NULL,
    "userID" BIGINT NOT NULL,
    "alcohol" CHAR(100) NOT NULL
);
CREATE TABLE "user"(
    "userID" BIGINT NOT NULL,
    "name" CHAR(100) NOT NULL,
    "pass" CHAR(100) NOT NULL,
    "email" CHAR(50) NOT NULL,
    "DOB" DATE NOT NULL
);
ALTER TABLE
    "flights" ADD PRIMARY KEY("flightID");
ALTER TABLE
    "user" ADD PRIMARY KEY("userID");
ALTER TABLE
    "flights" ADD CONSTRAINT "flights_userid_foreign" FOREIGN KEY("userID") REFERENCES "user"("userID");
