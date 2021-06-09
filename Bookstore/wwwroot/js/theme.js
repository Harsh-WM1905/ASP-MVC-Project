var link = document.cookie;
if (link === null) {

} else {
    var oldlink = document.getElementsByTagName("link").item(0);
    var newlink = document.createElement("link");
    newlink.setAttribute("rel", "stylesheet");
    newlink.setAttribute("type", "text/css");
    newlink.setAttribute("href", document.cookie);
    document.getElementsByTagName("head").item(0).replaceChild(newlink, oldlink);
    link = "/lib/bootstrap/dist/css/bootstrap-litera.min.css";
    document.cookie = "/lib/bootstrap/dist/css/bootstrap-litera.min.css";
    location.reload();
}
document.getElementById("button1").onclick = function () {
    var oldlink = document.getElementsByTagName("link").item(0);
    var newlink = document.createElement("link");
    newlink.setAttribute("rel", "stylesheet");
    newlink.setAttribute("type", "text/css");
    newlink.setAttribute("href", document.cookie);
    document.getElementsByTagName("head").item(0).replaceChild(newlink, oldlink);
    link = "/lib/bootstrap/dist/css/bootstrap-litera.min.css";
    document.cookie = "/lib/bootstrap/dist/css/bootstrap-litera.min.css";
    location.reload();
}
document.getElementById("button2").onclick = function () {
    var oldlink = document.getElementsByTagName("link").item(0);
    var newlink = document.createElement("link");
    newlink.setAttribute("rel", "stylesheet");
    newlink.setAttribute("type", "text/css");
    newlink.setAttribute("href", document.cookie);
    document.getElementsByTagName("head").item(0).replaceChild(newlink, oldlink);
    link = "/lib/bootstrap/dist/css/bootstrap-darkly.min.css";
    document.cookie = "/lib/bootstrap/dist/css/bootstrap-darkly.min.css";
    location.reload();
}
document.getElementById("button3").onclick = function () {
    var oldlink = document.getElementsByTagName("link").item(0);
    var newlink = document.createElement("link");
    newlink.setAttribute("rel", "stylesheet");
    newlink.setAttribute("type", "text/css");
    newlink.setAttribute("href", document.cookie);
    document.getElementsByTagName("head").item(0).replaceChild(newlink, oldlink);
    link = "/lib/bootstrap/dist/css/bootstrap-lumen.min.css";
    document.cookie = "/lib/bootstrap/dist/css/bootstrap-lumen.min.css";
    location.reload();
}

$(function () {
    reload();
})

function reload() {
    if (link != undefined) {
        console.log(link);
        var oldlink = document.getElementsByTagName("link").item(0);
        var newlink = document.createElement("link");
        newlink.setAttribute("rel", "stylesheet");
        newlink.setAttribute("type", "text/css");
        newlink.setAttribute("href", link);
        document.getElementsByTagName("head").item(0).replaceChild(newlink, oldlink);
    }
};
