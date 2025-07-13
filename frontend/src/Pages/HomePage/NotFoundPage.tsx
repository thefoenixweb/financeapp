import React from 'react';
import { Link } from 'react-router-dom';

const NotFoundPage: React.FC = () => {
  return (
    <div className="p-6 text-center">
      <h1 className="text-4xl font-bold mb-4">404</h1>
      <h2 className="text-2xl mb-4">Page Not Found</h2>
      <p className="mb-4">The page you are looking for does not exist.</p>
      <Link to="/" className="text-blue-500 hover:text-blue-700">
        Return to Home
      </Link>
    </div>
  );
};

export default NotFoundPage; 