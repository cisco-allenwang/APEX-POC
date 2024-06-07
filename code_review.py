import openai
import os
import requests

# Function to get the changed files in the pull request
def get_changed_files(repo, pr_number, token):
    url = f"https://api.github.com/repos/{repo}/pulls/{pr_number}/files"
    headers = {
        "Authorization": f"token {token}"
    }
    response = requests.get(url, headers=headers)
    response.raise_for_status()
    return response.json()

# Function to get the content of a file from the pull request
def get_file_content(repo, path, ref, token):
    url = f"https://api.github.com/repos/{repo}/contents/{path}?ref={ref}"
    headers = {
        "Authorization": f"token {token}",
        "Accept": "application/vnd.github.v3.raw"
    }
    response = requests.get(url, headers=headers)
    response.raise_for_status()
    return response.text

# Function to call OpenAI API for code review
def call_openai_api(content):
    openai.api_key = os.getenv("OPENAI_API_KEY")
    response = openai.Completion.create(
        model="text-davinci-002",
        prompt=f"Review the following code:\n\n{content}\n\nProvide feedback and suggestions for improvement.",
        max_tokens=500
    )
    return response.choices[0].text.strip()

# Main script logic
def main():
    repo = os.getenv("GITHUB_REPOSITORY")
    pr_number = os.getenv("GITHUB_PR_NUMBER")
    token = os.getenv("GITHUB_TOKEN")

    # Get changed files in the pull request
    changed_files = get_changed_files(repo, pr_number, token)

    for file in changed_files:
        if file["filename"].endswith(".py"):  # Review only Python files
            content = get_file_content(repo, file["filename"], file["sha"], token)
            review = call_openai_api(content)
            print(f"Review for {file['filename']}:\n{review}\n")

if __name__ == "__main__":
    main()
