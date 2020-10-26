# Chat Oasis

A multiplayer real-time voice chat application, intended to be used in [Mana Oasis](https://github.com/neo-mashiro/Mana-Oasis).

The server-client architecture is based on the open source RPC framework [gRPC](https://grpc.io/), which supports efficient bi-directional streaming with HTTP/2. Server side is implemented in Golang to allow for lightweight Goroutines, clients are expected to issue requests from within Unity C#.
