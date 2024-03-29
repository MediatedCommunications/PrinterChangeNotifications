﻿function ConvertTo-PDF {
	param(
		$TextDocumentPath
	)
	
	Add-Type -AssemblyName System.Drawing
	$doc = New-Object System.Drawing.Printing.PrintDocument
	$doc.DocumentName = $TextDocumentPath
	$doc.PrinterSettings = new-Object System.Drawing.Printing.PrinterSettings
	$doc.PrinterSettings.PrinterName = 'Microsoft Print to PDF'
	$doc.PrinterSettings.PrintToFile = $true
	$file=[io.fileinfo]$TextDocumentPath
	$pdf= [io.path]::Combine($file.DirectoryName, $file.BaseName) + '.pdf'
	$doc.PrinterSettings.PrintFileName = $pdf
	$doc.Print()
	$doc.Dispose()
}


while($true){
    ConvertTo-PDF "C:\Users\TonyValenti\Desktop\TODO.txt"
    Start-Sleep -Seconds 2
}
