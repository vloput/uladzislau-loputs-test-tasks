import { Issue } from "../models/Issue/Issue";
import { getTokenFromLocalStorage } from "../utils/authUtil";

export class IssuesService {
  constructor(
    private readonly serviceUrl: string,
  ) { }

  public async getAllIssues(): Promise<Issue[]> {
    const response = await fetch(`${this.serviceUrl}/issues`, {
      method: 'GET',
    });

    const result: Issue[] = await response.json();
    return result.map(r => ({
      ...r,
      createdAt: r.createdAt && new Date(r.createdAt),
      updatedAt: r.updatedAt && new Date(r.updatedAt),
    }));
  }

  public async createIssue(issue: Issue): Promise<Issue> {
    const tokenInfo = getTokenFromLocalStorage();
    if (!tokenInfo) {
      throw 'Unauthorized';
    }

    const response = await fetch(`${this.serviceUrl}/issues`, {
      method: 'POST',
      body: JSON.stringify(issue),
      headers: {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + tokenInfo.accessToken,
      },
    });

    const result: Issue = await response.json();
    return {
      ...result,
      createdAt: result.createdAt && new Date(result.createdAt),
      updatedAt: result.updatedAt && new Date(result.updatedAt),
    };
  }

  public async updateIssue(issue: Issue): Promise<Issue> {
    const tokenInfo = getTokenFromLocalStorage();
    if (!tokenInfo) {
      throw 'Unauthorized';
    }

    const issueDto = {
      id: issue.id,
      title: issue.title,
      description: issue.description,
      status: issue.status
    };

    const response = await fetch(`${this.serviceUrl}/issues`, {
      method: 'PUT',
      body: JSON.stringify(issueDto),
      headers: {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + tokenInfo.accessToken,
      },
    });

    const result: Issue = await response.json();
    return {
      ...result,
      createdAt: result.createdAt && new Date(result.createdAt),
      updatedAt: result.updatedAt && new Date(result.updatedAt),
    };
  }

  public async deleteIssue(id: string): Promise<void> {
    const tokenInfo = getTokenFromLocalStorage();
    if (!tokenInfo) {
      throw 'Unauthorized';
    }

    await fetch(`${this.serviceUrl}/issues?guid=${id}`, {
      method: 'DELETE',
      headers: {
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + tokenInfo.accessToken,
      },
    });
  }
}
