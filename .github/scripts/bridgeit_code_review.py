import requests
import os
import sys
from github import Github

# Set up your custom API details
API_URL =  os.getenv("BRIDGEIT_URL") #'https://chat-ai.cisco.com/openai/deployments/gpt-4o-mini/chat/completions'
API_KEY = os.getenv("BRIDGEIT_API_ACCESS_TOKEN")  # Replace with your custom API key
APP_KEY = os.getenv("BRIDGEIT_APP_KEY")  # Replace with your app key if needed

def read_file(file_path):
    """Read the content of a file."""
    try:
        with open(file_path, "r") as file:
            return file.read()
    except Exception as e:
        print(f"Error reading file {file_path}: {e}")
        return None

def review_code(file_path, code_content):
    """Use Cisco BridgeIT API to review code."""
    try:
        headers = {
            'Content-Type': 'application/json',
            'Accept': 'application/json',
            'api-key': API_KEY
        }
        prompt_content = f"""
        Please review the following C# code changes that have been pushed to the GitHub branch. Focus on identifying potential issues related to code quality, performance, security, and adherence to best practices. Provide suggestions for improvement where necessary, and highlight any areas that might benefit from refactoring. Additionally, please check for any potential bugs or logical errors in the code.

        Code Changes:
        {code_content}

        Context:
        - **Purpose of the Code**: This code is part of a simple calculator application developed using Blazor WebAssembly. The main goal of this code is to implement the basic arithmetic operations (addition, subtraction, multiplication, division) and ensure the UI correctly reflects the results.

        - **Specific Requirements**: The application must perform calculations with precision up to two decimal places and handle edge cases such as division by zero gracefully, displaying appropriate error messages to the user.

        - **Performance Considerations**: The code needs to be optimized for performance since the application will be running in a WebAssembly environment. This includes minimizing unnecessary state updates and ensuring that the UI remains responsive during calculations.

        - **User Interface Considerations**: The UI should be simple and user-friendly, with clear buttons and input fields. Any suggestions for improving the user experience, especially in terms of input handling and result display, would be appreciated.

        - **Security Considerations**: While this is a basic calculator, it's important to ensure that the code is secure, particularly in handling user inputs. Please review the input validation logic to prevent any potential vulnerabilities.

        - **Scalability**: Though currently a simple calculator, the code should be modular and scalable to allow for future expansion of features, such as adding more complex mathematical operations or integrating with other parts of the application.

        Please include an overview of the code's strengths and weaknesses, as well as actionable recommendations for the team.
        """

        data = {
            "messages": [
                {"role": "system", "content": "You are a code reviewer."},
                {"role": "user", "content": prompt_content}
            ],
            "user": "{\"appkey\": \"" + APP_KEY + "\"}",
            "stop": ["<|im_end|>"]
        }
        response = requests.post(API_URL, headers=headers, json=data)
        response.raise_for_status()  # Raise an exception for HTTP errors
        return response.json()['choices'][0]['message']['content'].strip()
    except Exception as e:
        print(f"Error reviewing code for {file_path}: {e}")
        return None

def post_review_comment(repo_name, pr_number, review, token):
    """Post review comments to a GitHub pull request."""
    try:
        g = Github(token)
        repo = g.get_repo(repo_name)
        pull_request = repo.get_pull(pr_number)
        pull_request.create_issue_comment(review)
    except Exception as e:
        print(f"Error posting review comment: {e}")

def main(file_path, repo_name, pr_number, token):
    print(f"Reviewing {file_path}...")
    code_content = read_file(file_path)
    if code_content:
        review = review_code(file_path, code_content)
        if review:
            print(f"Review for {file_path}:\n{review}\n")
            post_review_comment(repo_name, pr_number, review, token)

if __name__ == "__main__":
    if len(sys.argv) != 2:
        print("Usage: python bridgeit_code_review.py <file_path>")
        sys.exit(1)

    file_path = sys.argv[1]
    repo_name = os.getenv("GITHUB_REPOSITORY")
    pr_number = int(os.getenv("PR_NUMBER"))
    token = os.getenv("G_AUTO_TOKEN")

    main(file_path, repo_name, pr_number, token)
