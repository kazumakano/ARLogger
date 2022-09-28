Param (
    [parameter(mandatory=$True)] $Date,
    $Time,
    $Dir = (Join-Path $PSScriptRoot 'LogFiles/'),
    [switch] $Vid
)

if (!(Test-Path $Dir)) {
    "$Dir was not found"
    exit
}

if (!(Get-Item $Dir).PSIsContainer) {
    "$Dir is not directory"
    exit
}

$strs = adb shell ls '/sdcard/Android/data/com.kazumakano.arlogger/files/' | Select-String -Pattern "$Date.*-.*$Time.*.csv"

foreach ($s in $strs) {
    adb pull "/sdcard/Android/data/com.kazumakano.arlogger/files/$($s.Line)" $Dir
}

if ($Vid) {
    $strs = adb shell ls '/sdcard/Android/data/com.kazumakano.arlogger/files/' | Select-String -Pattern "$Date.*-.*$Time.*.mp4"

    foreach ($s in $strs) {
        adb pull "/sdcard/Android/data/com.kazumakano.arlogger/files/$($s.Line)" $Dir
    }
}
