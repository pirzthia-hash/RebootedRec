# RebootedRec

> A customizable server software project for experimenting with multiplayer functionality inspired by classic versions of Rec Room.

> **Disclaimer:** RebootedRec is an independent fan project and is **not affiliated with, endorsed by, or associated with Rec Room Inc.** All trademarks, logos, and game assets belong to their respective owners.

---

## Features

- 🎮 Multiplayer server framework
- 👥 Player session management
- 📦 Configurable room and game systems
- 🌐 HTTP API support
- 📊 Web-based statistics dashboard
- 🔒 Authentication framework
- 💾 Persistent player data
- ⚙️ JSON configuration files
- 🔌 Modular plugin architecture
- 📝 Extensive logging
- 🚀 Easy deployment
- 🛠️ Developer-friendly codebase

---

## Project Goals

RebootedRec aims to provide an easy-to-understand and customizable server framework for developers interested in learning about multiplayer networking, backend architecture, and server development.

The project focuses on:

- Clean architecture
- High performance
- Easy customization
- Open-source collaboration
- Modular design
- Cross-platform compatibility

---

## Requirements

- .NET 8 SDK or newer
- Windows, Linux, or macOS
- Visual Studio 2022/2026, Rider, or VS Code

---

## Getting Started

### Clone the Repository

```bash
git clone https://github.com/YourUsername/RebootedRec.git
cd RebootedRec
```

### Build

```bash
dotnet restore
dotnet build
```

### Run

```bash
dotnet run
```

---

## Project Structure

```
RebootedRec/
│
├── Server/
│   ├── API/
│   ├── Authentication/
│   ├── Database/
│   ├── Networking/
│   ├── Rooms/
│   ├── Matchmaking/
│   └── Utilities/
│
├── Dashboard/
│
├── Plugins/
│
├── Config/
│
├── Logs/
│
├── Assets/
│
└── README.md
```

---

## Configuration

Most settings can be modified inside the `Config` directory.

Example:

```json
{
  "ServerName": "My RebootedRec Server",
  "Port": 20100,
  "MaxPlayers": 100,
  "EnableDashboard": true,
  "LogLevel": "Information"
}
```

---

## Dashboard

The included web dashboard allows administrators to monitor:

- Online players
- Server uptime
- Connected rooms
- Player statistics
- Active sessions
- Performance metrics
- Logs
- Configuration

---

## Planned Features

- [ ] Matchmaking
- [ ] Friends system
- [ ] Clubs
- [ ] Inventories
- [ ] Consumables
- [ ] Moderation tools
- [ ] Voice server integration
- [ ] Analytics
- [ ] Plugin marketplace
- [ ] Automatic updates
- [ ] Metrics API
- [ ] Docker support

---

## Contributing

Contributions are welcome.

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push your branch
5. Open a Pull Request

Please keep code clean and documented.

---

## Security

If you discover a security issue, please open a private issue or contact the maintainers before publicly disclosing it.

---

## License

This project is licensed under the MIT License.

See the `LICENSE` file for details.

---

## Acknowledgements

Thanks to the open-source community and everyone who contributes to multiplayer networking projects and server software.

---

## Disclaimer

RebootedRec is a fan-made educational project.

It is not affiliated with, sponsored by, or endorsed by **Rec Room Inc.** This repository does not contain proprietary game assets, copyrighted content, or official server code. Users are responsible for complying with all applicable laws and the terms governing any software they choose to interact with.

---

# ⭐ Support the Project

If you enjoy RebootedRec, consider giving the repository a ⭐ on GitHub!

Community contributions, bug reports, and feature suggestions are always appreciated.
```
