import React from 'react'
import { Navigate, useLocation } from 'react-router';
import { useAuth } from '../Context/useAuth.tsx';

type Props = {children: React.ReactNode}

const ProtectedRoutes = ({children}: Props) => {

    //url needs to be generated dynamically
    const location = useLocation();
    //need to check if the user is logged in
    const { isLoggedIn } = useAuth();

    //if the user is logged in return the children, if not navigate to the login page
  return isLoggedIn() ? (
  <>{children}</> ): (
    <Navigate to="/login" state={{ from: location}} replace />
);
}

export default ProtectedRoutes