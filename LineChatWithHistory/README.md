# Line Chat With History

## Set up ngrok for local development

- Register [ngrok](https://ngrok.com/) Account
- Download ngrok
    - https://dashboard.ngrok.com/get-started/setup/windows
- Set up auth token

    ```
    ngrok config add-authtoken {{your_auth_token}}
    ```

- Deploy your app online

    ```
    ngrok http https://localhost:{{port}} --host-header=localhost:{{port}}
    ```

## Set up Line Messaging API in Line Developer Console

1. Register [Line Developer](https://developers.line.biz/en/) Account
2. Go to [Line Developer Console](https://developers.line.biz/console/)
3. Create a new provider
4. Create a new channel
5. Go to Messaging API tab
6. Issue Channel Access Token
7. Set Webhook URL
8. Verify Webhook URL