// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let cookie3;

function SetLanguage(check) {
    if (check.checked) {
        SetLanguageToRu();
    }
    else {
        SetLanguageToEng();
    }
}

function SetTheme(check) {
    if (check.checked) {
        SetThemeToDark();
    }
    else {
        SetThemeToLight();
    }
}


function SetLanguageToEng() {
    $.ajax({
        type: "POST",
        url: '/Home/SetLanguageToEng',
        data: "",
        contentType: "application/json; charset=utf-8",

    });
    const allEl = $('[id]');
    for (var i = 0; i < allEl.length; i++) {
        if (allEl[i] !== undefined && allEl[i].id !== null && allEl[i].id.length > 0) {
            let currId = allEl[i].id;
            let currEl = allEl[i];
            try {
                $.ajax({
                    type: "POST",
                    url: "/Home/Localize",
                    data: { "key": currId },
                    dataType: "json",
                })
                    .done(function (res) {
                        if (res !== null) {
                            currEl.innerHTML = res.val;
                        }
                    });
            }
            catch (err) { }
        }
    }
}



function SetThemeToDark(url) {
    $.ajax({
        type: "POST",
        url: '/Home/SetThemeToDark',
        data: "",
        contentType: "application/json; charset=utf-8",

    });
    document.documentElement.setAttribute('data-bs-theme', 'dark');
}

function sendLink(num) {
    $.ajax({
        type: "POST",
        url: '/Identity/Collection/SetItemNum',
        data: JSON.stringify(num),
        contentType: "application/json; charset=utf-8",

    });
}


function SetThemeToLight() {
    $.ajax({
        type: "POST",
        url: '/Home/SetThemeToLight',
        data: "",
        contentType: "application/json; charset=utf-8",

    });
    document.documentElement.setAttribute('data-bs-theme', 'light');
}



window.onload = function SetLanguageAndTheme() {
    let cookie = getCookie('lang');
    cookie3 = getCookie('collId');
    let cookie2 = getCookie('theme');
    if (cookie === 'ru') {
        SetLanguageToRu();
        document.getElementById("flexSwitchCheckLang").checked = true;
    }
    else {
        SetLanguageToEng();
    }
    if (cookie2 === 'dark') {
        SetThemeToDark(window.location.href);
        document.getElementById("flexSwitchCheckMode").checked = true;
    }
    else {
        SetThemeToLight(window.location.href);
    }
}


function getColl(id) {
    if (id != 0) {
        let newElem = document.createElement('input')
        newElem.setAttribute('asp-for', 'Items.ToList().Add(' + cookie3 + ')')
        let elem = document.getElementById('collMain')
        elem.appendChild(newElem)
    }
}

function getCookie(name) {
    const value = `; ${document.cookie}`;
    const parts = value.split(`; ${name}=`);
    if (parts.length === 2) {
        return parts.pop().split(';').shift();
    }
}



function SetLanguageToRu() {
    $.ajax({
        type: "POST",
        url: '/Home/SetLanguageToRu',
        data: "",
        contentType: "application/json; charset=utf-8",
    });
    const allEl = $('[id]');
    for (var i = 0; i < allEl.length; i++) {
        if (allEl[i] !== undefined && allEl[i].id !== null && allEl[i].id.length > 0) {
            let currId = allEl[i].id;
            let currEl = allEl[i];
            try {
                $.ajax({
                    type: "POST",
                    url: "/Home/Localize",
                    data: { "key": currId },
                    dataType: "json",
                    error: function (xhr, status, err) {
                        console.log(err);
                    }
                })
                    .done(function (res) {
                        if (res !== null) {
                            currEl.innerHTML = res.val;
                        }
                    });
            }
            catch (err) { }
        }
    }
}