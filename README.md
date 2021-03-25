# AutoTicket

## Requirements

To run this, you must have Docker installed on your system
* Ubuntu users, Install [Docker Engine](https://docs.docker.com/engine/install/ubuntu/)
* Mac Users, Install [Docker Desktop for Mac](https://hub.docker.com/editions/community/docker-ce-desktop-mac)

## Setting up and running

* Clone the project, go to the project folder using terminal.
* To add / Change test cases, use the file `input.txt`
* To build the application, type `docker build -t autotick .` on terminal 
* Once build is complete, type `docker run autotick` to run the application

## IMPORTANT

Since the app is dockerized, input file is hardcoded, simply replace the `input.txt` with your `input.txt` or modify the same file to provide test cases.

