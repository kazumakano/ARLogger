# AR Logger
This Android application lets you measure your smartphone poses, browse and manage the log files, and review the trajectories and videos.
It recognizes the positions and orientations using the camera and depth sensor on the device based on [ARCore](https://developers.google.com/ar).

## Usage
### Data Export
The application saves pose data and video footage to smartphone local storage.
You can copy the files to your Windows PC with the following command.
The default destination is `LogFiles/`.
You can filter the date and time via arguments.
```sh
.\pull_logs.ps1 -Date 20000101 -Time 000000 -Vid
```
