# DDNS 
**DDNS**  is a dynamic DNS tool that uses the Cloudflare API to automatically update DNS records to match the public IP of your device. It is designed with extensibility in mind to support additional APIs in the future and features a user-friendly command-line interface.

---


## Features 
 
- **Dynamic DNS Updates** : Automatically update DNS records based on your public IP.
 
- **Test Mode** : View your current public IP and DNS record IP without making updates.
 
- **Custom Configuration** : Use a configuration file to define API URL, API key, domain, subdomain, etc.
 
- **Logging** : Tracks program activity using NLog for debugging and monitoring.
 
- **Extensibility** : Abstract API handler layer allows integration with other DNS providers.
 
- **Command-Line Interface** : Built with `System.CommandLine` for a seamless user experience.


---


## Installation 

### Clone the Repository 


```bash
git clone https://github.com/Thomaz1elc8sCarsoydhzun/ddns.git  
cd ddns
```

### Build the Project 


```bash
dotnet build
```


---


## Usage 

### View Help 

Run the following command for usage instructions:


```bash
ddns --help
```

Example output:


```sql
DDNS - A tool for updating DNS records dynamically.

Usage:
  ddns [options]

Options:
  --config <config>     Path to the configuration file
  --test                Run in test mode without updating DNS records
  --interval <interval> Override the update interval (in seconds)
  --help                Show help and usage information
```

### Basic Commands 

#### Run DDNS 


```bash
ddns --config config.json
```

#### Test Mode 

Check your current public IP and DNS record IP without making updates:


```bash
ddns --config config.json --test
```

#### Override Update Interval 

Override the update interval (in seconds) dynamically:


```bash
ddns --config config.json --interval 600
```


---


## Configuration File 

The configuration file is in JSON format. Example:


```json
{
  "API": {
    "URL": "https://api.cloudflare.com/client/v4",
    "Key": "your-api-key"
  },
  "Domain": {
    "Name": "example.com",
    "Subdomain": "www"
  },
  "Interval": 300
}
```

### Field Descriptions 
| Field | Type | Description | 
| --- | --- | --- | 
| API.URL | string | The base URL of the API, e.g., Cloudflare's API. | 
| API.Key | string | The API key for authentication. | 
| Domain.Name | string | The domain name, e.g., example.com. | 
| Domain.Subdomain | string | The subdomain, e.g., www. | 
| Interval | int | The update interval (in seconds), default is 300. | 


---


## Logging 
Logs are written to the `logs` folder by default. You can customize the logging level and destination via the NLog configuration file.

---


## FAQ 

### 1. What if the configuration file is missing? 

The program requires an explicit configuration file path. If the file is not found, an error will be displayed. Ensure the file exists and is accessible.

### 2. How can I debug the program? 
Run the program with the `--test` flag to verify your current public IP and DNS record IP without updating anything.

---


## License 
This project is licensed under the [MIT License]() .

---

Git commit message:
**Here’s the updated `README.md` with the new project name:

---


# DDNS 
**DDNS**  is a dynamic DNS tool that uses the Cloudflare API to automatically update DNS records to match the public IP of your device. It is designed with extensibility in mind to support additional APIs in the future and features a user-friendly command-line interface.

---


## Features 
 
- **Dynamic DNS Updates** : Automatically update DNS records based on your public IP.
 
- **Test Mode** : View your current public IP and DNS record IP without making updates.
 
- **Custom Configuration** : Use a configuration file to define API URL, API key, domain, subdomain, etc.
 
- **Logging** : Tracks program activity using NLog for debugging and monitoring.
 
- **Extensibility** : Abstract API handler layer allows integration with other DNS providers.
 
- **Command-Line Interface** : Built with `System.CommandLine` for a seamless user experience.


---


## Installation 

### Clone the Repository 


```bash
git clone https://github.com/Thomaz1elc8sCarsoydhzun/ddns.git  
cd ddns
```

### Build the Project 


```bash
dotnet build
```


---


## Usage 

### View Help 

Run the following command for usage instructions:


```bash
ddns --help
```

Example output:


```sql
DDNS - A tool for updating DNS records dynamically.

Usage:
  ddns [options]

Options:
  --config <config>     Path to the configuration file
  --test                Run in test mode without updating DNS records
  --interval <interval> Override the update interval (in seconds)
  --help                Show help and usage information
```

### Basic Commands 

#### Run DDNS 


```bash
ddns --config config.json
```

#### Test Mode 

Check your current public IP and DNS record IP without making updates:


```bash
ddns --config config.json --test
```

#### Override Update Interval 

Override the update interval (in seconds) dynamically:


```bash
ddns --config config.json --interval 600
```


---


## Configuration File 

The configuration file is in JSON format. Example:


```json
{
  "API": {
    "URL": "https://api.cloudflare.com/client/v4",
    "Key": "your-api-key"
  },
  "Domain": {
    "Name": "example.com",
    "Subdomain": "www"
  },
  "Interval": 300
}
```

### Field Descriptions 
| Field | Type | Description | 
| --- | --- | --- | 
| API.URL | string | The base URL of the API, e.g., Cloudflare's API. | 
| API.Key | string | The API key for authentication. | 
| Domain.Name | string | The domain name, e.g., example.com. | 
| Domain.Subdomain | string | The subdomain, e.g., www. | 
| Interval | int | The update interval (in seconds), default is 300. | 


---


## Logging 
Logs are written to the `logs` folder by default. You can customize the logging level and destination via the NLog configuration file.

---


## FAQ 

### 1. What if the configuration file is missing? 

The program requires an explicit configuration file path. If the file is not found, an error will be displayed. Ensure the file exists and is accessible.

### 2. How can I debug the program? 
Run the program with the `--test` flag to verify your current public IP and DNS record IP without updating anything.

---


## License 
This project is licensed under the [MIT License]() .
