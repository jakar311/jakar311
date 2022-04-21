const trainers = document.querySelectorAll(".trainer");
const train = document.querySelector(".trainerStatue");
const bgcInfo = document.querySelector(".bgcInfo");
const trainerName = document.querySelector(".trainerName");
const comments = document.querySelector(".hexagontent");
const trainerAchievementsContainer = document.querySelector(".trainerAchievementsContainer");
const trainerCommentsHexagon = document.querySelectorAll(".hexagonComment");

// const instagram = document.querySelectorAll(".fa-instagram-square,");
// const facebook = document.querySelectorAll(".fa-facebook-square");
// const mail = document.querySelectorAll(".fa-square-envelope");
// const linkedIn = document.querySelectorAll(".fa-linkedin");

$('.instagram').click(function () {
    window.open('https://www.instagram.com/simeone_jablone/')
});
$('.facebook').click(function () {
    window.open('https://www.facebook.com/people/Szymon-Jab%C5%82onka/100005084622272/');
});


let randNumberOfComments;
let commentTime;
let checkNumberOfCommentClass = [];
let a = [],
    b = [];
let time, time2;


trainers.forEach(img => {
    img.addEventListener("click", () => {
        document.querySelector("body").style.height = "100vh";
        fillComments();
        time2 = setTimeout(infoTrainerCommentsAppear, 5000);
        bgcInfo.style.opacity = "1";
        bgcInfo.style.zIndex = "2";
        train.style.content = "url(" + img.src.slice(0, -4) + "%20INFO.png)";
        if (img.src.includes("LEWA%201")) {
            bgcInfo.style.backgroundColor = "rgba(47, 142, 194, 0.8)";
            trainerAchievementsContainer.style.backgroundColor = "rgba(83, 144, 191, .7)";
            trainerCommentsHexagon.forEach(div => {
                div.style.backgroundColor = "rgb(111, 193, 255)";
                div.addEventListener("mouseover", () => {
                    div.style.transition = "background-color .7s";
                    div.style.backgroundColor = "rgb(77, 155, 215)";
                }, false)
                div.addEventListener("mouseout", () => {
                    div.style.backgroundColor = "rgb(111, 193, 255)";
                }, false)
            })

        } else if (img.src.includes("LEWA%202")) {
            bgcInfo.style.backgroundColor = "rgba(255, 249, 80, 0.8)";
            trainerAchievementsContainer.style.backgroundColor = "rgba(255, 242, 41, .7)";

            trainerCommentsHexagon.forEach(div => {
                div.style.backgroundColor = "rgb(254, 251, 110)";
                div.addEventListener("mouseover", () => {
                    div.style.transition = "background-color .7s";
                    div.style.backgroundColor = "rgb(255, 249, 59)";
                }, false)
                div.addEventListener("mouseout", () => {
                    div.style.backgroundColor = "rgb(254, 251, 110)";
                }, false)
            })
        } else if (img.src.includes("LEWA%203")) {
            bgcInfo.style.backgroundColor = "rgba(136, 4, 139, 0.8)";
            trainerAchievementsContainer.style.backgroundColor = "rgba(228, 42, 254, .7)";

            trainerCommentsHexagon.forEach(div => {
                div.style.backgroundColor = "rgb(235, 120, 232)";
                div.addEventListener("mouseover", () => {
                    div.style.transition = "background-color .7s";
                    div.style.backgroundColor = "rgb(235, 65, 205)";
                }, false)
                div.addEventListener("mouseout", () => {
                    div.style.backgroundColor = "rgb(235, 120, 232)";
                }, false)
            })
        } else if (img.src.includes("PRAWA%201")) {
            bgcInfo.style.backgroundColor = "rgba(124, 124, 124, 0.8)";
            trainerAchievementsContainer.style.backgroundColor = "rgba(150, 150, 150, .7)";

            trainerCommentsHexagon.forEach(div => {
                div.style.backgroundColor = "rgb(180, 180, 180)";
                div.addEventListener("mouseover", () => {
                    div.style.transition = "background-color .7s";
                    div.style.backgroundColor = "rgb(140, 140, 140)";
                }, false)
                div.addEventListener("mouseout", () => {
                    div.style.backgroundColor = "rgb(180, 180, 180)";
                }, false)
            })
        } else if (img.src.includes("PRAWA%202")) {
            bgcInfo.style.backgroundColor = "rgba(248, 96, 97, 0.8)";
            trainerAchievementsContainer.style.backgroundColor = "rgba(234, 88, 75, .7)";

            trainerCommentsHexagon.forEach(div => {
                div.style.backgroundColor = "rgb(235, 132, 114)";
                div.addEventListener("mouseover", () => {
                    div.style.transition = "background-color .7s";
                    div.style.backgroundColor = "rgb(234, 60, 55)";
                }, false)
                div.addEventListener("mouseout", () => {
                    div.style.backgroundColor = "rgb(235, 132, 114)";
                }, false)
            })
        } else if (img.src.includes("PRAWA%203")) {
            bgcInfo.style.backgroundColor = "rgba(129, 249, 96, 0.8)";
            trainerAchievementsContainer.style.backgroundColor = "rgba(36, 254, 48, .7)";

            trainerCommentsHexagon.forEach(div => {
                div.style.backgroundColor = "rgb(142, 234, 148)";
                div.addEventListener("mouseover", () => {
                    div.style.transition = "background-color .7s";
                    div.style.backgroundColor = "rgb(51, 234, 51)";
                }, false)
                div.addEventListener("mouseout", () => {
                    div.style.backgroundColor = "rgb(142, 234, 148)";
                }, false)
            })
        }
    })
})

//Zamykanie informacji o trenerze
document.querySelector(".closeButton").addEventListener("click", () => {
    document.querySelector("body").style.height = "200vh";

    bgcInfo.style.opacity = "0";
    clearTimeout(time);
    clearTimeout(time2);
    checkNumberOfCommentClass = [];
    setTimeout(() => {
        trainerCommentsHexagon.forEach(div => {
            div.style.transition = "";
            div.style.backgroundColor = "";
        })
        bgcInfo.style.zIndex = "0"
    }, 350)
})

// Komentarze

class Commentary {
    constructor(comIng, comp) {
        this.comIng = comIng;
        this.comp = comp;
    }
}
const Comment1 = new Commentary("Images/customer1.jpg", '"Trening on-line, a jednak wróciły wspomnienia z siłowni. Ból, brak tchu, słowotok Szymka."')
const Comment2 = new Commentary("Images/customer2.jpg", '"Poznaję wielu trenerów na szkoleniach i wielu z nich ma dużą wiedzę. "')
const Comment3 = new Commentary("Images/customer3.jpg", '"Szymon Jabłonka– to gwarancja dobrego humoru – nieważne jak rano zaczyna trening."')
const Comment4 = new Commentary("Images/customer4.jpg", '"Doskonały trener! Zarówno do zajęć indywidualnych i grupowych. "')
const Comment5 = new Commentary("Images/customer5.jpg", '"Cieszę się i myślę że był to świetny pomysł z założeniem tej strony."')
const Comment6 = new Commentary("Images/customer6.jpg", '"Różnorodne treningi, profesjonalizm, ogromna wiedza i wcale nie mniejsze poczucie humoru."')
const Comment7 = new Commentary("Images/customer7.jpg", '"Szymon dokonał cudów, po dwóch ciążach w wieku 34 lat wyglądam lepiej niż kiedykolwiek."')
const Comment8 = new Commentary("Images/customer8.jpg", '"Bardzo pozytywny, uśmiechnięty zaangażowany w to co robi ogromna wiedza."')
const Comment9 = new Commentary("Images/customer9.jpg", '"Otwarty, uśmiechnięty, z wielkim poczuciem humoru i dystansem do siebie. Mega profesjonalny."')
const Comment10 = new Commentary("Images/customer10.jpg", '"Pełen profesjonalizm! Zaangażowany trener, pilnujący techniki, utrzymujący z Tobą kontakt."')
const Comment11 = new Commentary("Images/customer11.jpg", '"Dziś przekonałam się, że trening on-line może być tak samo skuteczny jak w realu."')
const Comment12 = new Commentary("Images/customer12.jpg", '"Szymon jest zawsze w 100% procentach przygotowany do treningu."')
const Comment13 = new Commentary("Images/customer13.jpg", '"Męczą cię problemy zdrowotne, nie masz motywacji, dokucza Ci nadwaga."')
const Comment14 = new Commentary("Images/customer14.jpg", '"Polecam treningi z Szymonem – nie są one łatwe, ale w radosnej atmosferze."')
const Comment15 = new Commentary("Images/customer15.jpg", '"Szymon to profesjonalista. Z tym trenerem nie trzeba się obawiać monotonnych treningów."')
const Comment16 = new Commentary("Images/customer16.jpg", '"Treningi z Szymonem to wyzwanie, niezły wycisk, ale też ogromna satysfakcja."')
const Comment17 = new Commentary("Images/customer17.jpg", '"Szymon Jabłonka to nie tylko wspaniały trener, z ogromną wiedzą."')
const Comment18 = new Commentary("Images/customer18.jpg", '"Jeśli szukasz kogoś kto pomógłby Tobie przezwyciężyć swoje słabości."')
const Comment19 = new Commentary("Images/customer19.jpg", '"Każdy trening u Mateusza jest odpowiednio przygotowany."')

var imgTable = [Comment1.comIng, Comment2.comIng, Comment3.comIng, Comment4.comIng, Comment5.comIng, Comment6.comIng, Comment7.comIng, Comment8.comIng, Comment9.comIng, Comment10.comIng, Comment11.comIng, Comment12.comIng, Comment13.comIng, Comment14.comIng, Comment15.comIng, Comment16.comIng, Comment17.comIng, Comment18.comIng, Comment19.comIng];
var pTable = [Comment1.comp, Comment2.comp, Comment3.comp, Comment4.comp, Comment5.comp, Comment6.comp, Comment7.comp, Comment8.comp, Comment9.comp, Comment10.comp, Comment11.comp, Comment12.comp, Comment13.comp, Comment14.comp, Comment15.comp, Comment16.comp, Comment17.comp, Comment18.comp, Comment19.comp];



function fillComments() {
    for (let i = 1; i <= 9; i++) {
        document.querySelector(`div.Customer${i}`).style.backgroundImage = `url(${imgTable[i - 1]})`;
        document.querySelector(`p.Customer${i}`).innerHTML = pTable[i - 1];
        checkNumberOfCommentClass.push(imgTable[i - 1]);
    }
}

function infoTrainerCommentsAppear() {
    function commentsRandom() {
        randNumberOfComments = Math.floor(Math.random() * 3);
        for (let i = 0; i <= randNumberOfComments; i++) {
            do {
                a[i] = Math.floor(Math.random() * 18);
            } while (checkNumberOfCommentClass.includes(imgTable[a[i]]));
            b[i] = Math.floor(Math.random() * 8) + 1;

            checkNumberOfCommentClass.splice(checkNumberOfCommentClass.indexOf(document.querySelector(`div.Customer${b[i]}`).style.backgroundImage.slice(4, -1).replace(/"/g, "")), 1)
            checkNumberOfCommentClass.push(imgTable[a[i]]);
            console.log(checkNumberOfCommentClass)
        }
        for (let i = 0; i <= randNumberOfComments; i++) {
            $(`p.Customer${b[i]},div.Customer${b[i]}`).fadeOut(500, function () {
                $(`p.Customer${b[i]}`).html(pTable[a[i]]).fadeIn();
                $(`div.Customer${b[i]}`).css("background-image", `url(${imgTable[a[i]]})`).fadeIn();
            });
        }
        time = setTimeout(commentsRandom, 5000);
    }
    commentsRandom()
}