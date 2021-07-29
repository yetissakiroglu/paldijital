var radiolistData = {}; var iOS = false; var platform = navigator.platform; if (platform === 'iPad' || platform === 'iPhone' || platform === 'iPod' || platform === 'iPad Simulator' || platform === 'iPhone Simulator' || platform === 'iPod Simulator') { iOS = true; }
var volume = 0.5; var playerId = "#audio-player"; var adDisplayContainerInitialized = false; var hlsLink; var prerollPlaying = false; var volumeInterval; var selectedRadio = null; var firstTimeAds = true; var daastUrl; var adsLoader; var hls; var isAdswizz = false; var adDisplayContainer; var adsManager; var prerollPaused = false; var isRadioPlaying = null; var initPlayer = false; var showSongInfo = true; var showAdsWizzBanner = true; var isPrerollShowed = false; var timerStarted = false; var secondConnectionUrl = 'https://moondigitaledge.radyotvonline.net/metadata?&cb=<random>'; var adRequestUrl = 'https://moondigital.deliveryengine.adswizz.com/afr?zone_alias=DisplayZone&context=<contextValue>&cb=<random>'; var audioPlayer = document.getElementById('audio-player'); $("#volume").slider({ min: 0, max: 100, value: 50, range: "min", slide: function (event, ui) { volume = ui.value / 100; setVolume(volume); } }); var muted = "false"; audioPlayer.useCredential = true; var adDisplayContainerInitialized = false; window.volumeRatio = 0.5; window.beforeAdRatio = null; var config = { fetchSetup: function (context, initParams) { initParams.credentials = 'include'; return new Request(context.url, initParams); } }; audioPlayer.useCredential = true; try { adDisplayContainer = new google.ima.AdDisplayContainer(document.getElementById('adContainer'), audioPlayer); adsLoader = new google.ima.AdsLoader(adDisplayContainer); adsLoader.getSettings().setDisableCustomPlaybackForIOS10Plus(true); adsLoader.addEventListener(google.ima.AdsManagerLoadedEvent.Type.ADS_MANAGER_LOADED, onAdsManagerLoaded, false); adsLoader.addEventListener(google.ima.AdErrorEvent.Type.AD_ERROR, onAdError, false); }
catch (err) { console.log(err); }
function onAdsManagerLoaded(adsManagerLoadedEvent) {
    var adsRenderingSettings = new google.ima.AdsRenderingSettings(); adsRenderingSettings.setLoadVideoTimeout = 12000
    adsManager = adsManagerLoadedEvent.getAdsManager(audioPlayer, adsRenderingSettings); requestPreroll(daastUrl); adsManager.addEventListener(google.ima.AdErrorEvent.Type.AD_ERROR, onAdError); adsManager.addEventListener(google.ima.AdEvent.Type.CONTENT_PAUSE_REQUESTED, onContentPauseRequested); adsManager.addEventListener(google.ima.AdEvent.Type.CONTENT_RESUME_REQUESTED, onContentResumeRequested); adsManager.addEventListener(google.ima.AdEvent.Type.ALL_ADS_COMPLETED, onAdEvent);
}
function onAdError(adErrorEvent) {
    console.log(adErrorEvent.getError()); if (adsManager) { adsManager.destroy(); }
    do_all_jobs(hlsLink);
}
function onAdEvent(adEvent) { }
function onContentPauseRequested() { prerollPlaying = true; }
function onContentResumeRequested() { prerollPlaying = false; do_all_jobs(hlsLink); }
function requestPreroll(adTagUrl) {
    try {
        if (!adDisplayContainerInitialized) { audioPlayer.load(); adDisplayContainer.initialize(); adDisplayContainerInitialized = true; }
        if (adsLoader) { adsLoader.contentComplete(); }
        try { adsManager.init(640, 360, google.ima.ViewMode.NORMAL); adsManager.start(); } catch (adError) {
            console.log(adError)
            do_all_jobs(hlsLink);
        }
        $.fn.setCookieWithMinute("vast", 'true', 5);
    }
    catch (err) { console.log(err); do_all_jobs(hlsLink) }
}
var Timer = function (cb, delay, cbEnd) { var timerId, start, remaining = delay; this.pause = function () { window.clearTimeout(timerId); remaining -= Date.now() - start; }; this.resume = function () { start = Date.now(); window.clearTimeout(timerId); window.timerStarted = true; cb(); timerId = window.setTimeout(function () { window.timerStarted = false; cbEnd(); }, remaining); }; this.cancel = function () { window.timerStarted = false; window.clearTimeout(timerId); }; if (!audioPlayer.paused) { this.resume(); } }; function do_all_jobs(hlsLink) {
    if (hls) {
        hls.destroy(); if (hls.bufferTimer) { clearInterval(hls.bufferTimer); hls.bufferTimer = undefined; }
        hls = null;
    }
    if (isAdswizz) { if ((typeof com_adswizz_synchro_decorateUrl != "undefined")) { try { hlsLink = com_adswizz_synchro_decorateUrl(hlsLink); isAdBlockActive = false; } catch (err) { isAdBlockActive = true; } } }
    audioPlayer.onplay = function () { if (window.TheTimer) { window.TheTimer.resume(); } }; audioPlayer.onpause = function () { if (window.TheTimer) { window.TheTimer.pause(); } }; muted = "false"; var volume = 0.5; if (volume > -1) { window.audioPlayer.volume = volume; }
    if (muted == "true") { window.audioPlayer.volume = 0; } else { window.audioPlayer.volume = volume; }
    if (iOS) { audioPlayer.src = hlsLink; }
    else if (Hls.isSupported()) {
        hls = new Hls(config); hls.loadSource(hlsLink); hls.attachMedia(audioPlayer); hls.on(Hls.Events.MANIFEST_PARSED, function () { playerPlay(); }); if (isAdswizz) {
            hls.off(Hls.Events.FRAG_PARSING_METADATA)
            hls.on(Hls.Events.FRAG_PARSING_METADATA, function (e, data) { makeMetadataReq(function (data) { var adsContext = parseAdsvizParam(data); if (adsContext.contextData) { makeAdRequest(adsContext); } }); });
        }
    }
    playerPlay();
}
function setVolume(volume) {
    if (volume <= 0) {
        window.audioPlayer.volume = 0
        if (prerollPlaying && (typeof (adsManager) !== "undefined")) { adsManager.setVolume(0); }
        if (typeof (Storage) !== "undefined") { localStorage.setItem("muted", "true"); localStorage.setItem("volume", volume); }
        $(".jp-mute").addClass("jp-muted");
    } else {
        window.audioPlayer.volume = volume; if (prerollPlaying && (typeof (adsManager) !== "undefined")) { adsManager.setVolume(volume); }
        if (typeof (Storage) !== "undefined") { localStorage.setItem("muted", "false"); localStorage.setItem("volume", volume); }
        $(".jp-mute").removeClass("jp-muted");
    }
}
function parseAdsvizParam(data) {
    var result = { contextData: '', milisec: 0 }; var arrData = data.split('\r\n'); if (arrData.length > 0) {
        for (var i = 0; i < arrData.length; i++) {
            if (arrData[i].startsWith('adswizzContext')) {
                var splittedValues = arrData[i].split(' '); var contextContainerArr = splittedValues[0].split('='); var contextData = contextContainerArr[1]; var milisec = splittedValues[2].split('=')[1]; var insertionType = splittedValues[4].split('='); if (insertionType[1] == "preroll") { if (isPrerollShowed == false) { result = { contextData: contextData, milisec: milisec }; isPrerollShowed = true; break; } }
                else { result = { contextData: contextData, milisec: milisec }; }
            }
        }
    }
    return result;
}
function makeMetadataReq(cb) {
    var xhr = new XMLHttpRequest(); xhr.withCredentials = true; var requestUrl = secondConnectionUrl; var cacheBuster = Math.random() * 10000000000000000; requestUrl = requestUrl.replace('<random>', cacheBuster); xhr.open('GET', requestUrl, true); xhr.onreadystatechange = function () { if (xhr.readyState == 4 && xhr.status == 200) { cb && cb(xhr.responseText); } }
    xhr.send();
}
function makeAdRequest(context) {
    if (window.timerStarted == false) {
        window.TheTimer = new Timer(function () {
            var requestUrl = adRequestUrl.replace('<contextValue>', context.contextData); var cacheBuster = Math.random() * 10000000000000000; requestUrl = requestUrl.replace('<random>', cacheBuster); var xhr = new XMLHttpRequest(); xhr.open('GET', requestUrl, true); xhr.onreadystatechange = function () { if (xhr.readyState == 4 && xhr.status == 200) { document.getElementById('afrBanner').innerHTML = xhr.responseText; } }
            xhr.send();
        }, context.milisec, function () { window.timerStarted = false; fillAdsArea(); });
    }
}
function prepareRadio(stationCode) {
    if (prerollPlaying == true) {
        if (!prerollPaused) {
            prerollPaused = true; adsManager.pause()
            $(".jp-audio").removeClass("jp-state-playing"); $("#ply-" + selectedRadio.STATIONCODE).removeClass('rP2');
        }
        else {
            prerollPaused = false; adsManager.resume()
            $(".jp-audio").addClass("jp-state-playing"); $("#ply-" + selectedRadio.STATIONCODE).addClass('rP2');
        }
    }
    else if (audioPlayer.paused) { audioPlayer.play(); }
    else { audioPlayer.pause(); }
    if (selectedRadio === null || stationCode != selectedRadio.STATIONCODE) {
        $.each(radioListData, function (index, value) { if (value.STATIONCODE === stationCode) { selectedRadio = radioListData[index]; } }); prerollPaused = false; $(".jp-audio").addClass("jp-state-playing"); stationCode = selectedRadio.STATIONCODE; logo = selectedRadio.ALBUMIMAGE; back = "https://www.radyoland.net" + selectedRadio.BACKGROUND; catid = selectedRadio.CATEGORYID; stream = selectedRadio.HLSLINK; stationname = selectedRadio.STATIONNAME; stationid = selectedRadio.STATIONCODE; daastUrl = selectedRadio.DAASTLINK; isAdswizz = selectedRadio.ISADSWIZZ; if (daastUrl == null || daastUrl == "") { daastUrl = "1"; }
        hlsLink = stream; Last5Song(stationid); changePageStyle(logo, back, stationid); $("#currentChannelTitle").html(selectedRadio.ARTISTNAME + " - " + selectedRadio.TRACKNAME); window.stream = stream; window.stationname = stationname; window.stationid = stationid; window.lastAd = true; window.nextAdID = 0; if (daastUrl != "1" && $.fn.getCookie("vast") === null) {
            if (daastUrl.indexOf("[timestamp]") != -1) { daastUrl = daastUrl.replace("[timestamp]", datetimeForReplace()); }
            var adsRequest = new google.ima.AdsRequest(); adsRequest.adTagUrl = daastUrl; adsRequest.linearAdSlotWidth = 640; adsRequest.linearAdSlotHeight = 400; adsLoader.requestAds(adsRequest);
        } else { do_all_jobs(hlsLink, 0); }
    }
}
function datetimeForReplace() {
    var currentdate = new Date(); var datetime = currentdate.getMonth().toString()
        + currentdate.getHours().toString()
        + currentdate.getMinutes().toString()
        + currentdate.getSeconds().toString()
        + currentdate.getMilliseconds().toString(); return datetime;
}
function Last5Song(stationid) { $.ajax({ url: "/Service/Last5Song", data: { stationid: stationid }, type: "GET", dataType: "json", success: function (result) { var songlist = ""; $('#lastsongs').html(''); $.each(result, function (i, item) { songlist += "<li class='list-group-item'>" + item.ARTISTNAME + " - " + item.TRACKNAME + "</li>"; }); $('#lastsongs').append(songlist); }, complete: function () { }, error: function (xhr, status) { if (xhr.status == 401) { console.log(xhr.statusText); } else { console.log(xhr.statusText); } } }); }
function playerPlay() { audioPlayer.play(); muteOff(); }
function callCurrentTrackList() {
    if (selectedRadio != null)
        Last5Song(selectedRadio.STATIONCODE); $.ajax({
            url: "/Service/GetCurrentTrackList", data: {}, type: "GET", dataType: "json", success: function (result) {
                $.each(result.Data, function (index, value) {
                    $.each(radioListData, function (radioListindex, radioListValue) {
                        if (radioListValue.STATIONCODE == value.STATIONCODE) {
                            radioListData[radioListindex].TRACKNAME = value.TRACKNAME
                            radioListData[radioListindex].ALBUMNAME = value.ALBUMNAME
                            radioListData[radioListindex].ALBUMIMAGE = value.ALBUMIMAGE
                            radioListData[radioListindex].ARTISTNAME = value.ARTISTNAME
                        }
                    }); if (selectedRadio != null) { if (selectedRadio.STATIONCODE == value.STATIONCODE) { $("#albumimg").attr("src", value.ALBUMIMAGE); $("#currentChannelTitle").html(value.ARTISTNAME + " - " + value.TRACKNAME); } }
                }); if (result.Errors != "") { console.log(result.Errors); }
                else { $.each(result.Data, function (i, item) { $("#" + item.STATIONCODE).html(item.ARTISTNAME + " - " + item.TRACKNAME); }); }
            }, complete: function () { }, error: function (xhr, status) { if (xhr.status == 401) { console.log(xhr.statusText); } else { console.log(xhr.statusText); } }
        });
}; function changePageStyle(logo, back, stationid) { $(".r-play").removeClass('rP2'); $("#ply-" + stationid).addClass('rP2'); $(".radyoactive").removeClass('radyoactive'); $(".ply-" + stationid).addClass('radyoactive'); sessionStorage.setItem("isStationID", stationid); $('.mainrender').css('background-image', 'url(' + back + ')'); $("#albumimg").attr("src", logo); $(".jp-audio").addClass("jp-state-playing"); $("#rightBannerAnchor").removeAttr("href"); }; function changeTimespan(daasturl) {
    if (daasturl != null && daasturl != "" && daasturl.indexOf("timestamp") != -1) {
        var currentdate = new Date(); var datetime = currentdate.getMonth().toString()
            + currentdate.getHours().toString()
            + currentdate.getMinutes().toString()
            + currentdate.getSeconds().toString()
            + currentdate.getMilliseconds().toString(); daasturl = daasturl.replace("timestamp", datetime); return daasturl;
    } else { return daasturl; }
}; $(document).on('click', '.radio-item', function () { var stationCode = $(this).data('radio-stationcode'); if (!prerollPlaying) { prepareRadio(stationCode) } }); $(".jp-play").bind('click', () => {
    if (prerollPlaying == true) {
        if (!prerollPaused) {
            prerollPaused = true; adsManager.pause()
            $(".jp-audio").removeClass("jp-state-playing"); $("#ply-" + selectedRadio.STATIONCODE).removeClass('rP2');
        }
        else {
            prerollPaused = false; adsManager.resume()
            $(".jp-audio").addClass("jp-state-playing"); $("#ply-" + selectedRadio.STATIONCODE).addClass('rP2');
        }
    }
    else if (audioPlayer.paused) { audioPlayer.play(); $(".jp-audio").addClass("jp-state-playing"); $("#ply-" + selectedRadio.STATIONCODE).addClass('rP2'); }
    else { audioPlayer.pause(); $(".jp-audio").removeClass("jp-state-playing"); $(".r-play").removeClass('rP2'); $("#ply-" + selectedRadio.STATIONCODE).removeClass('rP2'); }
})
$(".jp-mute").bind('click', () => {
    if (muted == "true") { muteOff() }
    else { muteOn() }
})
function muteOff() { setVolume(volume); $(".jp-mute").removeClass("jp-muted"); muted = "false"; }
function muteOn() { setVolume(0); $(".jp-mute").addClass("jp-muted"); muted = "true"; }
function toSec(sec) {
    var m = String(sec).substr(3, 2); var s = String(sec).substr(6, 2); var r = parseInt(m * 60) + parseInt(s); if (isNumber(r))
        return r; else return -1;
}; function isNumber(n) { return !isNaN(parseFloat(n)) && isFinite(n); }; $.fn.setCookieWithDay = function (name, value, days) {
    var expires = ""; if (days) { var date = new Date(); date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000)); expires = "; expires=" + date.toUTCString(); }
    document.cookie = name + "=" + (value || "") + expires + "; path=/";
}
$.fn.setCookieWithMinute = function (name, value, minute) {
    var expires = ""; if (minute) { var date = new Date(); date.setTime(date.getTime() + (minute * 60 * 1000)); expires = "; expires=" + date.toUTCString(); }
    document.cookie = name + "=" + (value || "") + expires + "; path=/";
}
$.fn.eraseCookie = function (name) { document.cookie = name + '=; Max-Age=-99999999;'; }
$.fn.getCookie = function (name) {
    var nameEQ = name + "="; var ca = document.cookie.split(';'); for (var i = 0; i < ca.length; i++) { var c = ca[i]; while (c.charAt(0) == ' ') c = c.substring(1, c.length); if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length); }
    return null;
}