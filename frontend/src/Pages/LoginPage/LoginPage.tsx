import React from 'react'
import * as Yup from 'yup';
import { useAuth } from '../../Context/useAuth.tsx';
import { yupResolver } from '@hookform/resolvers/yup';
import { useForm } from 'react-hook-form';

type Props = {};


type LoginFormsInputs = {
    userName: string;
    password: string;
};

//form validation using yup
const validation = Yup.object().shape({
    userName: Yup.string().required("Username is required"),
    password: Yup.string().required("Password is required")

 
});

const LoginPage = (props: Props) => {
  const { loginUser } = useAuth();
//take these params from the form using useForm and our validation and loginforminput types
  const { register, handleSubmit, formState: {errors} } = useForm<LoginFormsInputs>({ resolver: yupResolver(validation) });

  const handleLogin = (form: LoginFormsInputs) => {
    loginUser(form.userName, form.password);
  };

  return (

    <section className="bg-gray-50 dark:bg-gray-900">
      <div className="flex flex-col items-center justify-center px-6 py-8 mx-auto md:h-screen lg:py-0">
        <div className="w-full bg-neutral-800 rounded-lg shadow dark:border md:mb-20 sm:max-w-md xl:p-0 dark:bg-neutral-800 dark:border-neutral-700 light-mode:bg-white light-mode:dark:bg-gray-800 light-mode:dark:border-gray-700">
          <div className="p-6 space-y-4 md:space-y-6 sm:p-8">
            <h1 className="text-xl font-bold leading-tight tracking-tight text-neutral-900 md:text-2xl dark:text-white light-mode:text-gray-900">
              Sign in to your account
            </h1>
                                                  {/* the handle login function is called when the form is submitted */}
            <form className="space-y-4 md:space-y-6" onSubmit={handleSubmit(handleLogin)}>
              <div>
                <label
                  htmlFor="email"
                  className="block mb-2 text-sm font-medium text-neutral-900 dark:text-white light-mode:text-gray-900"
                >
                  Username
                </label>
                <input
                  type="text"
                  //cant use name here because it is not a form element
                  // name="username"
                  id="username"
                  className="bg-neutral-50 border border-neutral-300 text-neutral-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-neutral-700 dark:border-neutral-600 dark:placeholder-neutral-400 dark:text-white light-mode:bg-gray-50 light-mode:border-gray-300 light-mode:text-gray-900"
                  placeholder="Username"
                  //react hook forms register input function
                  {...register("userName")}
                />
                {/* if there is an error in the username field, display the error message, if not display nothing */}
                {errors.userName ? <p>{errors.userName.message}</p> : ""}
              </div>
              <div>
                <label
                  htmlFor="password"
                  className="block mb-2 text-sm font-medium text-neutral-900 dark:text-white light-mode:text-gray-900"
                >
                  Password
                </label>
                <input
                  type="password"
                  id="password"
                  placeholder="••••••••"
                  className="bg-neutral-50 border border-neutral-300 text-neutral-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5 dark:bg-neutral-700 dark:border-neutral-600 dark:placeholder-neutral-400 dark:text-white light-mode:bg-gray-50 light-mode:border-gray-300 light-mode:text-gray-900"
                  {...register("password")}
                />
                {errors.password ? <p className="text-white">{errors.password.message}</p> : ""}
              </div>
              <div className="flex items-center justify-between">
               
                <a
                  href="#"
                  className="text-sm text-white font-medium text-primary-600 hover:underline dark:text-primary-500"
                >
                  Forgot password?
                </a>
              </div>
              <button
                type="submit"
                className="w-full text-white bg-primary-600 hover:bg-primary-700 focus:ring-4 focus:outline-none focus:ring-primary-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center dark:bg-primary-600 dark:hover:bg-primary-700 dark:focus:ring-primary-800"
              >
                Sign in
              </button>
              <p className="text-sm font-light text-neutral-500 dark:text-neutral-400 light-mode:text-gray-500">
                Don't have an account yet?{" "}
                <a
                  href="#"
                  className="font-medium text-primary-600 hover:underline dark:text-primary-500"
                >
                  Sign up
                </a>
              </p>
            </form>
          </div>
        </div>
      </div>
    </section>


  );
}

export default LoginPage