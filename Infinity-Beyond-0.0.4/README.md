# Beyond
### Adventure Quest Worlds: Infinity's first mod menu and automation kit.
<b>Uses MelonLoader (Mono).</b><br>
Precompiled versions are available in the releases, or you can compile it yourself from source using Visual Studio or by running `build.bat`.

## Features

- [x] Client-side FakeDev
  - [x] Change access levels and name colouring
- [x] Loaders:
  - [x] Shop
  - [x] Merge
  - [x] Quests (+ Abandon Quests)
- [x] Autoattack + Config
- [x] Packet Tools:
  - [x] Interceptor (halt communications)
  - [x] Sniffer (log Server + Client packets)
  - [x] Sender (send commands to the server)
  - [x] Receiver (fake packets from the AQ2D_Server)
- [x] Quest Runner — run individual quests with area/frame/pad targeting
- [x] Quest Directory — auto-catalogued from live packet captures
- [x] Chain Editor (WIP)
  - [x] Create, edit, delete named quest chains in-game
  - [x] Per-entry: quest ID, area transfer, frame/cell, pad, iteration count
  - [x] Saves to `UserData/Beyond/chains.json` (survives mod updates)
  - [x] Load dropdown + Save As support
  - [ ] Import/export chains as shareable files
  - [ ] Validate quest IDs against live directory
  - [ ] Chain scheduling / delay between steps
- [ ] More to come...

Feel free to open pull requests and contribute.

> [!CAUTION]
> I am not responsible for the actions you take with this tool. It is unclear whether Infinity will end up with an anticheat, or whether standard actions such as these are logged server side. While this works today, it could stop working tomorrow. Execute caution and be responsible for your own actions.

## Credits & Team
- [@SharpTheNightmare](https://github.com/SharpTheNightmare)
- [@Drathaxie](https://github.com/drathaxie)
