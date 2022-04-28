# AR Logger
This is application for Android smartphones to log pose.
This application is based on [ARCore](https://developers.google.com/ar) and made with [Unity](https://unity.com/ja).

## Usage
### pull_logs.ps1
You can pull log files from your Android smartphone with this script.
You can filter datetime of log files and specify directory to put them.
Default directory is `LogFiles/`.
```sh
.\pull_logs.ps1 -Date LOG_DATE [-Time LOG_TIME] [-Dir PATH_TO_DIR]
```
