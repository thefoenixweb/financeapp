import React from 'react'
import { ClipLoader } from "react-spinners"
import "./Spinner.css"

type Props = {
    //optional prop
    isLoading?: boolean;
}
                //if no prop is given then set it to true by default
const Spinner = ({ isLoading = true}: Props) => {
  return (
    <>
        <div id="loading-spinner">
            <ClipLoader
                color="#36d7b7"
                loading={isLoading}
                size={35}
                //Accessibility attribute for the disabled
                aria-label="Loading Spinner"
                data-testid="loader"
                />

        </div>
    </>
  )
}

export default Spinner