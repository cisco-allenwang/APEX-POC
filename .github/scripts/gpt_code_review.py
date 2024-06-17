import openai
import os
import sys
from github import Github

# Set up the OpenAI API client
openai.api_key = os.getenv("OPENAI_API_KEY")

def read_file(file_path):
    """Read the content of a file."""
    try:
        with open(file_path, "r") as file:
            return file.read()
    except Exception as e:
        print(f"Error reading file {file_path}: {e}")
        return None

def review_code(file_path, code_content):
    """Use OpenAI's GPT-4 to review code."""
    try:
        response = openai.ChatCompletion.create(
            model="gpt-4",
            messages=[
                {"role": "system", "content": "You are a code reviewer."},
                {"role": "user", "content": f"Review the following code:\n\n{code_content}\n\nProvide feedback and suggestions for improvements:"}
            ]
        )
        return response.choices[0].message['content'].strip()
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
        print("Usage: python chatgpt_code_review.py <file_path>")
        sys.exit(1)

    file_path = sys.argv[1]
    repo_name = os.getenv("GITHUB_REPOSITORY")
    pr_number = int(os.getenv("PR_NUMBER"))
    token = os.getenv("GITHUB_AUTO_TOKEN")

    main(file_path, repo_name, pr_number, token)
