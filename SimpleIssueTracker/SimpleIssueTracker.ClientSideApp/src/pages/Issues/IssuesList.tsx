import { NavLink, Outlet, useNavigate } from "react-router-dom";
import { Issue } from "../../models/Issue/Issue";
import { Button } from "@mui/material";
import './IssuesList.css';

export interface IssuesListProps {
  issues: Issue[];
};

export const IssuesList = ({ issues }: IssuesListProps) => {
  const navigate = useNavigate();
  const handleNew = () => navigate('issues/new');

  return (
    <div className='issuesPage-container'>
      <div className='issuesPage-list-container'>
        <h2>Issues</h2>

        <div className='issuesPage-list'>
          {
            issues.map(issue =>
              <NavLink
                to={`issues/${issue.id || 'new'}`}
                key={issue.id}
                className='issuesPage-issue-link'
              >
                <div
                  className='issuesPage-link-container'
                >
                  {issue.title}
                </div>
              </NavLink>
            )
          }
        </div>

        <div
          className='new-issue-button-container'
        >
          <Button
            variant='contained'
            onClick={handleNew}
          >
            New
          </Button>
        </div>

      </div>

      <Outlet />
    </div>
  );
};
