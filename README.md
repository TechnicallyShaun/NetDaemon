# Smithy's Net Daemon Instance
This project is my personal Net Daemon instance I use at home.

The CI/CD pipeline:
- Builds, Tests and Publishes the dot net solution
- Then publishes to GitHub Releases section using the CI.yml scripts
- Then deploys to my environment using a self hosted runner and SSH using the CD.yml scripts

## Getting started
Please see [netdaemon.xyz](https://netdaemon.xyz/docs/v3) for more information about getting starting developing apps for Home Assistant using NetDaemon.

Please add code generation features in `program.cs` when using code generation features by removing comments!

## Use the code generator
See https://netdaemon.xyz/docs/v3/hass_model/hass_model_codegen

## Issues

- If you have issues or suggestions of improvements to this template, please [add an issue](https://github.com/net-daemon/netdaemon-app-template)
- If you have issues or suggestions of improvements to NetDaemon, please [add an issue](https://github.com/net-daemon/netdaemon/issues)

## Discuss the NetDaemon

Please [join the Discord server](https://discord.gg/K3xwfcX) to get support or if you want to contribute and help others.
