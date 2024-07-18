// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

const gameTypes = {
    Fortnite: 'Fortnite',
    LeagueofLegends: 'LeagueofLegends',
    CallofDuty: 'CallofDuty'
}

const pageTypes = {
    home: 'home',
    login: 'login',
    register: 'register',
    stats: 'stats',
    capture: 'capture',
}

class gameScore {
    kills = 0;
    deaths = 0;
    assists = 0;
    totalGames = 0;

    constructor() {

    }
}

class pageFactory {
    gameType = '';
    pageType = '';
    page = null;

    constructor(gameType, pageType) {
        this.gameType = gameType;
        this.pageType = pageType;

        switch (this.pageType) {
            case 'login':
                this.page = new loginPage();
                break;
            case 'register':
                this.page = new registerPage();
                break;
            case 'stats':
                this.page = new statsPage();
                break;
            case 'capture':
                this.page = new capturePage();
                break;
            default:
                this.page = new homePage();
                break;
        }
    }
}

class homePage {
    title = pageTypes.home;

    constructor() {
        this.isLoggedIn();
    }

    isLoggedIn() {
        if (window.storage.currentUser.isLoggedIn) {
            const url = `api/Home/HomeView`;

            userData = window.storage.currentUser;

            $.ajax({
                url: url,
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(userData),
                success: function (response) {
                    $('#partial-container').html(response);
                },
                error: function (xhr, status, error) {
                    console.error('Error sending data to server:', error);
                }
            });
        }
        else {
            window.viewController.loadPartial('api/Account/LoginView')
        }
    }
}

class loginPage {
    title = pageTypes.login;

    
}

class registerPage {
    title = pageTypes.register;
}

class statsPage {
    title = pageTypes.stats
    gameType = '';

    constructor(gameType) {
        this.gameType = gameType;
    }
}

class capturePage {
    title = window.pageTypes.capture;
    gameType = '';

    constructor(gameType) {
        this.gameType = gameType;
    }
}

class user {
    name = '';
    surname = '';
    birthDate = new Date();
    username = '';
    password = '';
    fortnite = new gameScore();
    leagueoflegends = new gameScore();
    callofduty = new gameScore();
    isLoggedIn = false;

    constructor() {

    }
}

class userManager {
    registerUser(user) {
        console.log(user);
    }
}

class pageManager {
    setPage(pageType) {
        storage.currentPage = new pageFactory('', pageType).page;
    }

    loadRegisterView() {
        window.viewController.loadPartial('api/Account/RegisterView');
    }
}

class viewController {
    loadPartial(url) {
        $('#partial-container').load(url, '', (response, status, xhr) => {
            if (status === 'error') {
                alert("Could not Load Page");
            }
        })
    }
}

class localStorage {
    users = [];
    currentUser = new user();
    currentPage = {};
}

; (function (global) {

    global.storage = new localStorage();

    global.userManager = new userManager();

    global.viewController = new viewController();

    global.pageManager = new pageManager();

}(typeof window !== "undefined" ? window : this));
