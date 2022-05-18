﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
 
public class GoogleAds : MonoBehaviour {
    // 広告ユニットID 本物
    #if DEVELOPMENT_BUILD
        private readonly string AdUnitId = "ca-app-pub-3940256099942544/6300978111";
    #elif UNITY_ANDROID
        private readonly string AdUnitId = "ca-app-pub-9131760489850595/7472116511";
    #elif UNTI_IPHONE
        private readonly string AdUnitId = "";
    #else
        private readonly string AdUnitId = "other";
    #endif

    // 動画ユニットID 本物
    #if DEVELOPMENT_BUILD
        private readonly string _AdUnitId = "ca-app-pub-3940256099942544/1033173712";
    #elif UNITY_ANDROID
        private readonly string _AdUnitId = "ca-app-pub-9131760489850595/9248286516";
    #elif UNTI_IPHONE
        private readonly string _AdUnitId = "";
    #else
        private readonly string _AdUnitId = "other";
    #endif

    private BannerView bannerView;
    private InterstitialAd interstitialAd;

    public void RequestBanner()
    {
        // アプリID
        // string appId = "ca-app-pub-9131760489850595~3015744991";

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(AdUnitId, AdSize.Banner, AdPosition.Bottom);
 
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
 
        // Load the banner with the request.
        bannerView.LoadAd(request);
    }

    public void HideBannerView () {
        bannerView.Hide ();
    }

    public void ShowBannerView () {
        bannerView.Show ();
    }

    //広告を表示するメソッド
    public void RequestInterstitial()
    {
        this.interstitialAd = new InterstitialAd(_AdUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        interstitialAd.LoadAd(request);
        interstitialAd.OnAdClosed += HandleOnAdClosed;
    }

    public void ShowIntersitialAd (EventHandler<EventArgs> callback = null) {
        interstitialAd.Show();

        if (callback != null) interstitialAd.OnAdClosed += callback;
    }

    private void HandleOnAdClosed(object sender, EventArgs args)
    {
        interstitialAd.Destroy();
        RequestInterstitial();
    }
}