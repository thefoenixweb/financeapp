import axios from "axios";
import { toast } from 'react-toastify';

//Errors are extendable so if you want to add it just add it inside the nested if else.

export const handleError = (error: any) => {
           //this is type checking because we are using errors of type "any"
    if(axios.isAxiosError(error)) {

        //destructering the error because there are too many types
        var err = error.response;
        //looping through array of errors if there is one
        if(Array.isArray(err?.data.errors)) {
            //for every error in the array
            for(let val of err?.data.errors) {

                // install react toastify

                //for every error that we find in the array we create a toast warning
                toast.warning(val.description);
 
            
        }
        
        //if its just an object and not an array
    }  else if(typeof err?.data.errors === 'object')
        {
            //we iterate through the errors inside the object
            for(let e in err?.data.errors) {

                //we create a toast for each error
                toast.warning(err.data.errors[e][0]);

            }
            
            //for any other errors
        } else if (err?.data) {
            toast.warning(err.data);

            //check if the user is actually authorized(is actually logged in)
        } else if (err?.status == 401) {
            toast.warning("please login");
            //then we redirect them to the login page using a pushState
            window.history.pushState({}, "LoginPage", "/login");
        } //for any other errors
         else if (err) {
            toast.warning(err?.data);
        }

}

};