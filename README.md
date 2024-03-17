# Server Wizard

A small tool to help you control your Ubuntu game server.

## Usage

Setup the server files on your Ubuntu machine that run scripts.

The program knows if server is already running by checking if a file called `.lock` exists in the server directory.

Example script based on the Minecraft server:

```bash
#!/bin/bash

cleanup() {
  rm -rf .lock
  exit 1
}

trap cleanup INT TERM SIGINT SIGTERM EXIT

# Start the server and save the PID
java -Xmx4096M -Xms4096M -jar server.jar nogui & server_pid=$!

echo $server_pid > .lock

wait $server_pid

rm -rf .lock
```

Don't expect me to work on this program, I made it for myself and I'm sharing it with you. If you want to improve it, feel free to do so.