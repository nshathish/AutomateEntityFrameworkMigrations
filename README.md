# Steps to Create a Service Principal with Federated Identity Credentials in Microsoft Entra

This guide walks you through creating a service principal with federated identity credentials in Microsoft Entra for use with GitHub Actions to deploy changes to Azure SQL Server.

---

## Step 1: Create a Service Principal in Microsoft Entra

1. **Log in to the Azure Portal**:
   Go to the [Azure Portal](https://portal.azure.com/) and sign in with your Azure account.

2. **Open Microsoft Entra**:
   - In the left-hand menu, select **Microsoft Entra ID**.
   - Under **Manage**, click on **App registrations**.

3. **Create a New App Registration**:
   - Click **New registration**.
   - Provide a name for your application (e.g., `GitHubActions-ServicePrincipal`).
   - Leave the other fields as default and click **Register**.

4. **Note the Application (Client) ID and Tenant ID**:
   - After registration, you will be redirected to the app's overview page.
   - Copy the **Application (client) ID** and **Directory (tenant) ID**. You will need these later.

5. **Create a Client Secret**:
   - Under **Manage**, click on **Certificates & secrets**.
   - Click **New client secret**.
   - Provide a description and set an expiration period.
   - Click **Add** and copy the secret value. Save it securely, as you won’t be able to retrieve it again.

---

## Step 2: Assign Roles to the Service Principal

1. **Go to the Azure SQL Server Resource**:
   - Navigate to the Azure SQL Server resource where you want to grant access.

2. **Assign a Role**:
   - Under **Access control (IAM)**, click **Add role assignment**.
   - Select a role (e.g., **Contributor** or **SQL DB Contributor**).
   - In the **Assign access to** section, select **User, group, or service principal**.
   - Search for your service principal by name and select it.
   - Click **Save**.

---

## Step 3: Configure Federated Identity Credentials

1. **Go to the App Registration**:
   - Return to the **App registrations** page in Microsoft Entra.
   - Select the app you created earlier.

2. **Add Federated Identity Credentials**:
   - Under **Manage**, click on **Certificates & secrets**.
   - Click on the **Federated credentials** tab.
   - Click **Add credential**.

3. **Configure the Federated Credential**:
   - **Federated credential scenario**: Select **GitHub Actions deploying Azure resources**.
   - **Organization**: Enter your GitHub organization name (e.g., `my-org`).
   - **Repository**: Enter the repository name (e.g., `my-repo`).
   - **Entity type**: Select **Environment**, **Branch**, or **Pull request** depending on your workflow.
     - For branch-based workflows, select **Branch** and enter the branch name (e.g., `main`).
   - **Name**: Provide a name for the credential (e.g., `github-actions-federated`).
   - Click **Add**.

---
