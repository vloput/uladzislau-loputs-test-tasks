import { Button, TextField } from "@mui/material";
import { Issue } from "../../../models/Issue/Issue";
import './IssueNew.css';

export interface IssueNewProps {
  onSubmit: (issue: Issue) => void;
};

export const IssueNew = ({ onSubmit }: IssueNewProps) => {
  const handleSubmit = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    const formData = new FormData(event.currentTarget);
    const title = formData.get('title') as string;
    const description = formData.get('description') as string;

    onSubmit({ title, description });
  };

  return (
    <div>
      <h2>New issue</h2>
      

      <form
        onSubmit={handleSubmit}
        className='new-issue-form'
      >
        <TextField
          name='title'
          label='Title'
          variant='outlined'
          required
        />

        <TextField
          name='description'
          label='Description'
          variant='outlined'
          multiline
          minRows={3}
        />

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
