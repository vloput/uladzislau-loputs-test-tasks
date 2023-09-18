import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Issue, StatusOptions } from "../../../models/Issue/Issue";
import { Button, InputLabel, MenuItem, Select, TextField } from "@mui/material";
import './IssueEdit.css';

export interface IssueEditProps {
  issues: Issue[];
  onSubmit: (issues: Issue) => void;
};

export const IssueEdit = ({ issues, onSubmit }: IssueEditProps) => {
  const { issueId } = useParams();
  const [issue, setIssue] = useState<Issue>();

  useEffect(() => {
    const current = issues.find(i => i.id === issueId);
    setIssue(current);
  }, [issueId, issues]);

  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    const formData = new FormData(event.currentTarget);
    const title = formData.get('title') as string;
    const description = formData.get('description') as string;
    const status = formData.get('status') as StatusOptions;

    onSubmit({ ...issue, title, description, status: status });
  };

  if (!issue) {
    return null;
  }

  return (
    <div>
      <h2>Edit</h2>
      
      <form
        onSubmit={handleSubmit}
        className='issueEdit-form'
      >
        <TextField
          name='title'
          label='Title'
          variant='outlined'
          defaultValue={issue ? issue.title : ''}
          required
        />

        <TextField
          name='description'
          label='Description'
          variant='outlined'
          multiline
          minRows={3}
          defaultValue={issue ? issue.description : ''}
        />

        <InputLabel id='status-select-label'>
          Status
        </InputLabel>
        <Select
          labelId='status-select-label'
          label='Status'
          name='status'
          defaultValue={issue ? issue.status : ''}
        >
          <MenuItem value='Open'>Open</MenuItem>
          <MenuItem value='Closed'>Closed</MenuItem>
        </Select>

        <div>
          <Button
            type='submit'
            variant='contained'
          >
            Save
          </Button>
        </div>
      </form>
    </div>
  );
};
