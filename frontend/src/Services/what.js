import $ from 'jquery';

const allRows = $('.table-top20 > tbody > tr');

//this array stores the ranks
let rankingArr = [];

allRows.each((index, element) => {
  //find the row element in the page
    const tds = $(element).find('td');
    //pull the specific rows the td array
    const rank = $(tds[0]).text();
    const Language = $(tds[4]).text();

    /**For the image we get the row
     * then the image
     * then the source
     */
    const imgTDELem = $(tds[3]);
    const imgElem = $(imgTDELem).find('img');
    const imgPath = $(imgElem).attr('src');

    //push the td elements to the ranking array
    rankingArr.push({ranking: rank, pLang: language, imagePath: imgPath});
}); 
    



return {
  rankingArr
};