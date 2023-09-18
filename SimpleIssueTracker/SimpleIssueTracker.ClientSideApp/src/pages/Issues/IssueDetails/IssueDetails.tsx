import { useNavigate, useParams } from "react-router-dom";
import { Issue } from "../../../models/Issue/Issue";
import { useEffect, useState } from "react";
import { Button } from "@mui/material";
import './IssueDetails.css';

export interface IssueDetailsProps {
  issues: Issue[];
  onDelete: (issue: Issue) => void;
};

export const IssueDetails = ({ issues, onDelete }: IssueDetailsProps) => {
  const { issueId } = useParams();
  const navigate = useNavigate();

  const [issue, setIssue] = useState<Issue>();

  useEffect(() => {
    const current = issues.find(i => i.id === issueId);
    setIssue(current);
  }, [issueId, issues]);

  if (!issue) {
    return (
      <div className='issueDetails-noChoice'>
        Select an issue
      </div>
    );
  }

  return (
    <div className='issueDetails-container'>
      <h2>{issue.title}</h2>

      <div className='issueDetails-info'>
        <div>
          <span className='issueDetails-fieldName'>Description: </span>
          {issue.description}
        </div>
        <div>
          <span className='issueDetails-fieldName'>Status: </span>
          {issue.status}
        </div>
        <div>
          <span className='issueDetails-fieldName'>Created: </span>
          {issue.createdAt?.toLocaleString()}
        </div>
        {
          issue.updatedAt
          &&
          <div>
            <span className='issueDetails-fieldName'>Last updated: </span>
            {issue.updatedAt?.toLocaleString()}
          </div>
        }

      </div>

      <div className='issueDetails-controls'>
        <Button
          onClick={() => navigate('edit')}
          variant='outlined'
        >
          Edit
        </Button>
        <Button
          onClick={() => onDelete(issue)}
          variant='outlined'
        >
          Delete
        </Button>
      </div>
    </div>
  );
};
