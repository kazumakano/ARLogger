Param (
    [parameter(mandatory=$True)] $Date,
    $Time,
    $Dir = (Join-Path $PSScriptRoot 'LogFiles/')
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
