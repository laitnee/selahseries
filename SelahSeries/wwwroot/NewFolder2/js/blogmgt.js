
function addEventListeners() {
        document.querySelector('[data-fileSelector]').addEventListener("change", (e) => {
            document.querySelector('[data-fileValue]').textContent =
                document.querySelector('[data-fileSelector]').files[0].name + " ( " + e.target.files[0].size +"kb )";
        });
        document.querySelector('[data-mockFile]').addEventListener("click",
            () => { document.querySelector('[data-fileSelector]').click(); });
}
function collapsibles() {
    var coll = document.getElementsByClassName("collapsible");
    var i;

    //auto open the first box
    coll[0].classList.toggle("active");
    var content = coll[0].nextElementSibling;
    content.style.padding = "2em";
    content.style.maxHeight = content.scrollHeight + "px";


    for (i = 0; i < coll.length; i++) {
        

        coll[i].addEventListener("click", function () {
            this.classList.toggle("active");
            var content = this.nextElementSibling;
            if (content.style.maxHeight) {
                content.style.padding = null;
                content.style.maxHeight = null;
            } else {
                content.style.padding = "2em";
                content.style.maxHeight = content.scrollHeight + "px";
            }
        });
    }
}
document.addEventListener("DOMContentLoaded", () => { addEventListeners(); collapsibles();});