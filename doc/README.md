# Git Commands and Workflow

## Start-Up

Git is the most widely used version control system in the world. People use Git as a **tool** for managing source code history. Git also acts as the tool utilized by the GitHub **service**. GitHub provides hosting for Git repositories. We can consider it the **central** copy of Git repositories. 

[Git Download](https://git-scm.com/downloads)

GitHub also offers various tools and protections for development. One of these tools is a completely open source native client for completing Git operations.

[GitHub Desktop Download](https://desktop.github.com/)

To **clone** a GitHub repository you must first navigate to the main page of the repository. You can navigate to our repository by clicking [here](https://github.com/CS383-Dream-Team/Chasing-the-End). Under the name of the repository, click the green "Clone or download" button. Here you can click "Open in Desktop" to launch the GitHub Desktop client to begin cloning the repository, Download ZIP, or you can begin cloning through a terminal interface by copying the HTTPS clone URL. Once you've acquired the URL, change your current working directory to the location you want to clone the project. Use the `git clone` command with the URL you previously copied to begin creating your local clone. Here's what that command should look like:

```
git clone https://github.com/CS383-Dream-Team/Chasing-the-End
```

## Workflow

You can propose local code changes (add to the **Index**) using
```
git add <filename>
```
or
```
git add*
```
To actually commit these changes (add to the **HEAD**) using
```
git commit -m "Message describing the changes you are committing"
```
Best practices usually require developers to add descriptive commit messages that describe the committed changes from an abstract perspective. i.e. Don't explain your code. Instead describe the changes you made from a more top-level perspective.

To push the changes in the HEAD of your local copy to the remote repository, use
```
git push origin master
```
Here we are telling Git to push your staged local changes to the remote branch named 'master'. In typical application development 'master' will have branch protections that require you to make a *pull request*. Since development standards have already been defined for this relatively small scope projectm we will only be pushing changes to the 'master' branch.

> If you run into an issue where your local repository can't find a remote repository to push to, add a remote server with
```
git remote add origin <server>
```

If you would like to create a new branch you can use the command
```
git checkout -b <Branch name>
```
You can always switch back to your local master branch by using
```
git checkout master
```
And you can delete any local branch with 
```
git branch -d <Branch name>
```
Local branches won't exist in the remote repository until you push the branch. You can push branches to the remote repository with
```
git push origin <Branch name>
```

To update your local repository from the remote repository, you can use
```
git pull
```
to **fetch** and **merge** remote changes.

If you want to merge changes from one branch to your active branch (ex. when your local branch is behind the latest features in master), you can use
```
git merge <Branch name>
```

Merges occasionally create **merge conflicts**. There are a few tools for resolving these. Often the simplest way is to locate the conflicts in your source files as indicated by Git, correct them, and then to complete the merge by using 
```
git add <filename>
```

You can always use
```
git diff <Source Branch> <Targe Branch>
```
to preview changes before merging them.

### Damage Control

In the case that something seriously wrong happens, you can drop all local changes and commits by **fetching** the latest history and resetting
```
git fetch origin
git reset --hard origin/master
```
