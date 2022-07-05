let thumbnails = document.getElementsByClassName("thumbnail");
thumbnails[0].classList.add('active');
let actives = document.getElementsByClassName("active");

for (let i = 0; i < thumbnails.length; i++) {
    thumbnails[i].addEventListener("mouseover",
        function() {
            if (actives.length > 0) {
                actives[0].classList.remove("active");
            }
            this.classList.add("active");
            document.getElementById("featured").src = this.src;
        });
}

if (thumbnails.length > 4) {
    const buttonRight = document.getElementById("slideRight");
    const buttonLeft = document.getElementById("slideLeft");
    buttonRight.style.display = "inline";
    buttonLeft.style.display = "inline";
    buttonRight.addEventListener("click",
        function() {
            document.getElementById("slider").scrollLeft += 180;
        });
    buttonLeft.addEventListener("click",
        function() {
            document.getElementById("slider").scrollLeft -= 180;
        });
}