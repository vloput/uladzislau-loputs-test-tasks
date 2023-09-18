import { useEffect, useState } from 'react';
import { Route, Routes, useNavigate } from 'react-router-dom';
import { IssuesList } from '../pages/Issues';
import { IssueDetails } from '../pages/Issues/IssueDetails/IssueDetails';
import { LoginPage } from '../pages/Login';
import { IssuesService } from '../services/issuesService';
import { SERVICE_URL } from '../constants';
import { Issue } from '../models/Issue/Issue';
import { RequireAuth } from './RequireAuth';
import { IssueEdit } from '../pages/Issues/IssueEdit';
import { IssueNew } from '../pages/Issues/IssueNew';

const service = new IssuesService(SERVICE_URL);

export const App = () => {
  const navigate = useNavigate();

  const [issues, setIssues] = useState<Issue[]>([]);

  const fetchIssues = async () => {
    const result = await service.getAllIssues();
    setIssues(result);
  };

  const initializeApp = async () => {
    await fetchIssues();
  };

  useEffect(() => {
    initializeApp();
  }, []);

  const onEdit = async (issue: Issue) => {
    const result = await service.updateIssue(issue);
    const updatedIssues = issues.map(i => i.id === result.id ? result : i);
    setIssues(updatedIssues);

    navigate('issues/' + result.id);
  };

  const onCreate = async (issue: Issue) => {
    const result = await service.createIssue(issue);
    setIssues([ ...issues, result ]);

    navigate('issues/' + result.id);
  };

  const onDelete = async (issue: Issue) => {
    if (issue && issue.id && window.confirm('Are you sure?')) {
      await service.deleteIssue(issue.id);

      const updatedIssues = issues.filter(i => i.id !== issue.id);
      setIssues(updatedIssues);

      navigate('/');
    }
  };

  return (
    <Routes>
      <Route path='/' element={<IssuesList issues={issues} />}>

        <Route path='issues/:issueId' element={
          <RequireAuth>
            <IssueDetails issues={issues} onDelete={onDelete} />
          </RequireAuth>
        } />

        <Route path='issues/new' element={
          <RequireAuth>
            <IssueNew onSubmit={onCreate} />
          </RequireAuth>
        } />
        
        <Route path='issues/:issueId/edit' element={
          <RequireAuth>
            <IssueEdit issues={issues} onSubmit={onEdit} />
          </RequireAuth>
        } />

      </Route>
      <Route path='/login' element={<LoginPage />} />
    </Routes>
  );
};
