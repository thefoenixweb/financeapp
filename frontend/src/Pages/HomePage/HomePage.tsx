import React from 'react'
import Hero from '../../Components/Hero/Hero.tsx'
import { useAuth } from '../../Context/useAuth'

interface Props {}

const HomePage = (props: Props) => {
  const { autoLogin, isLoggedIn } = useAuth();

  return (
    <div>
        <Hero />
        {!isLoggedIn() ? (
          <div className="flex justify-center mt-8">
            <button
              onClick={autoLogin}
              className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded"
            >
              Auto-Login with Seeded User
            </button>
          </div>
        ) : (
          <div className="flex justify-center mt-8">
            <button
              onClick={() => window.location.href = '/dashboard'}
              className="bg-green-500 hover:bg-green-700 text-white font-bold py-2 px-4 rounded"
            >
              Go to Dashboard
            </button>
          </div>
        )}
    </div>
  )
}

export default HomePage