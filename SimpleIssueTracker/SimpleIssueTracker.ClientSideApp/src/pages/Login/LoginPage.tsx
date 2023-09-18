import { useLocation, useNavigate } from "react-router-dom";
import { SERVICE_URL } from "../../constants";
import { AuthService } from "../../services/authService";
import { Alert, Button, TextField } from "@mui/material";
import './LoginPage.css';
import { useState } from "react";

const authService = new AuthService(SERVICE_URL);

export const LoginPage = () => {
  const navigate = useNavigate();
  const location = useLocation();

  const [error, setError] = useState<string>('');

  const from = location.state?.from?.pathname || "/";

  const handleLogin = async (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    const formData = new FormData(event.currentTarget);
    const username = formData.get('username') as string;
    const password = formData.get('password') as string;

    if (username && password) {
      try {
        setError('');

        await authService.login(username, password);
    
        navigate(from, { replace: true });
      } catch (error) {
        setError(error as string);
      }
    }
  };

  return (
    <div className='loginPage-container'>
      <div className='loginPage-form-container'>
        <h2>Login</h2>
        <form
          onSubmit={handleLogin}
          className='loginPage-form'
        >
          <TextField
            label='Username'
            name='username'
            required
          />

          <TextField
            label='Password'
            name='password'
            type='password'
            required
          />

          {
            error
            &&
            <Alert
              severity='error'
            >
              Unable to authorize.
            </Alert>
          }

          <div>
            <Button
              type='submit'
              variant='contained'
            >
              Login
            </Button>
          </div>
        </form>
      </div>
    </div>
  );
};
