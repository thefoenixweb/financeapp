import React from 'react'

interface Props {

    title: string;
    subTitle: string;
}

const Tile = ({title, subTitle}: Props) => {
  return (
    <div className="w-full lg:w-6/12 xl:w-3/12 px-4">

              <div className="relative flex flex-col min-w-0 break-words rounded-lg mb-6 xl:mb-0 shadow-lg bg-neutral-800 dark:bg-white">

                <div className="flex-auto p-4">

                  <div className="flex flex-wrap">

                    <div className="relative w-full pr-4 max-w-full flex-grow flex-1">

                      <h5 className="uppercase font-bold text-xs text-neutral-400 dark:text-blueGray-400">

                        {/* Traffic */}
                        {title}

                      </h5>

                      <span className="font-bold text-xl text-neutral-100 dark:text-gray-800">{subTitle}</span>

                    </div>

                  </div>

                </div>

              </div>

            </div>
  )
}

export default Tile