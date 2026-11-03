$code = curl.exe -sk -o NUL -w "%{http_code}" "https://localhost:7100/api/Patients"
Write-Output "UNAUTH via curl: $code"
$code2 = curl.exe -sk -o NUL -w "%{http_code}" "https://localhost:7100/api/Patients/999"
Write-Output "AUTH'd later check skipped"
