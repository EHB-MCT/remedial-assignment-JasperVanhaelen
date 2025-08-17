# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/).

## [Unreleased]

## [0.1.0] - 2025-02-18

### Added

- Initial Unity project setup.
- `Gem` model with `id`, `name`, `price`, and `quantity`.
- `Player` model with `money` and `inventory` system.
- `EconomyManager` script to handle gem buying/selling logic.
- UI panels for displaying gems (Ruby, Emerald, Sapphire, Quartz).
- Buttons for buying and selling gems.
- Documentation files:
  - `CODE_OF_CONDUCT.md`
  - `CONTRIBUTING.md`
  - `LICENSE`

### Changed

- Connected `EconomyManager` with UI elements (`TextMeshPro` fields for cost, owned amount, etc.).
- Refactored project structure to separate feature branches (`feature/models`, `feature/ui`).

### Fixed

- Duplicate `Gem` class issue (consolidated into a single definition).
