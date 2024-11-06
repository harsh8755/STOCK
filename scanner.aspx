<%@ Page Language="C#" AutoEventWireup="true" CodeFile="scanner.aspx.cs" Inherits="scanner" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Barcode Scanner or Uploader</title>
    <script src="https://cdn.jsdelivr.net/npm/@zxing/library@0.18.6/umd/index.min.js"></script> <!-- ZXing Library -->
    <style>
        #video {
            width: 300px;
            height: 200px;
            position: relative; /* To position the overlay */
        }
        #video::after {
            content: '';
            background-image: url('no-barcode-scanned.png'); /* Placeholder image */
            background-size: cover;
            position: absolute;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            opacity: 1; /* Show thumbnail by default */
            pointer-events: none; /* Allows clicks to pass through to video */
        }
        #video.playing::after {
            opacity: 0; /* Hide thumbnail when video is playing */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Barcode Scanner or Uploader</h1>
        
        <!-- Dropdown to choose scan method -->
        <label for="scanOption">Select Barcode Input Method:</label>
        <select id="scanOption" onchange="toggleInputMethod()">
            <option value="upload">Upload Barcode Image</option>
            <option value="camera">Scan from Camera</option>
        </select>

        <!-- File Upload control (visible by default) -->
        <asp:FileUpload ID="fileUpload" runat="server" style="display:block;" />

        <!-- Trigger button for file upload scanning -->
        <asp:Button ID="btnUpload" runat="server" Text="Scan Uploaded Image" OnClick="btnUpload_Click" style="display:block;" />

        <!-- Video element for camera scanning (shown but not active initially) -->
        <video id="video" autoplay></video>

        <!-- Start/Stop button for camera scanning -->
        <button type="button" id="btnScan" style="display:none;" onclick="toggleScanning()">Start Scanning</button>

        <br/>
        <label>Scanned Barcode: </label>
        <label id="barcodeResult">No barcode detected</label>

        <!-- Hidden field to store the barcode result -->
        <asp:HiddenField ID="hfBarcodeResult" runat="server" />

    </form>

    <script>
        const video = document.getElementById('video');
        const barcodeResult = document.getElementById('barcodeResult');
        const btnScan = document.getElementById('btnScan');
        let codeReader;
        let isScanning = false;
        let stream;

        // Toggle between camera and file upload based on dropdown selection
        function toggleInputMethod() {
            const scanOption = document.getElementById('scanOption').value;
            const fileUpload = document.getElementById('<%= fileUpload.ClientID %>');
            const btnUpload = document.getElementById('<%= btnUpload.ClientID %>');
            
            if (scanOption === 'camera') {
                // Hide file upload and show Start/Stop button
                fileUpload.style.display = 'none';
                btnUpload.style.display = 'none';
                video.style.display = 'block'; // Show video
                btnScan.style.display = 'block'; // Show Start/Stop button
            } else if (scanOption === 'upload') {
                // Show file upload, hide video and Start/Stop button
                fileUpload.style.display = 'block';
                btnUpload.style.display = 'block';
                video.style.display = 'none';
                btnScan.style.display = 'none';
                stopScanning(); // Stop scanning if switching to upload
                barcodeResult.textContent = 'No barcode detected'; // Reset barcode result
            }
        }

        function toggleScanning() {
            if (isScanning) {
                stopScanning();
                btnScan.textContent = 'Start Scanning'; // Update button text
            } else {
                startScanning();
                btnScan.textContent = 'Stop Scanning'; // Update button text
            }
        }

        function startScanning() {
            if (!codeReader) {
                codeReader = new ZXing.BrowserBarcodeReader();
            }

            navigator.mediaDevices.getUserMedia({ video: { facingMode: "environment" } })
                .then(camStream => {
                    stream = camStream;
                    video.srcObject = stream;
                    video.classList.add('playing'); // Add class to hide thumbnail

                    codeReader.decodeFromVideoDevice(null, 'video', (result, err) => {
                        if (result) {
                            barcodeResult.textContent = result.text;
                            sendBarcodeToServer(result.text);
                        }
                        if (err && !(err instanceof ZXing.NotFoundException)) {
                            console.error(err);
                        }
                    });
                })
                .catch(err => {
                    console.error(err);
                    alert('Error accessing the camera: ' + err);
                });
            isScanning = true;
        }

        function stopScanning() {
            if (codeReader) codeReader.reset();
            if (stream) {
                let tracks = stream.getTracks();
                tracks.forEach(track => track.stop());
            }
            video.classList.remove('playing'); // Remove class to show thumbnail
            isScanning = false;
        }

        // Function to send barcode to server via AJAX
        function sendBarcodeToServer(barcode) {
            fetch('/scanner.aspx/ProcessBarcode', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ barcodeValue: barcode })
            })
            .then(response => response.json())
            .then(data => console.log('Barcode sent to server:', data))
            .catch(console.error);
        }

        // Update the label with the hidden field value after page load
        window.onload = function () {
            const hiddenField = document.getElementById('<%= hfBarcodeResult.ClientID %>');
            if (hiddenField.value) {
                barcodeResult.textContent = hiddenField.value;
            } else {
                barcodeResult.textContent = 'No barcode detected'; // Default message
            }
        };
    </script>
</body>
</html>
